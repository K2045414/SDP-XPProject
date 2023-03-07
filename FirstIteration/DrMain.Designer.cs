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
            this.LBX_Patients.FormattingEnabled = true;
            this.LBX_Patients.Location = new System.Drawing.Point(12, 51);
            this.LBX_Patients.Name = "LBX_Patients";
            this.LBX_Patients.Size = new System.Drawing.Size(375, 225);
            this.LBX_Patients.TabIndex = 1;
            // 
            // BTN_EditPatient
            // 
            this.BTN_EditPatient.Location = new System.Drawing.Point(196, 282);
            this.BTN_EditPatient.Name = "BTN_EditPatient";
            this.BTN_EditPatient.Size = new System.Drawing.Size(191, 53);
            this.BTN_EditPatient.TabIndex = 2;
            this.BTN_EditPatient.Text = "See selected patient data";
            this.BTN_EditPatient.UseVisualStyleBackColor = true;
            this.BTN_EditPatient.Click += new System.EventHandler(this.BTN_EditPatient_Click);
            // 
            // BTN_RemovePatient
            // 
            this.BTN_RemovePatient.Location = new System.Drawing.Point(196, 341);
            this.BTN_RemovePatient.Name = "BTN_RemovePatient";
            this.BTN_RemovePatient.Size = new System.Drawing.Size(191, 53);
            this.BTN_RemovePatient.TabIndex = 3;
            this.BTN_RemovePatient.Text = "Remove selected patient from care";
            this.BTN_RemovePatient.UseVisualStyleBackColor = true;
            // 
            // BTN_AddPatient
            // 
            this.BTN_AddPatient.Location = new System.Drawing.Point(264, 432);
            this.BTN_AddPatient.Name = "BTN_AddPatient";
            this.BTN_AddPatient.Size = new System.Drawing.Size(123, 53);
            this.BTN_AddPatient.TabIndex = 4;
            this.BTN_AddPatient.Text = "Add new patient";
            this.BTN_AddPatient.UseVisualStyleBackColor = true;
            this.BTN_AddPatient.Click += new System.EventHandler(this.BTN_AddPatient_Click);
            // 
            // BTN_ImportCSV
            // 
            this.BTN_ImportCSV.Location = new System.Drawing.Point(135, 432);
            this.BTN_ImportCSV.Name = "BTN_ImportCSV";
            this.BTN_ImportCSV.Size = new System.Drawing.Size(123, 53);
            this.BTN_ImportCSV.TabIndex = 5;
            this.BTN_ImportCSV.Text = "Import from CSV";
            this.BTN_ImportCSV.UseVisualStyleBackColor = true;
            this.BTN_ImportCSV.Click += new System.EventHandler(this.BTN_ImportCSV_Click);
            // 
            // BTN_SignOut
            // 
            this.BTN_SignOut.Location = new System.Drawing.Point(6, 432);
            this.BTN_SignOut.Name = "BTN_SignOut";
            this.BTN_SignOut.Size = new System.Drawing.Size(123, 53);
            this.BTN_SignOut.TabIndex = 6;
            this.BTN_SignOut.Text = "Sign out";
            this.BTN_SignOut.UseVisualStyleBackColor = true;
            this.BTN_SignOut.Click += new System.EventHandler(this.BTN_SignOut_Click);
            // 
            // FRM_DrMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 497);
            this.Controls.Add(this.BTN_SignOut);
            this.Controls.Add(this.BTN_ImportCSV);
            this.Controls.Add(this.BTN_AddPatient);
            this.Controls.Add(this.BTN_RemovePatient);
            this.Controls.Add(this.BTN_EditPatient);
            this.Controls.Add(this.LBX_Patients);
            this.Controls.Add(this.LBL_HCPID);
            this.Name = "FRM_DrMain";
            this.Text = "Doctor Page";
            this.Load += new System.EventHandler(this.FRM_DrMain_Load);
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
    }
}