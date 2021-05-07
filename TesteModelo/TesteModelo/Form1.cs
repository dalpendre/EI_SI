using EI.SI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TesteModelo
{
    public partial class Form1 : Form
    {
        private RSACryptoServiceProvider assymAlgorithm;
        private AesCryptoServiceProvider symmAlgorithm;
        private NetworkStream netStream;
        private TcpClient client;
        private ProtocolSI protocol = new ProtocolSI();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void importAssymetricBtn_Click(object sender, EventArgs e)
        {
            assymAlgorithm = new RSACryptoServiceProvider();
            String keyXml = File.ReadAllText("publicKey.xml");
            assymAlgorithm.FromXmlString(keyXml);
        }

        private void generateSymmetricBtn_Click(object sender, EventArgs e)
        {
            symmAlgorithm = new AesCryptoServiceProvider();
            symmAlgorithm.GenerateIV();
            symmAlgorithm.GenerateKey();
        }

        private void connectBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string ip = ipTextBox.Text;
                string port = portTextBox.Text;

                IPEndPoint endpoint = new IPEndPoint(IPAddress.Parse(ip), Int32.Parse(port));
                client = new TcpClient();
                client.Connect(endpoint);
                netStream = client.GetStream();


            } catch(Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        private void sharePublicBtn_Click(object sender, EventArgs e)
        {
            byte[] msg = protocol.Make(ProtocolSICmdType.PUBLIC_KEY, assymAlgorithm.ToXmlString(false));
            netStream.Write(msg,0,msg.Length);
        }

        private void shareSecretBtn_Click(object sender, EventArgs e)
        {
            //Console.WriteLine("IV SENT: " +
            //    ProtocolSI.ConvertByteArrayToString(symmAlgorithm.IV));
            byte[] msg = protocol.Make(ProtocolSICmdType.IV,
                assymAlgorithm.Encrypt(symmAlgorithm.IV, true));
            netStream.Write(msg, 0, msg.Length);



            // Console.WriteLine("SECRET KEY SENT: " +
            //    ProtocolSI.ConvertByteArrayToString(symmAlgorithm.Key));
            msg = protocol.Make(ProtocolSICmdType.SECRET_KEY, 
                assymAlgorithm.Encrypt(symmAlgorithm.Key,true));
            netStream.Write(msg, 0, msg.Length);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string username = usernameTextbox.Text;
            string password = passwordTextBox.Text;

            try
            {
                SymmetricsSI symmetricsSI = new SymmetricsSI(symmAlgorithm);

                byte[] msg = protocol.Make(
                    ProtocolSICmdType.USER_OPTION_1, 
                    ProtocolSI.ConvertStringToByteArray(username)
                    );
                netStream.Write(msg, 0, msg.Length);

                msg = protocol.Make(
                    ProtocolSICmdType.USER_OPTION_2, 
                    symmetricsSI.Encrypt(ProtocolSI.ConvertStringToByteArray(password))
                    );
                netStream.Write(msg, 0, msg.Length);
                // READ ACK NACK
                netStream.Read(protocol.Buffer, 0, protocol.Buffer.Length);
            } catch(Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
        // GET AND DECRYPT DATA
        private void button7_Click(object sender, EventArgs e)
        {
            byte[] msg = protocol.Make(ProtocolSICmdType.USER_OPTION_3);
            netStream.Write(msg, 0, msg.Length);
            netStream.Read(protocol.Buffer, 0, protocol.Buffer.Length);
            Console.WriteLine(protocol.GetCmdType());
            if(protocol.GetCmdType() == ProtocolSICmdType.SYM_CIPHER_DATA)
            {
                SymmetricsSI symmetricsSI = new SymmetricsSI(symmAlgorithm);
                Console.Write(ProtocolSI.ConvertByteArrayToString(symmetricsSI.Decrypt(protocol.GetData())));
            }
        }

        //Get and verify data
        private void button6_Click(object sender, EventArgs e)
        {
            byte[] msg = protocol.Make(ProtocolSICmdType.ACK);

        }
    }
}
