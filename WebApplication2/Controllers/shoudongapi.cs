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




namespace FakeXiecheng.API.Controllers
{
    [Route("api/shoudongapi")]
    [ApiController]
    public class Shoudongapi : Controller
    {
        static ILog logger = LogManager.GetLogger(typeof(Shoudongapi));
        [HttpGet]
        public dynamic TodayHotDeals()
        {
            Guid channelId = Guid.Empty;
            string channelHost = string.Empty;
            string Test = "123456";
            string Test01 = "654321";
            try
            {
                return new ApiResult
                {
                    Code = ApiResultCode.OAuthTokerNoAuth,
                    Message = Test,
                };

                //string channelToken = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
                ////bool tokenLeg = FrontFacade.TryGetChannelId(channelToken, out channelId, out channelHost);

                //return new ApiResult
                //{
                //    Code = ApiResultCode.OAuthTokerNoAuth,
                //    Message = Test01,

                //};
                TaishinProductDeals deals = TaishinCacheFacade.TodayHotDeals(channelId, channelHost);
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


}
}
