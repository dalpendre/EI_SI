using EI.SI;
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
        private StreamReader fileStreamReader;
        private const int MIN_FILESIZE = 200;
        private char[] first_two_hundred_bytes_to_encrypt = null;
        String two_hundred_bytes_to_string = null;
        private char[] bytes_to_encrypt;
        String bytes_to_encrypt_to_string = null;
        SymmetricAlgorithm algorithm = null;
        SymmetricsSI symmetricsSI = null; 

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //Encrypts the whole file content
        private void ButtonEncrypt_Click(object sender, EventArgs e)
        {
            algorithm = new AesCryptoServiceProvider();
            symmetricsSI = new SymmetricsSI(algorithm);
            byte[] plainBytes = Encoding.UTF8.GetBytes(bytes_to_encrypt);
            byte[] encryptedBytes = symmetricsSI.Encrypt(plainBytes);
            textBoxEncryptedData.Text = Convert.ToBase64String(encryptedBytes);

            String path = "c:/temp/temp.dat";
            using (StreamWriter streamWriter = File.AppendText(path))
            {
                streamWriter.WriteLine(bytes_to_encrypt_to_string);
                streamWriter.Close();
            }
        }

        private void ButtonChooseFile_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                fileStreamReader = new StreamReader(openFileDialog1.FileName);

                long filesize = new FileInfo(openFileDialog1.FileName).Length;               

                if(filesize < MIN_FILESIZE) 
                {
                    MessageBox.Show("Invalid file size to encrypt/decrypt");
                    return;
                }              

                StringBuilder stringBuilder = new StringBuilder();

                //Read first 200 bytes to encrypt
                using (fileStreamReader) 
                {
                    while (fileStreamReader.Peek() >= 0 && fileStreamReader.Peek() < MIN_FILESIZE)
                    {
                        first_two_hundred_bytes_to_encrypt = new char[MIN_FILESIZE];
                        fileStreamReader.Read(first_two_hundred_bytes_to_encrypt, 0,
                        first_two_hundred_bytes_to_encrypt.Length);
                    }

                    //Appends each carachter to the string
                    foreach (char c in first_two_hundred_bytes_to_encrypt)
                    {
                        stringBuilder.Append(c);
                    }

                    two_hundred_bytes_to_string = stringBuilder.ToString();
                    textBoxDataToEncrypt.Text = two_hundred_bytes_to_string;

                    stringBuilder.Clear();

                    while (fileStreamReader.Peek() >= 0 && fileStreamReader.Peek() < filesize)
                    {
                        bytes_to_encrypt = new char[filesize];
                        fileStreamReader.Read(bytes_to_encrypt, 0, bytes_to_encrypt.Length);
                    }

                    foreach (char c in bytes_to_encrypt)
                    {
                        stringBuilder.Append(c);
                    }

                    bytes_to_encrypt_to_string = stringBuilder.ToString();

                    stringBuilder.Clear();
                }
            }
        }


        private void ButtonDecrypt_Click(object sender, EventArgs e)
        {

        }
    }
}
