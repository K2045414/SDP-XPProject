namespace FirstIteration
{
    partial class FRM_AddPatient
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
            this.LBL_Title = new System.Windows.Forms.Label();
            this.LBX_AllPatients = new System.Windows.Forms.ListBox();
            this.BTN_Back = new System.Windows.Forms.Button();
            this.BTN_SelectPatient = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LBL_Title
            // 
            this.LBL_Title.AutoSize = true;
            this.LBL_Title.Location = new System.Drawing.Point(24, 19);
            this.LBL_Title.Name = "LBL_Title";
            this.LBL_Title.Size = new System.Drawing.Size(37, 13);
            this.LBL_Title.TabIndex = 0;
            this.LBL_Title.Text = "TITLE";
            // 
            // LBX_AllPatients
            // 
            this.LBX_AllPatients.FormattingEnabled = true;
            this.LBX_AllPatients.Location = new System.Drawing.Point(27, 52);
            this.LBX_AllPatients.Name = "LBX_AllPatients";
            this.LBX_AllPatients.Size = new System.Drawing.Size(314, 238);
            this.LBX_AllPatients.TabIndex = 1;
            // 
            // BTN_Back
            // 
            this.BTN_Back.Location = new System.Drawing.Point(27, 323);
            this.BTN_Back.Name = "BTN_Back";
            this.BTN_Back.Size = new System.Drawing.Size(116, 56);
            this.BTN_Back.TabIndex = 2;
            this.BTN_Back.Text = "Back";
            this.BTN_Back.UseVisualStyleBackColor = true;
            this.BTN_Back.Click += new System.EventHandler(this.BTN_Back_Click);
            // 
            // BTN_SelectPatient
            // 
            this.BTN_SelectPatient.Location = new System.Drawing.Point(225, 323);
            this.BTN_SelectPatient.Name = "BTN_SelectPatient";
            this.BTN_SelectPatient.Size = new System.Drawing.Size(116, 56);
            this.BTN_SelectPatient.TabIndex = 3;
            this.BTN_SelectPatient.Text = "Add Patient to care";
            this.BTN_SelectPatient.UseVisualStyleBackColor = true;
            // 
            // FRM_AddPatient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 416);
            this.Controls.Add(this.BTN_SelectPatient);
            this.Controls.Add(this.BTN_Back);
            this.Controls.Add(this.LBX_AllPatients);
            this.Controls.Add(this.LBL_Title);
            this.Name = "FRM_AddPatient";
            this.Text = "Add Patient";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LBL_Title;
        private System.Windows.Forms.ListBox LBX_AllPatients;
        private System.Windows.Forms.Button BTN_Back;
        private System.Windows.Forms.Button BTN_SelectPatient;
    }
}