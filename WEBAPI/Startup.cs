using System;
using System.Configuration;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
//using Microsoft.Owin;
using Castle.Windsor;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataHandler.Encoder;
using Microsoft.Owin.Security.Jwt;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using Owin;
using WEBAPI.Infrastructure;
using WEBAPI.Security;
using WEBAPI.IoC;


[assembly: OwinStartup(typeof(WEBAPI.Startup))]

namespace WEBAPI
{
    public partial class Startup
    {
        private IWindsorContainer _container;
        public static OAuthBearerAuthenticationOptions OAuthBearerOptions { get; private set; }

        public void Configuration(IAppBuilder app)
        {
            var httpConfig = new HttpConfiguration();
            _container = ApiComponentRegistration.Register(httpConfig);
            //ConfigureOAuthTokenGeneration(app);
            //ConfigureOAuthTokenConsumption(app);
            ConfigureWebApi(httpConfig);
            app.UseCors(CorsOptions.AllowAll);
            app.UseWebApi(httpConfig);
        }

        public void ConfigureOAuthTokenGeneration(IAppBuilder app)
        {
            OAuthBearerOptions = new OAuthBearerAuthenticationOptions();
            app.CreatePerOwinContext(ApplicationDbContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            app.CreatePerOwinContext<ApplicationRoleManager>(ApplicationRoleManager.Create);

            //var claimsService = _container.Resolve<IClaimsService>();
            //var roleClaimsService = _container.Resolve<IRoleClaimsService>();

            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                //For Dev enviroment only (on production should be AllowInsecureHttp = false)
                AllowInsecureHttp = true,//get it from web.config
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(30),//take it from web.config
                Provider = new CustomOAuthProvider(),
                AccessTokenFormat = new CustomJwtFormat(ConfigurationManager.AppSettings["issuer"])
                    //claimsService, roleClaimsService)
            };

            // OAuth 2.0 Bearer Access Token Generation
            app.UseOAuthAuthorizationServer(OAuthServerOptions);
            app.UseOAuthBearerAuthentication(OAuthBearerOptions);

        }

        private void ConfigureOAuthTokenConsumption(IAppBuilder app)
        {
            var issuer = ConfigurationManager.AppSettings["issuer"];
            var audienceId = ConfigurationManager.AppSettings["as:AudienceId"];
            var audienceSecret = ConfigurationManager.AppSettings["as:AudienceSecret"];

            //app.UseJwtBearerAuthentication(
            //    new JwtBearerAuthenticationOptions
            //    {
            //        AuthenticationMode = AuthenticationMode.Active,
            //        AllowedAudiences = new[] {audienceId},
            //        IssuerSecurityTokenProviders = new IIssuerSecurityTokenProvider[]
            //        {
            //            new SymmetricKeyIssuerSecurityTokenProvider(issuer,audienceSecret)
            //        }
            //    });
        }

        private void ConfigureWebApi(HttpConfiguration config)
        {
            //config.Services.Add(typeof(IExceptionLogger), new ReservationsExceptionLogger());
            //XmlConfigurator.Configure();

            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{action}/{par1}/{par2}", new { par1 = RouteParameter.Optional, par2 = RouteParameter.Optional });
            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

        }
    }
}
