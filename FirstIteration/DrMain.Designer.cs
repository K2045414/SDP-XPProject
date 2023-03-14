namespace FirstIteration
{
    partial class FRM_DrMain
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
            this.LBL_HCPID = new System.Windows.Forms.Label();
            this.LBX_Patients = new System.Windows.Forms.ListBox();
            this.BTN_EditPatient = new System.Windows.Forms.Button();
            this.BTN_RemovePatient = new System.Windows.Forms.Button();
            this.BTN_AddPatient = new System.Windows.Forms.Button();
            this.BTN_ImportCSV = new System.Windows.Forms.Button();
            this.BTN_SignOut = new System.Windows.Forms.Button();
            this.OFD_Import = new System.Windows.Forms.OpenFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.LBL_Title = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // LBL_HCPID
            // 
            this.LBL_HCPID.AutoSize = true;
            this.LBL_HCPID.Location = new System.Drawing.Point(178, 23);
            this.LBL_HCPID.Name = "LBL_HCPID";
            this.LBL_HCPID.Size = new System.Drawing.Size(43, 13);
            this.LBL_HCPID.TabIndex = 0;
            this.LBL_HCPID.Text = "HCP ID";
            // 
            // LBX_Patients
            // 
            this.LBX_Patients.BackColor = System.Drawing.Color.LightSteelBlue;
            this.LBX_Patients.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LBX_Patients.FormattingEnabled = true;
            this.LBX_Patients.Location = new System.Drawing.Point(13, 14);
            this.LBX_Patients.Name = "LBX_Patients";
            this.LBX_Patients.Size = new System.Drawing.Size(353, 171);
            this.LBX_Patients.TabIndex = 1;
            // 
            // BTN_EditPatient
            // 
            this.BTN_EditPatient.BackColor = System.Drawing.Color.Transparent;
            this.BTN_EditPatient.BackgroundImage = global::FirstIteration.Properties.Resources.Button3;
            this.BTN_EditPatient.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BTN_EditPatient.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTN_EditPatient.FlatAppearance.BorderSize = 0;
            this.BTN_EditPatient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_EditPatient.Font = new System.Drawing.Font("Arial", 12F);
            this.BTN_EditPatient.ForeColor = System.Drawing.Color.White;
            this.BTN_EditPatient.Location = new System.Drawing.Point(175, 275);
            this.BTN_EditPatient.Name = "BTN_EditPatient";
            this.BTN_EditPatient.Size = new System.Drawing.Size(191, 53);
            this.BTN_EditPatient.TabIndex = 3;
            this.BTN_EditPatient.Text = "See selected patient data";
            this.BTN_EditPatient.UseVisualStyleBackColor = false;
            this.BTN_EditPatient.Click += new System.EventHandler(this.BTN_EditPatient_Click);
            // 
            // BTN_RemovePatient
            // 
            this.BTN_RemovePatient.BackColor = System.Drawing.Color.Transparent;
            this.BTN_RemovePatient.BackgroundImage = global::FirstIteration.Properties.Resources.Button32;
            this.BTN_RemovePatient.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BTN_RemovePatient.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTN_RemovePatient.FlatAppearance.BorderSize = 0;
            this.BTN_RemovePatient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_RemovePatient.Font = new System.Drawing.Font("Arial", 12F);
            this.BTN_RemovePatient.ForeColor = System.Drawing.Color.White;
            this.BTN_RemovePatient.Location = new System.Drawing.Point(175, 195);
            this.BTN_RemovePatient.Name = "BTN_RemovePatient";
            this.BTN_RemovePatient.Size = new System.Drawing.Size(191, 53);
            this.BTN_RemovePatient.TabIndex = 2;
            this.BTN_RemovePatient.Text = "Remove selected patient from care";
            this.BTN_RemovePatient.UseVisualStyleBackColor = false;
            this.BTN_RemovePatient.Click += new System.EventHandler(this.BTN_RemovePatient_Click);
            // 
            // BTN_AddPatient
            // 
            this.BTN_AddPatient.BackColor = System.Drawing.Color.Transparent;
            this.BTN_AddPatient.BackgroundImage = global::FirstIteration.Properties.Resources.Button3;
            this.BTN_AddPatient.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BTN_AddPatient.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTN_AddPatient.FlatAppearance.BorderSize = 0;
            this.BTN_AddPatient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_AddPatient.Font = new System.Drawing.Font("Arial", 12F);
            this.BTN_AddPatient.ForeColor = System.Drawing.Color.White;
            this.BTN_AddPatient.Location = new System.Drawing.Point(210, 355);
            this.BTN_AddPatient.Name = "BTN_AddPatient";
            this.BTN_AddPatient.Size = new System.Drawing.Size(156, 53);
            this.BTN_AddPatient.TabIndex = 5;
            this.BTN_AddPatient.Text = "Add new patient";
            this.BTN_AddPatient.UseVisualStyleBackColor = false;
            this.BTN_AddPatient.Click += new System.EventHandler(this.BTN_AddPatient_Click);
            // 
            // BTN_ImportCSV
            // 
            this.BTN_ImportCSV.BackColor = System.Drawing.Color.Transparent;
            this.BTN_ImportCSV.BackgroundImage = global::FirstIteration.Properties.Resources.Button3;
            this.BTN_ImportCSV.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BTN_ImportCSV.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTN_ImportCSV.FlatAppearance.BorderSize = 0;
            this.BTN_ImportCSV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_ImportCSV.Font = new System.Drawing.Font("Arial", 12F);
            this.BTN_ImportCSV.ForeColor = System.Drawing.Color.White;
            this.BTN_ImportCSV.Location = new System.Drawing.Point(13, 195);
            this.BTN_ImportCSV.Name = "BTN_ImportCSV";
            this.BTN_ImportCSV.Size = new System.Drawing.Size(156, 53);
            this.BTN_ImportCSV.TabIndex = 1;
            this.BTN_ImportCSV.Text = "Import from CSV";
            this.BTN_ImportCSV.UseVisualStyleBackColor = false;
            this.BTN_ImportCSV.Click += new System.EventHandler(this.BTN_ImportCSV_Click);
            // 
            // BTN_SignOut
            // 
            this.BTN_SignOut.BackColor = System.Drawing.Color.Transparent;
            this.BTN_SignOut.BackgroundImage = global::FirstIteration.Properties.Resources.Button3;
            this.BTN_SignOut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BTN_SignOut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTN_SignOut.FlatAppearance.BorderSize = 0;
            this.BTN_SignOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_SignOut.Font = new System.Drawing.Font("Arial", 12F);
            this.BTN_SignOut.ForeColor = System.Drawing.Color.White;
            this.BTN_SignOut.Location = new System.Drawing.Point(13, 355);
            this.BTN_SignOut.Name = "BTN_SignOut";
            this.BTN_SignOut.Size = new System.Drawing.Size(156, 53);
            this.BTN_SignOut.TabIndex = 4;
            this.BTN_SignOut.Text = "Sign out";
            this.BTN_SignOut.UseVisualStyleBackColor = false;
            this.BTN_SignOut.Click += new System.EventHandler(this.BTN_SignOut_Click);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::FirstIteration.Properties.Resources.HeaderImg;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.LBL_Title);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(400, 51);
            this.panel1.TabIndex = 18;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::FirstIteration.Properties.Resources.LogoImg;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(72, 43);
            this.pictureBox1.TabIndex = 38;
            this.pictureBox1.TabStop = false;
            // 
            // LBL_Title
            // 
            this.LBL_Title.AutoSize = true;
            this.LBL_Title.BackColor = System.Drawing.Color.Transparent;
            this.LBL_Title.Font = new System.Drawing.Font("Arial", 20F);
            this.LBL_Title.ForeColor = System.Drawing.Color.White;
            this.LBL_Title.Location = new System.Drawing.Point(175, 8);
            this.LBL_Title.Name = "LBL_Title";
            this.LBL_Title.Size = new System.Drawing.Size(42, 32);
            this.LBL_Title.TabIndex = 5;
            this.LBL_Title.Text = "ID";
            this.LBL_Title.Click += new System.EventHandler(this.LBL_Title_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BackgroundImage = global::FirstIteration.Properties.Resources.BufferImg;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Controls.Add(this.LBX_Patients);
            this.panel2.Controls.Add(this.BTN_EditPatient);
            this.panel2.Controls.Add(this.BTN_SignOut);
            this.panel2.Controls.Add(this.BTN_RemovePatient);
            this.panel2.Controls.Add(this.BTN_ImportCSV);
            this.panel2.Controls.Add(this.BTN_AddPatient);
            this.panel2.Location = new System.Drawing.Point(6, 57);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(381, 428);
            this.panel2.TabIndex = 19;
            // 
            // FRM_DrMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::FirstIteration.Properties.Resources.BGImg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(399, 497);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.LBL_HCPID);
            this.DoubleBuffered = true;
            this.Name = "FRM_DrMain";
            this.Text = "Doctor Page";
            this.Load += new System.EventHandler(this.FRM_DrMain_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LBL_HCPID;
        private System.Windows.Forms.ListBox LBX_Patients;
        private System.Windows.Forms.Button BTN_EditPatient;
        private System.Windows.Forms.Button BTN_RemovePatient;
        private System.Windows.Forms.Button BTN_AddPatient;
        private System.Windows.Forms.Button BTN_ImportCSV;
        private System.Windows.Forms.Button BTN_SignOut;
        private System.Windows.Forms.OpenFileDialog OFD_Import;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label LBL_Title;
        private System.Windows.Forms.Panel panel2;
    }
}