

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        static void Main(string[] args)
        {
            byte[] msg;
            IPEndPoint serverEndPoint;
            TcpClient client = null;
            NetworkStream netStream = null;
            ProtocolSI protocol = null;
            TripleDESCryptoServiceProvider algorithm = null;
            SymmetricsSI symmetricsSI = null;

            try
            {
                Console.WriteLine("CLIENT");

                #region Definitions
                // Client/Server Protocol to SI
                protocol = new ProtocolSI();

                // Defenitions for TcpClient: IP:port (127.0.0.1:9999)
                serverEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9999);

                //Ao instanciar, gera nova chave e IV
                algorithm = new TripleDESCryptoServiceProvider();

                symmetricsSI = new SymmetricsSI(algorithm);
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

                Console.Write("Sending secret key... ");
                msg = protocol.Make(ProtocolSICmdType.SECRET_KEY, algorithm.Key);
                netStream.Write(msg, 0, msg.Length);
                Console.WriteLine("ok.");
                Console.WriteLine("   Sent: {0}", ProtocolSI.ToHexString(algorithm.Key));

                // Receive answer from server
                Console.Write("waiting for ACK... ");
                netStream.Read(protocol.Buffer, 0, protocol.Buffer.Length);
                Console.WriteLine("ok.");

                #endregion

                #region Exchange IV

                Console.Write("Sending IV... ");
                msg = protocol.Make(ProtocolSICmdType.IV, algorithm.IV);
                netStream.Write(msg, 0, msg.Length);
                Console.WriteLine("ok.");
                Console.WriteLine("   Sent: {0}", ProtocolSI.ToHexString(algorithm.IV));

                // Receive answer from server
                Console.Write("waiting for ACK... ");
                netStream.Read(protocol.Buffer, 0, protocol.Buffer.Length);
                Console.WriteLine("ok.");

                #endregion

                #region Exchange Data (Unsecure channel)
                // Send data...
                string clearData = Console.ReadLine();
                double bitcoin = Double.Parse(clearData);
                byte[] plainBytes = BitConverter.GetBytes(bitcoin);

                byte[] encryptedBytes = symmetricsSI.Encrypt(plainBytes);

                Console.Write("Sending data... ");
                msg = protocol.Make(ProtocolSICmdType.SYM_CIPHER_DATA, encryptedBytes);
                netStream.Write(msg, 0, msg.Length);
                Console.WriteLine("ok.");
                Console.WriteLine("   Sent: {0} = {1}", clearData, ProtocolSI.ToHexString(encryptedBytes));

                // Receive answer from server
                Console.Write("waiting for ACK / NACK ... ");
                netStream.Read(protocol.Buffer, 0, protocol.Buffer.Length);

                if(protocol.GetCmdType() == ProtocolSICmdType.SYM_CIPHER_DATA)
                {
                    byte[] encryptedBytes = protocol.GetData();
                    byte[] plainEuros = symmetricsSI.Decrypt(encryptedBytes);
                    Console.WriteLine("Euros: {0}", BitConverter.ToDouble(plainEuros, 0));
                }
                else
                {
                    Console.WriteLine("NOT ok.");
                }
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
                Console.WriteLine(SEPARATOR);
                Console.WriteLine("Connection with server was closed.");
            }

            Console.WriteLine(SEPARATOR);
            Console.Write("End: Press a key...");
            Console.ReadKey();
        }
    }
}
