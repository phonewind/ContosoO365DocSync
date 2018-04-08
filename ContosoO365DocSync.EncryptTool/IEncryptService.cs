using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContosoO365DocSync.EncryptTool
{
    public interface IEncryptService
    {
        string EncryptString(string planText);
        string DecryptString(string cipherText);
    }
}
