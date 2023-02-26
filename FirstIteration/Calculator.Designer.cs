namespace FirstIteration
{
    partial class FRM_Calculator
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
            this.BTN_Calculate = new System.Windows.Forms.Button();
            this.RTB_Creatinine = new System.Windows.Forms.RichTextBox();
            this.LBL_Title = new System.Windows.Forms.Label();
            this.CBX_Ethnicity = new System.Windows.Forms.ComboBox();
            this.CBX_Gender = new System.Windows.Forms.ComboBox();
            this.CBX_Calculation = new System.Windows.Forms.ComboBox();
            this.RTB_eGFR = new System.Windows.Forms.RichTextBox();
            this.LBL_Creatinine = new System.Windows.Forms.Label();
            this.LBL_DOB = new System.Windows.Forms.Label();
            this.LBL_Gender = new System.Windows.Forms.Label();
            this.LBL_Ethnicity = new System.Windows.Forms.Label();
            this.LBL_Calculation = new System.Windows.Forms.Label();
            this.LBL_eGFR = new System.Windows.Forms.Label();
            this.BTN_Back = new System.Windows.Forms.Button();
            this.DTP_DOB = new System.Windows.Forms.DateTimePicker();
            this.RBN_mgdL = new System.Windows.Forms.RadioButton();
            this.RBN_umolL = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // BTN_Calculate
            // 
            this.BTN_Calculate.Location = new System.Drawing.Point(216, 320);
            this.BTN_Calculate.Name = "BTN_Calculate";
            this.BTN_Calculate.Size = new System.Drawing.Size(145, 52);
            this.BTN_Calculate.TabIndex = 0;
            this.BTN_Calculate.Text = "Calculate";
            this.BTN_Calculate.UseVisualStyleBackColor = true;
            this.BTN_Calculate.Click += new System.EventHandler(this.BTN_Calculate_Click);
            // 
            // RTB_Creatinine
            // 
            this.RTB_Creatinine.Location = new System.Drawing.Point(134, 63);
            this.RTB_Creatinine.Name = "RTB_Creatinine";
            this.RTB_Creatinine.Size = new System.Drawing.Size(227, 21);
            this.RTB_Creatinine.TabIndex = 2;
            this.RTB_Creatinine.Text = "";
            // 
            // LBL_Title
            // 
            this.LBL_Title.AutoSize = true;
            this.LBL_Title.Location = new System.Drawing.Point(152, 22);
            this.LBL_Title.Name = "LBL_Title";
            this.LBL_Title.Size = new System.Drawing.Size(54, 13);
            this.LBL_Title.TabIndex = 6;
            this.LBL_Title.Text = "Calculator";
            // 
            // CBX_Ethnicity
            // 
            this.CBX_Ethnicity.FormattingEnabled = true;
            this.CBX_Ethnicity.Items.AddRange(new object[] {
            "Black",
            "Other"});
            this.CBX_Ethnicity.Location = new System.Drawing.Point(134, 188);
            this.CBX_Ethnicity.Name = "CBX_Ethnicity";
            this.CBX_Ethnicity.Size = new System.Drawing.Size(227, 21);
            this.CBX_Ethnicity.TabIndex = 15;
            // 
            // CBX_Gender
            // 
            this.CBX_Gender.FormattingEnabled = true;
            this.CBX_Gender.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.CBX_Gender.Location = new System.Drawing.Point(134, 153);
            this.CBX_Gender.Name = "CBX_Gender";
            this.CBX_Gender.Size = new System.Drawing.Size(227, 21);
            this.CBX_Gender.TabIndex = 16;
            // 
            // CBX_Calculation
            // 
            this.CBX_Calculation.FormattingEnabled = true;
            this.CBX_Calculation.Location = new System.Drawing.Point(134, 215);
            this.CBX_Calculation.Name = "CBX_Calculation";
            this.CBX_Calculation.Size = new System.Drawing.Size(227, 21);
            this.CBX_Calculation.TabIndex = 17;
            // 
            // RTB_eGFR
            // 
            this.RTB_eGFR.Location = new System.Drawing.Point(134, 277);
            this.RTB_eGFR.Name = "RTB_eGFR";
            this.RTB_eGFR.Size = new System.Drawing.Size(227, 21);
            this.RTB_eGFR.TabIndex = 18;
            this.RTB_eGFR.Text = "";
            // 
            // LBL_Creatinine
            // 
            this.LBL_Creatinine.AutoSize = true;
            this.LBL_Creatinine.Location = new System.Drawing.Point(12, 66);
            this.LBL_Creatinine.Name = "LBL_Creatinine";
            this.LBL_Creatinine.Size = new System.Drawing.Size(54, 13);
            this.LBL_Creatinine.TabIndex = 19;
            this.LBL_Creatinine.Text = "Creatinine";
            // 
            // LBL_DOB
            // 
            this.LBL_DOB.AutoSize = true;
            this.LBL_DOB.Location = new System.Drawing.Point(12, 117);
            this.LBL_DOB.Name = "LBL_DOB";
            this.LBL_DOB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LBL_DOB.Size = new System.Drawing.Size(68, 13);
            this.LBL_DOB.TabIndex = 20;
            this.LBL_DOB.Text = "Date Of Birth";
            // 
            // LBL_Gender
            // 
            this.LBL_Gender.AutoSize = true;
            this.LBL_Gender.Location = new System.Drawing.Point(12, 156);
            this.LBL_Gender.Name = "LBL_Gender";
            this.LBL_Gender.Size = new System.Drawing.Size(66, 13);
            this.LBL_Gender.TabIndex = 21;
            this.LBL_Gender.Text = "Birth Gender";
            // 
            // LBL_Ethnicity
            // 
            this.LBL_Ethnicity.AutoSize = true;
            this.LBL_Ethnicity.Location = new System.Drawing.Point(12, 191);
            this.LBL_Ethnicity.Name = "LBL_Ethnicity";
            this.LBL_Ethnicity.Size = new System.Drawing.Size(47, 13);
            this.LBL_Ethnicity.TabIndex = 22;
            this.LBL_Ethnicity.Text = "Ethnicity";
            // 
            // LBL_Calculation
            // 
            this.LBL_Calculation.AutoSize = true;
            this.LBL_Calculation.Location = new System.Drawing.Point(12, 223);
            this.LBL_Calculation.Name = "LBL_Calculation";
            this.LBL_Calculation.Size = new System.Drawing.Size(112, 13);
            this.LBL_Calculation.TabIndex = 23;
            this.LBL_Calculation.Text = "Calculation to be used";
            // 
            // LBL_eGFR
            // 
            this.LBL_eGFR.AutoSize = true;
            this.LBL_eGFR.Location = new System.Drawing.Point(12, 280);
            this.LBL_eGFR.Name = "LBL_eGFR";
            this.LBL_eGFR.Size = new System.Drawing.Size(35, 13);
            this.LBL_eGFR.TabIndex = 24;
            this.LBL_eGFR.Text = "eGFR";
            // 
            // BTN_Back
            // 
            this.BTN_Back.Location = new System.Drawing.Point(12, 320);
            this.BTN_Back.Name = "BTN_Back";
            this.BTN_Back.Size = new System.Drawing.Size(145, 52);
            this.BTN_Back.TabIndex = 25;
            this.BTN_Back.Text = "Back";
            this.BTN_Back.UseVisualStyleBackColor = true;
            this.BTN_Back.Click += new System.EventHandler(this.BTN_Back_Click);
            // 
            // DTP_DOB
            // 
            this.DTP_DOB.Location = new System.Drawing.Point(134, 117);
            this.DTP_DOB.Name = "DTP_DOB";
            this.DTP_DOB.Size = new System.Drawing.Size(227, 20);
            this.DTP_DOB.TabIndex = 26;
            // 
            // RBN_mgdL
            // 
            this.RBN_mgdL.AutoSize = true;
            this.RBN_mgdL.Location = new System.Drawing.Point(134, 90);
            this.RBN_mgdL.Name = "RBN_mgdL";
            this.RBN_mgdL.Size = new System.Drawing.Size(56, 17);
            this.RBN_mgdL.TabIndex = 27;
            this.RBN_mgdL.TabStop = true;
            this.RBN_mgdL.Text = "mg/dL";
            this.RBN_mgdL.UseVisualStyleBackColor = true;
            this.RBN_mgdL.CheckedChanged += new System.EventHandler(this.RBN_mgdL_CheckedChanged);
            // 
            // RBN_umolL
            // 
            this.RBN_umolL.AutoSize = true;
            this.RBN_umolL.Location = new System.Drawing.Point(225, 90);
            this.RBN_umolL.Name = "RBN_umolL";
            this.RBN_umolL.Size = new System.Drawing.Size(58, 17);
            this.RBN_umolL.TabIndex = 28;
            this.RBN_umolL.TabStop = true;
            this.RBN_umolL.Text = "µmol/L";
            this.RBN_umolL.UseVisualStyleBackColor = true;
            this.RBN_umolL.CheckedChanged += new System.EventHandler(this.RBN_umolL_CheckedChanged);
            // 
            // FRM_Calculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 381);
            this.Controls.Add(this.RBN_umolL);
            this.Controls.Add(this.RBN_mgdL);
            this.Controls.Add(this.DTP_DOB);
            this.Controls.Add(this.BTN_Back);
            this.Controls.Add(this.LBL_eGFR);
            this.Controls.Add(this.LBL_Calculation);
            this.Controls.Add(this.LBL_Ethnicity);
            this.Controls.Add(this.LBL_Gender);
            this.Controls.Add(this.LBL_DOB);
            this.Controls.Add(this.LBL_Creatinine);
            this.Controls.Add(this.RTB_eGFR);
            this.Controls.Add(this.CBX_Calculation);
            this.Controls.Add(this.CBX_Gender);
            this.Controls.Add(this.CBX_Ethnicity);
            this.Controls.Add(this.LBL_Title);
            this.Controls.Add(this.RTB_Creatinine);
            this.Controls.Add(this.BTN_Calculate);
            this.Name = "FRM_Calculator";
            this.Text = "Calculator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BTN_Calculate;
        private System.Windows.Forms.RichTextBox RTB_Creatinine;
        private System.Windows.Forms.Label LBL_Title;
        private System.Windows.Forms.ComboBox CBX_Ethnicity;
        private System.Windows.Forms.ComboBox CBX_Gender;
        private System.Windows.Forms.ComboBox CBX_Calculation;
        private System.Windows.Forms.RichTextBox RTB_eGFR;
        private System.Windows.Forms.Label LBL_Creatinine;
        private System.Windows.Forms.Label LBL_DOB;
        private System.Windows.Forms.Label LBL_Gender;
        private System.Windows.Forms.Label LBL_Ethnicity;
        private System.Windows.Forms.Label LBL_Calculation;
        private System.Windows.Forms.Label LBL_eGFR;
        private System.Windows.Forms.Button BTN_Back;
        private System.Windows.Forms.DateTimePicker DTP_DOB;
        private System.Windows.Forms.RadioButton RBN_mgdL;
        private System.Windows.Forms.RadioButton RBN_umolL;
    }
}

