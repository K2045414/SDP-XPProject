namespace FirstIteration
{
    partial class FRM_Login
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
            this.RTB_Username = new System.Windows.Forms.RichTextBox();
            this.RTB_Password = new System.Windows.Forms.RichTextBox();
            this.BTN_Login = new System.Windows.Forms.Button();
            this.BTN_Calculate = new System.Windows.Forms.Button();
            this.LBL_Title = new System.Windows.Forms.Label();
            this.BTN_SignUp = new System.Windows.Forms.Button();
            this.LBL_Login = new System.Windows.Forms.Label();
            this.LBL_Password = new System.Windows.Forms.Label();
            this.ERR_Validation = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ERR_Validation)).BeginInit();
            this.SuspendLayout();
            // 
            // RTB_Username
            // 
            this.RTB_Username.Location = new System.Drawing.Point(138, 268);
            this.RTB_Username.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.RTB_Username.Name = "RTB_Username";
            this.RTB_Username.Size = new System.Drawing.Size(342, 82);
            this.RTB_Username.TabIndex = 0;
            this.RTB_Username.Text = "";
            // 
            // RTB_Password
            // 
            this.RTB_Password.Location = new System.Drawing.Point(138, 380);
            this.RTB_Password.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.RTB_Password.Name = "RTB_Password";
            this.RTB_Password.Size = new System.Drawing.Size(342, 82);
            this.RTB_Password.TabIndex = 1;
            this.RTB_Password.Text = "";
            // 
            // BTN_Login
            // 
            this.BTN_Login.Location = new System.Drawing.Point(24, 512);
            this.BTN_Login.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BTN_Login.Name = "BTN_Login";
            this.BTN_Login.Size = new System.Drawing.Size(192, 103);
            this.BTN_Login.TabIndex = 2;
            this.BTN_Login.Text = "Login";
            this.BTN_Login.UseVisualStyleBackColor = true;
            this.BTN_Login.Click += new System.EventHandler(this.BTN_Login_Click);
            // 
            // BTN_Calculate
            // 
            this.BTN_Calculate.Location = new System.Drawing.Point(288, 155);
            this.BTN_Calculate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BTN_Calculate.Name = "BTN_Calculate";
            this.BTN_Calculate.Size = new System.Drawing.Size(194, 103);
            this.BTN_Calculate.TabIndex = 3;
            this.BTN_Calculate.Text = "Calculator";
            this.BTN_Calculate.UseVisualStyleBackColor = true;
            this.BTN_Calculate.Click += new System.EventHandler(this.BTN_Calculate_Click);
            // 
            // LBL_Title
            // 
            this.LBL_Title.AutoSize = true;
            this.LBL_Title.Location = new System.Drawing.Point(231, 75);
            this.LBL_Title.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LBL_Title.Name = "LBL_Title";
            this.LBL_Title.Size = new System.Drawing.Size(52, 20);
            this.LBL_Title.TabIndex = 4;
            this.LBL_Title.Text = "TITLE";
            // 
            // BTN_SignUp
            // 
            this.BTN_SignUp.Location = new System.Drawing.Point(290, 512);
            this.BTN_SignUp.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BTN_SignUp.Name = "BTN_SignUp";
            this.BTN_SignUp.Size = new System.Drawing.Size(192, 103);
            this.BTN_SignUp.TabIndex = 5;
            this.BTN_SignUp.Text = "Sign Up";
            this.BTN_SignUp.UseVisualStyleBackColor = true;
            this.BTN_SignUp.Click += new System.EventHandler(this.BTN_SignUp_Click);
            // 
            // LBL_Login
            // 
            this.LBL_Login.AutoSize = true;
            this.LBL_Login.Location = new System.Drawing.Point(20, 295);
            this.LBL_Login.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LBL_Login.Name = "LBL_Login";
            this.LBL_Login.Size = new System.Drawing.Size(107, 20);
            this.LBL_Login.TabIndex = 6;
            this.LBL_Login.Text = "NHS Number:";
            // 
            // LBL_Password
            // 
            this.LBL_Password.AutoSize = true;
            this.LBL_Password.Location = new System.Drawing.Point(36, 412);
            this.LBL_Password.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LBL_Password.Name = "LBL_Password";
            this.LBL_Password.Size = new System.Drawing.Size(82, 20);
            this.LBL_Password.TabIndex = 7;
            this.LBL_Password.Text = "Password:";
            // 
            // ERR_Validation
            // 
            this.ERR_Validation.BlinkRate = 1;
            this.ERR_Validation.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink;
            this.ERR_Validation.ContainerControl = this;
            // 
            // FRM_Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 692);
            this.Controls.Add(this.LBL_Password);
            this.Controls.Add(this.LBL_Login);
            this.Controls.Add(this.BTN_SignUp);
            this.Controls.Add(this.LBL_Title);
            this.Controls.Add(this.BTN_Calculate);
            this.Controls.Add(this.BTN_Login);
            this.Controls.Add(this.RTB_Password);
            this.Controls.Add(this.RTB_Username);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FRM_Login";
            this.Text = "Login";
            ((System.ComponentModel.ISupportInitialize)(this.ERR_Validation)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox RTB_Username;
        private System.Windows.Forms.RichTextBox RTB_Password;
        private System.Windows.Forms.Button BTN_Login;
        private System.Windows.Forms.Button BTN_Calculate;
        private System.Windows.Forms.Label LBL_Title;
        private System.Windows.Forms.Button BTN_SignUp;
        private System.Windows.Forms.Label LBL_Login;
        private System.Windows.Forms.Label LBL_Password;
        private System.Windows.Forms.ErrorProvider ERR_Validation;
    }
}