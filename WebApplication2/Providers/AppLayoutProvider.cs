using LifeEnterpot.Core.DbContenxts;
using LifeEnterpot.Core.Providers;
using LifeEnterpot.Core.Enums;
using LifeEnterpot.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using LifeEnterpot.Core.Enums;


namespace LifeEnterpot.Core.Providers
{
    public class AppLayoutProvider //: IAppLayoutProvider
    {
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
