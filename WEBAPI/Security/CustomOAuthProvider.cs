using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System.Threading.Tasks;
using WEBAPI.Infrastructure;

namespace WEBAPI.Security
{
    public class CustomOAuthProvider : OAuthAuthorizationServerProvider
    {
        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
           context.Validated();
           return Task.FromResult<object>(null);
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {

            var allowedOrigin = "*";

            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { allowedOrigin });

            var userManager = context.OwinContext.GetUserManager<ApplicationUserManager>();
            var decUser = AESEncryptDecrypt.DecryptStringAES(context.UserName);

            var userFound = await userManager.FindByNameAsync(decUser);
            if(userFound == null)
            {
                context.SetError("invalid_grant", "The user name or pwd is incorrect.");
                return;
            }

            var oAuthIdentity = await userFound.GenerateUserIdentityAsync(userManager, "JWT");
            var currentClaims = await userManager.GetClaimsAsync(userFound.Id);

            oAuthIdentity.AddClaims(currentClaims);
            var ticket = new AuthenticationTicket(oAuthIdentity, null);
            context.Validated(ticket);

        }
    }
}