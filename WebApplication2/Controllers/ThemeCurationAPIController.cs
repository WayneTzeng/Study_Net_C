//using LifeEnterpot.Core.Facades;
//using LifeEnterpot.Core.Models;
//using LifeEnterpot.Core.Utilities;
//using LifeEnterpot.Web.Filters;
using log4net;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using LifeEnterpot.Core.Enums;
//using LifeEnterpot.Core.ModelCustom;
//using LifeEnterpot.Core.Kernel;
//using LifeEnterpot.Core.Providers;
using System.Text.Json;
using System.Text;
using System.IO;
using System.Drawing;

namespace LifeEnterpot.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[action]")]
    public class ThemeCurationAPIController : BaseController
    {
        //static ILog logger = LogManager.GetLogger(typeof(ThemeCurationAPIController));
        //static IThemeCurationProvider tcp = Ioc.Get<IThemeCurationProvider>();
        //static IProductProvider pp = Ioc.Get<IProductProvider>();
        //static ISystemConfig config = Ioc.GetConfig();

        #region 策展活動
        [HttpPost]
        [Authorization]
        [PermissionFilter("策展活動")]
        public dynamic GetThemeCurationList(ThemeCurationInput input)
        {
            int rowSize;
            Guid channelId = Guid.Empty;
            Guid.TryParse(input.ChannelId, out channelId);

            //取得策展列表
            List<ThemeCurationMainProposalModel> themeCurationList = tcp.GetThemeCurationProposalList(
                                    channelId, input.PageStart ?? 1, pageLength, input.IsHideExpired, out rowSize);
            Pagination pagination = new Pagination()
            {
                pageStart = input.PageStart.GetValueOrDefault(1),
                rowSize = rowSize,
                pageLength = pageLength
            };

            //ApiThemeCurationList data = ThemeCurationServices.GetThemeCurationList(pagination, themeCurationList);
            var result = JsonSerializer.Serialize(new
            {
                data = themeCurationList,
                pagination = pagination,
            });

            return result;

            //return themeCurationList;
        }

        [HttpPost]
        [Authorization]
        [PermissionFilter("策展活動")]
        public dynamic GetThemeCurationPreview(GetThemeCurationInput input)
        {
            Guid channelId = Guid.Empty;
            Guid.TryParse(input.ChannelId, out channelId);
            ThemeCurationMainProposalModel model = tcp.GetThemeCurationMainProposalById(input.CurationGuid, channelId);
            string previewUrl = string.Empty;
            
            string themeType = string.Empty;
            if (model != null)
            {
                themeType = model.ThemeType;
                if (themeType == ((int)ThemeCurationType.TypeCustomize).ToString())
                {
                    previewUrl = model.OuterUrl;
                }
                else
                {
                    //UserDefaultToken token = WebHelper.GetUserTokenInfo(input.ChannelId);
                    //string ptUrl = "pt=" + System.Web.HttpUtility.UrlEncode(token.encrypt);

                    string url = string.Format("{0}/curation/{1}?channelId={2}", ChannelFacade.GetChannel(channelId).FrontHost, input.CurationGuid, input.ChannelId);
                    //byte[] bytes = System.Text.Encoding.GetEncoding("utf-8").GetBytes(url);
                    //previewUrl = Convert.ToBase64String(bytes);
                    previewUrl = WebHelper.GetPreviewUrl(input.ChannelId, url);
                }
            }

            return new {
                ThemeType = themeType,
                Preview = previewUrl
            };
        }

        [HttpPost]
        [Authorization]
        [PermissionFilter("策展活動")]
        public dynamic GetThemeCuration(GetThemeCurationInput input)
        {
            bool isSuccess = false;
            string message = string.Empty;
            Guid channelId = Guid.Empty;
            Guid curationGuid = input.CurationGuid;
            ThemeCurationMainProposalModel main = new ThemeCurationMainProposalModel();
            try
            {
                if (Guid.TryParse(input.ChannelId, out channelId) && input.CurationGuid != null && input.CurationGuid != Guid.Empty)
                {
                    main = tcp.GetThemeCurationMainProposalById(curationGuid, channelId);
                    if (main == null)
                    {
                        message = "資料載入失敗*";
                    }
                    else
                    {
                        List<ThemeCurationCategoryProposal> themeCurationCategories = tcp.GetThemeCurationCategoryProposals(main.CurationGuid);
                        List<ThemeCurationProductProposal> themeCurationProducts = tcp.GetThemeCurationProductProposals(themeCurationCategories.Select(x => x.CategoryGuid).ToList());
                        List<ViewProductVersion> vpvs = pp.ViewProductVersionListGet(channelId, themeCurationProducts.Select(x => x.Bid).ToList());


                        if (string.IsNullOrEmpty(main.ImagePath) == false)
                        {
                            //main.ImagePath = string.Format(Ioc.GetConfig().ImagesBaseUrl + "/themecuration/{0}", main.ImagePath);
                            main.ImagePath = Helper.CombineUrls(Ioc.GetConfig().ImagesBaseUrl, main.ImagePath);
                        }

                        if (string.IsNullOrEmpty(main.BannerImagePath) == false)
                        {
                            main.BannerImagePath = Helper.CombineUrls(Ioc.GetConfig().ImagesBaseUrl, main.BannerImagePath);
                        }

                        //var config = Ioc.GetConfig();
                        //string imagesFolder = Path.Combine(Path.GetFullPath(config.ImagesFolder), "themecuration");
                        //string filePath = Path.Combine(imagesFolder, main.ImagePath);
                        //if (System.IO.File.Exists(filePath))
                        //{
                        //    byte[] base64Image = System.IO.File.ReadAllBytes(filePath);
                        //    main.ImagePath = "data:image/png;base64," + Convert.ToBase64String(base64Image);
                        //}


                        List<CurationTab> curationTabs = new List<CurationTab>();
                        foreach (ThemeCurationCategoryProposal themeCurationCategory in themeCurationCategories.OrderBy(t => t.Sort))
                        {
                            List<ThemeCurationProductProposal> currentThemeCurationProducts = themeCurationProducts
                                                    .Where(x => x.CategoryGuid == themeCurationCategory.CategoryGuid)
                                                    .ToList();
                            List<CurationBidStatus> bids = new List<CurationBidStatus>();
                            foreach (ThemeCurationProductProposal p in currentThemeCurationProducts.OrderBy(t => t.Sort))
                            {
                                ViewProductVersion vpv = vpvs.Where(x => x.Bid == p.Bid).FirstOrDefault();
                                if (vpv != null)
                                {
                                    bids.Add(new CurationBidStatus
                                    {
                                        Pid = p.Bid.ToString(),
                                        Bid = p.Bid,
                                        DealStatus = vpv.Offline.GetValueOrDefault() ? "下架" : "上架",
                                        DealName = vpv.ProductName,
                                        DealTime = string.Format("{0}~{1}", vpv.DealStartTime.ToString("yyyy/MM/dd HH:mm"), vpv.DealEndTime.ToString("yyyy/MM/dd HH:mm")),
                                        ImageUrl = vpv.ImagePath,
                                        Price = vpv.Price,
                                        OriPrice = vpv.OriginalPrice
                                    });
                                }
                            }
                            curationTabs.Add(new CurationTab
                            {
                                TabGuid = themeCurationCategory.CategoryGuid.ToString(),
                                TabName = themeCurationCategory.CategoryName,
                                Bids = bids
                            });
                        }
                        main.Tabs = curationTabs;

                        string url = string.Format("{0}/curation/{1}?channelId={2}", ChannelFacade.GetChannel(channelId).FrontHost, input.CurationGuid, input.ChannelId);
                        byte[] bytes = System.Text.Encoding.GetEncoding("utf-8").GetBytes(url);
                        string previewUrl = Convert.ToBase64String(bytes);
                        main.PreviewUrl = previewUrl;

                        isSuccess = true;
                    }
                }
                else
                {
                    message = "資料載入失敗**";
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }

            //ViewBag.Id = curationId;

            return new
            {
                data = main,
                isSuccess = isSuccess,
                message = message
            };
        }

        [HttpPost]
        [Authorization]
        [PermissionFilter("策展活動")]
        public dynamic GetThemeCurationStatus(GetThemeCurationInput input)
        {
            bool isSuccess = false;
            string message = string.Empty;
            Guid channelId = Guid.Empty;
            Guid curationGuid = input.CurationGuid;
            bool isExpired = false;
            int applyType = 0;
            try
            {
                if (Guid.TryParse(input.ChannelId, out channelId) && input.CurationGuid != null && input.CurationGuid != Guid.Empty)
                {
                    ThemeCurationMainProposal main = tcp.GetThemeCurationMainProposal(curationGuid, channelId);
                    if (main != null)
                    {
                        isExpired = main.EndTime < DateTime.Now;
                        applyType = main.ApplyType;
                        isSuccess = true;
                    }
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }

            //ViewBag.Id = curationId;

            return new
            {
                isExpired = isExpired,
                applyType = applyType,
                isSuccess = isSuccess,
                message = message
            };
        }
        [HttpPost]
        [Authorization]
        [PermissionFilter("策展活動")]
        public dynamic EditChoice(ThemeCurationMainBestChoiceModel input)
        {
            bool flag = false;
            string message = string.Empty;
            try
            {
                Guid channelId = Guid.Empty;
                if (Guid.TryParse(input.ChannelId, out channelId))
                {
                    ThemeCurationMain main = tcp.GetThemeCurationMain(input.CurationGuid, channelId);
                    if (main != null)
                    {
                        bool isChecked = !input.Checked;

                        if (isChecked)
                        {
                            List<ThemeCurationMain> list = tcp.GetThemeCurationMainByBestChoice(channelId);
                            foreach (ThemeCurationMain lst in list)
                            {
                                if (lst.CurationGuid != input.CurationGuid)
                                {
                                    if(lst.StartTime <= main.StartTime && lst.EndTime >= main.StartTime)
                                    {
                                        message = "僅能勾選一檔策展活動";
                                        break;
                                    }
                                    if (lst.StartTime >= main.StartTime && lst.EndTime <= main.EndTime)
                                    {
                                        message = "僅能勾選一檔策展活動";
                                        break;
                                    }
                                    if (lst.StartTime >= main.StartTime && lst.EndTime >= main.EndTime)
                                    {
                                        message = "僅能勾選一檔策展活動";
                                        break;
                                    }
                                    if (lst.StartTime <= main.StartTime && lst.EndTime >= main.EndTime)
                                    {
                                        message = "僅能勾選一檔策展活動";
                                        break;
                                    }
                                }
                            }
                        }


                        if (string.IsNullOrEmpty(message))
                        {
                            main.BestChoice = isChecked;
                            main.ModifyId = User.Identity.Name;
                            main.ModifyTime = DateTime.Now;
                            tcp.SaveThemeCurationMain(main, Microsoft.EntityFrameworkCore.EntityState.Modified);


                            ThemeCurationMainProposal mainP = tcp.GetThemeCurationMainProposal(input.CurationGuid, channelId);
                            if (mainP != null)
                            {
                                mainP.BestChoice = isChecked;
                                mainP.ModifyId = User.Identity.Name;
                                mainP.ModifyTime = DateTime.Now;
                                tcp.SaveThemeCurationMainProposal(mainP, Microsoft.EntityFrameworkCore.EntityState.Modified);
                            }
                            flag = true;
                        }
                    }
                    else
                    {
                        message = "策展活動請先送審後再勾選";
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error("EditChoice", ex);
            }
    
            return Ok(new { 
                isSuccess = flag,
                message = message
            });
        }
        [HttpPost]
        [Authorization]
        [PermissionFilter("策展活動")]
        public dynamic SaveThemeCuration(ThemeCurationMainProposalModel input)
        {
            bool isSuccess = false;
            string message = string.Empty;
            string message5 = string.Empty;
            Guid curationGuid = input.CurationGuid;
            try
            {
                Guid channelId = Guid.Empty;

                if (Guid.TryParse(input.ChannelId, out channelId))
                {
                    DateTime st = DateTime.MinValue;
                    DateTime et = DateTime.MinValue;

                    DateTime.TryParse(string.Format("{0} {1}:{2}", input.CurationTimeS, input.CurationTimeSH, input.CurationTimeSM), out st);
                    DateTime.TryParse(string.Format("{0} {1}:{2}", input.CurationTimeE, input.CurationTimeEH, input.CurationTimeEM), out et);
                    if(input.CurationGuid == Guid.Empty)
                    {
                        if(st.Ticks < DateTime.Now.Ticks)
                        {
                            message = "策展活動區間日期必需晚於現在，請重新確認與設定";
                            return new
                            {
                                IsSuccess = isSuccess,
                                Message = message,
                                Message2 = message
                            };
                        }
                    }
                    if (st == DateTime.MinValue || et == DateTime.MinValue)
                    {
                        message = "策展活動區間日期輸入不正確";
                        return new
                        {
                            IsSuccess = isSuccess,
                            Message = message,
                            Message2 = message
                        };
                    }
                    if (et <= st)
                    {
                        message = "策展活動區間日期輸入不正確";
                        return new
                        {
                            IsSuccess = isSuccess,
                            Message = message,
                            Message2 = message
                        };
                    }
                    if (string.IsNullOrEmpty(input.CurationStatus))
                    {
                        message = "請選擇開關";
                        return new
                        {
                            IsSuccess = isSuccess,
                            Message = message
                        };
                    }
                    if (string.IsNullOrEmpty(input.ThemeType))
                    {
                        message = "請選擇版型";
                        return new
                        {
                            IsSuccess = isSuccess,
                            Message = message
                        };
                    }

                    bool bestChoice = input.BestChoice;

                    if (bestChoice)
                    {
                        List<ThemeCurationMain> list = tcp.GetThemeCurationMainByBestChoice(channelId);
                        foreach (ThemeCurationMain lst in list)
                        {
                            if (lst.CurationGuid != input.CurationGuid)
                            {
                                if (lst.StartTime <= st && lst.EndTime >= st)
                                {
                                    message5 = "此策展活動區間「" + lst.Title + "」策展進行中";
                                    return new
                                    {
                                        IsSuccess = isSuccess,
                                        Message5 = message5
                                    };
                                }
                                if (lst.StartTime >= st && lst.EndTime <= et)
                                {
                                    message5 = "此策展活動區間「" + lst.Title + "」策展進行中";
                                    return new
                                    {
                                        IsSuccess = isSuccess,
                                        Message5 = message5
                                    };
                                }
                                if (lst.StartTime <= et && lst.EndTime >= et)
                                {
                                    message5 = "此策展活動區間「" + lst.Title + "」策展進行中";
                                    return new
                                    {
                                        IsSuccess = isSuccess,
                                        Message5 = message5
                                    };
                                }
                                if (lst.StartTime <= st && lst.EndTime >= et)
                                {
                                    message5 = "此策展活動區間「" + lst.Title + "」策展進行中";
                                    return new
                                    {
                                        IsSuccess = isSuccess,
                                        Message5 = message5
                                    };
                                }
                            }
                        }
                    }


                    if (curationGuid != null)
                    {
                        Microsoft.EntityFrameworkCore.EntityState entityState = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        ThemeCurationMainProposal main = tcp.GetThemeCurationMainProposal(curationGuid, channelId);
                        if (main == null)
                        {
                            entityState = Microsoft.EntityFrameworkCore.EntityState.Added;
                            main = new ThemeCurationMainProposal();
                            main.CurationGuid = Guid.NewGuid();
                            main.CreateTime = DateTime.Now;
                            main.CreateId = User.Identity.Name;
                        }
                        if(main.ApplyType == (int)ThemeCurationApplyType.Apply)
                        {
                            message = "送審中狀態不可編輯";
                            return new
                            {
                                IsSuccess = false,
                                Message = message
                            };
                        }
                        curationGuid = main.CurationGuid;
                        ThemeCurationMainProposal oriMain = main.Clone();

                        main.Title = input.Title;
                        main.SourceType = (int)ThemeCurationSource.Manual;
                        main.StartTime = st;
                        main.EndTime = et;
                        main.ThemeType = Convert.ToInt32(input.ThemeType);
                        main.ThemeStyle = Convert.ToInt32(input.ThemeStyle);
                        main.CurationStatus = Convert.ToInt32(input.CurationStatus);
                        main.ModifyTime = DateTime.Now;
                        main.ModifyId = User.Identity.Name;
                        main.ChannelId = channelId;
                        main.OuterUrl = input.OuterUrl;
                        // main.ImagePath = string.Empty;
                        main.CurationDescription = input.CurationDescription;
                        main.ApplyType = (int)ThemeCurationApplyType.Init;
                        main.ReturnType = (int)ThemeCurationApplyType.Init;
                        main.BestChoice = bestChoice;

                        if (input.ImagePath != null)
                        {
                            string relativeImgPath;
                            byte[] imageBinaryData;
                            bool result = Helper.SaveBase64ImageData(input.ImagePath, Ioc.GetConfig().ImagesFolder, "themecuration",
                                out relativeImgPath, out message, out imageBinaryData);
                            if (result)
                            {
                                main.ImagePath = relativeImgPath;
                                ISystemConfig config = Ioc.GetConfig();
                                try
                                {
                                    S3Helper.UploadFileToS3(imageBinaryData, relativeImgPath, config.S3Service.BucketName);
                                }
                                catch (Exception ex)
                                {
                                    logger.Warn("上傳到S3失敗", ex);
                                }
                            }
                        }

                        if (string.IsNullOrEmpty(input.BannerImagePath) == false)
                        {
                            string relativeImgPath;
                            byte[] imageBinaryData;
                            bool result = Helper.SaveBase64ImageData(input.BannerImagePath, Ioc.GetConfig().ImagesFolder, "themecuration",
                                out relativeImgPath, out message, out imageBinaryData);
                            if (result)
                            {
                                main.ActiveBannerImagePath = relativeImgPath;
                                ISystemConfig config = Ioc.GetConfig();
                                try
                                {
                                    S3Helper.UploadFileToS3(imageBinaryData, relativeImgPath, config.S3Service.BucketName);
                                }
                                catch (Exception ex)
                                {
                                    logger.Warn("上傳到S3失敗", ex);
                                }
                            }
                        }
                        else
                        {
                            main.ActiveBannerImagePath = "";
                        }



                        List<ThemeCurationCategoryProposal> themeCurationCategories = tcp.GetThemeCurationCategoryProposals(main.CurationGuid, false);
                        List<ThemeCurationProductProposal> themeCurationProducts = tcp.GetThemeCurationProductProposals(themeCurationCategories.Select(x => x.CategoryGuid).ToList(), false);
                        StringBuilder categoryBuilder = new StringBuilder();
                        if (tcp.SaveThemeCurationMainProposal(main, entityState))
                        {
                            #region ThemeCurationCategory

                            if (input.ThemeType == ((int)ThemeCurationType.TypeCustomize).ToString())
                            {
                                //自訂版型沒有Bid
                                //把所有的註記掉
                                foreach (ThemeCurationCategoryProposal themeCurationCategory in themeCurationCategories)
                                {
                                    themeCurationCategory.Status = false;
                                    tcp.SaveThemeCurationCategoryProposal(themeCurationCategory, Microsoft.EntityFrameworkCore.EntityState.Modified);
                                }

                                foreach (ThemeCurationProductProposal themeCurationProduct in themeCurationProducts)
                                {
                                    themeCurationProduct.Status = false;
                                    tcp.SaveThemeCurationProductProposal(themeCurationProduct, Microsoft.EntityFrameworkCore.EntityState.Modified);
                                }
                            }
                            else
                            {
                                //非自訂版型

                                //紀錄異動Log
                                CompareThemeCurationCategoryModified(themeCurationCategories, input.Tabs, ref categoryBuilder);
                                //先把所有的註記掉
                                foreach (ThemeCurationCategoryProposal themeCurationCategory in themeCurationCategories)
                                {
                                    themeCurationCategory.Status = false;
                                    tcp.SaveThemeCurationCategoryProposal(themeCurationCategory, Microsoft.EntityFrameworkCore.EntityState.Modified);
                                }
                                //將項目新增
                                int tabIdx = 1;
                                foreach (CurationTab tab in input.Tabs)
                                {
                                    ThemeCurationCategoryProposal themeCurationCategory = themeCurationCategories.Where(x => x.CategoryGuid.ToString() == tab.TabGuid).FirstOrDefault();
                                    if (themeCurationCategory == null)
                                    {
                                        themeCurationCategory = new ThemeCurationCategoryProposal
                                        {
                                            CategoryGuid = Guid.NewGuid(),
                                            CurationGuid = main.CurationGuid,
                                            Sort = tabIdx,
                                            CategoryName = tab.TabName,
                                            ModifyId = User.Identity.Name,
                                            ModifyTime = DateTime.Now,
                                            Status = true
                                        };
                                        tcp.SaveThemeCurationCategoryProposal(themeCurationCategory, Microsoft.EntityFrameworkCore.EntityState.Added);
                                    }
                                    else
                                    {
                                        themeCurationCategory.Sort = tabIdx;
                                        themeCurationCategory.CategoryName = tab.TabName;
                                        themeCurationCategory.ModifyId = User.Identity.Name;
                                        themeCurationCategory.ModifyTime = DateTime.Now;
                                        themeCurationCategory.Status = true;
                                        tcp.SaveThemeCurationCategoryProposal(themeCurationCategory, Microsoft.EntityFrameworkCore.EntityState.Modified);
                                    }
                                    #region ThemeCurationProduct
                                    List<ThemeCurationProductProposal> currentThemeCurationProducts = themeCurationProducts.Where(x => x.CategoryGuid == themeCurationCategory.CategoryGuid).ToList();
                                    //紀錄異動Log
                                    CompareThemeCurationProductModified(currentThemeCurationProducts, tab, ref categoryBuilder);
                                    //先把所有的註記掉
                                    foreach (ThemeCurationProductProposal themeCurationProduct in currentThemeCurationProducts)
                                    {
                                        themeCurationProduct.Status = false;
                                        tcp.SaveThemeCurationProductProposal(themeCurationProduct, Microsoft.EntityFrameworkCore.EntityState.Modified);
                                    }
                                    //將項目新增
                                    int bidIdx = 1;
                                    foreach (CurationBidStatus bid in tab.Bids)
                                    {
                                        ThemeCurationProductProposal themeCurationProduct = currentThemeCurationProducts.Where(x => x.Bid == bid.Bid).FirstOrDefault();
                                        if (themeCurationProduct == null)
                                        {
                                            themeCurationProduct = new ThemeCurationProductProposal
                                            {
                                                CategoryGuid = themeCurationCategory.CategoryGuid,
                                                Bid = bid.Bid,
                                                Sort = bidIdx,
                                                ModifyId = User.Identity.Name,
                                                ModifyTime = DateTime.Now,
                                                Status = true
                                            };
                                            tcp.SaveThemeCurationProductProposal(themeCurationProduct, Microsoft.EntityFrameworkCore.EntityState.Added);
                                        }
                                        else
                                        {
                                            themeCurationProduct.Sort = bidIdx;
                                            themeCurationProduct.ModifyId = User.Identity.Name;
                                            themeCurationProduct.ModifyTime = DateTime.Now;
                                            themeCurationProduct.Status = true;
                                            tcp.SaveThemeCurationProductProposal(themeCurationProduct, Microsoft.EntityFrameworkCore.EntityState.Modified);
                                        }
                                        bidIdx++;
                                    }

                                    #endregion ThemeCurationProduct

                                    tabIdx++;
                                }
                                
                                LogFacade.AddLog(User.Identity.Name, channelId, main.CurationGuid.ToString(), "策展活動", categoryBuilder.ToString());
                            }
                            #endregion ThemeCurationCategory


                            if (entityState == Microsoft.EntityFrameworkCore.EntityState.Added)
                            {
                                LogFacade.AddAuditLog(User.Identity.Name, channelId, "策展活動", main.CurationGuid.ToString(), AuditType.Add, input.Title, "/themeCuration/themeCurationAdd?id=" + main.CurationGuid.ToString(), AuditProcessing.None);
                                LogFacade.AddLog(User.Identity.Name, channelId, main.CurationGuid.ToString(), "策展活動", string.Format("新增( {0} )", main.CurationId));
                            }
                            else
                            {
                                LogFacade.AddAuditLog(User.Identity.Name, channelId, "策展活動", main.CurationGuid.ToString(), AuditType.Edit, input.Title, "/themeCuration/themeCurationAdd?id=" + main.CurationGuid.ToString(), AuditProcessing.None);
                                LogFacade.CompareModified(oriMain, main, channelId, main.CurationGuid.ToString(), User.Identity.Name, "策展活動", Microsoft.EntityFrameworkCore.EntityState.Modified);
                            }
                            isSuccess = true;
                        }
                        else
                        {
                            message = "更新失敗*。";
                        }
                    }
                    else
                    {
                        message = "更新失敗。";
                    }
                }
                else
                {
                    message = "請先選擇頻道。";
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
                if (ex.InnerException != null)
                {
                    if (!string.IsNullOrEmpty(ex.InnerException.Message))
                    {
                        message = ex.InnerException.Message;
                    }
                }
            }

            return new
            {
                IsSuccess = isSuccess,
                Message = message,
                CurationGuid = curationGuid
            };

        }
        [HttpPost]
        [Authorization]
        [PermissionFilter("策展活動")]
        public IActionResult UploadImage([FromForm]UploadImageModel input)
        {
            bool isSuccess = false;
            string message = string.Empty;
            StringBuilder builder = new StringBuilder();
            try
            {
                Guid channelId = Guid.Empty;
                Guid curationGuid = Guid.Empty;
                ThemeCurationMainProposal themeCurationMain = null;
                if (Guid.TryParse(input.ChannelId, out channelId) && Guid.TryParse(input.CurationGuid, out curationGuid))
                {
                    themeCurationMain = tcp.GetThemeCurationMainProposal(curationGuid, channelId);
                }

                if (themeCurationMain != null)
                {
                    foreach (var file in input.Files)
                    {
                        if (file.Length > 0)
                        {
                            int timeStamp = Convert.ToInt32(DateTime.UtcNow.AddHours(8).Subtract(new DateTime(1970, 1, 1)).TotalSeconds);

                            string fileName = string.Format("{0}_{1}{2}", input.CurationGuid.ToString(), timeStamp, Path.GetExtension(file.FileName));

                            var config = Ioc.GetConfig();
                            string imagesFolder = Path.Combine(Path.GetFullPath(config.ImagesFolder), "themecuration");

                            if (!System.IO.Directory.Exists(imagesFolder))
                            {
                                System.IO.Directory.CreateDirectory(imagesFolder);
                            }

                            string filePath = Path.Combine(imagesFolder, fileName);
                            builder.AppendLine(filePath);

                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                stream.Position = 0;
                                file.CopyTo(stream);
                            }
                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                stream.Position = 0;
                                S3Helper.UploadFileToS3(stream, string.Format("themecuration/{0}", fileName), config.S3Service.BucketName);
                            }
                            builder.AppendLine("CopyToAsync");


                            //themeCurationMain.Images = memoryStream.ToArray();
                            themeCurationMain.ImagePath = fileName;
                            tcp.SaveThemeCurationMainProposal(themeCurationMain, Microsoft.EntityFrameworkCore.EntityState.Modified);
                            LogFacade.AddLog(User.Identity.Name, channelId, curationGuid.ToString(), "策展活動", "變更圖片：" + fileName);
                            isSuccess = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }

            return Ok(new { IsSuccess = isSuccess, Message = message });
        }


        [HttpPost]
        [Authorization]
        [PermissionFilter("策展活動")]
        public IActionResult CheckImageSize([FromForm]UploadImageModel input)
        {
            int height = 0;
            int width = 0;

            foreach (var file in input.Files)
            {
                if (file.Length > 0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        string fileName = input.CurationGuid.ToString() + Path.GetExtension(file.FileName);
                        file.CopyToAsync(memoryStream);

                        using (var image = Image.FromStream(file.OpenReadStream()))
                        {
                            height = image.Height;
                            width = image.Width;
                        }
                    };
                }
            }
            return Ok(new { Width = width, Height = height });
        }

        private void CompareThemeCurationCategoryModified(
            List<ThemeCurationCategoryProposal> themeCurationCategories,
            List<CurationTab> curationTabs,
            ref StringBuilder builder)
        {
            foreach (ThemeCurationCategoryProposal themeCurationCategory in themeCurationCategories)
            {
                if (curationTabs.Where(x => x.TabGuid == themeCurationCategory.CategoryGuid.ToString()).FirstOrDefault() == null)
                {
                    builder.AppendLine("[刪除類別]" + themeCurationCategory.CategoryName);
                }
            }
            int tabIdx = 1;
            foreach (CurationTab curationTab in curationTabs)
            {
                ThemeCurationCategoryProposal themeCurationCategory = themeCurationCategories.Where(x => x.CategoryGuid.ToString() == curationTab.TabGuid).FirstOrDefault();
                if (themeCurationCategory == null)
                {
                    builder.AppendLine("[新增類別]" + curationTab.TabName + "[排序]" + tabIdx);
                }
                else
                {
                    if (curationTab.TabName != themeCurationCategory.CategoryName || tabIdx != themeCurationCategory.Sort)
                    {
                        builder.AppendLine("[修改類別]原：" + themeCurationCategory.CategoryName + "=>" + curationTab.TabName
                                            + "[排序]原：" + themeCurationCategory.Sort + "=>" + tabIdx);
                    }
                }
                tabIdx++;
            }
        }

        private void CompareThemeCurationProductModified(
            List<ThemeCurationProductProposal> themeCurationProducts,
            CurationTab curationTab,
            ref StringBuilder builder)
        {
            foreach (ThemeCurationProductProposal themeCurationProduct in themeCurationProducts)
            {
                if (curationTab.Bids.Where(x => x.Bid == themeCurationProduct.Bid).FirstOrDefault() == null)
                {
                    builder.AppendLine("[刪除Bid]" + themeCurationProduct.Bid);
                }
            }
            int tabIdx = 1;
            foreach (CurationBidStatus bid in curationTab.Bids)
            {
                ThemeCurationProductProposal themeCurationProduct = themeCurationProducts.Where(x => x.Bid == bid.Bid).FirstOrDefault();
                if (themeCurationProduct == null)
                {
                    builder.AppendLine("[新增Bid]" + bid.Bid + "[排序]" + tabIdx);
                }
                else
                {
                    if (tabIdx != themeCurationProduct.Sort)
                    {
                        builder.AppendLine("[修改Bid]" + bid.Bid + "[排序]" + tabIdx);
                    }
                }
                tabIdx++;
            }
        }

        [HttpPost]
        [Authorization]
        [PermissionFilter("策展活動")]
        public dynamic CheckBidExists(ThemeCurationCheckBidsInput input)
        {
            //bool isSuccess = false;
            //string message = string.Empty;
            //List<object> resps = new List<object>();

            try
            {
                Guid channelId = Guid.Empty;
                Guid bid = Guid.Empty;
                if (Guid.TryParse(input.ChannelId, out channelId))
                {
                    if (Guid.TryParse(input.Bid, out bid))
                    {
                        ViewProductVersion vpv = pp.ViewProductVersionGet(channelId, bid);
                        return CheckBidExistsResult(vpv);
                    }
                    else if (int.TryParse(input.Bid, out int suppilerProductId))
                    {
                        ViewProductVersion vpv = pp.ViewProductVersionGet(channelId, suppilerProductId.ToString());
                        return CheckBidExistsResult(vpv);
                    }
                    else
                    {
                        return CheckBidExistsResult();
                    }
                }
                else
                {
                    return new
                    {
                        Pid = input.Bid,
                        Bid = "",
                        DealStatus = "N/A",
                        DealName = "N/A",
                        DealTime = "N/A",
                        Status = "Error",
                        Checked = false,
                        Message = "請先選擇頻道"
                    };
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                //message = ex.Message;
            }

            return null;

            dynamic CheckBidExistsResult(ViewProductVersion vpv = null)
            {
                if (vpv == null)
                {
                    return new
                    {
                        Pid = input.Bid,
                        Bid = vpv.Bid,
                        DealStatus = "N/A",
                        DealName = "N/A",
                        DealTime = "N/A",
                        Status = "Error",
                        Checked = false,
                        Message = "Bid異常"
                    };
                }
                else
                {
                    if (vpv.Offline.GetValueOrDefault())
                    {
                        return new
                        {
                            Pid = input.Bid,
                            Bid = vpv.Bid,
                            DealStatus = "下架",
                            DealName = vpv.ProductName,
                            DealTime = string.Format("{0}~{1}", vpv.DealStartTime.ToString("yyyy/MM/dd HH:mm"), vpv.DealEndTime.ToString("yyyy/MM/dd HH:mm")),
                            Status = "Error",
                            Checked = false,
                            Message = "檔次已下架"
                        };
                    }
                    else
                    {
                        return new
                        {
                            Pid = input.Bid,
                            Bid = vpv.Bid,
                            DealStatus = "上架",
                            DealName = vpv.ProductName,
                            DealTime = string.Format("{0}~{1}", vpv.DealStartTime.ToString("yyyy/MM/dd HH:mm"), vpv.DealEndTime.ToString("yyyy/MM/dd HH:mm")),
                            Status = "Ready",
                            Checked = true,
                            Message = ""
                        };
                    }
                }
            }
        }

        /// <summary>
        /// 異動紀錄
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorization]
        [PermissionFilter("策展活動")]
        public dynamic GetThemeCurationChangeLog(GetThemeCurationChangeLogInput input)
        {
            int rowSize = 0;

            List<ChangeLog> changeLogs = new List<ChangeLog>();

            if (input.CurationGuid != null && input.CurationGuid != Guid.Empty)
            {
                changeLogs = LogFacade.GetChangeLogsWithPagition(input.PageStart.GetValueOrDefault(1), pageLength, input.ChannelId, User.Identity.Name, "策展活動", out rowSize, input.CurationGuid.ToString());
            }


            Pagination pagination = new Pagination()
            {
                pageStart = input.PageStart.GetValueOrDefault(1),
                rowSize = rowSize,
                pageLength = pageLength
            };
            var result = JsonSerializer.Serialize(new
            {
                data = changeLogs,
                pagination = pagination,
            });

            return result;
        }


        #endregion 策展活動

        #region 策展送審
        /// <summary>
        /// 送審紀錄
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorization]
        [PermissionFilter("策展活動")]
        public dynamic GetThemeCurationApplyChangeLog(GetThemeCurationChangeLogInput input)
        {
            int rowSize = 0;

            List<ChangeLog> changeLogs = new List<ChangeLog>();
            if (input.CurationGuid != null && input.CurationGuid != Guid.Empty)
            {
                changeLogs = LogFacade.GetChangeLogsWithPagition(input.PageStart.GetValueOrDefault(1), pageLength, input.ChannelId, User.Identity.Name, "策展活動", out rowSize, input.CurationGuid.ToString(), "apply");
            }

            Pagination pagination = new Pagination()
            {
                pageStart = input.PageStart.GetValueOrDefault(1),
                rowSize = rowSize,
                pageLength = pageLength
            };
            var result = JsonSerializer.Serialize(new
            {
                data = changeLogs,
                pagination = pagination,
            });

            return result;
        }
        /// <summary>
        /// 送審
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorization]
        [PermissionFilter("策展活動")]
        public dynamic ThemeCurationApply(GetThemeCurationChangeLogInput input)
        {
            bool isSuccess = false;
            string message = string.Empty;
            try
            {
                Guid curationGuid = input.CurationGuid.GetValueOrDefault();
                if (curationGuid != null && curationGuid != Guid.Empty)
                {
                    ThemeCurationMainProposal main = tcp.GetThemeCurationMainProposal(curationGuid, input.ChannelId);
                    if (main != null)
                    {
                        if (main.ApplyType != (int)ThemeCurationApplyType.Apply)
                        {
                            main.ApplyType = (int)ThemeCurationApplyType.Apply;
                            tcp.SaveThemeCurationMainProposal(main, Microsoft.EntityFrameworkCore.EntityState.Modified);
                            isSuccess = true;
                            message = "送審成功。";

                            LogFacade.AddAuditLog(User.Identity.Name, main.ChannelId, "策展活動", main.CurationGuid.ToString(), AuditType.Review, main.Title, "/themeCuration/themeCurationAdd?id=" + main.CurationGuid.ToString(), AuditProcessing.Processing);
                            LogFacade.AddLog(User.Identity.Name, input.ChannelId, main.CurationGuid.ToString(), "策展活動", string.Format("「送審」，編號 ({0})", main.CurationId), "apply");
                        }
                        else
                        {
                            message = "狀態異常，送審失敗。";
                        }
                    }
                    else
                    {
                        message = "送審失敗**";
                    }
                }
                else
                {
                    message = "送審失敗*";
                }

            }
            catch (Exception ex)
            {
                message = ex.Message;
            }

            return new
            {
                IsSuccess = isSuccess,
                Message = message
            };
        }
        /// <summary>
        /// 立即更新
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorization]
        [PermissionFilter("策展活動")]
        public dynamic ThemeCurationUpdate(GetThemeCurationChangeLogInput input)
        {
            bool isSuccess = false;
            string message = string.Empty;
            try
            {
                Guid curationGuid = input.CurationGuid.GetValueOrDefault();
                if (curationGuid != null && curationGuid != Guid.Empty)
                {
                    ThemeCurationMainProposal main = tcp.GetThemeCurationMainProposal(curationGuid, input.ChannelId);
                    if (main != null)
                    {
                        //if (main.ApplyType == (int)ThemeCurationApplyType.Apply)
                        //{


                        List<ThemeCurationCategoryProposal> themeCurationCategoryProposals = tcp.GetThemeCurationCategoryProposals(main.CurationGuid);
                        List<ThemeCurationProductProposal> themeCurationProductProposals = tcp.GetThemeCurationProductProposals(themeCurationCategoryProposals.Select(x => x.CategoryGuid).ToList());
                        SyncThemeCuration(main, themeCurationCategoryProposals, themeCurationProductProposals);


                        main.ApplyType = (int)ThemeCurationApplyType.Audit;
                        main.ReturnType = (int)ThemeCurationApplyType.Init;
                        main.ReturnReason = string.Empty;
                        main.ModifyId = User.Identity.Name;
                        main.ModifyTime = DateTime.Now;
                        tcp.SaveThemeCurationMainProposal(main, Microsoft.EntityFrameworkCore.EntityState.Modified);
                        isSuccess = true;

                        CurationFacade.ClearCurationCache(curationGuid, input.ChannelId);
                        ThemeCurationMainPreview m = CurationFacade.GetCurationCache(curationGuid, input.ChannelId);

                        message = "立即更新成功。";
                        LogFacade.ApproveAuditLog(User.Identity.Name, main.ChannelId, "策展活動", main.CurationGuid.ToString(), AuditType.Approved, main.Title, "/themeCuration/themeCurationAdd?id=" + main.CurationId);
                        LogFacade.AddLog(User.Identity.Name, input.ChannelId, main.CurationGuid.ToString(), "策展活動", string.Format("「立即更新」，編號 ({0})", main.CurationId), "apply");
                    }
                    else
                    {
                        message = "立即更新失敗**";
                    }
                }
                else
                {
                    message = "立即更新失敗*";
                }

            }
            catch (Exception ex)
            {
                message = ex.Message;
            }

            return new
            {
                IsSuccess = isSuccess,
                Message = message
            };
        }

        /// <summary>
        /// 退回
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorization]
        [PermissionFilter("策展活動")]
        public dynamic ThemeCurationReturn(GetThemeCurationChangeLogInput input)
        {
            bool isSuccess = false;
            string message = string.Empty;
            try
            {
                //int id = default(int);
                if (input.CurationGuid != null && input.CurationGuid != Guid.Empty)
                {
                    ThemeCurationMainProposal main = tcp.GetThemeCurationMainProposal(input.CurationGuid.GetValueOrDefault(), input.ChannelId);
                    if (main != null)
                    {
                        if (main.ApplyType == (int)ThemeCurationApplyType.Apply)
                        {
                            main.ApplyType = (int)ThemeCurationApplyType.Init;
                            main.ReturnType = (int)ThemeCurationApplyType.Return;
                            main.ReturnReason = input.Reason;
                            tcp.SaveThemeCurationMainProposal(main, Microsoft.EntityFrameworkCore.EntityState.Modified);
                            isSuccess = true;
                            message = "退回成功。"; 

                            LogFacade.ApproveAuditLog(User.Identity.Name, main.ChannelId, "策展活動", main.CurationGuid.ToString(), AuditType.Rejected, main.Title, "/themeCuration/themeCurationAdd?id=" + main.CurationId);
                            LogFacade.AddLog(User.Identity.Name, input.ChannelId, main.CurationGuid.ToString(), "策展活動", string.Format("「退回」，編號 ({0})，原因： {1}", main.CurationId, input.Reason), "apply");
                        }
                        else
                        {
                            message = "狀態異常，退回失敗。";
                        }
                    }
                    else
                    {
                        message = "退回失敗**";
                    }
                }
                else
                {
                    message = "退回失敗*";
                }

            }
            catch (Exception ex)
            {
                message = ex.Message;
            }

            return new
            {
                IsSuccess = isSuccess,
                Message = message
            };
        }

        /// <summary>
        /// 預覽
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorization]
        [PermissionFilter("策展活動")]
        public dynamic ThemeCurationPreview(GetThemeCurationInput input)
        {
            bool isSuccess = false;
            ThemeCurationMainProposalModel main = new ThemeCurationMainProposalModel();
            string message = string.Empty;
            try
            {
                //Guid channelId = Guid.Empty;
                //if(Guid.TryParse(input.ChannelId, out channelId))
                //{
                //    main = tcp.GetThemeCurationMainProposalById(input.CurationGuid, channelId);
                //    main.ImagePath = Helper.CombineUrls(Ioc.GetConfig().ImagesBaseUrl, main.ImagePath);

                //    List<ThemeCurationCategoryProposal> themeCurationCategories = tcp.GetThemeCurationCategoryProposals(main.CurationGuid);

                //    foreach (ThemeCurationCategoryProposal themeCurationCategory in themeCurationCategories.OrderBy(t => t.Sort))
                //    {
                //        List<ThemeCurationProductProposal> currentThemeCurationProducts = themeCurationProducts
                //                                .Where(x => x.CategoryGuid == themeCurationCategory.CategoryGuid)
                //                                .ToList();
                //        List<CurationBidStatus> bids = new List<CurationBidStatus>();
                //        foreach (ThemeCurationProductProposal p in currentThemeCurationProducts.OrderBy(t => t.Sort))
                //        {
                //            ViewProductVersion vpv = vpvs.Where(x => x.Bid == p.Bid).FirstOrDefault();
                //            if (vpv != null)
                //            {
                //                bids.Add(new CurationBidStatus
                //                {
                //                    Bid = p.Bid,
                //                    DealStatus = vpv.Offline.GetValueOrDefault() ? "下架" : "上架",
                //                    DealName = vpv.ProductName,
                //                    DealTime = string.Format("{0}~{1}", vpv.DealStartTime.ToString("yyyy/MM/dd"), vpv.DealEndTime.ToString("yyyy/MM/dd"))
                //                });
                //            }
                //        }
                //        curationTabs.Add(new CurationTab
                //        {
                //            TabGuid = themeCurationCategory.CategoryGuid.ToString(),
                //            TabName = themeCurationCategory.CategoryName,
                //            Bids = bids
                //        });
                //    }
                //    main.Tabs = curationTabs;


                //    isSuccess = true;
                //}
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }

            return new
            {
                IsSuccess = isSuccess,
                Data = main,
                Message = message
            };
        }

        private void SyncThemeCuration(
            ThemeCurationMainProposal themeCurationMainPro,
            List<ThemeCurationCategoryProposal> themeCurationCategoryPros,
            List<ThemeCurationProductProposal> themeCurationProductPros
            )
        {
            #region ThemeCurationMain
            Microsoft.EntityFrameworkCore.EntityState state = Microsoft.EntityFrameworkCore.EntityState.Modified;
            ThemeCurationMain themeCurationMain = tcp.GetThemeCurationMain(themeCurationMainPro.CurationGuid, themeCurationMainPro.ChannelId);
            if (themeCurationMain == null)
            {
                themeCurationMain = new ThemeCurationMain
                {
                    CurationId = themeCurationMainPro.CurationId,
                    CurationGuid = themeCurationMainPro.CurationGuid,
                    Title = themeCurationMainPro.Title,
                    StartTime = themeCurationMainPro.StartTime,
                    EndTime = themeCurationMainPro.EndTime,
                    ThemeType = themeCurationMainPro.ThemeType,
                    ThemeStyle = themeCurationMainPro.ThemeStyle,
                    CreateId = themeCurationMainPro.CreateId,
                    CreateTime = themeCurationMainPro.CreateTime,
                    ChannelId = themeCurationMainPro.ChannelId,
                    SourceType = themeCurationMainPro.SourceType,
                    ImagePath = themeCurationMainPro.ImagePath,
                    ModifyId = themeCurationMainPro.ModifyId,
                    ModifyTime = themeCurationMainPro.ModifyTime,
                    CurationDescription = themeCurationMainPro.CurationDescription,
                    ApplyType = (int)ThemeCurationApplyType.Audit,
                    OuterUrl = themeCurationMainPro.OuterUrl,
                    BestChoice = themeCurationMainPro.BestChoice,
                    ActiveBannerImagePath = themeCurationMainPro.ActiveBannerImagePath
                };
                state = Microsoft.EntityFrameworkCore.EntityState.Added;
            }
            else
            {
                themeCurationMain.CurationId = themeCurationMainPro.CurationId;
                themeCurationMain.Title = themeCurationMainPro.Title;
                themeCurationMain.StartTime = themeCurationMainPro.StartTime;
                themeCurationMain.EndTime = themeCurationMainPro.EndTime;
                themeCurationMain.ThemeType = themeCurationMainPro.ThemeType;
                themeCurationMain.ThemeStyle = themeCurationMainPro.ThemeStyle;
                themeCurationMain.CreateId = themeCurationMainPro.CreateId;
                themeCurationMain.CreateTime = themeCurationMainPro.CreateTime;
                themeCurationMain.SourceType = themeCurationMainPro.SourceType;
                themeCurationMain.ImagePath = themeCurationMainPro.ImagePath;
                themeCurationMain.ModifyId = themeCurationMainPro.ModifyId;
                themeCurationMain.ModifyTime = themeCurationMainPro.ModifyTime;
                themeCurationMain.CurationDescription = themeCurationMainPro.CurationDescription;
                themeCurationMain.ApplyType = (int)ThemeCurationApplyType.Audit;
                themeCurationMain.OuterUrl = themeCurationMainPro.OuterUrl;
                themeCurationMain.BestChoice = themeCurationMainPro.BestChoice;
                themeCurationMain.ActiveBannerImagePath = themeCurationMainPro.ActiveBannerImagePath;
                themeCurationMain.ActiveBannerSort = string.IsNullOrEmpty(themeCurationMainPro.ActiveBannerImagePath) ? null : themeCurationMain.ActiveBannerSort;
            }
            #endregion ThemeCurationMain

            List<ThemeCurationCategory> themeCurationCategories = new List<ThemeCurationCategory>();
            foreach (ThemeCurationCategoryProposal themeCurationCategoryProposal in themeCurationCategoryPros)
            {
                themeCurationCategories.Add(new ThemeCurationCategory()
                {
                    CategoryGuid = themeCurationCategoryProposal.CategoryGuid,
                    CurationGuid = themeCurationCategoryProposal.CurationGuid,
                    Sort = themeCurationCategoryProposal.Sort,
                    CategoryName = themeCurationCategoryProposal.CategoryName,
                    ModifyId = themeCurationCategoryProposal.ModifyId,
                    ModifyTime = themeCurationCategoryProposal.ModifyTime,
                    Status = true
                });
            }


            List<ThemeCurationProduct> themeCurationProducts = new List<ThemeCurationProduct>();
            foreach (ThemeCurationProductProposal themeCurationProductProposal in themeCurationProductPros)
            {
                themeCurationProducts.Add(new ThemeCurationProduct()
                {
                    CategoryGuid = themeCurationProductProposal.CategoryGuid,
                    Bid = themeCurationProductProposal.Bid,
                    Sort = themeCurationProductProposal.Sort,
                    Status = true,
                    ModifyTime = themeCurationProductProposal.ModifyTime,
                    ModifyId = themeCurationProductProposal.ModifyId
                });
            }



            if (tcp.SaveThemeCurationMain(themeCurationMain, state))
            {
                tcp.SyncThemeCurationMain(themeCurationMain, themeCurationCategories, themeCurationProducts);
            }
        }
        #endregion 策展送審

    }

    public class ThemeCurationInput
    {
        public bool IsHideExpired { get; set; }
        public string ChannelId { get; set; }
        public int? PageStart { get; set; }
    }
    public class GetThemeCurationInput
    {
        public Guid CurationGuid { get; set; }
        public string ChannelId { get; set; }
    }
    public class GetThemeCurationChangeLogInput
    {
        public Guid? CurationGuid { get; set; }
        public Guid ChannelId { get; set; }
        public string Key1 { get; set; }
        public string Reason { get; set; }
        public int? PageStart { get; set; }
    }
    public partial class ThemeCurationMainBestChoiceModel
    {
        public string ChannelId { get; set; }
        public Guid CurationGuid { get; set; }
        public bool Checked { get; set; }
    }
    public class ThemeCurationCheckBidsInput
    {
        public string ChannelId { get; set; }
        public string Bid { get; set; }
    }
    public class SaveThemeCurationInput
    {
        public string ChannelId { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string SourceType { get; set; }
        public string CurationCategory { get; set; }
        public string CurationType { get; set; }
        public string CurationTimeS { get; set; }
        public string CurationTimeSH { get; set; }
        public string CurationTimeSM { get; set; }
        public string CurationTimeE { get; set; }
        public string CurationTimeEH { get; set; }
        public string CurationTimeEM { get; set; }
        public string ThemeType { get; set; }
        public string CurationStatus { get; set; }
        public string ImagePath { get; set; }
        public string CurationDescription { get; set; }
    }

    public class DeleteThemeCurationInput
    {
        public string Id { get; set; }
    }

    public class UploadImageModel
    {
        public Microsoft.AspNetCore.Http.IFormFileCollection Files { get; set; }
        public string CurationGuid { get; set; }
        public string ChannelId { get; set; }
    }
}
