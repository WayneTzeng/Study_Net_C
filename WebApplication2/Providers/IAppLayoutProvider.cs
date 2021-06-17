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
        #endregion AppLayoutMain

    }
}
