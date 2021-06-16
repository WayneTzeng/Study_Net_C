using Microsoft.AspNetCore.Mvc;
using LifeEnterpot.Web.WebAPI.Models;
using LifeEnterpot.Core.Enums;
//using LifeEnterpot.Core.Utilities;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using log4net;




// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public partial class TestAPIController : ControllerBase
    {
        //static ILog logger = LogManager.GetLogger(typeof(TaishinBankAPIController));



        // GET: api/<TestAPIController>
        [HttpGet]
        public dynamic TodayHotDeals()
        {
            Guid channelId = Guid.Empty;
            string channelHost = string.Empty;
            return new string[] { "value1", "value2" };
            //    int a = 2;
            //    if (a == 1) 
            //        return new ApiResult
            //        {
            //            Code = ApiResultCode.OAuthTokerNoAuth,
            //            Message = Helper.GetEnumDescription(ApiResultCode.OAuthTokerNoAuth)
            //        };
        }

        // GET api/<TestAPIController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TestAPIController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TestAPIController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TestAPIController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }




}
}
