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
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // LBL_Title
            // 
            this.LBL_Title.AutoSize = true;
            this.LBL_Title.Font = new System.Drawing.Font("Arial", 20F);
            this.LBL_Title.ForeColor = System.Drawing.Color.White;
            this.LBL_Title.Location = new System.Drawing.Point(166, 17);
            this.LBL_Title.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LBL_Title.Name = "LBL_Title";
            this.LBL_Title.Size = new System.Drawing.Size(224, 45);
            this.LBL_Title.TabIndex = 0;
            this.LBL_Title.Text = "Add Patient";
            // 
            // LBX_AllPatients
            // 
            this.LBX_AllPatients.BackColor = System.Drawing.Color.LightSteelBlue;
            this.LBX_AllPatients.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LBX_AllPatients.Font = new System.Drawing.Font("Arial", 8F);
            this.LBX_AllPatients.FormattingEnabled = true;
            this.LBX_AllPatients.ItemHeight = 18;
            this.LBX_AllPatients.Location = new System.Drawing.Point(24, 32);
            this.LBX_AllPatients.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.LBX_AllPatients.Name = "LBX_AllPatients";
            this.LBX_AllPatients.Size = new System.Drawing.Size(470, 344);
            this.LBX_AllPatients.TabIndex = 1;
            // 
            // BTN_Back
            // 
            this.BTN_Back.BackgroundImage = global::FirstIteration.Properties.Resources.Button3;
            this.BTN_Back.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BTN_Back.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTN_Back.FlatAppearance.BorderSize = 0;
            this.BTN_Back.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.BTN_Back.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.BTN_Back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_Back.Font = new System.Drawing.Font("Arial", 18F);
            this.BTN_Back.ForeColor = System.Drawing.Color.White;
            this.BTN_Back.Location = new System.Drawing.Point(24, 437);
            this.BTN_Back.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BTN_Back.Name = "BTN_Back";
            this.BTN_Back.Size = new System.Drawing.Size(228, 91);
            this.BTN_Back.TabIndex = 2;
            this.BTN_Back.Text = "Back";
            this.BTN_Back.UseVisualStyleBackColor = true;
            this.BTN_Back.Click += new System.EventHandler(this.BTN_Back_Click);
            // 
            // BTN_SelectPatient
            // 
            this.BTN_SelectPatient.BackgroundImage = global::FirstIteration.Properties.Resources.Button3;
            this.BTN_SelectPatient.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BTN_SelectPatient.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTN_SelectPatient.FlatAppearance.BorderSize = 0;
            this.BTN_SelectPatient.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.BTN_SelectPatient.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.BTN_SelectPatient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_SelectPatient.Font = new System.Drawing.Font("Arial", 14F);
            this.BTN_SelectPatient.ForeColor = System.Drawing.Color.White;
            this.BTN_SelectPatient.Location = new System.Drawing.Point(267, 437);
            this.BTN_SelectPatient.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BTN_SelectPatient.Name = "BTN_SelectPatient";
            this.BTN_SelectPatient.Size = new System.Drawing.Size(228, 91);
            this.BTN_SelectPatient.TabIndex = 3;
            this.BTN_SelectPatient.Text = "Add Patient to care";
            this.BTN_SelectPatient.UseVisualStyleBackColor = true;
            this.BTN_SelectPatient.Click += new System.EventHandler(this.BTN_SelectPatient_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = global::FirstIteration.Properties.Resources.HeaderImg;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.LBL_Title);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(555, 71);
            this.panel1.TabIndex = 4;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::FirstIteration.Properties.Resources.LogoImg;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(116, 66);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BackgroundImage = global::FirstIteration.Properties.Resources.BufferImg;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Controls.Add(this.LBX_AllPatients);
            this.panel2.Controls.Add(this.BTN_Back);
            this.panel2.Controls.Add(this.BTN_SelectPatient);
            this.panel2.Location = new System.Drawing.Point(18, 80);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(519, 554);
            this.panel2.TabIndex = 5;
            // 
            // FRM_AddPatient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackgroundImage = global::FirstIteration.Properties.Resources.BGImg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(555, 648);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FRM_AddPatient";
            this.Text = "Add Patient";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LBL_Title;
        private System.Windows.Forms.ListBox LBX_AllPatients;
        private System.Windows.Forms.Button BTN_Back;
        private System.Windows.Forms.Button BTN_SelectPatient;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
    }
}