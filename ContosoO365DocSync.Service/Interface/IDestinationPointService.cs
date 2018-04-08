using ContosoO365DocSync.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContosoO365DocSync.Service
{
    public interface IDestinationService
    {
        Task<DestinationPoint> AddDestinationPoint(string fileName, string documentId, DestinationPoint destinationPoint);
        Task<DestinationCatalog> GetDestinationCatalog(string fileName, string documentId);
        Task<IEnumerable<DestinationPoint>> GetDestinationPointBySourcePoint(Guid sourcePointId);
        Task DeleteDestinationPoint(Guid destinationPointId);
        Task DeleteSelectedDestinationPoint(IEnumerable<Guid> seletedDestinationPointIds);

        Task<IEnumerable<CustomFormat>> GetCustomFormats();
        Task<DestinationPoint> UpdateDestinationPointCustomFormat(DestinationPoint destinationPoint);
    }
}
