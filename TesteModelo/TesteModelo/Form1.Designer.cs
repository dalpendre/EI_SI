
namespace TesteModelo
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.generateSymmetricBtn = new System.Windows.Forms.Button();
            this.importAssymetricBtn = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.shareSecretBtn = new System.Windows.Forms.Button();
            this.sharePublicBtn = new System.Windows.Forms.Button();
            this.connectBtn = new System.Windows.Forms.Button();
            this.ipTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.portTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.usernameTextbox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.generateSymmetricBtn);
            this.groupBox1.Controls.Add(this.importAssymetricBtn);
            this.groupBox1.Location = new System.Drawing.Point(9, 10);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(548, 81);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cryptographic Algorithms";
            // 
            // generateSymmetricBtn
            // 
            this.generateSymmetricBtn.Location = new System.Drawing.Point(314, 30);
            this.generateSymmetricBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.generateSymmetricBtn.Name = "generateSymmetricBtn";
            this.generateSymmetricBtn.Size = new System.Drawing.Size(202, 28);
            this.generateSymmetricBtn.TabIndex = 1;
            this.generateSymmetricBtn.Text = "Generate Symmetric Algorithm";
            this.generateSymmetricBtn.UseVisualStyleBackColor = true;
            this.generateSymmetricBtn.Click += new System.EventHandler(this.generateSymmetricBtn_Click);
            // 
            // importAssymetricBtn
            // 
            this.importAssymetricBtn.Location = new System.Drawing.Point(13, 30);
            this.importAssymetricBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.importAssymetricBtn.Name = "importAssymetricBtn";
            this.importAssymetricBtn.Size = new System.Drawing.Size(133, 28);
            this.importAssymetricBtn.TabIndex = 0;
            this.importAssymetricBtn.Text = "Import Assymetric Key";
            this.importAssymetricBtn.UseVisualStyleBackColor = true;
            this.importAssymetricBtn.Click += new System.EventHandler(this.importAssymetricBtn_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.shareSecretBtn);
            this.groupBox2.Controls.Add(this.sharePublicBtn);
            this.groupBox2.Controls.Add(this.connectBtn);
            this.groupBox2.Controls.Add(this.ipTextBox);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(9, 106);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Size = new System.Drawing.Size(548, 81);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Server";
            // 
            // shareSecretBtn
            // 
            this.shareSecretBtn.Location = new System.Drawing.Point(385, 49);
            this.shareSecretBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.shareSecretBtn.Name = "shareSecretBtn";
            this.shareSecretBtn.Size = new System.Drawing.Size(124, 28);
            this.shareSecretBtn.TabIndex = 4;
            this.shareSecretBtn.Text = "Share Secret Key";
            this.shareSecretBtn.UseVisualStyleBackColor = true;
            this.shareSecretBtn.Click += new System.EventHandler(this.shareSecretBtn_Click);
            // 
            // sharePublicBtn
            // 
            this.sharePublicBtn.Location = new System.Drawing.Point(22, 49);
            this.sharePublicBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.sharePublicBtn.Name = "sharePublicBtn";
            this.sharePublicBtn.Size = new System.Drawing.Size(124, 28);
            this.sharePublicBtn.TabIndex = 3;
            this.sharePublicBtn.Text = "Share Public Keys";
            this.sharePublicBtn.UseVisualStyleBackColor = true;
            this.sharePublicBtn.Click += new System.EventHandler(this.sharePublicBtn_Click);
            // 
            // connectBtn
            // 
            this.connectBtn.Location = new System.Drawing.Point(385, 16);
            this.connectBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.connectBtn.Name = "connectBtn";
            this.connectBtn.Size = new System.Drawing.Size(124, 28);
            this.connectBtn.TabIndex = 2;
            this.connectBtn.Text = "Connect";
            this.connectBtn.UseVisualStyleBackColor = true;
            this.connectBtn.Click += new System.EventHandler(this.connectBtn_Click);
            // 
            // ipTextBox
            // 
            this.ipTextBox.Location = new System.Drawing.Point(35, 18);
            this.ipTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ipTextBox.Name = "ipTextBox";
            this.ipTextBox.Size = new System.Drawing.Size(76, 20);
            this.ipTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP";
            // 
            // portTextBox
            // 
            this.portTextBox.Location = new System.Drawing.Point(220, 124);
            this.portTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.portTextBox.Name = "portTextBox";
            this.portTextBox.Size = new System.Drawing.Size(76, 20);
            this.portTextBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(190, 124);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Port";
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(290, 18);
            this.passwordTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(76, 20);
            this.passwordTextBox.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(190, 227);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Password:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.passwordTextBox);
            this.groupBox3.Controls.Add(this.button6);
            this.groupBox3.Controls.Add(this.button7);
            this.groupBox3.Controls.Add(this.button8);
            this.groupBox3.Controls.Add(this.usernameTextbox);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Location = new System.Drawing.Point(9, 209);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox3.Size = new System.Drawing.Size(548, 129);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Server";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(271, 76);
            this.button6.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(227, 28);
            this.button6.TabIndex = 4;
            this.button6.Text = "Get and verity data signature";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(22, 76);
            this.button7.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(124, 28);
            this.button7.TabIndex = 3;
            this.button7.Text = "Get and encrypt data";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(22, 44);
            this.button8.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(124, 28);
            this.button8.TabIndex = 2;
            this.button8.Text = "Login";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // usernameTextbox
            // 
            this.usernameTextbox.Location = new System.Drawing.Point(60, 18);
            this.usernameTextbox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.usernameTextbox.Name = "usernameTextbox";
            this.usernameTextbox.Size = new System.Drawing.Size(76, 20);
            this.usernameTextbox.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 18);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Username:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.portTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button generateSymmetricBtn;
        private System.Windows.Forms.Button importAssymetricBtn;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox ipTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox portTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button shareSecretBtn;
        private System.Windows.Forms.Button sharePublicBtn;
        private System.Windows.Forms.Button connectBtn;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.TextBox usernameTextbox;
        private System.Windows.Forms.Label label4;
    }
}

