using ContosoO365DocSync.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContosoO365DocSync.Service
{
    public interface ISourceService
    {
        Task<SourcePoint> AddSourcePoint(string fileName, string documentId, SourcePoint sourcePoint);
        Task<SourcePoint> EditSourcePoint(SourcePoint sourcePoint);
        Task<SourceCatalog> GetSourceCatalog(string fileName, string documentId);
        Task<SourceCatalog> GetSourceCatalog(string documentId);
        Task<int> DeleteSourcePoint(Guid sourcePointId);
        Task DeleteSelectedSourcePoint(IEnumerable<Guid> selectedSourcePointIds);

        Task<PublishSourcePointResult> PublishSourcePointList(IEnumerable<PublishSourcePointForm> publishSourcePointForms);
        Task<PublishedHistory> GetPublishHistoryById(Guid publishHistoryId);

        Task<IEnumerable<DocumentCheckResult>> GetAllCatalogs();
        Task<IEnumerable<DocumentCheckResult>> UpdateDocumentUrlById(IEnumerable<DocumentCheckResult> documents);

        Task<IEnumerable<CloneForm>> CheckCloneFileStatus(IEnumerable<CloneForm> files);

        Task CloneFiles(IEnumerable<CloneForm> files);
    }
}
