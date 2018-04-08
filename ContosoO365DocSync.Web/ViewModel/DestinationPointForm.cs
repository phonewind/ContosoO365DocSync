using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContosoO365DocSync.Web.ViewModel
{
    public class DestinationPointForm
    {
        public string Id { get; set; }
        public string CatalogName { get; set; }
        public string RangeId { get; set; }
        public string SourcePointId { get; set; }
        public int[] CustomFormatIds { get; set; }
        public int? DecimalPlace { get; set; }
        public string DocumentId { get; set; }
        public int DestinationType { get; set; }
    }
}