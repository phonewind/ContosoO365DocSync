using ContosoO365DocSync.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContosoO365DocSync.Service
{
    public interface IDocumentService
    {
        Task<DocumentUpdateResult> UpdateBookmrkValue(string documentId, IEnumerable<DestinationPoint> destinationPoints, string value);
        Task<DocumentCheckResult> GetDocumentUrlByID(DocumentCheckResult result);
    }
}
