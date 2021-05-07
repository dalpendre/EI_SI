
namespace TestePratico1_Modelo
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
            this.label1 = new System.Windows.Forms.Label();
            this.buttonImportAssymetricKey = new System.Windows.Forms.Button();
            this.buttonGenerateSymmetricAlgorithm = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxIP = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.buttonSharePublicKeys = new System.Windows.Forms.Button();
            this.buttonShareSecretKey = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.buttonGetDecryptData = new System.Windows.Forms.Button();
            this.buttonGetVerifyDataSignature = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Crypthographic Algorithms";
            // 
            // buttonImportAssymetricKey
            // 
            this.buttonImportAssymetricKey.Location = new System.Drawing.Point(16, 41);
            this.buttonImportAssymetricKey.Name = "buttonImportAssymetricKey";
            this.buttonImportAssymetricKey.Size = new System.Drawing.Size(129, 23);
            this.buttonImportAssymetricKey.TabIndex = 1;
            this.buttonImportAssymetricKey.Text = "Import Assymmetric Key";
            this.buttonImportAssymetricKey.UseVisualStyleBackColor = true;
            this.buttonImportAssymetricKey.Click += new System.EventHandler(this.buttonImportAssymetricKey_Click);
            // 
            // buttonGenerateSymmetricAlgorithm
            // 
            this.buttonGenerateSymmetricAlgorithm.Location = new System.Drawing.Point(318, 41);
            this.buttonGenerateSymmetricAlgorithm.Name = "buttonGenerateSymmetricAlgorithm";
            this.buttonGenerateSymmetricAlgorithm.Size = new System.Drawing.Size(160, 23);
            this.buttonGenerateSymmetricAlgorithm.TabIndex = 2;
            this.buttonGenerateSymmetricAlgorithm.Text = "Generate Symmetric Algorithm";
            this.buttonGenerateSymmetricAlgorithm.UseVisualStyleBackColor = true;
            this.buttonGenerateSymmetricAlgorithm.Click += new System.EventHandler(this.buttonGenerateSymmetricAlgorithm_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Server";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "IP";
            // 
            // textBoxIP
            // 
            this.textBoxIP.Location = new System.Drawing.Point(40, 125);
            this.textBoxIP.Name = "textBoxIP";
            this.textBoxIP.Size = new System.Drawing.Size(100, 20);
            this.textBoxIP.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(157, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Port";
            // 
            // textBoxPort
            // 
            this.textBoxPort.Location = new System.Drawing.Point(189, 125);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.Size = new System.Drawing.Size(100, 20);
            this.textBoxPort.TabIndex = 7;
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(318, 125);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(160, 23);
            this.buttonConnect.TabIndex = 8;
            this.buttonConnect.Text = "Connect";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // buttonSharePublicKeys
            // 
            this.buttonSharePublicKeys.Location = new System.Drawing.Point(16, 177);
            this.buttonSharePublicKeys.Name = "buttonSharePublicKeys";
            this.buttonSharePublicKeys.Size = new System.Drawing.Size(160, 23);
            this.buttonSharePublicKeys.TabIndex = 9;
            this.buttonSharePublicKeys.Text = "Share Public Keys";
            this.buttonSharePublicKeys.UseVisualStyleBackColor = true;
            this.buttonSharePublicKeys.Click += new System.EventHandler(this.buttonSharePublicKeys_Click);
            // 
            // buttonShareSecretKey
            // 
            this.buttonShareSecretKey.Location = new System.Drawing.Point(257, 177);
            this.buttonShareSecretKey.Name = "buttonShareSecretKey";
            this.buttonShareSecretKey.Size = new System.Drawing.Size(221, 23);
            this.buttonShareSecretKey.TabIndex = 10;
            this.buttonShareSecretKey.Text = "Share Secret Key";
            this.buttonShareSecretKey.UseVisualStyleBackColor = true;
            this.buttonShareSecretKey.Click += new System.EventHandler(this.buttonShareSecretKey_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 274);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Login";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 301);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Username";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(77, 297);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(144, 20);
            this.textBox1.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(234, 304);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Password";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(293, 298);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(169, 20);
            this.textBoxPassword.TabIndex = 15;
            // 
            // buttonLogin
            // 
            this.buttonLogin.Location = new System.Drawing.Point(16, 338);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(205, 23);
            this.buttonLogin.TabIndex = 16;
            this.buttonLogin.Text = "Login";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // buttonGetDecryptData
            // 
            this.buttonGetDecryptData.Location = new System.Drawing.Point(16, 389);
            this.buttonGetDecryptData.Name = "buttonGetDecryptData";
            this.buttonGetDecryptData.Size = new System.Drawing.Size(205, 23);
            this.buttonGetDecryptData.TabIndex = 17;
            this.buttonGetDecryptData.Text = "Get And Decrypt Data";
            this.buttonGetDecryptData.UseVisualStyleBackColor = true;
            this.buttonGetDecryptData.Click += new System.EventHandler(this.buttonGetDecryptData_Click);
            // 
            // buttonGetVerifyDataSignature
            // 
            this.buttonGetVerifyDataSignature.Location = new System.Drawing.Point(257, 389);
            this.buttonGetVerifyDataSignature.Name = "buttonGetVerifyDataSignature";
            this.buttonGetVerifyDataSignature.Size = new System.Drawing.Size(205, 23);
            this.buttonGetVerifyDataSignature.TabIndex = 18;
            this.buttonGetVerifyDataSignature.Text = "Get And Verify Data Signature";
            this.buttonGetVerifyDataSignature.UseVisualStyleBackColor = true;
            this.buttonGetVerifyDataSignature.Click += new System.EventHandler(this.buttonGetVerifyDataSignature_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 450);
            this.Controls.Add(this.buttonGetVerifyDataSignature);
            this.Controls.Add(this.buttonGetDecryptData);
            this.Controls.Add(this.buttonLogin);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.buttonShareSecretKey);
            this.Controls.Add(this.buttonSharePublicKeys);
            this.Controls.Add(this.buttonConnect);
            this.Controls.Add(this.textBoxPort);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxIP);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonGenerateSymmetricAlgorithm);
            this.Controls.Add(this.buttonImportAssymetricKey);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonImportAssymetricKey;
        private System.Windows.Forms.Button buttonGenerateSymmetricAlgorithm;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxIP;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxPort;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.Button buttonSharePublicKeys;
        private System.Windows.Forms.Button buttonShareSecretKey;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.Button buttonGetDecryptData;
        private System.Windows.Forms.Button buttonGetVerifyDataSignature;
    }
}

