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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_Calculator));
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.CalcInfo = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.CalcTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ERR_Validation)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CalcInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // BTN_Calculate
            // 
            this.BTN_Calculate.BackgroundImage = global::FirstIteration.Properties.Resources.Button3;
            this.BTN_Calculate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BTN_Calculate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTN_Calculate.FlatAppearance.BorderSize = 0;
            this.BTN_Calculate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.BTN_Calculate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.BTN_Calculate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_Calculate.Font = new System.Drawing.Font("Arial", 18F);
            this.BTN_Calculate.ForeColor = System.Drawing.Color.White;
            this.BTN_Calculate.Location = new System.Drawing.Point(224, 471);
            this.BTN_Calculate.Name = "BTN_Calculate";
            this.BTN_Calculate.Size = new System.Drawing.Size(152, 48);
            this.BTN_Calculate.TabIndex = 12;
            this.BTN_Calculate.Text = "Calculate";
            this.BTN_Calculate.UseVisualStyleBackColor = true;
            this.BTN_Calculate.Click += new System.EventHandler(this.BTN_Calculate_Click);
            // 
            // RTB_Creatinine
            // 
            this.RTB_Creatinine.BackColor = System.Drawing.Color.LightSteelBlue;
            this.RTB_Creatinine.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RTB_Creatinine.Font = new System.Drawing.Font("Arial", 12F);
            this.RTB_Creatinine.Location = new System.Drawing.Point(28, 196);
            this.RTB_Creatinine.MaxLength = 100;
            this.RTB_Creatinine.Name = "RTB_Creatinine";
            this.RTB_Creatinine.Size = new System.Drawing.Size(255, 26);
            this.RTB_Creatinine.TabIndex = 6;
            this.RTB_Creatinine.Text = "";
            // 
            // LBL_Title
            // 
            this.LBL_Title.Font = new System.Drawing.Font("Arial", 20F);
            this.LBL_Title.ForeColor = System.Drawing.Color.White;
            this.LBL_Title.Location = new System.Drawing.Point(15, 0);
            this.LBL_Title.Name = "LBL_Title";
            this.LBL_Title.Size = new System.Drawing.Size(483, 46);
            this.LBL_Title.TabIndex = 6;
            this.LBL_Title.Text = "Calculator";
            this.LBL_Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CBX_Ethnicity
            // 
            this.CBX_Ethnicity.BackColor = System.Drawing.Color.LightSteelBlue;
            this.CBX_Ethnicity.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CBX_Ethnicity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBX_Ethnicity.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CBX_Ethnicity.Font = new System.Drawing.Font("Arial", 12F);
            this.CBX_Ethnicity.ForeColor = System.Drawing.SystemColors.WindowText;
            this.CBX_Ethnicity.FormattingEnabled = true;
            this.CBX_Ethnicity.Items.AddRange(new object[] {
            "Black",
            "Other"});
            this.CBX_Ethnicity.Location = new System.Drawing.Point(302, 196);
            this.CBX_Ethnicity.Name = "CBX_Ethnicity";
            this.CBX_Ethnicity.Size = new System.Drawing.Size(255, 26);
            this.CBX_Ethnicity.TabIndex = 7;
            // 
            // CBX_Gender
            // 
            this.CBX_Gender.BackColor = System.Drawing.Color.LightSteelBlue;
            this.CBX_Gender.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CBX_Gender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBX_Gender.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CBX_Gender.Font = new System.Drawing.Font("Arial", 12F);
            this.CBX_Gender.ForeColor = System.Drawing.SystemColors.WindowText;
            this.CBX_Gender.FormattingEnabled = true;
            this.CBX_Gender.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.CBX_Gender.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.CBX_Gender.Location = new System.Drawing.Point(302, 115);
            this.CBX_Gender.Name = "CBX_Gender";
            this.CBX_Gender.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CBX_Gender.Size = new System.Drawing.Size(255, 26);
            this.CBX_Gender.TabIndex = 3;
            // 
            // CBX_Calculation
            // 
            this.CBX_Calculation.BackColor = System.Drawing.Color.LightSteelBlue;
            this.CBX_Calculation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CBX_Calculation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBX_Calculation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CBX_Calculation.Font = new System.Drawing.Font("Arial", 12F);
            this.CBX_Calculation.FormattingEnabled = true;
            this.CBX_Calculation.Items.AddRange(new object[] {
            "MDRD",
            "CKDEPI",
            "Cockroft-Gault",
            "All"});
            this.CBX_Calculation.Location = new System.Drawing.Point(164, 45);
            this.CBX_Calculation.Name = "CBX_Calculation";
            this.CBX_Calculation.Size = new System.Drawing.Size(255, 26);
            this.CBX_Calculation.TabIndex = 1;
            this.CalcTip.SetToolTip(this.CBX_Calculation, resources.GetString("CBX_Calculation.ToolTip"));
            this.CBX_Calculation.SelectedIndexChanged += new System.EventHandler(this.CBX_Calculation_SelectedIndexChanged);
            // 
            // RTB_eGFR
            // 
            this.RTB_eGFR.BackColor = System.Drawing.Color.LightSteelBlue;
            this.RTB_eGFR.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RTB_eGFR.Font = new System.Drawing.Font("Arial", 14F);
            this.RTB_eGFR.Location = new System.Drawing.Point(116, 378);
            this.RTB_eGFR.Name = "RTB_eGFR";
            this.RTB_eGFR.ReadOnly = true;
            this.RTB_eGFR.Size = new System.Drawing.Size(370, 87);
            this.RTB_eGFR.TabIndex = 10;
            this.RTB_eGFR.Text = "";
            // 
            // LBL_Creatinine
            // 
            this.LBL_Creatinine.AutoSize = true;
            this.LBL_Creatinine.Font = new System.Drawing.Font("Arial", 18F);
            this.LBL_Creatinine.ForeColor = System.Drawing.Color.White;
            this.LBL_Creatinine.Location = new System.Drawing.Point(23, 166);
            this.LBL_Creatinine.Name = "LBL_Creatinine";
            this.LBL_Creatinine.Size = new System.Drawing.Size(128, 27);
            this.LBL_Creatinine.TabIndex = 19;
            this.LBL_Creatinine.Text = "Creatinine:";
            // 
            // LBL_Age
            // 
            this.LBL_Age.AutoSize = true;
            this.LBL_Age.Font = new System.Drawing.Font("Arial", 18F);
            this.LBL_Age.ForeColor = System.Drawing.Color.White;
            this.LBL_Age.Location = new System.Drawing.Point(25, 85);
            this.LBL_Age.Name = "LBL_Age";
            this.LBL_Age.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LBL_Age.Size = new System.Drawing.Size(142, 27);
            this.LBL_Age.TabIndex = 20;
            this.LBL_Age.Text = "Age (years):";
            // 
            // LBL_Gender
            // 
            this.LBL_Gender.AutoSize = true;
            this.LBL_Gender.Font = new System.Drawing.Font("Arial", 18F);
            this.LBL_Gender.ForeColor = System.Drawing.Color.White;
            this.LBL_Gender.Location = new System.Drawing.Point(297, 85);
            this.LBL_Gender.Name = "LBL_Gender";
            this.LBL_Gender.Size = new System.Drawing.Size(157, 27);
            this.LBL_Gender.TabIndex = 21;
            this.LBL_Gender.Text = "Birth Gender:";
            // 
            // LBL_Ethnicity
            // 
            this.LBL_Ethnicity.AutoSize = true;
            this.LBL_Ethnicity.Font = new System.Drawing.Font("Arial", 18F);
            this.LBL_Ethnicity.ForeColor = System.Drawing.Color.White;
            this.LBL_Ethnicity.Location = new System.Drawing.Point(297, 166);
            this.LBL_Ethnicity.Name = "LBL_Ethnicity";
            this.LBL_Ethnicity.Size = new System.Drawing.Size(111, 27);
            this.LBL_Ethnicity.TabIndex = 22;
            this.LBL_Ethnicity.Text = "Ethnicity:";
            // 
            // LBL_Calculation
            // 
            this.LBL_Calculation.AutoSize = true;
            this.LBL_Calculation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LBL_Calculation.Font = new System.Drawing.Font("Arial", 18F);
            this.LBL_Calculation.ForeColor = System.Drawing.Color.White;
            this.LBL_Calculation.Location = new System.Drawing.Point(159, 15);
            this.LBL_Calculation.Name = "LBL_Calculation";
            this.LBL_Calculation.Size = new System.Drawing.Size(260, 27);
            this.LBL_Calculation.TabIndex = 23;
            this.LBL_Calculation.Text = "Calculation to be used:";
            // 
            // LBL_eGFR
            // 
            this.LBL_eGFR.AutoSize = true;
            this.LBL_eGFR.Font = new System.Drawing.Font("Arial", 18F);
            this.LBL_eGFR.ForeColor = System.Drawing.Color.White;
            this.LBL_eGFR.Location = new System.Drawing.Point(168, 348);
            this.LBL_eGFR.Name = "LBL_eGFR";
            this.LBL_eGFR.Size = new System.Drawing.Size(273, 27);
            this.LBL_eGFR.TabIndex = 24;
            this.LBL_eGFR.Text = "eGFR (mL/min/1.73 m²):";
            // 
            // BTN_Back
            // 
            this.BTN_Back.BackgroundImage = global::FirstIteration.Properties.Resources.Button3;
            this.BTN_Back.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BTN_Back.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTN_Back.FlatAppearance.BorderSize = 0;
            this.BTN_Back.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.BTN_Back.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.BTN_Back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_Back.Font = new System.Drawing.Font("Arial", 18F);
            this.BTN_Back.ForeColor = System.Drawing.Color.White;
            this.BTN_Back.Location = new System.Drawing.Point(66, 471);
            this.BTN_Back.Name = "BTN_Back";
            this.BTN_Back.Size = new System.Drawing.Size(152, 48);
            this.BTN_Back.TabIndex = 11;
            this.BTN_Back.Text = "Back";
            this.BTN_Back.UseVisualStyleBackColor = true;
            this.BTN_Back.Click += new System.EventHandler(this.BTN_Back_Click);
            // 
            // RBN_mgdL
            // 
            this.RBN_mgdL.AutoSize = true;
            this.RBN_mgdL.BackColor = System.Drawing.Color.Transparent;
            this.RBN_mgdL.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RBN_mgdL.Font = new System.Drawing.Font("Arial", 10F);
            this.RBN_mgdL.ForeColor = System.Drawing.Color.White;
            this.RBN_mgdL.Location = new System.Drawing.Point(154, 172);
            this.RBN_mgdL.Name = "RBN_mgdL";
            this.RBN_mgdL.Size = new System.Drawing.Size(64, 20);
            this.RBN_mgdL.TabIndex = 4;
            this.RBN_mgdL.TabStop = true;
            this.RBN_mgdL.Text = "mg/dL";
            this.RBN_mgdL.UseVisualStyleBackColor = false;
            this.RBN_mgdL.CheckedChanged += new System.EventHandler(this.RBN_mgdL_CheckedChanged);
            // 
            // RBN_umolL
            // 
            this.RBN_umolL.AutoSize = true;
            this.RBN_umolL.Checked = true;
            this.RBN_umolL.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RBN_umolL.Font = new System.Drawing.Font("Arial", 12F);
            this.RBN_umolL.ForeColor = System.Drawing.Color.White;
            this.RBN_umolL.Location = new System.Drawing.Point(220, 171);
            this.RBN_umolL.Name = "RBN_umolL";
            this.RBN_umolL.Size = new System.Drawing.Size(73, 22);
            this.RBN_umolL.TabIndex = 5;
            this.RBN_umolL.TabStop = true;
            this.RBN_umolL.Text = "µmol/L";
            this.RBN_umolL.UseVisualStyleBackColor = true;
            this.RBN_umolL.CheckedChanged += new System.EventHandler(this.RBN_umolL_CheckedChanged);
            // 
            // ERR_Validation
            // 
            this.ERR_Validation.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.ERR_Validation.ContainerControl = this;
            // 
            // BTN_MoreInfo
            // 
            this.BTN_MoreInfo.BackgroundImage = global::FirstIteration.Properties.Resources.Button3;
            this.BTN_MoreInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BTN_MoreInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTN_MoreInfo.FlatAppearance.BorderSize = 0;
            this.BTN_MoreInfo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.BTN_MoreInfo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.BTN_MoreInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_MoreInfo.Font = new System.Drawing.Font("Arial", 18F);
            this.BTN_MoreInfo.ForeColor = System.Drawing.Color.White;
            this.BTN_MoreInfo.Location = new System.Drawing.Point(164, 556);
            this.BTN_MoreInfo.Name = "BTN_MoreInfo";
            this.BTN_MoreInfo.Size = new System.Drawing.Size(264, 63);
            this.BTN_MoreInfo.TabIndex = 14;
            this.BTN_MoreInfo.Text = "See what to do next";
            this.BTN_MoreInfo.UseVisualStyleBackColor = false;
            this.BTN_MoreInfo.Visible = false;
            this.BTN_MoreInfo.Click += new System.EventHandler(this.BTN_MoreInfo_Click);
            // 
            // LBL_Height
            // 
            this.LBL_Height.AutoSize = true;
            this.LBL_Height.Font = new System.Drawing.Font("Arial", 18F);
            this.LBL_Height.ForeColor = System.Drawing.Color.White;
            this.LBL_Height.Location = new System.Drawing.Point(23, 247);
            this.LBL_Height.Name = "LBL_Height";
            this.LBL_Height.Size = new System.Drawing.Size(144, 27);
            this.LBL_Height.TabIndex = 31;
            this.LBL_Height.Text = "Height (cm):";
            this.LBL_Height.Visible = false;
            // 
            // RTB_Weight
            // 
            this.RTB_Weight.BackColor = System.Drawing.Color.LightSteelBlue;
            this.RTB_Weight.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RTB_Weight.Font = new System.Drawing.Font("Arial", 12F);
            this.RTB_Weight.Location = new System.Drawing.Point(302, 278);
            this.RTB_Weight.Name = "RTB_Weight";
            this.RTB_Weight.Size = new System.Drawing.Size(255, 26);
            this.RTB_Weight.TabIndex = 9;
            this.RTB_Weight.Text = "";
            this.RTB_Weight.Visible = false;
            // 
            // RTB_Height
            // 
            this.RTB_Height.BackColor = System.Drawing.Color.LightSteelBlue;
            this.RTB_Height.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RTB_Height.Font = new System.Drawing.Font("Arial", 12F);
            this.RTB_Height.Location = new System.Drawing.Point(28, 277);
            this.RTB_Height.Name = "RTB_Height";
            this.RTB_Height.Size = new System.Drawing.Size(255, 27);
            this.RTB_Height.TabIndex = 8;
            this.RTB_Height.Text = "";
            this.RTB_Height.Visible = false;
            // 
            // LBL_Weight
            // 
            this.LBL_Weight.AutoSize = true;
            this.LBL_Weight.Font = new System.Drawing.Font("Arial", 18F);
            this.LBL_Weight.ForeColor = System.Drawing.Color.White;
            this.LBL_Weight.Location = new System.Drawing.Point(297, 247);
            this.LBL_Weight.Name = "LBL_Weight";
            this.LBL_Weight.Size = new System.Drawing.Size(144, 27);
            this.LBL_Weight.TabIndex = 33;
            this.LBL_Weight.Text = "Weight (kg):";
            this.LBL_Weight.Visible = false;
            // 
            // BTN_Edit
            // 
            this.BTN_Edit.BackgroundImage = global::FirstIteration.Properties.Resources.Button3;
            this.BTN_Edit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BTN_Edit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTN_Edit.FlatAppearance.BorderSize = 0;
            this.BTN_Edit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.BTN_Edit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.BTN_Edit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_Edit.Font = new System.Drawing.Font("Arial", 18F);
            this.BTN_Edit.ForeColor = System.Drawing.Color.White;
            this.BTN_Edit.Location = new System.Drawing.Point(382, 471);
            this.BTN_Edit.Name = "BTN_Edit";
            this.BTN_Edit.Size = new System.Drawing.Size(152, 48);
            this.BTN_Edit.TabIndex = 13;
            this.BTN_Edit.Text = "Edit";
            this.BTN_Edit.UseVisualStyleBackColor = true;
            this.BTN_Edit.Visible = false;
            this.BTN_Edit.Click += new System.EventHandler(this.BTN_Edit_Click);
            // 
            // RTB_Age
            // 
            this.RTB_Age.BackColor = System.Drawing.Color.LightSteelBlue;
            this.RTB_Age.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RTB_Age.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RTB_Age.Location = new System.Drawing.Point(28, 115);
            this.RTB_Age.Name = "RTB_Age";
            this.RTB_Age.Size = new System.Drawing.Size(255, 26);
            this.RTB_Age.TabIndex = 2;
            this.RTB_Age.Text = "";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = global::FirstIteration.Properties.Resources.HeaderImg;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.LBL_Title);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(604, 46);
            this.panel1.TabIndex = 36;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::FirstIteration.Properties.Resources.Information_icon_svg;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox2.Location = new System.Drawing.Point(566, 11);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(27, 27);
            this.pictureBox2.TabIndex = 38;
            this.pictureBox2.TabStop = false;
            this.CalcTip.SetToolTip(this.pictureBox2, "Please note this calculator provides a suggestion on eGFR based on recognised stu" +
        "dies. For more accurate results, please consult a professional.");
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::FirstIteration.Properties.Resources.LogoImg;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(72, 43);
            this.pictureBox1.TabIndex = 37;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BackgroundImage = global::FirstIteration.Properties.Resources.BufferImg;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.CalcInfo);
            this.panel2.Controls.Add(this.pictureBox3);
            this.panel2.Controls.Add(this.LBL_Creatinine);
            this.panel2.Controls.Add(this.LBL_Age);
            this.panel2.Controls.Add(this.RTB_Height);
            this.panel2.Controls.Add(this.BTN_Edit);
            this.panel2.Controls.Add(this.RTB_eGFR);
            this.panel2.Controls.Add(this.RTB_Age);
            this.panel2.Controls.Add(this.LBL_Gender);
            this.panel2.Controls.Add(this.RTB_Weight);
            this.panel2.Controls.Add(this.BTN_Calculate);
            this.panel2.Controls.Add(this.LBL_Ethnicity);
            this.panel2.Controls.Add(this.LBL_Weight);
            this.panel2.Controls.Add(this.CBX_Calculation);
            this.panel2.Controls.Add(this.LBL_Height);
            this.panel2.Controls.Add(this.CBX_Ethnicity);
            this.panel2.Controls.Add(this.CBX_Gender);
            this.panel2.Controls.Add(this.RBN_umolL);
            this.panel2.Controls.Add(this.BTN_MoreInfo);
            this.panel2.Controls.Add(this.RBN_mgdL);
            this.panel2.Controls.Add(this.LBL_Calculation);
            this.panel2.Controls.Add(this.LBL_eGFR);
            this.panel2.Controls.Add(this.BTN_Back);
            this.panel2.Controls.Add(this.RTB_Creatinine);
            this.panel2.Location = new System.Drawing.Point(12, 54);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(577, 636);
            this.panel2.TabIndex = 37;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 14F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(76, 522);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(459, 22);
            this.label1.TabIndex = 41;
            this.label1.Text = "This calculator will continue from here out with MDRD ";
            this.label1.Visible = false;
            // 
            // CalcInfo
            // 
            this.CalcInfo.BackgroundImage = global::FirstIteration.Properties.Resources.Information_icon_svg;
            this.CalcInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.CalcInfo.Cursor = System.Windows.Forms.Cursors.Default;
            this.CalcInfo.InitialImage = global::FirstIteration.Properties.Resources.Question;
            this.CalcInfo.Location = new System.Drawing.Point(425, 45);
            this.CalcInfo.Name = "CalcInfo";
            this.CalcInfo.Size = new System.Drawing.Size(25, 23);
            this.CalcInfo.TabIndex = 40;
            this.CalcInfo.TabStop = false;
            this.CalcTip.SetToolTip(this.CalcInfo, resources.GetString("CalcInfo.ToolTip"));
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.LightSteelBlue;
            this.pictureBox3.Location = new System.Drawing.Point(28, 338);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(529, 8);
            this.pictureBox3.TabIndex = 39;
            this.pictureBox3.TabStop = false;
            // 
            // CalcTip
            // 
            this.CalcTip.AutoPopDelay = 50000;
            this.CalcTip.InitialDelay = 500;
            this.CalcTip.ReshowDelay = 100;
            // 
            // FRM_Calculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::FirstIteration.Properties.Resources.BGImg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(604, 702);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FRM_Calculator";
            this.RightToLeftLayout = true;
            this.Text = "Calculator";
            ((System.ComponentModel.ISupportInitialize)(this.ERR_Validation)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CalcInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BTN_Calculate;
        private System.Windows.Forms.RichTextBox RTB_Creatinine;
        private System.Windows.Forms.Label LBL_Title;
        private System.Windows.Forms.ComboBox CBX_Ethnicity;
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
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.ComboBox CBX_Gender;
        private System.Windows.Forms.ToolTip CalcTip;
        private System.Windows.Forms.PictureBox CalcInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}

