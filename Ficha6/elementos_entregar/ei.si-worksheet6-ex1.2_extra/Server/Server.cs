using System;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Collections.Generic;

namespace EI.SI
{
    /// <summary>
    /// Server
    /// Symmetrics (Encryption)
    /// </summary>
    class ServerWithProtocolSI
    {
        public static string SEPARATOR = "...";

        /// <summary>
        /// IMPORTANTE: a cada RECE��O deve seguir-se, obrigat�riamente, um ENVIO de dados
        /// IMPORTANT: each network .Read must be fallowed by a network .Write
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            byte[] msg;
            IPEndPoint listenEndPoint;
            TcpListener server = null;
            TcpClient client = null;
            NetworkStream netStream = null;
            ProtocolSI protocol = null;
            AesCryptoServiceProvider aes = null;
            SymmetricsSI symmetricsSI = null;
            RSACryptoServiceProvider rsaClient = null;
            RSACryptoServiceProvider rsaServer = null;
            SHA256CryptoServiceProvider hashAlgorithm = null;
            Dictionary<int, double> accounts = null;

            try
            {
                Console.WriteLine("SERVER");

                #region Definitions

                // algoritmos assim�tricos
                rsaClient = new RSACryptoServiceProvider();
                rsaServer = new RSACryptoServiceProvider();

                // algoritmos sim�trico a usar...
                aes = new AesCryptoServiceProvider();
                symmetricsSI = new SymmetricsSI(aes);

                // Binding IP/port
                listenEndPoint = new IPEndPoint(IPAddress.Any, 13000);
                
                // Client/Server Protocol to SI
                protocol = new ProtocolSI();

                hashAlgorithm = new SHA256CryptoServiceProvider();

                accounts = new Dictionary<int, double>();

                accounts.Add(123, 100.50);
                accounts.Add(456, 200.50);
                accounts.Add(789, 3000);

                #endregion

                Console.WriteLine(SEPARATOR);
                 
                #region TCP Listener
                // Start TcpListener
                server = new TcpListener(listenEndPoint);
                server.Start();

                // Waits for a client connection (bloqueant wait)
                Console.Write("waiting for a connection... ");
                client = server.AcceptTcpClient();
                netStream = client.GetStream();
                Console.WriteLine("ok");
                #endregion

                Console.WriteLine(SEPARATOR);

                #region Exchange Public Keys
                // Receive client public key
                Console.Write("waiting for client public key...");
                netStream.Read(protocol.Buffer, 0, protocol.Buffer.Length);
                rsaClient.FromXmlString(protocol.GetStringFromData());
                Console.WriteLine("ok");

                // Send public key...
                Console.Write("Sending public key... ");
                msg = protocol.Make(ProtocolSICmdType.PUBLIC_KEY, rsaServer.ToXmlString(false));
                netStream.Write(msg, 0, msg.Length);
                Console.WriteLine("ok");
                #endregion

                Console.WriteLine(SEPARATOR);

                #region Exchange Secret Key               
                // Receive key
                Console.Write("waiting for key...");
                netStream.Read(protocol.Buffer, 0, protocol.Buffer.Length);
                aes.Key = rsaServer.Decrypt(protocol.GetData(), true);
                Console.WriteLine("ok");
                Console.WriteLine("   Received: {0} ", ProtocolSI.ToHexString(aes.Key));

                // Answer with a ACK
                Console.Write("Sending a ACK... ");
                msg = protocol.Make(ProtocolSICmdType.ACK);
                netStream.Write(msg, 0, msg.Length);
                Console.WriteLine("ok");


                // Receive iv
                Console.Write("waiting for iv...");
                netStream.Read(protocol.Buffer, 0, protocol.Buffer.Length);
                aes.IV = rsaServer.Decrypt(protocol.GetData(), true);
                Console.WriteLine("ok");
                Console.WriteLine("   Received: {0} ", ProtocolSI.ToHexString(aes.IV));

                // Answer with a ACK
                Console.Write("Sending a ACK... ");
                msg = protocol.Make(ProtocolSICmdType.ACK);
                netStream.Write(msg, 0, msg.Length);
                Console.WriteLine("ok");
                #endregion

                Console.WriteLine(SEPARATOR);

                #region Exchange Data (Secure channel)                
                

                #endregion

                #region Exchange Digital Signature      
                // Receive the cipher
                Console.Write("waiting for data...");
                netStream.Read(protocol.Buffer, 0, protocol.Buffer.Length);
                byte[] signature = protocol.GetData();
                Console.WriteLine("ok");
                Console.WriteLine("   Signature: {0}", ProtocolSI.ToHexString(signature));
                Console.WriteLine("ok");
                byte[] hash = hashAlgorithm.ComputeHash(encryptedData);
                if(rsaClient.VerifyHash(hash, CryptoConfig.MapNameToOID("SHA256",
                signature))) 
                {

                }

                /*if(rsaClient.VerifyData(encryptedData, hashAlgorithm, signature))
                {
                    Console.WriteLine("Signature Valid");
                    msg = protocol.Make(ProtocolSICmdType.ACK);
                }
                else 
                {
                    Console.WriteLine("Signature Invalid");
                    msg = protocol.Make(ProtocolSICmdType.NACK);

                }*/

                #endregion
            }
            catch (Exception ex)
            {
                Console.WriteLine(SEPARATOR);
                Console.WriteLine("Exception: {0}", ex.ToString());
            }
            finally
            {
                // Close connections
                if (netStream != null)
                    netStream.Dispose();
                if (client != null)
                    client.Close();
                if (server != null)
                    server.Stop();
                Console.WriteLine(SEPARATOR);
                Console.WriteLine("Connection with client was closed.");
            }

            Console.WriteLine(SEPARATOR);
            Console.Write("End: Press a key...");
            Console.ReadKey();
        }

    }
}
