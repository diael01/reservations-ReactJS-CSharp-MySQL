using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using WEBAPI.Infrastructure;


namespace WEBAPI.Controllers
{
    public class BaseApiController : ApiController
    {
        private readonly ApplicationRoleManager _AppRoleManager = null;
        private readonly ApplicationUserManager _AppUserManager = null;



        protected ApplicationUserManager AppUserManager
        {
            get { return _AppUserManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>(); }
        }

        protected ApplicationRoleManager AppRoleManager
        {
            get { return _AppRoleManager ?? Request.GetOwinContext().GetUserManager<ApplicationRoleManager>(); }
        }

        protected IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if(result == null)
            {
                return InternalServerError();
            }

            if(!result.Succeeded)
            {
                if(result.Errors != null)
                {
                    foreach(var error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }
            }

            if(ModelState.IsValid)
            {
                return BadRequest();
            }

            return BadRequest(ModelState);
        }

    }
}