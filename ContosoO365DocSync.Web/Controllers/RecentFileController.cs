using AutoMapper;
using ContosoO365DocSync.Entity;
using ContosoO365DocSync.Service;
using ContosoO365DocSync.Web.ViewModel;
using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace ContosoO365DocSync.Web.Controllers
{
    public class RecentFileController : ApiController
    {
        protected readonly IRecentFileService _recentFileService;
        protected readonly IMapper _mapper;
        public RecentFileController(IRecentFileService recentFileService, IMapper mapper)
        {
            _recentFileService = recentFileService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("api/RecentFiles")]
        public async Task<IHttpActionResult> GetRecentFiles()
        {
            var retValue = await _recentFileService.GetRecentFiles();
            return Ok(retValue);
        }

        [HttpPost]
        [Route("api/RecentFile")]
        public async Task<IHttpActionResult> Post([FromBody]CatalogViewModel catalogAdded)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid posted data.");
            }

            try
            {
                var catalogName = HttpUtility.UrlDecode(catalogAdded.Name);
                var documentId = HttpUtility.UrlDecode(catalogAdded.DocumentId);
                return Ok(await _recentFileService.AddRecentFile(new SourceCatalog() { Name = catalogName, DocumentId = documentId }));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}