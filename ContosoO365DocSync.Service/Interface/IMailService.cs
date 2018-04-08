using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContosoO365DocSync.Service
{
    public interface IMailService
    {
        Task SendPlanTextMail(string fromAddress, string fromDisplayName, IEnumerable<string> toAddresses, string subject, string content);
    }
}
