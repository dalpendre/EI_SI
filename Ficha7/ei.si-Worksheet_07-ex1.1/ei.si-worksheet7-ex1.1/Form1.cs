using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ei.si_worksheet7
{
    public partial class Form1 : Form
    {
        // The digital certificates should be copied to ./bin/debug directory
        const string fileCertPFX = @".pfx";
        const string fileCertCER = @".cer";
        static readonly string pwdfileCertPFX = Properties.Settings.Default.PwdCertPFX;

        private byte[] tempCertRaw = null;
        private byte[] tempData = null;


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
            textBoxInfo.Text += "Has Private Key: " + cert.HasPrivateKey.ToString() 
            + Environment.NewLine;
            // todo

            textBoxInfo.Text += "++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++" + Environment.NewLine;
            textBoxInfo.Text += Environment.NewLine;
        }

        //Certificado + componente privada
        private void ButtonOpenPFX_Click(object sender, EventArgs e)
        {
            X509Certificate2 certificate = new X509Certificate2("estg.ei.si.a.pfx", "ei.si");
            ShowCertificate(certificate);
        }

        //Certificado (Ficheiro + password)
        private void ButtonOpenCER_Click(object sender, EventArgs e)
        {
            X509Certificate2 certificate = new X509Certificate2("estg.ei.si.a.cer");
            ShowCertificate(certificate);
        }

        //Ir para página pessoal de certificados
        private void ButtonOpenFromStore_Click(object sender, EventArgs e)
        {
            X509Store store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
            store.Open(OpenFlags.ReadOnly);

            X509Certificate2Collection certificates =
            X509Certificate2UI.SelectFromCollection(store.Certificates, "EI SI", 
            "Choose a certificate", X509SelectionFlag.SingleSelection);

            ShowCertificate(certificates[0]);
        }

        private void ButtonAddToStoreCER_Click(object sender, EventArgs e)
        {
            X509Store store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
            store.Open(OpenFlags.ReadWrite);

            X509Certificate2 certificate = new X509Certificate2("estg.ei.si.a.pfx", "ei.si");

            store.Add(certificate);

            MessageBox.Show("Certificate added");
        }

        private void ButtonVerifyCert_Click(object sender, EventArgs e)
        {
            X509Certificate2 certificate = new X509Certificate2("estg.ei.si.a.cer");
            ShowCertificate(certificate);

            if(certificate.Verify())
            {
                MessageBox.Show("VALID");
            }
            else 
            {
                MessageBox.Show("INVALID");
            }
        }

        private void ButtonVerifyCertChain_Click(object sender, EventArgs e)
        {

        }

        private void ButtonExportPublicCert_Click(object sender, EventArgs e)
        {
            X509Certificate2 certificate = new X509Certificate2("estg.ei.si.a.cer");
            ShowCertificate(certificate);

            byte[] rawCertificate = certificate.Export(X509ContentType.Cert);
            File.WriteAllBytes("newcert.cer", rawCertificate);

            MessageBox.Show("File Saved");
        }

        private void ButtonImportPublicCert_Click(object sender, EventArgs e)
        {
            byte[] rawCertificate = File.ReadAllBytes("newcert.cer");

            X509Certificate2 certificate = new X509Certificate2();

            certificate.Import(rawCertificate);

            ShowCertificate(certificate);
        }

        private void ButtonExportPrivateCert_Click(object sender, EventArgs e)
        {
            X509Certificate2 certificate = 
            new X509Certificate2("estg.ei.si.a.pfx", "ei.si", X509KeyStorageFlags.Exportable);
            ShowCertificate(certificate);

            byte[] rawCertificate = certificate.Export(X509ContentType.Pfx, "pass");
            File.WriteAllBytes("newcert.pfx", rawCertificate);

            MessageBox.Show("File Saved");
        }

        private void ButtonImportPrivateCert_Click(object sender, EventArgs e)
        {
            byte[] rawCertificate = File.ReadAllBytes("newcert.pfx");

            X509Certificate2 certificate = new X509Certificate2();

            certificate.Import(rawCertificate, "pass", X509KeyStorageFlags.Exportable);

            ShowCertificate(certificate);
        }
    }
}
