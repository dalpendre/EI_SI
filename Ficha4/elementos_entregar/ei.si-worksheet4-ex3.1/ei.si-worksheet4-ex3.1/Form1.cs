using EI.SI;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace ei_si_worksheet4
{
    public partial class Form1 : Form
    {
        SymmetricAlgorithm algorithm = null;
        SymmetricsSI symmetricsSI = null;
        private String encryptedFileContent = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ButtonGenerateKeys_Click(object sender, EventArgs e)
        {
            using (RSACryptoServiceProvider algorithm = new RSACryptoServiceProvider())
            {
                String publicKey = algorithm.ToXmlString(false);
                String privatePublicKey = algorithm.ToXmlString(true);

                tbPublicKey.Text = publicKey;
                tbBothKeys.Text = privatePublicKey;
            }
        }

        private void ButtonImportKeys_Click(object sender, EventArgs e)
        {
            if(File.Exists("PrivatePublicKey.txt"))
            {
                
            }
            else 
            {

            }
        }

        private void ButtonSavePublicKey_Click(object sender, EventArgs e)
        {
            File.WriteAllText("PublicKey.txt", tbPublicKey.Text);
            MessageBox.Show("File saved");
        }

        private void ButtonSaveKeys_Click(object sender, EventArgs e)
        {
            File.WriteAllText("PrivatePublicKey.txt", tbBothKeys.Text);
            MessageBox.Show("File saved");
        }

        private void ButtonGenerateSymmetricKey_Click(object sender, EventArgs e)
        {
            algorithm = new AesCryptoServiceProvider();
            symmetricsSI = new SymmetricsSI(algorithm);
            byte[] plainBytes = Encoding.UTF8.GetBytes(textBoxSymmetricKey.Text);
            byte[] encryptedBytes = symmetricsSI.Encrypt(plainBytes);
            tbSymmetricKeyEncrypted.Text = Convert.ToBase64String(encryptedBytes);
        }

        private void ButtonEncryptFile_Click(object sender, EventArgs e)
        {
            algorithm = new AesCryptoServiceProvider();
            symmetricsSI = new SymmetricsSI(algorithm);
            
            String filecontent = null;

            using(OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if(openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Stream filestream = openFileDialog.OpenFile();

                    using(StreamReader reader = new StreamReader(filestream)) 
                    {
                        filecontent = "Hello World!";
                        filecontent = reader.ReadToEnd();

                        byte[] plainContent = Encoding.UTF8.GetBytes(filecontent);
                        byte[] encryptedBytes = symmetricsSI.Encrypt(plainContent);
                        encryptedFileContent = 
                        Convert.ToBase64String(encryptedBytes);

                        reader.Close();

                        File.WriteAllText(openFileDialog.FileName, encryptedFileContent);
                    }
                }
            }
        }

        private void buttonDecryptFile_Click(object sender, EventArgs e)
        {
            using(OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if(openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    byte[] encryptedBytes = 
                    Convert.FromBase64String(encryptedFileContent);
                    byte[] plainContent = symmetricsSI.Decrypt(encryptedBytes);

                    String decryptedFileContent = Convert.ToBase64String(plainContent);

                    File.WriteAllText(openFileDialog.FileName, f);
                }
            }
        }
    }
}
