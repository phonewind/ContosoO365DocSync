using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace ContosoO365DocSync.Web
{
    public class APIAuthorizeAttribute: AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            var response = HttpContext.Current.Response;
            response.SuppressFormsAuthenticationRedirect = true;
            response.StatusCode = 410;
            response.End();
        }
    }
}