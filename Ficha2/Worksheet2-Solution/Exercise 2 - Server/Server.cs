using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_2___Server
{
    class Server
    {
        static void Main(string[] args)
        {
            #region VARIABLES

            int bufferSize = 1400;

            byte[] buffer = new byte[bufferSize];
            int bytesRead = 0;

            TcpListener tcpListener = null;
            TcpClient client = null;
            NetworkStream stream = null;
            IPEndPoint endpoint = null;

            #endregion

            try 
            {
                #region SOCKET SET UP

                endpoint = new IPEndPoint(IPAddress.Any, 9999);
                tcpListener = new TcpListener(endpoint);
                tcpListener.Start();
                client = tcpListener.AcceptTcpClient(); //BLOCKING CALL
                stream = client.GetStream();

                #endregion

                #region COMMUNICATION - String

                Console.WriteLine("Waiting for Client");
                bytesRead = stream.Read(buffer, 0, bufferSize);
                Console.WriteLine("Received: {0}", Encoding.ASCII.GetString(buffer, 0, bytesRead));

                string ackString = "ACK";
                byte[] ack = Encoding.UTF8.GetBytes(ackString);
                Console.WriteLine("Sending ACK");
                stream.Write(ack, 0, ack.Length);

                #endregion

                #region COMMUNICATION - String

                Console.WriteLine("Waiting for Client");
                bytesRead = stream.Read(buffer, 0, bufferSize);
                Console.WriteLine("Received: {0}", Encoding.UTF8.GetString(buffer, 0, bytesRead));

                Console.WriteLine("Sending ACK");
                stream.Write(ack, 0, ack.Length);

                #endregion

                #region COMMUNICATION - Integer

                Console.WriteLine("Waiting for Client");
                bytesRead = stream.Read(buffer, 0, bufferSize);
                Console.WriteLine("Received: {0}", BitConverter.ToInt32(buffer, 0));

                Console.WriteLine("Sending ACK ");
                stream.Write(ack, 0, ack.Length);

                #endregion
            }
            catch (Exception exception) 
            {
                Console.WriteLine(exception.Message);
            }
            finally 
            {
                if (stream != null)
                {
                    stream.Close();
                }

                if(client != null) 
                {
                    client.Close();
                }

                if(tcpListener != null) 
                {
                    tcpListener.Stop();
                }

                Console.ReadKey();
            }
        }
    }
}