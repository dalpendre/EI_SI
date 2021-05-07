using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ei.si.worksheet6
{
    public partial class Form1 : Form
    {
        private String publicKey;
        private String bothKeys;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ButtonSignHash_Click(object sender, EventArgs e)
        {
            byte[] dataToSign = Encoding.UTF8.GetBytes(textBoxOriginalMessage.Text);
            using(SHA256CryptoServiceProvider hashAlgorithm = new SHA256CryptoServiceProvider())
            {
                using(RSACryptoServiceProvider assymmAlgorithm = new RSACryptoServiceProvider())
                {
                    this.publicKey = assymmAlgorithm.ToXmlString(false);    //Public key generate
                    this.bothKeys = assymmAlgorithm.ToXmlString(true);

                    byte[] hash = hashAlgorithm.ComputeHash(dataToSign);
                    //MessageBox.Show(CryptoConfig.MapNameToOID("SHA256"));
                    byte[] signature = assymmAlgorithm.SignHash(hash, 
                    CryptoConfig.MapNameToOID("SHA256"));

                    textBoxDigitalSignature.Text = Convert.ToBase64String(signature);
                    textBoxDigitalSignatureBits.Text = (signature.Length * 8).ToString();
                    textBoxMessageDigest.Text = Convert.ToBase64String(hash);
                    textBoxMessageDigestBits.Text = (hash.Length * 8).ToString();
                }
            }
        }

        private void ButtonSignData_Click(object sender, EventArgs e)
        {
            byte[] dataToSign = Encoding.UTF8.GetBytes(textBoxOriginalMessage.Text);
            using (SHA256CryptoServiceProvider hashAlgorithm = new SHA256CryptoServiceProvider())
            {
                using (RSACryptoServiceProvider assymmAlgorithm = new RSACryptoServiceProvider())
                {
                    this.publicKey = assymmAlgorithm.ToXmlString(false);    //Public key generate
                    this.bothKeys = assymmAlgorithm.ToXmlString(true);  

                    byte[] hash = hashAlgorithm.ComputeHash(dataToSign);
                    //MessageBox.Show(CryptoConfig.MapNameToOID("SHA256"));
                    byte[] signature = assymmAlgorithm.SignData(dataToSign,
                    hashAlgorithm);

                    textBoxDigitalSignature.Text = Convert.ToBase64String(signature);
                    textBoxDigitalSignatureBits.Text = (signature.Length * 8).ToString();
                    textBoxMessageDigest.Text = "";
                    textBoxMessageDigestBits.Text = "";
                }
            }
        }

        private void ButtonVerifyHash_Click(object sender, EventArgs e)
        {
            byte[] dataToSign = Encoding.UTF8.GetBytes(textBoxOriginalMessage.Text);
            using(SHA256CryptoServiceProvider hashAlgorithm = new SHA256CryptoServiceProvider())
            {
                using(RSACryptoServiceProvider assymAlgorithm = new RSACryptoServiceProvider())
                {
                    assymAlgorithm.FromXmlString(this.publicKey);
                    byte[] hash = hashAlgorithm.ComputeHash(dataToSign);
                    byte[] signature = Convert.FromBase64String(textBoxDigitalSignature.Text);
                    if(assymAlgorithm.VerifyHash(hash, 
                    CryptoConfig.MapNameToOID("SHA256"), signature)) 
                    {
                        MessageBox.Show("VALID signature");
                    }
                    else 
                    {
                        MessageBox.Show("INVALID signature");
                    }
                }
            }
        }

        private void ButtonVerifyData_Click(object sender, EventArgs e)
        {
            byte[] dataToSign = Encoding.UTF8.GetBytes(textBoxOriginalMessage.Text);
            using (SHA256CryptoServiceProvider hashAlgorithm = new SHA256CryptoServiceProvider())
            {
                using (RSACryptoServiceProvider assymAlgorithm = new RSACryptoServiceProvider())
                {
                    assymAlgorithm.FromXmlString(this.publicKey);
                    byte[] signature = Convert.FromBase64String(textBoxDigitalSignature.Text);
                    if (assymAlgorithm.VerifyData(dataToSign,
                    hashAlgorithm, signature))
                    {
                        MessageBox.Show("VALID signature");
                    }
                    else
                    {
                        MessageBox.Show("INVALID signature");
                    }
                }
            }
        }


    }
}
