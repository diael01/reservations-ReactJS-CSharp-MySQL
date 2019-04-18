using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using WEBAPI.Models;
using WEBAPI.Results;
using System.Web.Http.Cors;
using System.Diagnostics;
using WEBAPI.Infrastructure;

namespace WEBAPI.Controllers
{
    [EnableCors("*","*","*")]
    [RoutePrefix("api/Account")]
    public class AccountController : BaseApiController
    {
        //private readonly IMenuAuthorizationService _menuAuthorizationService;
        //private readonly IMenuItemsService _menuItemsService;

        //public void AccountsController(IMenuAuthorizationsService mSvc, IMenuItemsService menuItems)
        //{
        //    _menuAuthorizationService = mSvc;
        //    _menuItemsService = menuItems;
        //}
        public void AccountsController()
        {
           
        }

        [AllowAnonymous]
        [Route("verify")]
        public async Task<IHttpActionResult> Verify(UserModel createUserModel)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var NTLogin="";
            var decUser="";
            if(HttpContext.Current!=null)
            {
                NTLogin = HttpContext.Current.Request.LogonUserIdentity.Name;
                decUser = NTLogin.Substring(NTLogin.LastIndexOf("\\")+1);
            }
            else {
                //decUser = AESEncryptDecrypt.DecryptStringAES(createUserModel.UserName);
            }

            try
            {
                var user = await AppUserManager.FindByNameAsync(decUser);
                if(user == null)
                {
                    user = new ApplicationUser
                    {
                        UserName = decUser
                    };
                    var addUserResult = AppUserManager.Create(user);
                    if(!addUserResult.Succeeded)
                    {
                        return GetErrorResult(addUserResult);
                    }
                    //var isAuthorized = SetMenuAuthorizations(user);
                    //return Ok(isAuthorized);
                    return Ok();
                }
            }
            catch (Exception ex)
            {

                EventLog.WriteEntry("accontsController",ex.StackTrace);
            }
            return null;
        }

        //private Dictionary<string,string>  SetMenuAuthorizations(ApplicationUser user)
        //{
        //    var isAuthorized = new Dictionary<string,string>();
        //    try {

        //        var menuAuthorizations = _menuAuthorizationService.GetMenuAuthorizations();
        //        var menuItems = _menuItemsService.GetMenuItems();
        //        isAuthorized["user"]=user.UserName;
        //        isAuthorized["logout"]="true";

        //        foreach(var mi in menuItems)
        //        {
        //            var miName = mi.itemName;
        //            isAuthorized[miName]=false.ToString();
        //            var menuAuth = menuAuthorizations.FirstOrDefault(c=>c.menuId.Equals(mi.Id));
        //            if(user.Roles.Any(role=>role.RoleId.Equals(menuAuth.roleId)))
        //            {
        //                isAuthorized [miName] = true.ToString();

        //            }
        //            var foundClaim = user.Claims.FirstOrDefault(s => s.ClaimValue.Equals(miName));
        //            if(foundClaim != null)
        //            {
        //                isAuthorized[miName] = true.ToString();
        //            }
        //        }


        //    }
        //    catch(Exception ex){
        //        EventLog.WriteEntry("accountsController.SetMenuAuth", ex.StackTrace);
        //    }
        //    return isAuthorized;
        //}

    }
}
