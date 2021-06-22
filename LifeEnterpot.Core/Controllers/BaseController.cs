//using LifeEnterpot.Core.Components;
//using LifeEnterpot.Web.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
//using LifeEnterpot.Core.ModelCustom;

namespace LifeEnterpot.WebAPI.Controllers
{
    //[ChannelPermission]
    public class BackendChannelController : BaseController
    {
        //public ChannelInfo ChannelInfo
        //{
        //    get
        //    {
        //        CentralIdentity user = HttpContext.User.Identity as CentralIdentity;
        //        if (user != null)
        //        {
        //            return new ChannelInfo
        //            {
        //                ChannelId = user.ChannelId.Value,
        //                CreateId = user.Name
        //            };
        //        }
        //        return null;
        //    }
        //}
    }
    public class BaseController : Controller
    {
        protected static int pageLength = 20;

        public ObjectResult ServerError(string message)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, message);
        }


    }
}
