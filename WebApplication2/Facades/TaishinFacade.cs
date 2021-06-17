﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LifeEnterpot.Core.ModelCustom;
using LifeEnterpot.Core.Models;

namespace LifeEnterpot.Core.Facades

{
    public class TaishinFacade
    {

        public static TaishinProductDeals TodayHotDeals(Guid channelId, string channelHost)
        {
            ViewAppLayoutMain main = alp.ViewAppLayoutMainGet(channelId, (int)AppLayoutSectionEnum.Product);
            if (main == null)
            {
                return null;
            }

            //logger.Info("main.ActionGuid:" + main.ActionGuid);
            var bids = alp.AppLayoutProductGetList(main.ActionGuid).Select(x => new
            {
                Bid = x.Bid,
                DealName = x.DealName,
                Sort = x.Sort
            }).ToList();

            List<ViewProductDeal> products = new List<ViewProductDeal>();
            foreach (var data in bids)
            {
                List<Guid> bid = new List<Guid>();
                bid.Add(data.Bid);
                products.AddRange(pp.ViewProductDealsGet(channelId, bid)
                .Where(x => x.DealStartTime < DateTime.Now && x.DealEndTime >= DateTime.Now && x.Offline == false).ToList());
            }


            List<TaishinProductDealList> deals = new List<TaishinProductDealList>();

            #region 因應雙11先手動塞策展檔次，結束後拿掉

            //TaishinProductDealList deal = null;
            ////測試
            //if (DateTime.Now >= new DateTime(2020, 10, 30) && DateTime.Now < new DateTime(2020, 11, 1))
            //{
            //    deal = new TaishinProductDealList
            //    {
            //        Bid = "b388227c-8193-40f0-9e08-045651cea479",
            //        Title = "咖啡11杯下殺68折",
            //        SubTitle = "滿11,111現折1,111 滿1,111現折11",
            //        ImagePath = "https://image.i-buy88.com/1000x1000%E9%9B%9911-2.jpg",
            //        Price = 1000,
            //        OriginalPrice = 1111,
            //        SoldNum = 0,
            //        SoldOut = false,
            //        IsChosen = false,
            //        ProductUrl = "https://uat.ktc.i-buy88.com/curation/b388227c-8193-40f0-9e08-045651cea479"
            //    };
            //}
            ////正式
            //if (DateTime.Now >= new DateTime(2020, 11, 2) && DateTime.Now < new DateTime(2020, 11, 13))
            //{
            //    deal = new TaishinProductDealList
            //    {
            //        Bid = "25f6a678-e1c0-4712-addb-cc9d9540a76b",
            //        Title = "咖啡11杯下殺$411",
            //        SubTitle = "滿11,111現折1,111 滿1,111現折11",
            //        ImagePath = "https://img.i-buy88.com/lADPGSkR_aAJZMPNA-jNA-g_1000_1000.jpg",
            //        Price = 411,
            //        OriginalPrice = 605,
            //        SoldNum = 0,
            //        SoldOut = false,
            //        IsChosen = false,
            //        ProductUrl = "https://ktc.i-buy88.com/curation/25f6a678-e1c0-4712-addb-cc9d9540a76b",
            //        sort = 0
            //    };
            //}

            //if (deal != null)
            //{
            //    deals.Add(deal);
            //}

            #endregion 因應雙11先手動塞策展檔次，結束後拿掉
            //雙12增加Config手動加策展，後續討論轉存DB
            if (config.APP_TodayHotDeals.Any())
            {
                deals.AddRange(config.APP_TodayHotDeals);
            }

            foreach (var pd in products)
            {
                string dealName = pd.ProductName;
                int dealSort = 0;
                if (bids.Any(x => x.Bid == pd.Bid))
                {
                    dealName = bids.FirstOrDefault(x => x.Bid == pd.Bid).DealName;
                    dealSort = bids.FirstOrDefault(x => x.Bid == pd.Bid).Sort;
                }

                deals.Add(new TaishinProductDealList
                {
                    Bid = pd.Bid.ToString(),
                    Title = dealName,
                    SubTitle = pd.SubTitle,
                    ImagePath = pd.ImagePath,
                    Price = pd.Price,
                    OriginalPrice = pd.OriginalPrice,
                    SoldNum = pd.SoldNum,
                    SoldOut = pd.IsSoldOut,
                    IsChosen = pd.IsChosen,
                    ProductUrl = channelHost + string.Format("/product/{0}", pd.Bid.ToString()),
                    sort = dealSort
                });

            }
            TaishinProductDeals result = new TaishinProductDeals
            {
                Headline = main.LayoutName,
                FunctionUrl = channelHost,
                DealList = deals.Take(24).ToList()
            };

            return result;
        }
    } 
}