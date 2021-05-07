using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ei_si_worksheet4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
         
        private void ButtonGenerateKeys_Click(object sender, EventArgs e)
        {
            using(RSACryptoServiceProvider algorithm = new RSACryptoServiceProvider())
            {
                string publicKey = algorithm.ToXmlString(false);
                string privatePublicKey = algorithm.ToXmlString(true);

                textboxPublicKey.Text = publicKey;
                textboxBothKeys.Text = privatePublicKey;
            }
        }

        private void ButtonSavePublicKey_Click(object sender, EventArgs e)
        {
            File.WriteAllText("PublicKey.txt", textboxPublicKey.Text);
            MessageBox.Show("File saved");
        }

        private void ButtonSaveKeys_Click(object sender, EventArgs e)
        {
            File.WriteAllText("PrivatePublicKey.txt", textboxBothKeys.Text);
            MessageBox.Show("File saved");
        }

        private void ButtonEncrypt_Click(object sender, EventArgs e)
        {
            byte[] plainSecretKey = Encoding.UTF8.GetBytes(textboxSymmetricKey.Text);
            using(RSACryptoServiceProvider algorithm = new RSACryptoServiceProvider()) 
            {
                algorithm.FromXmlString(File.ReadAllText("PublicKey.txt"));
                byte[] encryptedSecretKey = algorithm.Encrypt(plainSecretKey, true);
                textboxSymmetricKeyEncrypted.Text = 
                Convert.ToBase64String(encryptedSecretKey);
                textboxBitSize.Text = (encryptedSecretKey.Length * 8).ToString();
            }
        }

        private void ButtonDecrypt_Click(object sender, EventArgs e)
        {
            byte[] encryptedSecretKey = 
            Convert.FromBase64String(textboxSymmetricKeyEncrypted.Text);
            using (RSACryptoServiceProvider algorithm = new RSACryptoServiceProvider())
            {
                algorithm.FromXmlString(File.ReadAllText("PrivatePublicKey.txt"));
                byte[] plainSecretKey = algorithm.Decrypt(encryptedSecretKey, true);
                textboxSymmetricKeyDecrypted.Text = Encoding.UTF8.GetString(plainSecretKey);
            }
        }
    }
}
