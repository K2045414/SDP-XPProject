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
            this.components = new System.ComponentModel.Container();
            this.BTN_Calculate = new System.Windows.Forms.Button();
            this.RTB_Creatinine = new System.Windows.Forms.RichTextBox();
            this.LBL_Title = new System.Windows.Forms.Label();
            this.CBX_Ethnicity = new System.Windows.Forms.ComboBox();
            this.CBX_Gender = new System.Windows.Forms.ComboBox();
            this.CBX_Calculation = new System.Windows.Forms.ComboBox();
            this.RTB_eGFR = new System.Windows.Forms.RichTextBox();
            this.LBL_Creatinine = new System.Windows.Forms.Label();
            this.LBL_Age = new System.Windows.Forms.Label();
            this.LBL_Gender = new System.Windows.Forms.Label();
            this.LBL_Ethnicity = new System.Windows.Forms.Label();
            this.LBL_Calculation = new System.Windows.Forms.Label();
            this.LBL_eGFR = new System.Windows.Forms.Label();
            this.BTN_Back = new System.Windows.Forms.Button();
            this.RBN_mgdL = new System.Windows.Forms.RadioButton();
            this.RBN_umolL = new System.Windows.Forms.RadioButton();
            this.ERR_Validation = new System.Windows.Forms.ErrorProvider(this.components);
            this.BTN_MoreInfo = new System.Windows.Forms.Button();
            this.LBL_Height = new System.Windows.Forms.Label();
            this.RTB_Weight = new System.Windows.Forms.RichTextBox();
            this.RTB_Height = new System.Windows.Forms.RichTextBox();
            this.LBL_Weight = new System.Windows.Forms.Label();
            this.BTN_Edit = new System.Windows.Forms.Button();
            this.RTB_Age = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.ERR_Validation)).BeginInit();
            this.SuspendLayout();
            // 
            // BTN_Calculate
            // 
            this.BTN_Calculate.Location = new System.Drawing.Point(259, 414);
            this.BTN_Calculate.Name = "BTN_Calculate";
            this.BTN_Calculate.Size = new System.Drawing.Size(102, 52);
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
            this.LBL_Title.Location = new System.Drawing.Point(86, 22);
            this.LBL_Title.Name = "LBL_Title";
            this.LBL_Title.Size = new System.Drawing.Size(208, 24);
            this.LBL_Title.TabIndex = 6;
            this.LBL_Title.Text = "Calculator";
            // 
            // CBX_Ethnicity
            // 
            this.CBX_Ethnicity.FormattingEnabled = true;
            this.CBX_Ethnicity.Items.AddRange(new object[] {
            "Black",
            "Other"});
            this.CBX_Ethnicity.Location = new System.Drawing.Point(131, 189);
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
            this.CBX_Gender.Location = new System.Drawing.Point(131, 154);
            this.CBX_Gender.Name = "CBX_Gender";
            this.CBX_Gender.Size = new System.Drawing.Size(227, 21);
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
            this.CBX_Calculation.Location = new System.Drawing.Point(131, 216);
            this.CBX_Calculation.Name = "CBX_Calculation";
            this.CBX_Calculation.Size = new System.Drawing.Size(227, 21);
            this.CBX_Calculation.TabIndex = 17;
            this.CBX_Calculation.Text = "MDRD";
            this.CBX_Calculation.SelectedIndexChanged += new System.EventHandler(this.CBX_Calculation_SelectedIndexChanged);
            // 
            // RTB_eGFR
            // 
            this.RTB_eGFR.Location = new System.Drawing.Point(134, 338);
            this.RTB_eGFR.Name = "RTB_eGFR";
            this.RTB_eGFR.Size = new System.Drawing.Size(227, 46);
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
            // LBL_Age
            // 
            this.LBL_Age.AutoSize = true;
            this.LBL_Age.Location = new System.Drawing.Point(12, 117);
            this.LBL_Age.Name = "LBL_Age";
            this.LBL_Age.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LBL_Age.Size = new System.Drawing.Size(26, 13);
            this.LBL_Age.TabIndex = 20;
            this.LBL_Age.Text = "Age";
            // 
            // LBL_Gender
            // 
            this.LBL_Gender.AutoSize = true;
            this.LBL_Gender.Location = new System.Drawing.Point(9, 157);
            this.LBL_Gender.Name = "LBL_Gender";
            this.LBL_Gender.Size = new System.Drawing.Size(66, 13);
            this.LBL_Gender.TabIndex = 21;
            this.LBL_Gender.Text = "Birth Gender";
            // 
            // LBL_Ethnicity
            // 
            this.LBL_Ethnicity.AutoSize = true;
            this.LBL_Ethnicity.Location = new System.Drawing.Point(9, 192);
            this.LBL_Ethnicity.Name = "LBL_Ethnicity";
            this.LBL_Ethnicity.Size = new System.Drawing.Size(47, 13);
            this.LBL_Ethnicity.TabIndex = 22;
            this.LBL_Ethnicity.Text = "Ethnicity";
            // 
            // LBL_Calculation
            // 
            this.LBL_Calculation.AutoSize = true;
            this.LBL_Calculation.Location = new System.Drawing.Point(9, 224);
            this.LBL_Calculation.Name = "LBL_Calculation";
            this.LBL_Calculation.Size = new System.Drawing.Size(112, 13);
            this.LBL_Calculation.TabIndex = 23;
            this.LBL_Calculation.Text = "Calculation to be used";
            // 
            // LBL_eGFR
            // 
            this.LBL_eGFR.AutoSize = true;
            this.LBL_eGFR.Location = new System.Drawing.Point(12, 350);
            this.LBL_eGFR.Name = "LBL_eGFR";
            this.LBL_eGFR.Size = new System.Drawing.Size(35, 13);
            this.LBL_eGFR.TabIndex = 24;
            this.LBL_eGFR.Text = "eGFR";
            // 
            // BTN_Back
            // 
            this.BTN_Back.Location = new System.Drawing.Point(15, 414);
            this.BTN_Back.Name = "BTN_Back";
            this.BTN_Back.Size = new System.Drawing.Size(99, 52);
            this.BTN_Back.TabIndex = 25;
            this.BTN_Back.Text = "Back";
            this.BTN_Back.UseVisualStyleBackColor = true;
            this.BTN_Back.Click += new System.EventHandler(this.BTN_Back_Click);
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
            this.RBN_umolL.Location = new System.Drawing.Point(218, 89);
            this.RBN_umolL.Name = "RBN_umolL";
            this.RBN_umolL.Size = new System.Drawing.Size(58, 17);
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
            this.BTN_MoreInfo.Location = new System.Drawing.Point(22, 482);
            this.BTN_MoreInfo.Name = "BTN_MoreInfo";
            this.BTN_MoreInfo.Size = new System.Drawing.Size(349, 52);
            this.BTN_MoreInfo.TabIndex = 29;
            this.BTN_MoreInfo.Text = "See what to do next";
            this.BTN_MoreInfo.UseVisualStyleBackColor = true;
            this.BTN_MoreInfo.Visible = false;
            this.BTN_MoreInfo.Click += new System.EventHandler(this.BTN_MoreInfo_Click);
            // 
            // LBL_Height
            // 
            this.LBL_Height.AutoSize = true;
            this.LBL_Height.Location = new System.Drawing.Point(9, 277);
            this.LBL_Height.Name = "LBL_Height";
            this.LBL_Height.Size = new System.Drawing.Size(38, 13);
            this.LBL_Height.TabIndex = 31;
            this.LBL_Height.Text = "Height";
            this.LBL_Height.Visible = false;
            // 
            // RTB_Weight
            // 
            this.RTB_Weight.Location = new System.Drawing.Point(134, 247);
            this.RTB_Weight.Name = "RTB_Weight";
            this.RTB_Weight.Size = new System.Drawing.Size(227, 21);
            this.RTB_Weight.TabIndex = 30;
            this.RTB_Weight.Text = "";
            this.RTB_Weight.Visible = false;
            // 
            // RTB_Height
            // 
            this.RTB_Height.Location = new System.Drawing.Point(134, 277);
            this.RTB_Height.Name = "RTB_Height";
            this.RTB_Height.Size = new System.Drawing.Size(227, 21);
            this.RTB_Height.TabIndex = 32;
            this.RTB_Height.Text = "";
            this.RTB_Height.Visible = false;
            // 
            // LBL_Weight
            // 
            this.LBL_Weight.AutoSize = true;
            this.LBL_Weight.Location = new System.Drawing.Point(12, 250);
            this.LBL_Weight.Name = "LBL_Weight";
            this.LBL_Weight.Size = new System.Drawing.Size(62, 13);
            this.LBL_Weight.TabIndex = 33;
            this.LBL_Weight.Text = "Weight (kg)";
            this.LBL_Weight.Visible = false;
            // 
            // BTN_Edit
            // 
            this.BTN_Edit.Location = new System.Drawing.Point(131, 414);
            this.BTN_Edit.Name = "BTN_Edit";
            this.BTN_Edit.Size = new System.Drawing.Size(102, 52);
            this.BTN_Edit.TabIndex = 34;
            this.BTN_Edit.Text = "Edit";
            this.BTN_Edit.UseVisualStyleBackColor = true;
            this.BTN_Edit.Visible = false;
            this.BTN_Edit.Click += new System.EventHandler(this.BTN_Edit_Click);
            // 
            // RTB_Age
            // 
            this.RTB_Age.Location = new System.Drawing.Point(131, 117);
            this.RTB_Age.Name = "RTB_Age";
            this.RTB_Age.Size = new System.Drawing.Size(227, 21);
            this.RTB_Age.TabIndex = 35;
            this.RTB_Age.Text = "";
            // 
            // FRM_Calculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 546);
            this.Controls.Add(this.RTB_Age);
            this.Controls.Add(this.BTN_Edit);
            this.Controls.Add(this.LBL_Weight);
            this.Controls.Add(this.RTB_Height);
            this.Controls.Add(this.LBL_Height);
            this.Controls.Add(this.RTB_Weight);
            this.Controls.Add(this.BTN_MoreInfo);
            this.Controls.Add(this.RBN_umolL);
            this.Controls.Add(this.RBN_mgdL);
            this.Controls.Add(this.BTN_Back);
            this.Controls.Add(this.LBL_eGFR);
            this.Controls.Add(this.LBL_Calculation);
            this.Controls.Add(this.LBL_Ethnicity);
            this.Controls.Add(this.LBL_Gender);
            this.Controls.Add(this.LBL_Age);
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
            ((System.ComponentModel.ISupportInitialize)(this.ERR_Validation)).EndInit();
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
        private System.Windows.Forms.Label LBL_Age;
        private System.Windows.Forms.Label LBL_Gender;
        private System.Windows.Forms.Label LBL_Ethnicity;
        private System.Windows.Forms.Label LBL_Calculation;
        private System.Windows.Forms.Label LBL_eGFR;
        private System.Windows.Forms.Button BTN_Back;
        private System.Windows.Forms.RadioButton RBN_mgdL;
        private System.Windows.Forms.RadioButton RBN_umolL;
        private System.Windows.Forms.ErrorProvider ERR_Validation;
        private System.Windows.Forms.Button BTN_Edit;
        private System.Windows.Forms.Label LBL_Weight;
        private System.Windows.Forms.RichTextBox RTB_Height;
        private System.Windows.Forms.Label LBL_Height;
        private System.Windows.Forms.RichTextBox RTB_Weight;
        private System.Windows.Forms.Button BTN_MoreInfo;
        private System.Windows.Forms.RichTextBox RTB_Age;
    }
}

