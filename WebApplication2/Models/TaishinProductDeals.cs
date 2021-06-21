using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LifeEnterpot.Core.Enums;


namespace LifeEnterpot.Core.ModelCustom
{

    public class TaishinProductDeals
    {
        // GET: TS_API_Model
        public TaishinProductDeals()
        {
            DealList = new List<TaishinProductDealList>();
        }
        public string Headline { get; set; }
        public string FunctionUrl { get; set; }
        public List<TaishinProductDealList> DealList { get; set; }


        // GET: TS_API_Model/Details/5
        
        
    };


    public class TaishinProductDealList
    {
        public TaishinProductDealList()
        {
            SubTitle = string.Empty;
        }
        public string Bid { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string ImagePath { get; set; }
        public decimal Price { get; set; }
        public decimal OriginalPrice { get; set; }
        public int SoldNum { get; set; }
        public bool SoldOut { get; set; }
        public bool IsChosen { get; set; }
        public string ProductUrl { get; set; }
        public int sort { get; set; }
    }

    public class TaishinCurationDeals
    {
        public TaishinCurationDeals()
        {
            DealList = new List<TaishinProductDealList>();
        }
        public string Headline { get; set; }
        public string FunctionUrl { get; set; }
        public List<TaishinProductDealList> DealList { get; set; }
    }


    public class TaishinCacheData<T>
    {
        public T Data { get; set; }

        //public static implicit operator TaishinCacheData<T>(string v)
        //{
        //    throw new NotImplementedException();
        //}
    }

};
