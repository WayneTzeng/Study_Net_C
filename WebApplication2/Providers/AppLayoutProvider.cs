using LifeEnterpot.Core.DbContenxts;
using LifeEnterpot.Core.Providers;
using LifeEnterpot.Core.Enums;
using LifeEnterpot.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using LifeEnterpot.Core.Enums;
using LifeEnterpot.Core.ModelCustom;

namespace LifeEnterpot.Core.Providers
{
    public class AppLayoutProvider : IAppLayoutProvider
    {
        private List<AppLayoutMain> _roures;
        private List<AppLayoutProduct> _roures01;
        private List<ViewAppLayoutMain> _roures02;
        private List<TaishinProductDealList> _roures03;

        public  AppLayoutProvider()
        {
            MockDataTest();
            MockDataAppLayoutProduct();
            MockDataViewAppLayoutMain();
            MockDataTaishinProductDealList();
        }
        public  void MockDataTest()
        {
            _roures = new List<AppLayoutMain>
            {
                new AppLayoutMain
                {
                    Id = 999 ,
                    ChannelId = Guid.Empty,
                    SectionId = Guid.Empty,
                    LayoutName = "Layour測試",
                    CreateId  = "CreateId測試",
                    ActionGuid  = Guid.Empty,
                    ModifyId =  "ModifyId" ,
                    MainId = 998,
                    ModifyTime = DateTime.Now,
                    StartTime = DateTime.Now,
                    EndTime = DateTime.Now,
                 },

                //new AppLayoutMain
                //{
                //    Id = 999 ,
                //    ChannelId = Guid.Empty,
                //    SectionId = Guid.Empty,
                //    LayoutName = "Layour測試",
                //    CreateId  = "CreateId測試",
                //    ActionGuid  =  Guid.Empty,
                //    ModifyId =  "ModifyId" ,
                //    MainId = 998,
                //    ModifyTime = DateTime.Now,
                //    StartTime = DateTime.Now,
                //    EndTime = DateTime.Now,
                    
                // }

            };
        }
        public  void MockDataAppLayoutProduct()
        {
            _roures01 = new List<AppLayoutProduct>
            {
                new AppLayoutProduct
                {
                     Id = 7777,
                    ActionGuid = Guid.Empty,
                    Bid = Guid.Empty,
                    Latest =7777,
                    Sort =777,
                    DealName = "AppLayoutProduct",
                }               
            };
        }

        internal object GetAppLayoutProviders()
        {
            return _roures03;
        }

        public void MockDataViewAppLayoutMain()
        {
            _roures02 = new List<ViewAppLayoutMain>
            {
                new ViewAppLayoutMain
                {
		            Id =777,
		            ChannelId  = Guid.Empty,
		            Type  =1,
                    Status =1,
                    Memo ="Memo",
                    LayoutName  ="LayoutName",
                    StartTime  =DateTime.Now,
                    EndTime =  DateTime.Now,
                    CreateId  ="CreateId",
                    CreateTime =  DateTime.Now,
                    ActionGuid  =Guid.Empty,
                    MainId  =999,
                   
                }
            };
        }

        public void MockDataTaishinProductDealList()
        {
            _roures03 = new List<TaishinProductDealList>
            {
                new TaishinProductDealList
                {
                    Bid = "123",
                    Title = "123",
                    SubTitle = "123",
                    ImagePath = "123",
                    Price = 500,
                    OriginalPrice = 600,
                    SoldNum = 30,
                    SoldOut = false,
                    IsChosen = false,
                    ProductUrl = "123",
                    sort = 1,

                }
            };
        }



        public AppLayoutMain AppLayoutMainGet(Guid channelId, Guid sectionId, int mainId)
        {
            return _roures.FirstOrDefault(n => n.ChannelId == channelId && n.SectionId == sectionId && n.MainId == mainId);
            //return null;
            //throw new NotImplementedException();
        }

        public AppLayoutMain AppLayoutMainGet(int id)
        {
            return _roures.FirstOrDefault(x => x.Id == id);

            //return null;
            //throw new NotImplementedException();
        }

        public List<AppLayoutMain> AppLayoutMainGetLast(Guid channelId, Guid sectionId)
        {

            return _roures.ToList();
                //.Where(n => n.ChannelId == channelId && n.SectionId == sectionId ).ToList();
            //return this._roures;
            //return null;
            //throw new NotImplementedException();
        }

        public AppLayoutProduct AppLayoutProductGet(Guid actionGuid, Guid bid)
        {           
            return _roures01.FirstOrDefault(n => n.ActionGuid == actionGuid && n.Bid == bid);     
        }

        public List<AppLayoutProduct> AppLayoutProductGetList(Guid actionGuid)
        {
            return _roures01.ToList();
        }

        public ViewAppLayoutMain ViewAppLayoutMainGet(Guid channelId, int num)
        {
            return _roures02.FirstOrDefault();
            //return null;
            //throw new NotImplementedException();
        }

        public List<Guid> AppLayoutMainGetActionGuid(Guid channelId, Guid sectionId, int mainId)
        {
            //return _roures.Last();
            return null;
            //throw new NotImplementedException();
        }

        IEnumerable<AppLayoutProvider> IAppLayoutProvider.GetAppLayoutProviders()
        {
            return (IEnumerable<AppLayoutProvider>)_roures03;
        }


        //    #region AppLayoutMain
        //    public AppLayoutMain AppLayoutMainGet(Guid channelId, Guid sectionId, int mainId)
        //    {
        //        using (var dbx = new CommonDbContext())
        //        {
        //            return dbx.applayoutmainset.where(x => x.channelid.equals(channelid)
        //                        && x.sectionid.equals(sectionid)
        //                        && x.mainid.equals(mainid))
        //                .orderbydescending(t => t.createtime).firstordefault();
        //        }
        //    }
        //    public AppLayoutMain AppLayoutMainGet(int id)
        //    {

        //        return AppLayoutMainSet.(Id);

        //        using (var dbx = new CommonDbContext())
        //        {
        //            return dbx.AppLayoutMainSet.Where(x => x.Id.Equals(id)).FirstOrDefault();
        //        }
        //    }
        //    public List<Guid> AppLayoutMainGetActionGuid(Guid channelId, Guid sectionId, int mainId)
        //    }
        //    public List<AppLayoutMain> AppLayoutMainGetLast(Guid channelId, Guid sectionId)
        //    {
        //        string sql = @"
        //            select * from app_layout_main a with(nolock)
        //            where id = (select max(id) from app_layout_main a2 with(nolock) where a2.main_id = a.main_id)
        //            and a.channel_id = {0}
        //            and a.section_id = {1}
        //            order by a.create_time desc
        //            ";
        //        using (var dbx = new CommonDbContext())
        //        {
        //            return dbx.AppLayoutMainSet.FromSqlRaw(sql, channelId, sectionId).ToList();
        //        }
        //        //using (var dbx = new CommonDbContext())
        //        //{
        //        //    return dbx.AppLayoutMainSet.Where(x => x.ChannelId.Equals(channelId) && x.SectionId.Equals(sectionId)).ToList();
        //        //}
        //    }
        //    public ViewAppLayoutMain ViewAppLayoutMainGet(Guid channelId, int num)
        //    {
        //        string sql = @"
        //            SELECT  *
        //                FROM View_App_Layout_Main a with(nolock)
        //                Where channel_id={0}
        //                And id = (
        //                   Select max(id) from View_App_Layout_Main a2 with(nolock) 
        //                   Where a2.main_id = a.main_id
        //                   And start_time<=getdate()
        //                   And end_time>=getdate()
        //                   And status={1}
        //                   And type={2}
        //                )
        //                And start_time<=getdate()
        //                And end_time>=getdate()
        //                And status={1}
        //                And type={2}
        //            ";
        //        using (var dbx = new CommonDbContext())
        //        {
        //            int status = (int)AppLayoutStatus.Approved;
        //            return dbx.ViewAppLayoutMainSet.FromSqlRaw(sql, channelId, status, num).FirstOrDefault();
        //        }

        //    using (var dbx = new CommonDbContext())
        //    {
        //        return dbx.ViewAppLayoutMainSet.Where(x => x.ChannelId == channelId
        //            && x.Type == num
        //            && x.StartTime < DateTime.Now
        //            && x.EndTime >= DateTime.Now
        //            && x.Status == (int)AppLayoutStatus.Approved).FirstOrDefault();
        //    }
        //}
        //    #endregion AppLayoutMain


    }
}
