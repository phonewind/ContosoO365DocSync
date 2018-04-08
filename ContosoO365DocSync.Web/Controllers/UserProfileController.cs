using AutoMapper;
using ContosoO365DocSync.Entity;
using ContosoO365DocSync.Service;
using ContosoO365DocSync.Web.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Security.Principal;
using System.Security.Claims;
using System.Web;
using Newtonsoft.Json;

namespace ContosoO365DocSync.Web.Controllers
{
    [APIAuthorize]
    public class UserProfileController : ApiController
    {
        protected readonly IUserProfileService _userProfileService;
        public UserProfileController(IUserProfileService userProfileService)
        {
            _userProfileService = userProfileService;
        }

        [HttpGet]
        [Route("api/UserProfile")]
        public IHttpActionResult GetUserProfile()
        {
            var retValue = _userProfileService.GetCurrentUser();
            return Ok(retValue);
        }
    }
}