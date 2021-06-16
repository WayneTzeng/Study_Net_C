using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LifeEnterpot.Core.Enums;

namespace LifeEnterpot.Web.WebAPI.Models
{
    public class ApiResult
    {
        /// <summary>
        /// 回傳的結果
        /// </summary>
        public ApiResultCode Code { get; set; }
        /// <summary>
        /// 回傳資料主體
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public object Data { get; set; }
        /// <summary>
        /// 回傳的訊息
        /// </summary>
        public string Message { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        public ApiResult()
        {
            Code = ApiResultCode.Ready;
            Data = null;
            Message = string.Empty;
            Title = string.Empty;
        }
    }
}
