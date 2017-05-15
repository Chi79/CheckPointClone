
using CheckPoint.API.App_Start;
using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IdentityServer3.AccessTokenValidation;
using CheckPoint.Constants;

[assembly: OwinStartup(typeof(CheckPoint.API.Startup))]

namespace CheckPoint.API
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            //app.UseIdentityServerBearerTokenAuthentication(
            //    new IdentityServerBearerTokenAuthenticationOptions
            //    {
            //        Authority = CheckPointConstants.IdSrv,
            //        RequiredScopes = new[] { "checkpointapi" }
            //    });


            app.UseWebApi(WebApiConfig.Register());

        }
    }
}