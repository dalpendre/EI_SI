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

namespace ei_si_worksheet3
{
    public partial class Form1 : Form
    {
        byte[] Key = null;
        byte[] IV = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ButtonEncrypt_Click(object sender, EventArgs e)
        {
            using(AesCryptoServiceProvider symmetricAlgorithm = new AesCryptoServiceProvider())
            {
                this.Key = symmetricAlgorithm.Key;
                this.IV = symmetricAlgorithm.IV;
                using(MemoryStream memoryStream = new MemoryStream())
                {
                    using(CryptoStream cryptoStream = new CryptoStream(memoryStream,
                    symmetricAlgorithm.CreateEncryptor(), CryptoStreamMode.Write)) 
                    {
                        string plain_text = textBoxTextToEncrypt.Text;
                        byte[] plainBytes = Encoding.UTF8.GetBytes(plain_text);

                        cryptoStream.Write(plainBytes, 0, plainBytes.Length);
                        cryptoStream.Flush();
                    }

                    byte[] encryptedBytes = memoryStream.ToArray();
                    textBoxEncryptedText.Text = Convert.ToBase64String(encryptedBytes);
                }
            }
        }

        private void ButtonDecrypt_Click(object sender, EventArgs e)
        {
            using (AesCryptoServiceProvider symmetricAlgorithm = new AesCryptoServiceProvider())
            {
                symmetricAlgorithm.Key = this.Key;
                symmetricAlgorithm.IV = this.IV;

                string encryptedText = textBoxEncryptedText.Text;
                byte[] encryptedBytes = Convert.FromBase64String(encryptedText);
                byte[] plain_bytes = new byte[encryptedBytes.Length];
                using (MemoryStream memoryStream = new MemoryStream(encryptedBytes))
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream,
                    symmetricAlgorithm.CreateDecryptor(), CryptoStreamMode.Read))
                    {
                        int bytesRead = cryptoStream.Read(plain_bytes, 0, plain_bytes.Length);
                        Array.Resize(ref plain_bytes, bytesRead);
                    }
                }

                textBoxDecryptedText.Text = Encoding.UTF8.GetString(plain_bytes);
            }
        }
    }
}