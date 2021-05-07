using EI.SI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Exercise3___Server
{
    class Server
    {
        static void Main(string[] args)
        {
            #region VARIABLES

            ProtocolSI protocol = null;
            TcpListener listener = null;
            TcpClient client = null;
            NetworkStream stream = null;
            IPEndPoint endpoint = null;
            #endregion
            try
            {
                #region SOCKET SET UP
                protocol = new ProtocolSI();
                endpoint = new IPEndPoint(IPAddress.Any, 9999);
                listener = new TcpListener(endpoint);
                listener.Start();
                client = listener.AcceptTcpClient();    //Chamada bloqueante
                stream = client.GetStream();
                #endregion
                #region COMMUNICATION
                do
                {
                    Console.WriteLine("Waiting for Client");
                    stream.Read(protocol.Buffer, 0, protocol.Buffer.Length);
                    switch (protocol.GetCmdType())
                    {
                        case ProtocolSICmdType.NORMAL:
                            Console.WriteLine("Received Integer: {0}", protocol.GetIntFromData());
                            break;
                        case ProtocolSICmdType.DATA:
                            Console.WriteLine("Received String: {0}", protocol.GetStringFromData());
                            break;
                        case ProtocolSICmdType.EOT:
                            Console.WriteLine("Received EOT");
                            break;
                    }
                    Console.WriteLine("Sending ACK");
                    byte[] ack = protocol.Make(ProtocolSICmdType.ACK);
                    stream.Write(ack, 0, ack.Length);
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
                if (stream != null) stream.Close();
                if (client != null) client.Close();
                if (listener != null) listener.Stop();
            }
            Console.ReadLine();
        }
    }
}