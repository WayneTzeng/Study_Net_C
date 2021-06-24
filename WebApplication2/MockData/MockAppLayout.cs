using LifeEnterpot.Core.Models;
using LifeEnterpot.Core.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LifeEnterpot.Core.MockData
{
    //public class MockAppLayout : IAppLayoutProvider
    //{
    //    private List<AppLayoutMain> _roures ;

    //    public MockAppLayout()
    //    {
    //        if (_roures ==  null)
    //        {
    //            MockDataTest();
    //        }
    //     }
    //    private void MockDataTest()
    //    {
    //        _roures = new List<AppLayoutMain>
    //        {
    //            new AppLayoutMain
    //            {
    //                Id = 999 ,
    //                ChannelId = Guid.Empty,
    //                SectionId = Guid.Empty,
    //                LayoutName = "Layour測試",
    //                CreateId  = "CreateId測試",
    //                ActionGuid  = Guid.Empty,
    //                ModifyId =  "ModifyId" ,
    //                MainId = 998,
    //                ModifyTime = DateTime.Now,
    //                StartTime = DateTime.Now,
    //                EndTime = DateTime.Now,
    //             },

    //            new AppLayoutMain
    //            {
    //                Id = 999 ,
    //                ChannelId = Guid.NewGuid(),
    //                SectionId = Guid.NewGuid(),
    //                LayoutName = "Layour測試",
    //                CreateId  = "CreateId測試",
    //                ActionGuid  = Guid.NewGuid(),
    //                ModifyId =  "ModifyId" ,
    //                MainId = 998,
    //                ModifyTime = DateTime.Now,
    //                StartTime = DateTime.Now,
    //                EndTime = DateTime.Now
    //             }

    //        };
    //     }
   


    //    public AppLayoutMain AppLayoutMainGet(Guid channelId, Guid sectionId, int mainId)
    //    {
    //        return _roures.FirstOrDefault(n => n.ChannelId == channelId && n.SectionId == sectionId && n.MainId == mainId );
    //    }

    //    public AppLayoutMain AppLayoutMainGet(int id) 
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public List<Guid> AppLayoutMainGetActionGuid(Guid channelId, Guid sectionId, int mainId)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public List<AppLayoutMain> AppLayoutMainGetLast(Guid channelId, Guid sectionId)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public AppLayoutProduct AppLayoutProductGet(Guid actionGuid, Guid bid)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public List<AppLayoutProduct> AppLayoutProductGetList(Guid actionGuid)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public ViewAppLayoutMain ViewAppLayoutMainGet(Guid channelId, int num)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}
