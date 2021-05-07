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

namespace TestePratico1_Modelo
{
    public partial class Form1 : Form
    {
        private RSACryptoServiceProvider assymAlgorithm = null;
        private AesCryptoServiceProvider symmAlgorithm = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonImportAssymetricKey_Click(object sender, EventArgs e)
        {
        }

        private void buttonGenerateSymmetricAlgorithm_Click(object sender, EventArgs e)
        {
            symmAlgorithm = new AesCryptoServiceProvider();
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {

        }

        private void buttonSharePublicKeys_Click(object sender, EventArgs e)
        {

        }

        private void buttonShareSecretKey_Click(object sender, EventArgs e)
        {

        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {

        }

        private void buttonGetDecryptData_Click(object sender, EventArgs e)
        {

        }

        private void buttonGetVerifyDataSignature_Click(object sender, EventArgs e)
        {

        }
    }
}
