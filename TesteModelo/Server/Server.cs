using EI.SI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Server
    {
        static void Main(string[] args)
        {
            RSACryptoServiceProvider assymAlgorigthm = new RSACryptoServiceProvider();
            assymAlgorigthm.FromXmlString(File.ReadAllText("privateKey.xml"));

            IPEndPoint endpoint = new IPEndPoint(IPAddress.Any, 9999);
            TcpListener listener = new TcpListener(endpoint);
            listener.Start();
            
            ProtocolSI protocol = new ProtocolSI();
            TcpClient client = listener.AcceptTcpClient(); //chamada bloqueante
            NetworkStream netStream = client.GetStream();

            AesCryptoServiceProvider symmAlgorithm = new AesCryptoServiceProvider();
            SymmetricsSI symmetricsSI = new SymmetricsSI(symmAlgorithm);

            string username = null;
            string password = null;

            do
            {
                netStream.Read(protocol.Buffer, 0, protocol.Buffer.Length);

                Console.WriteLine("Getting Type" + protocol.GetCmdType().ToString());
                switch(protocol.GetCmdType())
                {
                    case ProtocolSICmdType.PUBLIC_KEY:
                        Console.WriteLine("pub key:" + protocol.GetStringFromData());
                        break;
                    case ProtocolSICmdType.IV:
                        symmAlgorithm.IV = assymAlgorigthm.Decrypt(
                            protocol.GetData(),
                            true);
                        break;
                    case ProtocolSICmdType.SECRET_KEY:
                        symmAlgorithm.Key = assymAlgorigthm.Decrypt(
                            protocol.GetData(), 
                            true);
                        break;
                    case ProtocolSICmdType.USER_OPTION_1:
                        username = ProtocolSI.ConvertByteArrayToString(protocol.GetData());
                        break;
                    case ProtocolSICmdType.USER_OPTION_2:
                        password = ProtocolSI.ConvertByteArrayToString(symmetricsSI.Decrypt(protocol.GetData()));

                        byte[] msg;
                        if(username=="ola" && password=="123")
                        {
                            msg = protocol.Make(ProtocolSICmdType.ACK);
                            netStream.Write(msg,0,msg.Length);
                        }
                        else
                        {
                            msg = protocol.Make(ProtocolSICmdType.NACK);
                            netStream.Write(msg,0,msg.Length);
                        }
                        break;
                    case ProtocolSICmdType.USER_OPTION_3:
                        msg = protocol.Make(ProtocolSICmdType.SYM_CIPHER_DATA, symmetricsSI.Encrypt(
                            Encoding.UTF8.GetBytes("ola mundo")));
                        netStream.Write(msg, 0, msg.Length);
                        break;
                }
            } while (protocol.GetCmdType() != ProtocolSICmdType.EOT);

            Console.ReadLine();
        }
    }
}
