﻿namespace FirstIteration
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
            this.components = new System.ComponentModel.Container();
            this.BTN_Calculate = new System.Windows.Forms.Button();
            this.RTB_Creatinine = new System.Windows.Forms.RichTextBox();
            this.LBL_NHSID = new System.Windows.Forms.Label();
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
            this.ERR_Validation = new System.Windows.Forms.ErrorProvider(this.components);
            this.BTN_MoreInfo = new System.Windows.Forms.Button();
            this.LBL_Height = new System.Windows.Forms.Label();
            this.RTB_Weight = new System.Windows.Forms.RichTextBox();
            this.RTB_Height = new System.Windows.Forms.RichTextBox();
            this.LBL_Weight = new System.Windows.Forms.Label();
            this.BTN_Edit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ERR_Validation)).BeginInit();
            this.SuspendLayout();
            // 
            // BTN_Calculate
            // 
            this.BTN_Calculate.Location = new System.Drawing.Point(388, 637);
            this.BTN_Calculate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BTN_Calculate.Name = "BTN_Calculate";
            this.BTN_Calculate.Size = new System.Drawing.Size(153, 80);
            this.BTN_Calculate.TabIndex = 0;
            this.BTN_Calculate.Text = "Calculate";
            this.BTN_Calculate.UseVisualStyleBackColor = true;
            this.BTN_Calculate.Click += new System.EventHandler(this.BTN_Calculate_Click);
            // 
            // RTB_Creatinine
            // 
            this.RTB_Creatinine.Location = new System.Drawing.Point(201, 97);
            this.RTB_Creatinine.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.RTB_Creatinine.Name = "RTB_Creatinine";
            this.RTB_Creatinine.Size = new System.Drawing.Size(338, 30);
            this.RTB_Creatinine.TabIndex = 2;
            this.RTB_Creatinine.Text = "";
            // 
            // LBL_NHSID
            // 
            this.LBL_NHSID.AutoSize = true;
            this.LBL_NHSID.Location = new System.Drawing.Point(228, 34);
            this.LBL_NHSID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LBL_NHSID.Name = "LBL_NHSID";
            this.LBL_NHSID.Size = new System.Drawing.Size(64, 20);
            this.LBL_NHSID.TabIndex = 6;
            this.LBL_NHSID.Text = "NHS ID";
            // 
            // CBX_Ethnicity
            // 
            this.CBX_Ethnicity.FormattingEnabled = true;
            this.CBX_Ethnicity.Items.AddRange(new object[] {
            "Black",
            "Other"});
            this.CBX_Ethnicity.Location = new System.Drawing.Point(196, 291);
            this.CBX_Ethnicity.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CBX_Ethnicity.Name = "CBX_Ethnicity";
            this.CBX_Ethnicity.Size = new System.Drawing.Size(338, 28);
            this.CBX_Ethnicity.TabIndex = 15;
            // 
            // CBX_Gender
            // 
            this.CBX_Gender.FormattingEnabled = true;
            this.CBX_Gender.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.CBX_Gender.Location = new System.Drawing.Point(196, 237);
            this.CBX_Gender.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CBX_Gender.Name = "CBX_Gender";
            this.CBX_Gender.Size = new System.Drawing.Size(338, 28);
            this.CBX_Gender.TabIndex = 16;
            // 
            // CBX_Calculation
            // 
            this.CBX_Calculation.FormattingEnabled = true;
            this.CBX_Calculation.Items.AddRange(new object[] {
            "MDRD",
            "CKDEPI",
            "Cockroft-Gault",
            "All"});
            this.CBX_Calculation.Location = new System.Drawing.Point(196, 332);
            this.CBX_Calculation.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CBX_Calculation.Name = "CBX_Calculation";
            this.CBX_Calculation.Size = new System.Drawing.Size(338, 28);
            this.CBX_Calculation.TabIndex = 17;
            this.CBX_Calculation.SelectedIndexChanged += new System.EventHandler(this.CBX_Calculation_SelectedIndexChanged);
            // 
            // RTB_eGFR
            // 
            this.RTB_eGFR.Location = new System.Drawing.Point(201, 520);
            this.RTB_eGFR.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.RTB_eGFR.Name = "RTB_eGFR";
            this.RTB_eGFR.Size = new System.Drawing.Size(338, 69);
            this.RTB_eGFR.TabIndex = 18;
            this.RTB_eGFR.Text = "";
            // 
            // LBL_Creatinine
            // 
            this.LBL_Creatinine.AutoSize = true;
            this.LBL_Creatinine.Location = new System.Drawing.Point(18, 102);
            this.LBL_Creatinine.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LBL_Creatinine.Name = "LBL_Creatinine";
            this.LBL_Creatinine.Size = new System.Drawing.Size(81, 20);
            this.LBL_Creatinine.TabIndex = 19;
            this.LBL_Creatinine.Text = "Creatinine";
            // 
            // LBL_DOB
            // 
            this.LBL_DOB.AutoSize = true;
            this.LBL_DOB.Location = new System.Drawing.Point(18, 180);
            this.LBL_DOB.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LBL_DOB.Name = "LBL_DOB";
            this.LBL_DOB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LBL_DOB.Size = new System.Drawing.Size(102, 20);
            this.LBL_DOB.TabIndex = 20;
            this.LBL_DOB.Text = "Date Of Birth";
            // 
            // LBL_Gender
            // 
            this.LBL_Gender.AutoSize = true;
            this.LBL_Gender.Location = new System.Drawing.Point(14, 242);
            this.LBL_Gender.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LBL_Gender.Name = "LBL_Gender";
            this.LBL_Gender.Size = new System.Drawing.Size(100, 20);
            this.LBL_Gender.TabIndex = 21;
            this.LBL_Gender.Text = "Birth Gender";
            // 
            // LBL_Ethnicity
            // 
            this.LBL_Ethnicity.AutoSize = true;
            this.LBL_Ethnicity.Location = new System.Drawing.Point(14, 295);
            this.LBL_Ethnicity.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LBL_Ethnicity.Name = "LBL_Ethnicity";
            this.LBL_Ethnicity.Size = new System.Drawing.Size(69, 20);
            this.LBL_Ethnicity.TabIndex = 22;
            this.LBL_Ethnicity.Text = "Ethnicity";
            // 
            // LBL_Calculation
            // 
            this.LBL_Calculation.AutoSize = true;
            this.LBL_Calculation.Location = new System.Drawing.Point(14, 345);
            this.LBL_Calculation.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LBL_Calculation.Name = "LBL_Calculation";
            this.LBL_Calculation.Size = new System.Drawing.Size(166, 20);
            this.LBL_Calculation.TabIndex = 23;
            this.LBL_Calculation.Text = "Calculation to be used";
            // 
            // LBL_eGFR
            // 
            this.LBL_eGFR.AutoSize = true;
            this.LBL_eGFR.Location = new System.Drawing.Point(18, 538);
            this.LBL_eGFR.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LBL_eGFR.Name = "LBL_eGFR";
            this.LBL_eGFR.Size = new System.Drawing.Size(53, 20);
            this.LBL_eGFR.TabIndex = 24;
            this.LBL_eGFR.Text = "eGFR";
            // 
            // BTN_Back
            // 
            this.BTN_Back.Location = new System.Drawing.Point(22, 637);
            this.BTN_Back.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BTN_Back.Name = "BTN_Back";
            this.BTN_Back.Size = new System.Drawing.Size(148, 80);
            this.BTN_Back.TabIndex = 25;
            this.BTN_Back.Text = "Back";
            this.BTN_Back.UseVisualStyleBackColor = true;
            this.BTN_Back.Click += new System.EventHandler(this.BTN_Back_Click);
            // 
            // DTP_DOB
            // 
            this.DTP_DOB.Location = new System.Drawing.Point(201, 180);
            this.DTP_DOB.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DTP_DOB.Name = "DTP_DOB";
            this.DTP_DOB.Size = new System.Drawing.Size(338, 26);
            this.DTP_DOB.TabIndex = 26;
            // 
            // RBN_mgdL
            // 
            this.RBN_mgdL.AutoSize = true;
            this.RBN_mgdL.Location = new System.Drawing.Point(201, 138);
            this.RBN_mgdL.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.RBN_mgdL.Name = "RBN_mgdL";
            this.RBN_mgdL.Size = new System.Drawing.Size(78, 24);
            this.RBN_mgdL.TabIndex = 27;
            this.RBN_mgdL.TabStop = true;
            this.RBN_mgdL.Text = "mg/dL";
            this.RBN_mgdL.UseVisualStyleBackColor = true;
            this.RBN_mgdL.CheckedChanged += new System.EventHandler(this.RBN_mgdL_CheckedChanged);
            // 
            // RBN_umolL
            // 
            this.RBN_umolL.AutoSize = true;
            this.RBN_umolL.Location = new System.Drawing.Point(327, 137);
            this.RBN_umolL.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.RBN_umolL.Name = "RBN_umolL";
            this.RBN_umolL.Size = new System.Drawing.Size(80, 24);
            this.RBN_umolL.TabIndex = 28;
            this.RBN_umolL.TabStop = true;
            this.RBN_umolL.Text = "µmol/L";
            this.RBN_umolL.UseVisualStyleBackColor = true;
            this.RBN_umolL.CheckedChanged += new System.EventHandler(this.RBN_umolL_CheckedChanged);
            // 
            // ERR_Validation
            // 
            this.ERR_Validation.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink;
            this.ERR_Validation.ContainerControl = this;
            // 
            // BTN_MoreInfo
            // 
            this.BTN_MoreInfo.Location = new System.Drawing.Point(22, 742);
            this.BTN_MoreInfo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BTN_MoreInfo.Name = "BTN_MoreInfo";
            this.BTN_MoreInfo.Size = new System.Drawing.Size(524, 80);
            this.BTN_MoreInfo.TabIndex = 29;
            this.BTN_MoreInfo.Text = "See what to do next";
            this.BTN_MoreInfo.UseVisualStyleBackColor = true;
            this.BTN_MoreInfo.Click += new System.EventHandler(this.BTN_MoreInfo_Click);
            // 
            // LBL_Height
            // 
            this.LBL_Height.AutoSize = true;
            this.LBL_Height.Location = new System.Drawing.Point(14, 426);
            this.LBL_Height.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LBL_Height.Name = "LBL_Height";
            this.LBL_Height.Size = new System.Drawing.Size(56, 20);
            this.LBL_Height.TabIndex = 31;
            this.LBL_Height.Text = "Height";
            this.LBL_Height.Visible = false;
            // 
            // RTB_Weight
            // 
            this.RTB_Weight.Location = new System.Drawing.Point(201, 380);
            this.RTB_Weight.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.RTB_Weight.Name = "RTB_Weight";
            this.RTB_Weight.Size = new System.Drawing.Size(338, 30);
            this.RTB_Weight.TabIndex = 30;
            this.RTB_Weight.Text = "";
            this.RTB_Weight.Visible = false;
            // 
            // RTB_Height
            // 
            this.RTB_Height.Location = new System.Drawing.Point(201, 426);
            this.RTB_Height.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.RTB_Height.Name = "RTB_Height";
            this.RTB_Height.Size = new System.Drawing.Size(338, 30);
            this.RTB_Height.TabIndex = 32;
            this.RTB_Height.Text = "";
            this.RTB_Height.Visible = false;
            // 
            // LBL_Weight
            // 
            this.LBL_Weight.AutoSize = true;
            this.LBL_Weight.Location = new System.Drawing.Point(18, 385);
            this.LBL_Weight.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LBL_Weight.Name = "LBL_Weight";
            this.LBL_Weight.Size = new System.Drawing.Size(90, 20);
            this.LBL_Weight.TabIndex = 33;
            this.LBL_Weight.Text = "Weight (kg)";
            this.LBL_Weight.Visible = false;
            // 
            // BTN_Edit
            // 
            this.BTN_Edit.Location = new System.Drawing.Point(196, 637);
            this.BTN_Edit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BTN_Edit.Name = "BTN_Edit";
            this.BTN_Edit.Size = new System.Drawing.Size(153, 80);
            this.BTN_Edit.TabIndex = 34;
            this.BTN_Edit.Text = "Edit";
            this.BTN_Edit.UseVisualStyleBackColor = true;
            // 
            // FRM_Calculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 840);
            this.Controls.Add(this.BTN_Edit);
            this.Controls.Add(this.LBL_Weight);
            this.Controls.Add(this.RTB_Height);
            this.Controls.Add(this.LBL_Height);
            this.Controls.Add(this.RTB_Weight);
            this.Controls.Add(this.BTN_MoreInfo);
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
            this.Controls.Add(this.LBL_NHSID);
            this.Controls.Add(this.RTB_Creatinine);
            this.Controls.Add(this.BTN_Calculate);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FRM_Calculator";
            this.Text = "Calculator";
            ((System.ComponentModel.ISupportInitialize)(this.ERR_Validation)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BTN_Calculate;
        private System.Windows.Forms.RichTextBox RTB_Creatinine;
        private System.Windows.Forms.Label LBL_NHSID;
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
        private System.Windows.Forms.ErrorProvider ERR_Validation;
        private System.Windows.Forms.Button BTN_Edit;
        private System.Windows.Forms.Label LBL_Weight;
        private System.Windows.Forms.RichTextBox RTB_Height;
        private System.Windows.Forms.Label LBL_Height;
        private System.Windows.Forms.RichTextBox RTB_Weight;
        private System.Windows.Forms.Button BTN_MoreInfo;
    }
}

