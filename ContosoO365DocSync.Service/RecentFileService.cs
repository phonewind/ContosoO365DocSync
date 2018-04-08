using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Threading.Tasks;
using AutoMapper;
using ContosoO365DocSync.Entity;

namespace ContosoO365DocSync.Service
{
    public class RecentFileService : IRecentFileService
    {
        protected readonly ContosoO365DocSyncDbContext _dbContext;
        protected readonly IMapper _mapper;
        protected readonly IAzureStorageService _azureStorageService;
        protected readonly ILogService _logService;
        protected readonly IUserProfileService _userProfileService;

        public RecentFileService(ContosoO365DocSyncDbContext dbContext, IMapper mapper, IAzureStorageService azureStorageService, ILogService logService, IUserProfileService userProfileService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _azureStorageService = azureStorageService;
            _logService = logService;
            _userProfileService = userProfileService;
        }

        public async Task<IEnumerable<SourceCatalog>> GetRecentFiles()
        {
            var userName = _userProfileService.GetCurrentUser().Username;
            var allRecentFiles = await _dbContext.RecentFiles.Where(o => o.User.Equals(userName, StringComparison.CurrentCultureIgnoreCase))
                .Include(o => o.Catalog)
                .OrderByDescending(o => o.Date)
                .Select(o => o.Catalog).Where(o => !o.IsDeleted).ToArrayAsync();

            var recentFiles = allRecentFiles.Distinct().Take(5);

            foreach (var catalog in recentFiles)
            {
                catalog.SourcePoints = (await _dbContext.SourcePoints.Where(o => o.Status == SourcePointStatus.Created && o.CatalogId == catalog.Id)
                    .Include(o => o.DestinationPoints).ToArrayAsync())
                    .OrderByDescending(o => o.Name).ToArray();
            }
            return recentFiles;
        }

        public async Task<IEnumerable<SourceCatalog>> AddRecentFile(SourceCatalog sourceCatalog)
        {
            var catalog = await _dbContext.SourceCatalogs.FirstOrDefaultAsync(o => o.DocumentId == sourceCatalog.DocumentId);
            if (catalog == null)
            {
                catalog = new SourceCatalog() { Name = sourceCatalog.Name, DocumentId = sourceCatalog.DocumentId };
                _dbContext.SourceCatalogs.Add(catalog);
            }
            var recentFile = new RecentFile();
            recentFile.User = _userProfileService.GetCurrentUser().Username;
            recentFile.Date = DateTime.Now.ToUniversalTime().ToPSTDateTime();
            recentFile.CatalogId = catalog.Id;
            _dbContext.RecentFiles.Add(recentFile);

            await _dbContext.SaveChangesAsync();

            return await GetRecentFiles();
        }
    }

}
