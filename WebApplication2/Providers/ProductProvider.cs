using LifeEnterpot.Core.Models;
using LifeEnterpot.Core.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LifeEnterpot.Web.Providers
{
    public class ProductProvider : IProductProvider
    {
        public List<ViewProductDeal> _roures;

        public ProductProvider()
        {
            if (_roures == null)
            {
                MockDataTest();
            }
        }
        public void MockDataTest()
        {
            _roures = new List<ViewProductDeal>
            {
                //new ViewProductDeal
                //{
                //    Id = 999,
                //    ProductPvid = 1,
                //    Pvid = 1,
                //    ProductId = 1,
                //    Bid = Guid.Empty,
                //    IsMain = true,
                //    ChannelId = Guid.Empty,
                //    ProductName = "ProductName測試",
                //    SubTitle = "SubTitle測試",
                //    ImagePath = "ImagePath",
                //    Price = 50,
                //    OriginalPrice = 90,
                //    IsSoldOut = false,
                //    DeliveryType = 1,
                //    Cost = 5,
                //    IsChosen = false,
                //    Offline = false,
                //    SysOffline = false,
                //    SuppilerId = 1,
                //    SuppilerProductId = "SuppilerProductId",
                //    CreateTime = DateTime.Now,
                //    IsGroupCoupon = false,
                //    CouponType = null,
                //    SaleMultipleBase = 1,
                //    PaymentRestrict = 10,
                //    Promotion = "Promotion",
                //    DealStartTime = DateTime.Now,
                //    DealEndTime = DateTime.Now,
                //}

                new ViewProductDeal
                {
                    Pvid = 1,
                    Bid = Guid.Empty,
                    IsMain = true,
                    ChannelId = Guid.Empty,
                    ProductName = "ProductName測試",
                    SubTitle = "SubTitle測試",
                    ImagePath = "ImagePath",
                    Price = 50,
                    OriginalPrice = 90,
                    IsSoldOut = false,
                    DeliveryType = 1,
                    IsChosen = false,
                    Offline = false,
                    IsGroupCoupon = false,
                    CouponType = null,
                    SaleMultipleBase = 1,
                    PaymentRestrict = 10,
                    Promotion = "Promotion",
                    DealStartTime = DateTime.Now,
                    DealEndTime = DateTime.Now,
                    

                }
            };
          }



        public List<ViewProductDeal> ViewProductDealsAll()
        {
            //List<ViewProductDeal> ViewProductDeals =   new List<ViewProductDeal>();

            //ViewProductDeals.Add(new ViewProductDeal() { }) ;

            // return ViewProductDeals;
            return _roures.ToList();
            //return _roures.Where();
            //throw new NotImplementedException();
        }

        public ViewProductDeal  ViewProductDealsByChannelId(Guid channelId)
        {
            return  _roures.FirstOrDefault(n => n.ChannelId == channelId ) ;
        }

        public List<ViewProductDeal> ViewProductDealsByChannelIdWithDealTime(Guid channelId)
        {
            return _roures.ToList();
            //return _roures.FirstOrDefault(n => n.ChannelId == channelId); 
            //throw new NotImplementedException();
        }

        public List<ViewProductDeal> ViewProductDealsGet(Guid channelId, List<Guid> bids)
        {
            //return _roures.Where(n => n.ChannelId = channelId); //_roures.FirstOrDefault(n => n.ChannelId == channelId && n.Bid  = bids ) ;
            return _roures.ToList();

            //throw new NotImplementedException();
        }

        public List<ViewProductDeal> ViewProductDealsGetAll()
        {
            return _roures.ToList();

            //return ViewProductDeals;
            //throw new NotImplementedException();
        }

        public List<ViewProductDeal> ViewProductDealsGetRandom(Guid channelId, List<Guid> bids, int deliveryType, int num)
        {
            return _roures.ToList();

            //return ViewProductDeals;
            //throw new NotImplementedException();
        }

        List<ViewProductDeal> IProductProvider.ViewProductDealsByChannelId(Guid channelId)
        {
            return _roures.ToList();

            //return ViewProductDeals;
            
        }
    }
}
