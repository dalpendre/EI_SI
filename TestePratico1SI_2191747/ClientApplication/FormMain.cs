using EI.SI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientApplication
{
    public partial class FormMain : Form
    {
        byte[] msg;
        RSACryptoServiceProvider assymAlgorithm = null;
        IPEndPoint serverEndpoint = null;
        AesCryptoServiceProvider symmAlgorithm = null;
        SHA256CryptoServiceProvider hashAlgorithm = null;
        SymmetricsSI symmetricsSI = null;
        NetworkStream netStream = null;
        TcpClient client = null;
        ProtocolSI protocol = null;


        public FormMain()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            serverEndpoint = new IPEndPoint(IPAddress.Parse(txtIPAddress.Text), 
            Int32.Parse(txtTCPPort.Text));

            client = new TcpClient();
            client.Connect(serverEndpoint);
            client = new TcpClient();
            client.Connect(serverEndpoint);
            netStream = client.GetStream();

            // Enable next panel
            panelSecurity.Enabled = true;
        }

        private void btnExchangeAsymmetricKeys_Click(object sender, EventArgs e)
        {
            assymAlgorithm = new RSACryptoServiceProvider();
            protocol = new ProtocolSI();

            msg = protocol.Make(ProtocolSICmdType.PUBLIC_KEY, assymAlgorithm.ToXmlString(false));            
            netStream.Write(msg, 0, msg.Length);

            // Show the DONE Label
            lblExchangeAsymetricKeys.Visible = true;
        }

        private void btnExchangeSymmetricKeys_Click(object sender, EventArgs e)
        {
            symmAlgorithm = new AesCryptoServiceProvider();
            symmetricsSI = new SymmetricsSI(symmAlgorithm);

            msg = protocol.Make(ProtocolSICmdType.SECRET_KEY, 
            assymAlgorithm.Encrypt(symmAlgorithm.Key, true));

            netStream.Write(msg, 0, msg.Length);
        }
        private void btnSendDomainReceiveIP_Click(object sender, EventArgs e)
        {
            byte[] clearData = ProtocolSI.ConvertStringToByteArray(txtDomain.Text);
            byte[] encryptedData = symmetricsSI.Encrypt(clearData);

            msg = protocol.Make(ProtocolSICmdType.NORMAL, encryptedData);
            netStream.Write(msg, 0, msg.Length);

            netStream.Read(protocol.Buffer, 0, protocol.Buffer.Length);
            byte[] encryptedDomainIPAddress = protocol.GetData();
            txtDomainIP.Text = symmetricsSI.Decrypt(encryptedDomainIPAddress).ToString();
        }

        private void btnRequestAndVerifySignature_Click(object sender, EventArgs e)
        {

        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        
    }
}
