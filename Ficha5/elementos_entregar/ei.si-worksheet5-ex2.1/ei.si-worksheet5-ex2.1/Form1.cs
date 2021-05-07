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

namespace ei.si.worksheet5
{
    public partial class Form1 : Form
    {
        private String firstInputDataHashedData = null;
        private String nextInputDataHashedData = null;
        private String lastInputDataHashedData = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ButtonTransformFirstBlock_Click(object sender, EventArgs e)
        {
            byte[] dataToHash = Encoding.UTF8.GetBytes(textBoxFirstInputData.Text);
            using (SHA256CryptoServiceProvider algorithm = new SHA256CryptoServiceProvider())
            {
                byte[] hash = algorithm.ComputeHash(dataToHash);
                firstInputDataHashedData = Convert.ToBase64String(hash);
            }
        }

        private void ButtonTransformNextBlock_Click(object sender, EventArgs e)
        {
            byte[] dataToHash = Encoding.UTF8.GetBytes(textBoxNextInputData.Text);
            using (SHA256CryptoServiceProvider algorithm = new SHA256CryptoServiceProvider())
            {
                byte[] hash = algorithm.ComputeHash(dataToHash);
                nextInputDataHashedData = Convert.ToBase64String(hash);
            }
        }

        private void ButtonTransformFinalBlock_Click(object sender, EventArgs e)
        {
            byte[] dataToHash = Encoding.UTF8.GetBytes(textBoxLastInputData.Text);
            using (SHA256CryptoServiceProvider algorithm = new SHA256CryptoServiceProvider())
            {
                byte[] hash = algorithm.ComputeHash(dataToHash);
                lastInputDataHashedData = Convert.ToBase64String(hash);
            }

            textBoxHashBytes.Text += "First Input Hash: " + firstInputDataHashedData + "\n\n";
            textBoxHashBytes.Text += "\nNext Input Hash: " + nextInputDataHashedData + "\n\n";
            textBoxHashBytes.Text += "\nLast Input Hash: " + lastInputDataHashedData;
        }
    }
}
