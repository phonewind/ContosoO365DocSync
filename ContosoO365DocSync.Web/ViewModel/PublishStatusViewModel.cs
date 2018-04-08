using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContosoO365DocSync.Web.ViewModel
{
    public class PublishStatusViewModel
    {
        public string Status { get; set; }
        public PublishItemViewModel[] SourcePoints { get; set; }
    }

    public class PublishItemViewModel
    {
        public string Id { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
    }
}