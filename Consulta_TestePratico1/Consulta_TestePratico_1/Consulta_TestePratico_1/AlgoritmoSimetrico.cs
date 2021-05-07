using EI.SI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Consulta_TestePratico_1
{
    class AlgoritmoSimetrico
    {
        static void Main(string[] args)
        {
            //Usado para cifrar dados

            AesCryptoServiceProvider symmAlgorithm = new AesCryptoServiceProvider();

            //Gerar IV e chave
            symmAlgorithm.GenerateIV();
            symmAlgorithm.GenerateKey();

            //Instanciar symmetricSI
            SymmetricsSI symmetricsSI = new SymmetricsSI(symmAlgorithm);

            //Uso
            symmetricsSI.Encrypt(/*byte array to encrypt*/);
            symmetricsSI.Decrypt(/*byte array to decrypt*/);

            Console.ReadKey();
        }
    }
}
