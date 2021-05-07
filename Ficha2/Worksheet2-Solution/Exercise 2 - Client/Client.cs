using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_2___Client
{
    class Client
    {
        static void Main(string[] args)
        {
            #region VARIABLES
            int bufferSize = 1400;

            byte[] buffer = new byte[bufferSize];
            int bytesRead = 0;

            TcpClient client = null;
            NetworkStream stream = null;
            IPEndPoint endpoint = null;

            #endregion

            try 
            {
                #region SOCKET SET UP

                endpoint = new IPEndPoint(IPAddress.Loopback, 9999);
                client = new TcpClient();
                client.Connect(endpoint);   //Client tenta-se conectar ao endpoint com o porto 9999
                stream = client.GetStream();    //Devolve a stream usada para enviar e receber dados

                #endregion COMMUNICATION - Byte Array

                byte[] arrayMsg = new byte[2] { 83, 73 };

                Console.WriteLine("Sending Byte Array ");
                stream.Write(arrayMsg, 0, arrayMsg.Length); //Escreve bytes do array para a stream

                Console.WriteLine("Waiting for Client");
                bytesRead = stream.Read(buffer, 0, bufferSize); //Lê stream recebida
                Console.WriteLine("Received: {0}", Encoding.ASCII.GetString(buffer, 0, bytesRead));

                #region COMMUNICATION - String

                string msg = "EI.SI";
                byte[] stringMsg = Encoding.UTF8.GetBytes(msg);
                Console.WriteLine("Sending Byte Array ");
                stream.Write(stringMsg, 0, stringMsg.Length);

                Console.WriteLine("Waiting for ACK");
                bytesRead = stream.Read(buffer, 0, bufferSize);
                Console.WriteLine("Received: {0}", Encoding.UTF8.GetString(buffer, 0, bytesRead));

                #endregion

                #region COMMUNICATION - Integer

                int intToSend = 42;
                byte[] intMsg = BitConverter.GetBytes(intToSend);
                Console.WriteLine("Sending Integer ");
                stream.Write(intMsg, 0, intMsg.Length);

                Console.WriteLine("Waiting for ACK");
                bytesRead = stream.Read(buffer, 0, bufferSize);
                Console.WriteLine("Received: {0}", Encoding.UTF8.GetString(buffer, 0, bytesRead));

                #endregion
            }
            catch (Exception exception) 
            {
                Console.WriteLine(exception.Message);
            }
            finally
            {
                if(stream != null)
                {
                    stream.Close();
                }

                if(client != null)
                {
                    client.Close();
                }

                Console.ReadKey();
            }
        }
    }
}
