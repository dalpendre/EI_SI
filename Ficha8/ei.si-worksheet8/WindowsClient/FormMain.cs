using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


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

            MessageBox.Show(client.VerifyAcessToBD());

            //// versão 1
            //lboxUsers.DataSource = users;
            //lboxUsers.DisplayMember = "Name";
            //lboxUsers.ValueMember = "Login";

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
            //if (lboxUsers.SelectedIndex == -1)
            //{
            //    MessageBox.Show("tem que escolher um utilizador!");
            //    return;
            //}

            // todo: linha selecionada na listbox.... ((string)lboxUsers.SelectedValue)

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
