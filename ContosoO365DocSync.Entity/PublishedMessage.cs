using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContosoO365DocSync.Entity
{
    public class PublishedMessage
    {
        public Guid PublishBatchId { get; set; }
        public Guid PublishHistoryId { get; set; }
        public Guid SourcePointId { get; set; }
    }
}
