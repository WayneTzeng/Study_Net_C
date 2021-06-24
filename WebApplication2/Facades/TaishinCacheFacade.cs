﻿using LifeEnterpot.Core.Enums;
//using LifeEnterpot.Core.Kernel;
//using LifeEnterpot.Core.Models;
//using LifeEnterpot.Core.Providers;
//using LifeEnterpot.Core.Template;
//using LifeEnterpot.Core.Template.ViewModel;
//using LifeEnterpot.Core.Utilities.TemplateHelper;
//using LifeEnterpot.Core.Utilities;
using LifeEnterpot.Core.ModelCustom;
using log4net;
//using RazorLight;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Net.Mime;
using LifeEnterpot.Core.Kernel;

namespace LifeEnterpot.Core.Facades
{
    public class TaishinCacheFacade
    {

        //static IProductProvider pp = Ioc.Get<IProductProvider>();

        /// <summary>
        /// 取得APP 首頁 TodayHotDeals
        /// </summary>
        /// <returns></returns>
        
        public static TaishinProductDeals TodayHotDeals(Guid channelId, string channelHost)
        {
            //string UR = "Facade成功";
            Console.WriteLine("Open_TodayHotDeals");

            string key = string.Format("TodayHotDeals://{0}/{1}", channelId, channelHost);
            Console.WriteLine(key);
            Console.WriteLine("Format");

            TaishinCacheData<TaishinProductDeals> result = null;//  CacheFacade.Get<TaishinCacheData<TaishinProductDeals>>(key);
           
            Console.WriteLine("Open_CacheFacade");
            Console.WriteLine(result);

            if (result == null)
            {
                var data = TaishinFacade.TodayHotDeals(channelId, channelHost);
                result = new TaishinCacheData<TaishinProductDeals>
                {
                    Data = data
                };
                CacheFacade.Set(key, result, Ioc.GetConfig().TaishinDefaultCacheMinute);
            }
            return result.Data;
        }

    }

}
