namespace WindowsFormsApp
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
            this.textBoxStudentName = new System.Windows.Forms.TextBox();
            this.buttonGetUCName = new System.Windows.Forms.Button();
            this.labelUCName = new System.Windows.Forms.Label();
            this.textBoxUCName = new System.Windows.Forms.TextBox();
            this.buttonSaveToDatabase = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Student Name";
            // 
            // textBoxStudentName
            // 
            this.textBoxStudentName.Location = new System.Drawing.Point(95, 35);
            this.textBoxStudentName.Name = "textBoxStudentName";
            this.textBoxStudentName.Size = new System.Drawing.Size(347, 20);
            this.textBoxStudentName.TabIndex = 1;
            // 
            // buttonGetUCName
            // 
            this.buttonGetUCName.Location = new System.Drawing.Point(16, 128);
            this.buttonGetUCName.Name = "buttonGetUCName";
            this.buttonGetUCName.Size = new System.Drawing.Size(114, 23);
            this.buttonGetUCName.TabIndex = 4;
            this.buttonGetUCName.Text = "Get UC Name";
            this.buttonGetUCName.UseVisualStyleBackColor = true;
            this.buttonGetUCName.Click += new System.EventHandler(this.buttonGetUCName_Click);
            // 
            // labelUCName
            // 
            this.labelUCName.AutoSize = true;
            this.labelUCName.Location = new System.Drawing.Point(14, 71);
            this.labelUCName.Name = "labelUCName";
            this.labelUCName.Size = new System.Drawing.Size(53, 13);
            this.labelUCName.TabIndex = 5;
            this.labelUCName.Text = "UC Name";
            // 
            // textBoxUCName
            // 
            this.textBoxUCName.Location = new System.Drawing.Point(95, 68);
            this.textBoxUCName.Name = "textBoxUCName";
            this.textBoxUCName.Size = new System.Drawing.Size(347, 20);
            this.textBoxUCName.TabIndex = 6;
            // 
            // buttonSaveToDatabase
            // 
            this.buttonSaveToDatabase.Location = new System.Drawing.Point(318, 128);
            this.buttonSaveToDatabase.Name = "buttonSaveToDatabase";
            this.buttonSaveToDatabase.Size = new System.Drawing.Size(123, 23);
            this.buttonSaveToDatabase.TabIndex = 7;
            this.buttonSaveToDatabase.Text = "Save To Database";
            this.buttonSaveToDatabase.UseVisualStyleBackColor = true;
            this.buttonSaveToDatabase.Click += new System.EventHandler(this.buttonSaveToDatabase_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 163);
            this.Controls.Add(this.buttonSaveToDatabase);
            this.Controls.Add(this.textBoxUCName);
            this.Controls.Add(this.labelUCName);
            this.Controls.Add(this.buttonGetUCName);
            this.Controls.Add(this.textBoxStudentName);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "EI SI Worksheet 1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxStudentName;
        private System.Windows.Forms.Button buttonGetUCName;
        private System.Windows.Forms.Label labelUCName;
        private System.Windows.Forms.TextBox textBoxUCName;
        private System.Windows.Forms.Button buttonSaveToDatabase;
    }
}

