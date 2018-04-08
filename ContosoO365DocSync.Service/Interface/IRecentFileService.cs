using ContosoO365DocSync.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContosoO365DocSync.Service
{
    public interface IRecentFileService
    {
        Task<IEnumerable<SourceCatalog>> GetRecentFiles();
        Task<IEnumerable<SourceCatalog>> AddRecentFile(SourceCatalog sourceCatalog);
    }
}
