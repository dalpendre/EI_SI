using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.Pkcs;    // Mandatory to add the reference to System.Security DLL
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ei.si_worksheet7
{
    public partial class Form1 : Form
    {
        // The digital certificates should be copied to ./bin/debug directory
        const string fileCertPFX = @"estg.dei.si.a.pfx";
        const string fileCertCER = @"estg.dei.si.a.cer";
        static readonly string pwdfileCertPFX = Properties.Settings.Default.PwdCertPFX;

        private byte[] tempDigitalSignature = null;
        private byte[] tempEnvelope = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }



        /// <summary>
        /// Show digital certificate info in the textbox
        /// </summary>
        /// <param name="cert">digital certificate</param>
        private void ShowCertificate(X509Certificate2 cert)
        {
            textBoxInfo.Text += "++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++" + Environment.NewLine;
            textBoxInfo.Text += "Subject: " + cert.Subject + Environment.NewLine;
            textBoxInfo.Text += "FriendlyName: " + cert.FriendlyName + Environment.NewLine;
            textBoxInfo.Text += "Thumbprint: " + cert.Thumbprint + Environment.NewLine;
            textBoxInfo.Text += "SerialNumber: " + cert.SerialNumber + Environment.NewLine;
            textBoxInfo.Text += "HasPrivateKey: " + cert.HasPrivateKey + Environment.NewLine;
            textBoxInfo.Text += "++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++" + Environment.NewLine;
            textBoxInfo.Text += Environment.NewLine;
        }
        private void ButtonSignatureWithData_Click(object sender, EventArgs e)
        {
            X509Certificate2 certificate = new X509Certificate2("estg.ei.si.b.pfx", "ei.si");
            ShowCertificate(certificate);

            //Dados
            ContentInfo contentInfo = new ContentInfo(Encoding.UTF8.GetBytes(textBoxInfo.Text));

            //Quem faz
            CmsSigner cmsSigner = new CmsSigner(certificate);

            //Resultado     false -> com dados, true -> sem dados
            SignedCms signedCms = new SignedCms(contentInfo, false);

            signedCms.ComputeSignature(cmsSigner);

            this.tempDigitalSignature = signedCms.Encode();

            MessageBox.Show("Signature Done");
        }

        private void ButtonVerifySignatureWithData_Click(object sender, EventArgs e)
        {
            SignedCms signedCms = null;

            try 
            {
                signedCms = new SignedCms();

                signedCms.Decode(this.tempDigitalSignature);

                signedCms.CheckSignature(false);    //Integridade e autenticação

                MessageBox.Show("Signature Valid");

                ShowCertificate(signedCms.Certificates[0]);

                MessageBox.Show(Encoding.UTF8.GetString(signedCms.ContentInfo.Content));
            }
            catch (Exception exception) 
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void ButtonSignatureWithoutData_Click(object sender, EventArgs e)
        {
            X509Store store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
            store.Open(OpenFlags.ReadOnly);

            var certs = X509Certificate2UI.SelectFromCollection(store.Certificates, "EI SI",
            "Choose a certificate", X509SelectionFlag.SingleSelection);

            ShowCertificate(certs[0]);

            ContentInfo contentInfo = new ContentInfo(Encoding.UTF8.GetBytes(textBoxInfo.Text));

            SignedCms signedCms = new SignedCms(contentInfo, true); //true if without data

            CmsSigner cmsSigner = new CmsSigner(certs[0]);

            signedCms.ComputeSignature(cmsSigner);
            this.tempDigitalSignature = signedCms.Encode();

            //final message PKCS#7
            //signature hash (data)
            //certificate (only data)
            //metadata

            MessageBox.Show("Digital Signature Done");
        }

        private void ButtonVerifySignatureWithoutData_Click(object sender, EventArgs e)
        {
            ContentInfo contentInfo = 
            new ContentInfo(Encoding.UTF8.GetBytes(textBoxInfo.Text));

            SignedCms signedCms = new SignedCms(contentInfo, true);

            signedCms.Decode(this.tempDigitalSignature);

            try 
            {
                signedCms.CheckSignature(false);    //false auth + integrity
                MessageBox.Show("Signature Valid");
            }
            catch(Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void ButtonEncryptWithCER_Click(object sender, EventArgs e)
        {
            X509Certificate2 certificate = new X509Certificate2("estg.ei.si.b.cer");

            ShowCertificate(certificate);

            ContentInfo contentInfo = 
            new ContentInfo(Encoding.UTF8.GetBytes(textBoxInfo.Text));

            EnvelopedCms envelopedCms = new EnvelopedCms(contentInfo);

            CmsRecipient cmsRecipient = new CmsRecipient(certificate);

            envelopedCms.Encrypt(cmsRecipient);

            this.tempEnvelope = envelopedCms.Encode();

            // PKCS 7
            //SecretKey - Encrypted Public Key Recipient1
            //SecretKey - Encrypted Public Key Recipient2
            //Data - Encrypted Secret Key
            //Certificates

            MessageBox.Show("Encrypted Data");
        }

        private void ButtonDecryptFromPFX_Click(object sender, EventArgs e)
        {
            EnvelopedCms envelopedCms = new EnvelopedCms();

            envelopedCms.Decode(this.tempEnvelope);

            X509Certificate2 certificate = new X509Certificate2("estg.ei.si.b.pfx", "ei.si");

            try 
            {
                MessageBox.Show(Encoding.UTF8.GetString(envelopedCms.ContentInfo.Content));

                envelopedCms.Decrypt(new X509Certificate2Collection(certificate));

                MessageBox.Show(Encoding.UTF8.GetString(envelopedCms.ContentInfo.Content));
            }
            catch(Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }



        private void ButtonEncryptWithStore_Click(object sender, EventArgs e)
        {
            X509Store store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
            store.Open(OpenFlags.ReadOnly);

            var certs = X509Certificate2UI.SelectFromCollection(store.Certificates, 
            "EI SI", "Choose a certificate", X509SelectionFlag.SingleSelection);

            ShowCertificate(certs[0]);

            ContentInfo contentInfo = new ContentInfo(Encoding.UTF8.GetBytes(textBoxInfo.Text));

            EnvelopedCms envelopedCms = new EnvelopedCms(contentInfo);

            CmsRecipient cmsRecipient = new CmsRecipient(certs[0]);

            envelopedCms.Encrypt(cmsRecipient);

            this.tempEnvelope = envelopedCms.Encode();

            // PKCS 7
            //SecretKey - Encrypted Public Key Recipient1
            //SecretKey - Encrypted Public Key Recipient2
            //Data - Encrypted Secret Key
            //Certificates

            MessageBox.Show("Encrypted Data");
        }

        private void ButtonDecryptFromStore_Click(object sender, EventArgs e)
        {
            EnvelopedCms envelopedCms = new EnvelopedCms();

            envelopedCms.Decode(this.tempEnvelope);

            X509Certificate2 certificate = new X509Certificate2("estg.ei.si.b.pfx", "ei.si");

            try
            {
                MessageBox.Show(Encoding.UTF8.GetString(envelopedCms.ContentInfo.Content));

                envelopedCms.Decrypt();

                MessageBox.Show(Encoding.UTF8.GetString(envelopedCms.ContentInfo.Content));
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void ButtonEncryptAndSign_Click(object sender, EventArgs e)
        {
            X509Store store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
            store.Open(OpenFlags.ReadOnly);

            X509Certificate2Collection certs = X509Certificate2UI.SelectFromCollection(store.Certificates, "EI SI",
            "Choose a certificate", X509SelectionFlag.SingleSelection);

            X509Certificate2 certificate = certs[0];
            certificate.
        }

        private void ButtonVerifyAndDecrypt_Click(object sender, EventArgs e)
        {

        }
    }
}
