using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharedLibrary;

namespace WindowsFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonGetUCName_Click(object sender, EventArgs e)
        {
            textBoxUCName.Text = SIHelper.GetUCName();
        }

        private void buttonSaveToDatabase_Click(object sender, EventArgs e)
        {
            string studentName = textBoxStudentName.Text;
            string ucName = textBoxUCName.Text;

            if(DatabaseHelper.CreateStudent(studentName, ucName) == 1)
            {
                MessageBox.Show("Student created");
            }
            else
            {
                MessageBox.Show("Error Creating Student");
            }
        }
    }
}
