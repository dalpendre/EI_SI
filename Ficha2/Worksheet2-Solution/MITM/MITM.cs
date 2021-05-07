using EI.SI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MITM
{
    class MITM
    {
        static void Main(string[] args)
        {
            #region VARIABLES

            //Server for "Client"
            ProtocolSI protocol = null;
            TcpListener clientListener = null;
            TcpClient client = null;
            NetworkStream clientStream = null;
            IPEndPoint clientEndpoint = null;

            //new Client for "Server" (non authorized client now)
            TcpClient server = null;
            NetworkStream serverStream = null;
            IPEndPoint serverEndpoint = null;

            #endregion
            try
            {
                #region SOCKET SET UP

                //Listening to client and changing port for new client connection with 
                //server
                protocol = new ProtocolSI();
                clientEndpoint = new IPEndPoint(IPAddress.Any, 9998);
                clientListener = new TcpListener(clientEndpoint);
                clientListener.Start();
                client = clientListener.AcceptTcpClient();    //Chamada bloqueante
                clientStream = client.GetStream();

                server = new TcpClient();
                serverEndpoint = new IPEndPoint(IPAddress.Loopback, 9999);
                server.Connect(serverEndpoint);
                serverStream = server.GetStream();

                #endregion

                #region COMMUNICATION
                do
                {
                    Console.WriteLine("Waiting for Client");
                    clientStream.Read(protocol.Buffer, 0, protocol.Buffer.Length);
                    switch (protocol.GetCmdType())
                    {
                        case ProtocolSICmdType.NORMAL:
                            Console.WriteLine("MITM: Received Integer: {0}", protocol.GetIntFromData());
                            break;
                        case ProtocolSICmdType.DATA:
                            Console.WriteLine("MITM: Received String: {0}", protocol.GetStringFromData());
                            break;
                        case ProtocolSICmdType.EOT:
                            Console.WriteLine("MITM: Received EOT");
                            break;
                    }

                    Console.WriteLine("Forwarding to server");
                    byte[] ack = protocol.Make(ProtocolSICmdType.ACK);
                    clientStream.Write(ack, 0, ack.Length);
                    serverStream.Write(protocol.Buffer, 0, protocol.Buffer.Length);
                    Console.WriteLine();

                } while (protocol.GetCmdType() != ProtocolSICmdType.EOT);
                #endregion
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            finally
            {
                if (clientStream != null) clientStream.Close();
                if (client != null) client.Close();
                if (clientListener != null) clientListener.Stop();
            }
            Console.ReadLine();
        }
    }
}
