using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
using LifeEnterpot.Web.WebAPI.Models;
using LifeEnterpot.WebAPI.Controllers;
using LifeEnterpot.Core.Enums;
//using LifeEnterpot.Core.Utilities;
using LifeEnterpot.Core.ModelCustom;
using LifeEnterpot.Core.Facades;
using LifeEnterpot.Core.Kernel;
using log4net;




namespace LifeEnterpot.WebAPI.Controllers
{
    [Route("api/app/{action}")]
    [ApiController]
    public class TaishinBankAPIController : Controller
    {
        static ILog logger = LogManager.GetLogger(typeof(TaishinBankAPIController));

        [HttpGet]
        public dynamic TodayHotDeals()
        {
            Guid channelId = Guid.Empty;
            string channelHost = string.Empty;
            string Test = "TodayHotDeals";
            string Test01 = "TaishinProductDeals";
            bool TokenLog = true;
            try
            {
                if (!TokenLog)
                {
                    return new ApiResult
                    {
                        Code = ApiResultCode.OAuthTokerNoAuth,
                        Message = Test,
                    };
                }


                //string channelToken = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
                ////bool tokenLeg = FrontFacade.TryGetChannelId(channelToken, out channelId, out channelHost);

                //return new ApiResult
                //{
                //    Code = ApiResultCode.OAuthTokerNoAuth,
                //    Message = Test01,

                //};
                TaishinProductDeals deals =  TaishinCacheFacade.TodayHotDeals(channelId, channelHost);
                
                if (deals == null)
                {
                    return new ApiResult
                    {
                        Code = ApiResultCode.DataNotFound,
                        Message = Test01,
                    };
                }

                //string deals = "我是資料";
                return Ok(new ApiResult
                {
                    Code = ApiResultCode.Success,
                    Data = deals
                });
                //return new ApiResult //string[] { "value1", "value2" };
                //{
                //};
            }
            catch (Exception ex)
            {
                logger.Warn("取得API todayHotDeals 資料時發生錯誤.", ex);
                throw new Exception("取得API資料時發生錯誤.");

            }

        }





        [HttpGet]
        public dynamic HotCurationDeals()
        {
            Guid channelId = Guid.Empty;
            string channelHost = string.Empty;
            string ErrorText = "錯誤";
            try
            {
                string channelToken = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
                //bool tokenLeg =  FrontFacade.TryGetChannelId(channelToken, out channelId, out channelHost);
                bool tokenLeg = true ;
                if (!tokenLeg)
                {
                    return new ApiResult
                    {
                        Code = ApiResultCode.OAuthTokerNoAuth,
                        Message = ErrorText //Helper.GetEnumDescription(ApiResultCode.OAuthTokerNoAuth)
                    };
                }
                //if (channelId == null)
                //{
                //    return new ApiResult
                //    {
                //        Code = ApiResultCode.OAuthTokerNotFound,
                //        Message = ErrorText//Helper.GetEnumDescription(ApiResultCode.OAuthTokerNotFound)
                //    };
                //}

                TaishinCurationDeals deals = TaishinFacade.HotCurationDeals(channelId, channelHost);

                if (deals == null)
                {
                    return new ApiResult
                    {
                        Code = ApiResultCode.DataNotFound,
                        Message = ErrorText  //Helper.GetEnumDescription(ApiResultCode.DataNotFound)
                    };
                }

                return Ok(new ApiResult
                {
                    Code = ApiResultCode.Success,
                    Data = deals
                });
            }
            catch (Exception ex)
            {
                logger.Warn("取得API hotCurationDeals 資料時發生錯誤.", ex);
                throw new Exception("取得API資料時發生錯誤.");
            }
        }












    }
}
