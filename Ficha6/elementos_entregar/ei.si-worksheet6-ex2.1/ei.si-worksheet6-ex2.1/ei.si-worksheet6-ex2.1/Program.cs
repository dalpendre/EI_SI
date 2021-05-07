using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ei.si_worksheet6_ex2._1
{
	class Program
	{
		static void Main(string[] args)
		{
			const int num_public_keys = 5;
			const int max_signature_size = 128;

			String filecontent = File.ReadAllText("C:/Users/Diogo Alpendre/OneDrive - IPLeiria" +
			"/Para arrumar/Documentos/GitHub/EI_seguranca_informacao/Ficha6/elementos_entregar" +
			"/ei.si-worksheet6-ex2.1/dados.txt");

			String formatted_path = string.Empty;
			String bothKeys = File.ReadAllText("C:/Users/Diogo Alpendre/OneDrive - IPLeiria" +
			"/Para arrumar/Documentos/GitHub/EI_seguranca_informacao/Ficha6/elementos_entregar" +
			"/ei.si-worksheet6-ex2.1/privada_publica.txt");

			String publicKey = string.Empty;
			String[] publicKeys = new string[num_public_keys];

			//1 - Author of the digital signature
			using(SHA256CryptoServiceProvider hashAlgorithm = new SHA256CryptoServiceProvider())
			{
				byte[] dataToSign = Encoding.UTF8.GetBytes(filecontent);
				byte[] signature = new byte[max_signature_size];
				byte[] signedData = null;

				using(FileStream signature_stream = new FileStream("C:/Users/Diogo Alpendre/OneDrive - IPLeiria" +
				"/Para arrumar/Documentos/GitHub/EI_seguranca_informacao/Ficha6/elementos_entregar" +
				"/ei.si-worksheet6-ex2.1/assinatura_e_dados.txt", FileMode.Open, FileAccess.Read))
				{
					signedData = new byte[signature_stream.Length-max_signature_size];
					signature_stream.Read(signature, 0, max_signature_size);
					signature_stream.Read(signedData, 0, signedData.Length);
				}

				using (RSACryptoServiceProvider assymAlgorithm = new RSACryptoServiceProvider())
				{
					//Read public keys
					for (int i = 1; i <= num_public_keys; i++)
					{
						//Add variable i to iterate public key files
						formatted_path = Path.Combine("C:/Users/Diogo Alpendre/OneDrive - IPLeiria" +
						"/Para arrumar/Documentos/GitHub/EI_seguranca_informacao/Ficha6/elementos_entregar" +
						"/ei.si-worksheet6-ex2.1/publica_" + i.ToString() + ".txt");

						publicKeys[i - 1] = File.ReadAllText(formatted_path);

						publicKey = publicKeys[i - 1];  //Public key used 
						assymAlgorithm.FromXmlString(publicKey);

						if (assymAlgorithm.VerifyData(signedData, hashAlgorithm, signature))
						{
							Console.WriteLine("VALID signature (Public key {0})", i);
							Console.WriteLine("Public key {0}", publicKeys[i - 1]);
							Console.WriteLine("Author of the digital signature: OID -> {0}", CryptoConfig.MapNameToOID("SHA256"));
						}
						else
						{
							Console.WriteLine("INVALID signature (Public key {0})", i);
						}
					}
				}
			}

			Console.ReadKey();
		}
	}
}