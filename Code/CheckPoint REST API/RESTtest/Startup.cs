using Microsoft.Owin;
using Owin;
using System.Collections.Generic;

[assembly: OwinStartup(typeof(RESTtest.Startup))]
namespace RESTtest
{
    class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            app.UseOpenIdConnectAuthentication(new OpenIdConnectAuthenticationOptions
            {
                ClientId = "mvc",
                Authority = ExpenseTrackerConstants.IdSrv,
                //RedirectUri = ExpenseTrackerConstants.ExpenseTrackerClient,
                //SignInAsAuthenticationType = "Cookies",
            }
            }

