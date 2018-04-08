using AutoMapper;
using ContosoO365DocSync.Entity;
using ContosoO365DocSync.Service;
using ContosoO365DocSync.Web.Common;
using ContosoO365DocSync.Web.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace ContosoO365DocSync.Web.Controllers
{
    [APIAuthorize]
    public class DestinationPointController : ApiController
    {
        protected readonly IDestinationService _destinationService;
        protected readonly IMapper _mapper;
        public DestinationPointController(IDestinationService destinationService, IMapper mapper)
        {
            _destinationService = destinationService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("api/DestinationPoint")]
        public async Task<IHttpActionResult> Post([FromBody]DestinationPointForm destinationPointAdded)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid posted data.");
            }

            try
            {
                var destinationPoint = _mapper.Map<DestinationPoint>(destinationPointAdded);
                var catalogName = HttpUtility.UrlDecode(destinationPointAdded.CatalogName);
                var documentId = HttpUtility.UrlDecode(destinationPointAdded.DocumentId);
                return Ok(await _destinationService.AddDestinationPoint(catalogName, documentId, destinationPoint));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("api/DestinationPoint")]
        public async Task<IHttpActionResult> DeleteSourcePoint(string id)
        {
            await _destinationService.DeleteDestinationPoint(Guid.Parse(id));
            return Ok();
        }

        [HttpPost]
        [Route("api/DeleteSelectedDestinationPoint")]
        public async Task<IHttpActionResult> DeleteSelectedDestinationPoint([FromBody]IEnumerable<Guid> seletedIds)
        {
            await _destinationService.DeleteSelectedDestinationPoint(seletedIds);
            return Ok();
        }

        [HttpGet]
        [Route("api/DestinationPointCatalog")]
        public async Task<IHttpActionResult> GetDestinationPointCatalog(string fileName, string documentId)
        {
            var retValue = await _destinationService.GetDestinationCatalog(HttpUtility.UrlDecode(fileName), HttpUtility.UrlDecode(documentId));
            return Ok(retValue);
        }

        [HttpGet]
        [Route("api/DestinationPoint")]
        public async Task<IHttpActionResult> GetDestinationPointBySourcePoint(string sourcePointId)
        {
            var retValue = await _destinationService.GetDestinationPointBySourcePoint(Guid.Parse(sourcePointId));
            return Ok(retValue);
        }

        [HttpGet]
        [Route("api/GraphAccessToken")]
        public async Task<IHttpActionResult> GetGraphAccessToken()
        {
            var retValue = await AuthenticationHelper.AcquireTokenAsync();
            return Ok(retValue);
        }

        [HttpGet]
        [Route("api/CustomFormats")]
        public async Task<IHttpActionResult> GetCustomFormats()
        {
            var retValue = await _destinationService.GetCustomFormats();
            return Ok(retValue);
        }

        [HttpPut]
        [Route("api/UpdateDestinationPointCustomFormat")]
        public async Task<IHttpActionResult> UpdateDestinationPointCustomFormat([FromBody]DestinationPointForm destinationPointAdded)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid posted data.");
            }

            try
            {
                var destinationPoint = _mapper.Map<DestinationPoint>(destinationPointAdded);
                return Ok(await _destinationService.UpdateDestinationPointCustomFormat(destinationPoint));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("api/SharePointAccessToken")]
        public async Task<IHttpActionResult> GetSharePointAccessToken()
        {
            var retValue = await AuthenticationHelper.AcquireSharePointTokenAsync();
            return Ok(retValue);
        }
    }
}
