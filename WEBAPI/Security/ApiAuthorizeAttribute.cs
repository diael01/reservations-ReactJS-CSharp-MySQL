using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;

namespace WEBAPI.Security
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    public sealed class ApiAuthorizeAttribute : AuthorizationFilterAttribute
    {

        public override Task OnAuthorizationAsync(HttpActionContext actionContext, 
                System.Threading.CancellationToken cancellationToken)
        {
            if (SkipAuthorization(actionContext))
            {
                return base.OnAuthorizationAsync(actionContext, cancellationToken);
            }
            try
            {
                var authorized = false;
                var principal = actionContext.Request.GetOwinContext().Authentication.User;
                if(principal == null || ! principal.Identity.IsAuthenticated)
                {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                    return Task.FromResult<object>(null);
                }
                if(!authorized && CheckRolesAuthorization(actionContext))
                {
                    var roles = (actionContext.ActionDescriptor.GetCustomAttributes<AuthorizeAttribute>());
                    foreach(var r in roles)
                    {
                        char[] seps = { ';', ',' };
                        var allRoles = r.Roles.Split(seps);
                        foreach(var role in allRoles)
                        {
                            if(principal.IsInRole(role))
                            {
                                return Task.FromResult<object>(null);
                            }
                        }
                    }
                }

                var demands = actionContext.ActionDescriptor.GetCustomAttributes<ApiDemandAttribute>();
                if(!demands.Any())
                {
                    actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.InternalServerError,
                        "No demand could be found for route");
                    return Task.FromResult(actionContext.Response);
                }

                char[] delimiterChars = { ';', ',' };
                demands.ToList().ForEach(delegate(ApiDemandAttribute demand)
                    {
                        var restClaims = demand.Demand.Split(delimiterChars);

                        foreach (var claim in restClaims)
                        {
                            if (principal.HasClaim("userClaimsPerRole", claim))
                            {
                                authorized = true;
                            }
                        }
                        //if the claim not in any role
                        if (!authorized && principal.HasClaim("exceptionClaim", demand.Demand))
                        {
                            authorized = true;
                        }
                    });
            

                if(!authorized)
                {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Forbidden,
                        "User not allowed to perform this action");
                    return Task.FromResult<object>(actionContext.Response);
                }

            }
            catch(Exception)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            return base.OnAuthorizationAsync(actionContext, cancellationToken);
        }

        private static bool SkipAuthorization(HttpActionContext actionContext)
        {
            //Contract.Assert(actionContext != null);
            return actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any()
                ||
                actionContext.ControllerContext.ControllerDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any();
        }

        private static bool CheckRolesAuthorization(HttpActionContext actionContext)
        {
            //Contract.Assert(actionContext != null);
            return actionContext.ActionDescriptor.GetCustomAttributes<AuthorizeAttribute>().Any()
                ||
                actionContext.ControllerContext.ControllerDescriptor.GetCustomAttributes<AuthorizeAttribute>().Any();
        }

    }
}