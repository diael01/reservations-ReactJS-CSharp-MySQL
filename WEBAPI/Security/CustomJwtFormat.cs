
using System;
using System.IdentityModel.Tokens;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Thinktecture.IdentityModel.Tokens;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataHandler.Encoder;
using Microsoft.Owin;
using WEBAPI.Infrastructure;

namespace WEBAPI.Security
{
    public class CustomJwtFormat : ISecureDataFormat<AuthenticationTicket>
    {
        //private readonly IEnumerable<Reservation.Contract.Claim> _claims;
        //private readonly IClaimsService _claimsService;
        private readonly string _issuer = string.Empty;
        //private readonly IEnumerable<RoleClaim> _roleClaims;
        //private readonly IRoleClaims _roleClaimsService;

        //public CustomJwtFormat(string issuer, IClaimsService claimsService, IRoleClaims rcService)
        //{
        //    _issuer = issuer;
        //    _claimsService = claimsService;
        //    _roleClaimsService = rcService;
        //    _roleClaims = _roleClaimsService.GetRoleClaims();
        //    _claims = _claimsService.GetClaims();

        //}

        public CustomJwtFormat(string issuer)
        {
            _issuer = issuer;
            //_claimsService = claimsService;
            //_roleClaimsService = rcService;
            //_roleClaims = _roleClaimsService.GetRoleClaims();
            //_claims = _claimsService.GetClaims();

        }



        public string Protect(AuthenticationTicket data)
        {
            if (data == null)
            {
                throw new ArgumentNullException("data");
            }

            var audienceId = ConfigurationManager.AppSettings["as:AudienceId"];

            string symmetricKeyAsBase64 = ConfigurationManager.AppSettings["as:AudienceSecret"];

            var keyByteArray = TextEncodings.Base64Url.Decode(symmetricKeyAsBase64);

            var signingKey = new HmacSigningCredentials(keyByteArray);

            var issued = data.Properties.IssuedUtc;
            var expires = data.Properties.ExpiresUtc;

            //var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
            //if(HttpContext.Current != null)
            //{
            //    var app = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            //    var user = app.FindByName(data.Identity.Name);
            //    foreach(var role in roleManager.Roles)
            //    {
            //        if(user.Roles.Any(r=>r.RoleId.Equals(role.Id)))
            //        {
            //            var rClaims = _roleClaims.Where(r => r.RoleId.Equals(role.Id)).ToList();
            //            foreach(var rClaim in rClaims)
            //            {
            //                var claim = _claims.FirstOrDefault(c=>c.Id == rClaim.ClaimId);
            //                var securityClaim =
            //                    new System.Security.Claims.Claim("userClaimsPerRole", claim.ClaimValue);
            //                data.Identity.AddClaim(securityClaim);
            //             }
            //        }
            //    }
            //}


            var token = new JwtSecurityToken(_issuer, audienceId, data.Identity.Claims, 
                issued.Value.UtcDateTime, expires.Value.UtcDateTime, signingKey);

            var handler = new JwtSecurityTokenHandler();

            var jwt = handler.WriteToken(token);

            return jwt;
        }

        public AuthenticationTicket Unprotect(string protectedText)
        {
            throw new NotImplementedException();
        }
    }
}