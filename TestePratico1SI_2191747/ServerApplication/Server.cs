using EI.SI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace ServerApplication
{
    class Server
    {
        static void Main(string[] args)
        {
            IPEndPoint listenEndPoint;
            TcpListener listener = null;
            TcpClient client = null;
            NetworkStream networkStream = null;
            ProtocolSI protocol = null;
            RSACryptoServiceProvider rsaClient = null;
            RSACryptoServiceProvider rsaServer = null;
            AesCryptoServiceProvider aes = null;
            SymmetricsSI symmetricsSI = null;
            SHA256CryptoServiceProvider sha256 = null;
            Dictionary<string, string> domains = null; 
                        
            try
            {

                Console.WriteLine($"** SERVER: Practical Exam on {DateTime.Today.ToLongDateString()} **");

                // DNS Management Set Up
                domains = new Dictionary<string, string>();
                domains.Add("ipleiria.pt", "192.168.1.1");
                domains.Add("ead.ipleiria.pt", "192.168.1.2");
                domains.Add("estudantes.ipleiria.pt", "192.168.1.3");

                listenEndPoint = new IPEndPoint(IPAddress.Any, 10000);
                listener = new TcpListener(listenEndPoint);

                Console.Write("Waiting for client... ");
                listener.Start();
                client = listener.AcceptTcpClient();
                networkStream = client.GetStream();
                Console.WriteLine("OK.");

                protocol = new ProtocolSI();
                byte[] ack = protocol.Make(ProtocolSICmdType.ACK);

                rsaServer = new RSACryptoServiceProvider();
                rsaClient = new RSACryptoServiceProvider();
                aes = new AesCryptoServiceProvider();

                Console.Write("Reading Public Key... ");
                networkStream.Read(protocol.Buffer, 0, protocol.Buffer.Length);
                Console.WriteLine("OK.");
                String clientPublicKey = protocol.GetStringFromData();
                byte[] packet = protocol.Make(ProtocolSICmdType.PUBLIC_KEY, rsaServer.ToXmlString(false));
                Console.WriteLine("Sending Public Key... OK.");
                networkStream.Write(packet, 0, packet.Length);


                Console.Write("Reading Secret Key... ");
                networkStream.Read(protocol.Buffer, 0, protocol.Buffer.Length);
                byte[] encryptedSymKey = protocol.GetData();
                aes.Key = rsaServer.Decrypt(encryptedSymKey, true);
                Console.WriteLine("OK.");
                networkStream.Write(ack, 0, ack.Length);

                Console.Write("Reading IV...");
                networkStream.Read(protocol.Buffer, 0, protocol.Buffer.Length);
                aes.IV = protocol.GetData();
                Console.WriteLine("OK.");
                networkStream.Write(ack, 0, ack.Length);


                symmetricsSI = new SymmetricsSI(aes);
                Console.Write("Reading Domain Request... ");
                networkStream.Read(protocol.Buffer, 0, protocol.Buffer.Length);
                Console.WriteLine("OK.");
                byte[] data = symmetricsSI.Decrypt(protocol.GetData());
                string domain = Encoding.UTF8.GetString(data);

                string ip = domains[domain];
                byte[] ipBytes = Encoding.UTF8.GetBytes(ip);
                packet = protocol.Make(ProtocolSICmdType.DATA, ipBytes);
                Console.WriteLine("Sending IP Address ... OK.");
                networkStream.Write(packet, 0, packet.Length);


                Console.Write("Reading Signature Request... ");
                networkStream.Read(protocol.Buffer, 0, protocol.Buffer.Length);
                if(protocol.GetCmdType() == ProtocolSICmdType.USER_OPTION_1)
                {
                    byte[] encryptedData = symmetricsSI.Encrypt(protocol.GetData());

                    byte[] signature = rsaClient.SignData(encryptedData, sha256); // TODO: CREATE SIGNATURE
                    packet = protocol.Make(ProtocolSICmdType.DIGITAL_SIGNATURE, signature);

                    Console.WriteLine("Sending Signature... OK.");
                    Console.WriteLine("   Signature: {0}", ProtocolSI.ToHexString(signature));
                    
                }
                else
                {
                    Console.WriteLine("Request Invalid - Sending NACK");
                    packet = protocol.Make(ProtocolSICmdType.NACK);
                }
                networkStream.Write(packet, 0, packet.Length);


            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.ToString()}");
            }
            finally
            {
                if (sha256 != null)
                    sha256.Dispose();
                if (aes != null)
                    aes.Dispose();
                if (rsaClient != null)
                    rsaClient.Dispose();
                if (rsaServer != null)
                    rsaServer.Dispose();
                if (networkStream != null)
                    networkStream.Dispose();
                if (client != null)
                    client.Close();
                if (listener != null)
                    listener.Stop();
                Console.WriteLine("CLIENT should verify the digital signature.");
            }

            Console.Write("End: Press a key...");
            Console.ReadKey();
        } // main
    } // class
} // namespace

