using System;
using System.Text;
using EI.SI;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;

namespace Client
{
    /// <summary>
    /// Client
    /// </summary>
    class Client
    {
        public static string SEPARATOR = "...";

        /// <summary>
        /// IMPORTANTE: a cada RECEÇÃO deve seguir-se, obrigatóriamente, um ENVIO de dados
        /// IMPORTANT: each network .Read() must be fallowed by a network .Write()
        /// </summary>
        static void Main(string[] args)
        {
            byte[] msg;
            IPEndPoint serverEndPoint;
            TcpClient client = null;
            NetworkStream netStream = null;
            ProtocolSI protocol = null;
            TripleDESCryptoServiceProvider tripleDES = null;
            SymmetricsSI symmetricsSI = null;

            try
            {
                Console.WriteLine("CLIENT");

                #region Definitions
                // Client/Server Protocol to SI
                protocol = new ProtocolSI();

                // Defenitions for TcpClient: IP:port (127.0.0.1:9999)
                serverEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9999);

                // algoritmo simétrico a usar
                tripleDES = new TripleDESCryptoServiceProvider();
                symmetricsSI = new SymmetricsSI(tripleDES);
                #endregion

                Console.WriteLine(SEPARATOR);

                #region TCP Connection
                // Connects to Server ...
                Console.Write("Connecting to server... ");
                client = new TcpClient();
                client.Connect(serverEndPoint);
                netStream = client.GetStream();
                Console.WriteLine("ok.");
                #endregion

                Console.WriteLine(SEPARATOR);

                #region Exchange Secret Key
                // Send key...
                Console.Write("Sending key... ");
                msg = protocol.Make(ProtocolSICmdType.SECRET_KEY, tripleDES.Key);
                netStream.Write(msg, 0, msg.Length);
                Console.WriteLine("ok.");
                Console.WriteLine("Key: " + ProtocolSI.ToHexString(tripleDES.Key));

                // Receive ack from server
                Console.Write("waiting for ACK... ");
                netStream.Read(protocol.Buffer, 0, protocol.Buffer.Length);
                Console.WriteLine("ok.");

                // Send iv...
                Console.Write("Sending iv... ");
                msg = protocol.Make(ProtocolSICmdType.IV, tripleDES.IV);
                netStream.Write(msg, 0, msg.Length);
                Console.WriteLine("ok.");
                Console.WriteLine("IV: " + ProtocolSI.ToHexString(tripleDES.IV));

                // Receive ack from server
                Console.Write("waiting for ACK... ");
                netStream.Read(protocol.Buffer, 0, protocol.Buffer.Length);
                Console.WriteLine("ok.");
                #endregion

                Console.WriteLine(SEPARATOR);

                #region Exchange Data  (Secure channel)
                // Send data...
                byte[] clearData = Encoding.UTF8.GetBytes("hello world!!!");
                byte[] encryptedData = symmetricsSI.Encrypt(clearData);
                Console.Write("Sending  data... ");
                msg = protocol.Make(ProtocolSICmdType.DATA, encryptedData);
                netStream.Write(msg, 0, msg.Length);
                Console.WriteLine("ok.");
                Console.WriteLine("Data to encrypt.... (STR): {0}", ProtocolSI.ToString(clearData));
                Console.WriteLine("Data to encrypt.... (HEX): {0}", ProtocolSI.ToHexString(clearData));
                Console.WriteLine("Encrypted data sent (HEX): {0}", ProtocolSI.ToHexString(encryptedData));

                // Receive answer from server
                Console.Write("waiting for ACK... ");
                netStream.Read(protocol.Buffer, 0, protocol.Buffer.Length);
                Console.WriteLine("ok.");
                #endregion

            }
            catch (Exception ex)
            {
                Console.WriteLine(SEPARATOR);
                Console.WriteLine("Exception: {0}", ex.ToString());
            }
            finally
            {
                if (tripleDES != null)
                    tripleDES.Dispose();
                // Close connections
                if (netStream != null)
                    netStream.Dispose();
                if (client != null)
                    client.Close();
                Console.WriteLine(SEPARATOR);
                Console.WriteLine("Connection with server was closed.");
            }

            Console.WriteLine(SEPARATOR);
            Console.Write("End: Press a key...");
            Console.ReadKey();
        }
    }
}
