namespace ClientApplication
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.label5 = new System.Windows.Forms.Label();
            this.panelDNS = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDomainIP = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDomain = new System.Windows.Forms.TextBox();
            this.lblVerify = new System.Windows.Forms.Label();
            this.lblReceiveIP = new System.Windows.Forms.Label();
            this.btnRequestAndVerifySignature = new System.Windows.Forms.Button();
            this.btnSendDomainReceiveIP = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.panelSecurity = new System.Windows.Forms.Panel();
            this.labelExchangeSymmetricKey = new System.Windows.Forms.Label();
            this.btnExchangeSymmetricKeys = new System.Windows.Forms.Button();
            this.lblExchangeAsymetricKeys = new System.Windows.Forms.Label();
            this.btnExchangeAsymmetricKeys = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panelConnection = new System.Windows.Forms.Panel();
            this.btnConnect = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTCPPort = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIPAddress = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panelDNS.SuspendLayout();
            this.panelSecurity.SuspendLayout();
            this.panelConnection.SuspendLayout();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label5.Location = new System.Drawing.Point(412, 362);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 25);
            this.label5.TabIndex = 21;
            this.label5.Text = "DNS System";
            // 
            // panelDNS
            // 
            this.panelDNS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDNS.Controls.Add(this.label7);
            this.panelDNS.Controls.Add(this.txtDomainIP);
            this.panelDNS.Controls.Add(this.label6);
            this.panelDNS.Controls.Add(this.txtDomain);
            this.panelDNS.Controls.Add(this.lblVerify);
            this.panelDNS.Controls.Add(this.lblReceiveIP);
            this.panelDNS.Controls.Add(this.btnRequestAndVerifySignature);
            this.panelDNS.Controls.Add(this.btnSendDomainReceiveIP);
            this.panelDNS.Enabled = false;
            this.panelDNS.Location = new System.Drawing.Point(16, 381);
            this.panelDNS.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.panelDNS.Name = "panelDNS";
            this.panelDNS.Size = new System.Drawing.Size(974, 265);
            this.panelDNS.TabIndex = 20;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(502, 23);
            this.label7.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(116, 25);
            this.label7.TabIndex = 12;
            this.label7.Text = "IP Address";
            // 
            // txtDomainIP
            // 
            this.txtDomainIP.Enabled = false;
            this.txtDomainIP.Location = new System.Drawing.Point(506, 56);
            this.txtDomainIP.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtDomainIP.Name = "txtDomainIP";
            this.txtDomainIP.Size = new System.Drawing.Size(442, 31);
            this.txtDomainIP.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 23);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 25);
            this.label6.TabIndex = 10;
            this.label6.Text = "Domain";
            // 
            // txtDomain
            // 
            this.txtDomain.Location = new System.Drawing.Point(24, 54);
            this.txtDomain.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtDomain.Name = "txtDomain";
            this.txtDomain.Size = new System.Drawing.Size(424, 31);
            this.txtDomain.TabIndex = 9;
            // 
            // lblVerify
            // 
            this.lblVerify.AutoSize = true;
            this.lblVerify.Location = new System.Drawing.Point(496, 208);
            this.lblVerify.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblVerify.Name = "lblVerify";
            this.lblVerify.Size = new System.Drawing.Size(72, 25);
            this.lblVerify.TabIndex = 8;
            this.lblVerify.Text = "DONE";
            this.lblVerify.Visible = false;
            // 
            // lblReceiveIP
            // 
            this.lblReceiveIP.AutoSize = true;
            this.lblReceiveIP.Location = new System.Drawing.Point(496, 152);
            this.lblReceiveIP.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblReceiveIP.Name = "lblReceiveIP";
            this.lblReceiveIP.Size = new System.Drawing.Size(72, 25);
            this.lblReceiveIP.TabIndex = 7;
            this.lblReceiveIP.Text = "DONE";
            this.lblReceiveIP.Visible = false;
            // 
            // btnRequestAndVerifySignature
            // 
            this.btnRequestAndVerifySignature.Location = new System.Drawing.Point(24, 188);
            this.btnRequestAndVerifySignature.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnRequestAndVerifySignature.Name = "btnRequestAndVerifySignature";
            this.btnRequestAndVerifySignature.Size = new System.Drawing.Size(428, 44);
            this.btnRequestAndVerifySignature.TabIndex = 1;
            this.btnRequestAndVerifySignature.Text = "5) Request and Verify Signature";
            this.btnRequestAndVerifySignature.UseVisualStyleBackColor = true;
            this.btnRequestAndVerifySignature.Click += new System.EventHandler(this.btnRequestAndVerifySignature_Click);
            // 
            // btnSendDomainReceiveIP
            // 
            this.btnSendDomainReceiveIP.Location = new System.Drawing.Point(26, 133);
            this.btnSendDomainReceiveIP.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnSendDomainReceiveIP.Name = "btnSendDomainReceiveIP";
            this.btnSendDomainReceiveIP.Size = new System.Drawing.Size(428, 44);
            this.btnSendDomainReceiveIP.TabIndex = 0;
            this.btnSendDomainReceiveIP.Text = "4) Send Domain and Receive IP";
            this.btnSendDomainReceiveIP.UseVisualStyleBackColor = true;
            this.btnSendDomainReceiveIP.Click += new System.EventHandler(this.btnSendDomainReceiveIP_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label4.Location = new System.Drawing.Point(422, 175);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 25);
            this.label4.TabIndex = 16;
            this.label4.Text = "Security Info";
            // 
            // panelSecurity
            // 
            this.panelSecurity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSecurity.Controls.Add(this.labelExchangeSymmetricKey);
            this.panelSecurity.Controls.Add(this.btnExchangeSymmetricKeys);
            this.panelSecurity.Controls.Add(this.lblExchangeAsymetricKeys);
            this.panelSecurity.Controls.Add(this.btnExchangeAsymmetricKeys);
            this.panelSecurity.Enabled = false;
            this.panelSecurity.Location = new System.Drawing.Point(16, 198);
            this.panelSecurity.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.panelSecurity.Name = "panelSecurity";
            this.panelSecurity.Size = new System.Drawing.Size(974, 152);
            this.panelSecurity.TabIndex = 19;
            // 
            // labelExchangeSymmetricKey
            // 
            this.labelExchangeSymmetricKey.AutoSize = true;
            this.labelExchangeSymmetricKey.Location = new System.Drawing.Point(876, 102);
            this.labelExchangeSymmetricKey.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelExchangeSymmetricKey.Name = "labelExchangeSymmetricKey";
            this.labelExchangeSymmetricKey.Size = new System.Drawing.Size(72, 25);
            this.labelExchangeSymmetricKey.TabIndex = 7;
            this.labelExchangeSymmetricKey.Text = "DONE";
            this.labelExchangeSymmetricKey.Visible = false;
            // 
            // btnExchangeSymmetricKeys
            // 
            this.btnExchangeSymmetricKeys.Location = new System.Drawing.Point(24, 83);
            this.btnExchangeSymmetricKeys.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnExchangeSymmetricKeys.Name = "btnExchangeSymmetricKeys";
            this.btnExchangeSymmetricKeys.Size = new System.Drawing.Size(428, 44);
            this.btnExchangeSymmetricKeys.TabIndex = 6;
            this.btnExchangeSymmetricKeys.Text = "3) Exchange Symmetric Keys";
            this.btnExchangeSymmetricKeys.UseVisualStyleBackColor = true;
            this.btnExchangeSymmetricKeys.Click += new System.EventHandler(this.btnExchangeSymmetricKeys_Click);
            // 
            // lblExchangeAsymetricKeys
            // 
            this.lblExchangeAsymetricKeys.AutoSize = true;
            this.lblExchangeAsymetricKeys.Location = new System.Drawing.Point(876, 46);
            this.lblExchangeAsymetricKeys.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblExchangeAsymetricKeys.Name = "lblExchangeAsymetricKeys";
            this.lblExchangeAsymetricKeys.Size = new System.Drawing.Size(72, 25);
            this.lblExchangeAsymetricKeys.TabIndex = 5;
            this.lblExchangeAsymetricKeys.Text = "DONE";
            this.lblExchangeAsymetricKeys.Visible = false;
            // 
            // btnExchangeAsymmetricKeys
            // 
            this.btnExchangeAsymmetricKeys.Location = new System.Drawing.Point(24, 27);
            this.btnExchangeAsymmetricKeys.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnExchangeAsymmetricKeys.Name = "btnExchangeAsymmetricKeys";
            this.btnExchangeAsymmetricKeys.Size = new System.Drawing.Size(428, 44);
            this.btnExchangeAsymmetricKeys.TabIndex = 3;
            this.btnExchangeAsymmetricKeys.Text = "2) Exchange Asymmetric Keys";
            this.btnExchangeAsymmetricKeys.UseVisualStyleBackColor = true;
            this.btnExchangeAsymmetricKeys.Click += new System.EventHandler(this.btnExchangeAsymmetricKeys_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label1.Location = new System.Drawing.Point(438, 4);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 25);
            this.label1.TabIndex = 15;
            this.label1.Text = "Network";
            // 
            // panelConnection
            // 
            this.panelConnection.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelConnection.Controls.Add(this.btnConnect);
            this.panelConnection.Controls.Add(this.label3);
            this.panelConnection.Controls.Add(this.txtTCPPort);
            this.panelConnection.Controls.Add(this.label2);
            this.panelConnection.Controls.Add(this.txtIPAddress);
            this.panelConnection.Location = new System.Drawing.Point(16, 23);
            this.panelConnection.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.panelConnection.Name = "panelConnection";
            this.panelConnection.Size = new System.Drawing.Size(974, 129);
            this.panelConnection.TabIndex = 14;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(752, 52);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(200, 44);
            this.btnConnect.TabIndex = 4;
            this.btnConnect.Text = "1) Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(346, 17);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(168, 25);
            this.label3.TabIndex = 3;
            this.label3.Text = "Server TCP Port";
            // 
            // txtTCPPort
            // 
            this.txtTCPPort.Location = new System.Drawing.Point(352, 60);
            this.txtTCPPort.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtTCPPort.Name = "txtTCPPort";
            this.txtTCPPort.Size = new System.Drawing.Size(246, 31);
            this.txtTCPPort.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 17);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(185, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Server IP Address";
            // 
            // txtIPAddress
            // 
            this.txtIPAddress.Location = new System.Drawing.Point(20, 58);
            this.txtIPAddress.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtIPAddress.Name = "txtIPAddress";
            this.txtIPAddress.Size = new System.Drawing.Size(310, 31);
            this.txtIPAddress.TabIndex = 0;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 685);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panelDNS);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panelSecurity);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panelConnection);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormMain";
            this.Text = "EI.SI - Practical Exam 1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.panelDNS.ResumeLayout(false);
            this.panelDNS.PerformLayout();
            this.panelSecurity.ResumeLayout(false);
            this.panelSecurity.PerformLayout();
            this.panelConnection.ResumeLayout(false);
            this.panelConnection.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panelDNS;
        private System.Windows.Forms.Label lblVerify;
        private System.Windows.Forms.Label lblReceiveIP;
        private System.Windows.Forms.Button btnRequestAndVerifySignature;
        private System.Windows.Forms.Button btnSendDomainReceiveIP;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panelSecurity;
        private System.Windows.Forms.Label labelExchangeSymmetricKey;
        private System.Windows.Forms.Button btnExchangeSymmetricKeys;
        private System.Windows.Forms.Label lblExchangeAsymetricKeys;
        private System.Windows.Forms.Button btnExchangeAsymmetricKeys;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelConnection;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTCPPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIPAddress;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDomainIP;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDomain;
    }
}

