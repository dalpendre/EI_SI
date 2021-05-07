using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Consulta_TestePratico_1
{
    class Hash
    {
        static void Main(string[] args)
        {
            SHA256CryptoServiceProvider hashAlgorithm = new SHA256CryptoServiceProvider();

            byte[] dataToHash = Encoding.UTF8.GetBytes("data to hash");

            byte[] hash = hashAlgorithm.ComputeHash(dataToHash);

            //Mostrar a hash
            Convert.ToBase64String(hash);
        }
    }
}
