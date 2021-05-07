using EI.SI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Exercise3___Client
{
    class Client
    {
        static void Main(string[] args)
        {
            #region VARIABLES

            ProtocolSI protocol = null;

            TcpClient client = null;
            NetworkStream stream = null;
            IPEndPoint endpoint = null;

            #endregion

            try
            {
                #region SOCKET SET UP

                protocol = new ProtocolSI();
                endpoint = new IPEndPoint(IPAddress.Loopback, 9998);
                client = new TcpClient();
                client.Connect(endpoint);
                stream = client.GetStream();

                #endregion

                #region COMMUNICATION

                string option = null;

                do
                {
                    Console.WriteLine("1) Integer | 2) String | 9) EOT");
                    option = Console.ReadLine();
                    byte[] msgBytes = null;
                    string msg = null;

                    switch(option)
                    {
                        case "1":
                            Console.WriteLine("Integer to Send: ");
                            msg = Console.ReadLine();
                            int intToSend = Int32.Parse(msg);
                            msgBytes = protocol.Make(ProtocolSICmdType.NORMAL, intToSend);  
                            break;

                        case "2":
                            Console.WriteLine("String to Send: ");
                            msg = Console.ReadLine();
                            msgBytes = protocol.Make(ProtocolSICmdType.DATA, msg);
                            break;

                        case "9":
                            msgBytes = protocol.Make(ProtocolSICmdType.EOT);
                            break;
                    }

                    stream.Write(msgBytes, 0, msgBytes.Length);

                    Console.WriteLine("Waiting for ACK");
                    stream.Read(protocol.Buffer, 0, protocol.Buffer.Length);
                    Console.WriteLine("Received ACK");
                    Console.WriteLine();
                }while(option != "9");

                #endregion
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            finally 
            {
                if (stream != null) stream.Close();
                if (client != null) client.Close();
            }

            Console.ReadLine();
        }
    }
}