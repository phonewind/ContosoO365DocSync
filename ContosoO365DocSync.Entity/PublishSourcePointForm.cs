using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContosoO365DocSync.Entity
{
    public class PublishSourcePointForm
    {
        public Guid SourcePointId { get; set; }
        public string CurrentValue { get; set; }
        public string Position { get; set; }
        public string Name { get; set; }
        public string NamePosition { get; set; }
    }
}