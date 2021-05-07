using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Consulta_TestePratico_1
{
    class AlgoritmoAssimétrico
    {
        static void Main(string[] args)
        {
            RSACryptoServiceProvider assymAlgorithm = new RSACryptoServiceProvider();
            assymAlgorithm.ToXmlString(false);  //Chave pública
            assymAlgorithm.ToXmlString(true);   //Chave pública/privada

            //Encriptar chave simétrica
            byte[] plainSecretKey_Encrypt = Encoding.UTF8.GetBytes("exemplo_chave_simétrica");
            byte[] encryptedSecretKey_Encrypt = assymAlgorithm.Encrypt(plainSecretKey_Encrypt, true);

            //Para escrever em textBox (cifrada)
            Convert.ToBase64String(encryptedSecretKey_Encrypt);

            //Desencriptar chave simétrica
            byte[] encryptedSecretKey_Decrypt = Convert.FromBase64String(/*string chave*/);
            byte[] plainSecretKey_Decrypt = assymAlgorithm.Decrypt(encryptedSecretKey_Decrypt, true);

            //Para escrever em textBox (decifrada)
            Encoding.UTF8.GetString(plainSecretKey_Decrypt);
        }
    }
}
