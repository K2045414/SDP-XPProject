namespace FirstIteration
{
    partial class FRM_SignUp
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
            this.LBL_Username = new System.Windows.Forms.Label();
            this.LBL_Password1 = new System.Windows.Forms.Label();
            this.LBL_Password2 = new System.Windows.Forms.Label();
            this.LBL_Title = new System.Windows.Forms.Label();
            this.CBX_TAndC = new System.Windows.Forms.CheckBox();
            this.BTN_Back = new System.Windows.Forms.Button();
            this.BTN_SignUp = new System.Windows.Forms.Button();
            this.LIN_Terms = new System.Windows.Forms.LinkLabel();
            this.ERR_Validation = new System.Windows.Forms.ErrorProvider(this.components);
            this.CBX_Pass = new System.Windows.Forms.CheckBox();
            this.RTB_Password2 = new System.Windows.Forms.TextBox();
            this.RTB_Password1 = new System.Windows.Forms.TextBox();
            this.RTB_Username = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.ERR_Validation)).BeginInit();
            this.SuspendLayout();
            // 
            // LBL_Username
            // 
            this.LBL_Username.AutoSize = true;
            this.LBL_Username.Location = new System.Drawing.Point(58, 165);
            this.LBL_Username.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LBL_Username.Name = "LBL_Username";
            this.LBL_Username.Size = new System.Drawing.Size(107, 20);
            this.LBL_Username.TabIndex = 0;
            this.LBL_Username.Text = "NHS Number:";
            // 
            // LBL_Password1
            // 
            this.LBL_Password1.AutoSize = true;
            this.LBL_Password1.Location = new System.Drawing.Point(83, 217);
            this.LBL_Password1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LBL_Password1.Name = "LBL_Password1";
            this.LBL_Password1.Size = new System.Drawing.Size(82, 20);
            this.LBL_Password1.TabIndex = 1;
            this.LBL_Password1.Text = "Password:";
            // 
            // LBL_Password2
            // 
            this.LBL_Password2.AutoSize = true;
            this.LBL_Password2.Location = new System.Drawing.Point(16, 269);
            this.LBL_Password2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LBL_Password2.Name = "LBL_Password2";
            this.LBL_Password2.Size = new System.Drawing.Size(149, 20);
            this.LBL_Password2.TabIndex = 2;
            this.LBL_Password2.Text = "Re-enter Password:";
            // 
            // LBL_Title
            // 
            this.LBL_Title.AutoSize = true;
            this.LBL_Title.Location = new System.Drawing.Point(200, 62);
            this.LBL_Title.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LBL_Title.Name = "LBL_Title";
            this.LBL_Title.Size = new System.Drawing.Size(52, 20);
            this.LBL_Title.TabIndex = 5;
            this.LBL_Title.Text = "TITLE";
            // 
            // CBX_TAndC
            // 
            this.CBX_TAndC.AutoSize = true;
            this.CBX_TAndC.Location = new System.Drawing.Point(122, 402);
            this.CBX_TAndC.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CBX_TAndC.Name = "CBX_TAndC";
            this.CBX_TAndC.Size = new System.Drawing.Size(277, 24);
            this.CBX_TAndC.TabIndex = 8;
            this.CBX_TAndC.Text = "I accept the Terms and Conditions";
            this.CBX_TAndC.UseVisualStyleBackColor = true;
            // 
            // BTN_Back
            // 
            this.BTN_Back.Location = new System.Drawing.Point(21, 458);
            this.BTN_Back.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BTN_Back.Name = "BTN_Back";
            this.BTN_Back.Size = new System.Drawing.Size(196, 92);
            this.BTN_Back.TabIndex = 9;
            this.BTN_Back.Text = "Back";
            this.BTN_Back.UseVisualStyleBackColor = true;
            this.BTN_Back.Click += new System.EventHandler(this.BTN_Back_Click);
            // 
            // BTN_SignUp
            // 
            this.BTN_SignUp.Location = new System.Drawing.Point(266, 458);
            this.BTN_SignUp.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BTN_SignUp.Name = "BTN_SignUp";
            this.BTN_SignUp.Size = new System.Drawing.Size(196, 92);
            this.BTN_SignUp.TabIndex = 10;
            this.BTN_SignUp.Text = "Sign Up";
            this.BTN_SignUp.UseVisualStyleBackColor = true;
            this.BTN_SignUp.Click += new System.EventHandler(this.BTN_SignUp_Click);
            // 
            // LIN_Terms
            // 
            this.LIN_Terms.AutoSize = true;
            this.LIN_Terms.Location = new System.Drawing.Point(117, 377);
            this.LIN_Terms.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LIN_Terms.Name = "LIN_Terms";
            this.LIN_Terms.Size = new System.Drawing.Size(267, 20);
            this.LIN_Terms.TabIndex = 12;
            this.LIN_Terms.TabStop = true;
            this.LIN_Terms.Text = "For Terms and Conditions Click Here";
            this.LIN_Terms.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LIN_Terms_LinkClicked);
            // 
            // ERR_Validation
            // 
            this.ERR_Validation.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.ERR_Validation.ContainerControl = this;
            // 
            // CBX_Pass
            // 
            this.CBX_Pass.AutoSize = true;
            this.CBX_Pass.Location = new System.Drawing.Point(172, 320);
            this.CBX_Pass.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CBX_Pass.Name = "CBX_Pass";
            this.CBX_Pass.Size = new System.Drawing.Size(142, 24);
            this.CBX_Pass.TabIndex = 13;
            this.CBX_Pass.Text = "View Password";
            this.CBX_Pass.UseVisualStyleBackColor = true;
            this.CBX_Pass.CheckedChanged += new System.EventHandler(this.CBX_Pass_CheckedChanged);
            // 
            // RTB_Password2
            // 
            this.RTB_Password2.Location = new System.Drawing.Point(172, 266);
            this.RTB_Password2.Name = "RTB_Password2";
            this.RTB_Password2.Size = new System.Drawing.Size(262, 26);
            this.RTB_Password2.TabIndex = 14;
            this.RTB_Password2.UseSystemPasswordChar = true;
            // 
            // RTB_Password1
            // 
            this.RTB_Password1.Location = new System.Drawing.Point(172, 217);
            this.RTB_Password1.Name = "RTB_Password1";
            this.RTB_Password1.Size = new System.Drawing.Size(264, 26);
            this.RTB_Password1.TabIndex = 15;
            this.RTB_Password1.UseSystemPasswordChar = true;
            // 
            // RTB_Username
            // 
            this.RTB_Username.Location = new System.Drawing.Point(172, 165);
            this.RTB_Username.Name = "RTB_Username";
            this.RTB_Username.Size = new System.Drawing.Size(262, 26);
            this.RTB_Username.TabIndex = 16;
            // 
            // FRM_SignUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 569);
            this.Controls.Add(this.RTB_Username);
            this.Controls.Add(this.RTB_Password1);
            this.Controls.Add(this.RTB_Password2);
            this.Controls.Add(this.CBX_Pass);
            this.Controls.Add(this.LIN_Terms);
            this.Controls.Add(this.BTN_SignUp);
            this.Controls.Add(this.BTN_Back);
            this.Controls.Add(this.CBX_TAndC);
            this.Controls.Add(this.LBL_Title);
            this.Controls.Add(this.LBL_Password2);
            this.Controls.Add(this.LBL_Password1);
            this.Controls.Add(this.LBL_Username);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FRM_SignUp";
            this.Text = "Sign Up";
            ((System.ComponentModel.ISupportInitialize)(this.ERR_Validation)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LBL_Username;
        private System.Windows.Forms.Label LBL_Password1;
        private System.Windows.Forms.Label LBL_Password2;
        private System.Windows.Forms.Label LBL_Title;
        private System.Windows.Forms.CheckBox CBX_TAndC;
        private System.Windows.Forms.Button BTN_Back;
        private System.Windows.Forms.Button BTN_SignUp;
        private System.Windows.Forms.LinkLabel LIN_Terms;
        private System.Windows.Forms.ErrorProvider ERR_Validation;
        private System.Windows.Forms.CheckBox CBX_Pass;
        private System.Windows.Forms.TextBox RTB_Username;
        private System.Windows.Forms.TextBox RTB_Password1;
        private System.Windows.Forms.TextBox RTB_Password2;
    }
}