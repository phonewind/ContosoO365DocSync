using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContosoO365DocSync.Service
{
    public class EncryptionService : IEncryptService
    {
        private AES _decrypt;
        public EncryptionService()
        {
            _decrypt = new AES();
        }

        public string DecryptString(string cipherText)
        {
            return _decrypt.Decrypt(cipherText);
        }

        public string EncryptString(string plainText)
        {
            return _decrypt.Encrypt(plainText);
        }
    }
}
