using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContosoO365DocSync.Entity
{
    public class DocumentUpdateResult
    {
        public bool IsSuccess { get; set; }
        public List<string> Message { get; set; }
        public DocumentUpdateResult()
        {
            Message = new List<string>();
        }
    }
}
