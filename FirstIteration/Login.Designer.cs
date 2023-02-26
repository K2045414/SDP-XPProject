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
            this.RTB_Username = new System.Windows.Forms.RichTextBox();
            this.RTB_Password = new System.Windows.Forms.RichTextBox();
            this.BTN_Login = new System.Windows.Forms.Button();
            this.BTN_Calculate = new System.Windows.Forms.Button();
            this.LBL_Title = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // RTB_Username
            // 
            this.RTB_Username.Location = new System.Drawing.Point(47, 125);
            this.RTB_Username.Name = "RTB_Username";
            this.RTB_Username.Size = new System.Drawing.Size(229, 55);
            this.RTB_Username.TabIndex = 0;
            this.RTB_Username.Text = "";
            // 
            // RTB_Password
            // 
            this.RTB_Password.Location = new System.Drawing.Point(47, 214);
            this.RTB_Password.Name = "RTB_Password";
            this.RTB_Password.Size = new System.Drawing.Size(229, 55);
            this.RTB_Password.TabIndex = 1;
            this.RTB_Password.Text = "";
            // 
            // BTN_Login
            // 
            this.BTN_Login.Location = new System.Drawing.Point(23, 293);
            this.BTN_Login.Name = "BTN_Login";
            this.BTN_Login.Size = new System.Drawing.Size(128, 67);
            this.BTN_Login.TabIndex = 2;
            this.BTN_Login.Text = "Login";
            this.BTN_Login.UseVisualStyleBackColor = true;
            this.BTN_Login.Click += new System.EventHandler(this.BTN_Login_Click);
            // 
            // BTN_Calculate
            // 
            this.BTN_Calculate.Location = new System.Drawing.Point(168, 293);
            this.BTN_Calculate.Name = "BTN_Calculate";
            this.BTN_Calculate.Size = new System.Drawing.Size(129, 67);
            this.BTN_Calculate.TabIndex = 3;
            this.BTN_Calculate.Text = "Calculate";
            this.BTN_Calculate.UseVisualStyleBackColor = true;
            this.BTN_Calculate.Click += new System.EventHandler(this.BTN_Calculate_Click);
            // 
            // LBL_Title
            // 
            this.LBL_Title.AutoSize = true;
            this.LBL_Title.Location = new System.Drawing.Point(143, 66);
            this.LBL_Title.Name = "LBL_Title";
            this.LBL_Title.Size = new System.Drawing.Size(33, 13);
            this.LBL_Title.TabIndex = 4;
            this.LBL_Title.Text = "Login";
            // 
            // FRM_Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 450);
            this.Controls.Add(this.LBL_Title);
            this.Controls.Add(this.BTN_Calculate);
            this.Controls.Add(this.BTN_Login);
            this.Controls.Add(this.RTB_Password);
            this.Controls.Add(this.RTB_Username);
            this.Name = "FRM_Login";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox RTB_Username;
        private System.Windows.Forms.RichTextBox RTB_Password;
        private System.Windows.Forms.Button BTN_Login;
        private System.Windows.Forms.Button BTN_Calculate;
        private System.Windows.Forms.Label LBL_Title;
    }
}