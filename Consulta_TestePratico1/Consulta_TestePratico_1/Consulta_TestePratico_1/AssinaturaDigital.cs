using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Consulta_TestePratico_1
{
    class AssinaturaDigital
    {
        static void Main(string[] args)
        {
            RSACryptoServiceProvider assymAlgorithm = new RSACryptoServiceProvider();
            SHA256CryptoServiceProvider hashAlgorithm = new SHA256CryptoServiceProvider();

            assymAlgorithm.ToXmlString(false);
            assymAlgorithm.ToXmlString(true);

            byte[] dataToSign = Encoding.UTF8.GetBytes("mensagem para assinar");
            byte[] hash = hashAlgorithm.ComputeHash(dataToSign);

            //Assinar hash
            byte[] hash_signature = assymAlgorithm.SignHash(hash, CryptoConfig.MapNameToOID("SHA256"));

            //Assinar dados
            byte[] data_signature = assymAlgorithm.SignData(dataToSign, hashAlgorithm);

            //Escrever assinatura (hash ou dados)
            Convert.ToBase64String(hash_signature);
        }
    }
}
