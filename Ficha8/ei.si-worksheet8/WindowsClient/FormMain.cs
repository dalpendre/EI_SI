using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WindowsClient.AuthServiceReference;

namespace WindowsClient
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Form Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_Load(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// Obter a lista de utilizadores
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnGetUsers_Click(object sender, EventArgs e)
        {
            AuthServiceReference.AuthServiceClient client =
            new AuthServiceReference.AuthServiceClient();

            //MessageBox.Show(client.VerifyAcessToBD());

            var users = client.GetUsers(txtLogin.Text, txtPassword.Text);

            if(users == null)
            {
                MessageBox.Show("NOT AUTHENTICATED");
                return;
            }

            //// versão 1
            lboxUsers.DataSource = users;
            lboxUsers.DisplayMember = "Name";
            lboxUsers.ValueMember = "ID";

            //// versão 2
            //lboxUsers.Items.Clear();
            //foreach (User user in users)
            //{
            //  lboxUsers.Items.Add(user.Login);
            //}
        }


        /// <summary>
        /// Obter a descrição de um utilizador 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnGetDescription_Click(object sender, EventArgs e)
        {
            //// proteção para que não se execute esta funcionalidade sem que um utilizador esteja selecionado
            if(lboxUsers.SelectedIndex == -1)
            {
                MessageBox.Show("tem que escolher um utilizador!");
                return;
            }

            int id = (int)lboxUsers.SelectedValue;

            AuthServiceClient client = new AuthServiceClient();

            User user = client.GetUser(id);

            txtDescription.Text = user.Description;
        }

        /// <summary>
        /// Atualizar a descrição de um utilizador
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSetDescription_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                Application.DoEvents();

                // lembrar de usar o "using"

                using(AuthServiceClient client = new AuthServiceClient())
                {
                    string login = txtLogin.Text;
                    string password = txtPassword.Text;
                    string description = txtMyDescription.Text;

                    var result = client.UpdateUserDescription(login, password, description);
                    if(result)
                    {
                        MessageBox.Show("Description updated");
                    }
                    else 
                    {
                        MessageBox.Show("Description NOT Updated");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }


    }
}
