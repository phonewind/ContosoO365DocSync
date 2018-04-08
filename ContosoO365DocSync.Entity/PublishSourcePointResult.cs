using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContosoO365DocSync.Entity
{
    public class PublishSourcePointResult
    {
        public Guid BatchId { get; set; }
        public ICollection<SourcePoint> SourcePoints { get; set; }
    }
}
