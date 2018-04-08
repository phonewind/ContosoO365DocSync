using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Web;
using Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;
using Microsoft.Azure;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System.IdentityModel.Claims;
using System.Threading.Tasks;
using ContosoO365DocSync.Web.Common;

namespace ContosoO365DocSync.Web
{
    public partial class Startup
    {
        private static string clientId = CloudConfigurationManager.GetSetting("ida:ClientId");
        private static string aadInstance = CloudConfigurationManager.GetSetting("ida:AADInstance");
        private static string tenantId = CloudConfigurationManager.GetSetting("ida:TenantId");
        private static string postLogoutRedirectUri = CloudConfigurationManager.GetSetting("ida:PostLogoutRedirectUri");
        private static string appKey = CloudConfigurationManager.GetSetting("ida:ClientSecret");
        private static string resourceId = CloudConfigurationManager.GetSetting("ResourceId");
        private static string sharePointUrl = CloudConfigurationManager.GetSetting("SharePointUrl");
        private static string authority = aadInstance + tenantId;

        public void ConfigureAuth(IAppBuilder app)
        {
            app.SetDefaultSignInAsAuthenticationType(CookieAuthenticationDefaults.AuthenticationType);

            app.UseCookieAuthentication(new CookieAuthenticationOptions());

            app.UseOpenIdConnectAuthentication(
                new OpenIdConnectAuthenticationOptions
                {
                    ClientId = clientId,
                    Authority = authority,
                    RedirectUri = postLogoutRedirectUri,
                    PostLogoutRedirectUri = postLogoutRedirectUri
                    ,
                    Notifications = new OpenIdConnectAuthenticationNotifications()
                    {
                        AuthorizationCodeReceived = (context) =>
                        {
                            var code = context.Code;
                            var redirectUrl = new Uri(HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Path));
                            var consentRedirectUrl = new Uri(HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) + "/Admin/Result");
                            ClientCredential credential = new ClientCredential(clientId, appKey);
                            AuthenticationContext authContext = new AuthenticationContext(authority);

                            string userObjectID = context.AuthenticationTicket.Identity.FindFirst("http://schemas.microsoft.com/identity/claims/objectidentifier").Value;
                            UserIdentifier userIdentifier = new UserIdentifier(userObjectID, UserIdentifierType.UniqueId);
                            AuthenticationHelper.consentUrl = authContext.GetAuthorizationRequestUrlAsync(sharePointUrl, clientId, consentRedirectUrl, userIdentifier, "prompt=admin_consent").Result.ToString();

                            AuthenticationResult result = authContext.AcquireTokenByAuthorizationCodeAsync(code, redirectUrl, credential, resourceId).Result;
                            AuthenticationHelper.token = result.AccessToken;

                            AuthenticationResult spResult = authContext.AcquireTokenByAuthorizationCodeAsync(code, redirectUrl, credential, sharePointUrl).Result;
                            AuthenticationHelper.sharePointToken = spResult.AccessToken;

                            return Task.FromResult(0);
                        }
                    }
                });


        }
    }
}