using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContosoO365DocSync.Web.ViewModel
{
    public class CatalogViewModel
    {
        public string Name { get; set; }

        public string DocumentId { get; set; }

        public bool IsDeleted { get; set; }
    }
}