using LifeEnterpot.Core.Models;
using System;
using System.Collections.Generic;

namespace LifeEnterpot.Core.Providers
{
    public interface IAppLayoutProvider
    {
        #region AppLayoutMain
        List<AppLayoutMain> AppLayoutMainGetLast(Guid channelId, Guid sectionId);
        AppLayoutMain AppLayoutMainGet(Guid channelId, Guid sectionId, int mainId);
        AppLayoutMain AppLayoutMainGet(int id);
        List<Guid> AppLayoutMainGetActionGuid(Guid channelId, Guid sectionId, int mainId);
        ViewAppLayoutMain ViewAppLayoutMainGet(Guid channelId, int num);
        IEnumerable<AppLayoutProvider> GetAppLayoutProviders();
        

        #endregion AppLayoutMain

        #region AppLayoutProduct
        List<AppLayoutProduct> AppLayoutProductGetList(Guid actionGuid);
        AppLayoutProduct AppLayoutProductGet(Guid actionGuid, Guid bid);
        //IEnumerable<AppLayoutProvider> GetAppLayoutProviders();
        #endregion AppLayoutProduct


    }
}
