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
            this.LBL_Username = new System.Windows.Forms.Label();
            this.LBL_Password1 = new System.Windows.Forms.Label();
            this.LBL_Password2 = new System.Windows.Forms.Label();
            this.RTB_Username = new System.Windows.Forms.RichTextBox();
            this.LBL_Title = new System.Windows.Forms.Label();
            this.RTB_Password1 = new System.Windows.Forms.RichTextBox();
            this.RTB_Password2 = new System.Windows.Forms.RichTextBox();
            this.CBX_TAndC = new System.Windows.Forms.CheckBox();
            this.BTN_Back = new System.Windows.Forms.Button();
            this.BTN_SignUp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LBL_Username
            // 
            this.LBL_Username.AutoSize = true;
            this.LBL_Username.Location = new System.Drawing.Point(39, 107);
            this.LBL_Username.Name = "LBL_Username";
            this.LBL_Username.Size = new System.Drawing.Size(73, 13);
            this.LBL_Username.TabIndex = 0;
            this.LBL_Username.Text = "NHS Number:";
            // 
            // LBL_Password1
            // 
            this.LBL_Password1.AutoSize = true;
            this.LBL_Password1.Location = new System.Drawing.Point(56, 152);
            this.LBL_Password1.Name = "LBL_Password1";
            this.LBL_Password1.Size = new System.Drawing.Size(56, 13);
            this.LBL_Password1.TabIndex = 1;
            this.LBL_Password1.Text = "Password:";
            // 
            // LBL_Password2
            // 
            this.LBL_Password2.AutoSize = true;
            this.LBL_Password2.Location = new System.Drawing.Point(12, 191);
            this.LBL_Password2.Name = "LBL_Password2";
            this.LBL_Password2.Size = new System.Drawing.Size(100, 13);
            this.LBL_Password2.TabIndex = 2;
            this.LBL_Password2.Text = "Re-enter Password:";
            // 
            // RTB_Username
            // 
            this.RTB_Username.Location = new System.Drawing.Point(118, 92);
            this.RTB_Username.Name = "RTB_Username";
            this.RTB_Username.Size = new System.Drawing.Size(176, 40);
            this.RTB_Username.TabIndex = 4;
            this.RTB_Username.Text = "";
            // 
            // LBL_Title
            // 
            this.LBL_Title.AutoSize = true;
            this.LBL_Title.Location = new System.Drawing.Point(133, 40);
            this.LBL_Title.Name = "LBL_Title";
            this.LBL_Title.Size = new System.Drawing.Size(37, 13);
            this.LBL_Title.TabIndex = 5;
            this.LBL_Title.Text = "TITLE";
            // 
            // RTB_Password1
            // 
            this.RTB_Password1.Location = new System.Drawing.Point(118, 138);
            this.RTB_Password1.Name = "RTB_Password1";
            this.RTB_Password1.Size = new System.Drawing.Size(176, 40);
            this.RTB_Password1.TabIndex = 6;
            this.RTB_Password1.Text = "";
            // 
            // RTB_Password2
            // 
            this.RTB_Password2.Location = new System.Drawing.Point(118, 184);
            this.RTB_Password2.Name = "RTB_Password2";
            this.RTB_Password2.Size = new System.Drawing.Size(176, 40);
            this.RTB_Password2.TabIndex = 7;
            this.RTB_Password2.Text = "";
            // 
            // CBX_TAndC
            // 
            this.CBX_TAndC.AutoSize = true;
            this.CBX_TAndC.Location = new System.Drawing.Point(105, 243);
            this.CBX_TAndC.Name = "CBX_TAndC";
            this.CBX_TAndC.Size = new System.Drawing.Size(129, 17);
            this.CBX_TAndC.TabIndex = 8;
            this.CBX_TAndC.Text = "Terms And Conditions";
            this.CBX_TAndC.UseVisualStyleBackColor = true;
            // 
            // BTN_Back
            // 
            this.BTN_Back.Location = new System.Drawing.Point(15, 280);
            this.BTN_Back.Name = "BTN_Back";
            this.BTN_Back.Size = new System.Drawing.Size(131, 60);
            this.BTN_Back.TabIndex = 9;
            this.BTN_Back.Text = "Back";
            this.BTN_Back.UseVisualStyleBackColor = true;
            // 
            // BTN_SignUp
            // 
            this.BTN_SignUp.Location = new System.Drawing.Point(178, 280);
            this.BTN_SignUp.Name = "BTN_SignUp";
            this.BTN_SignUp.Size = new System.Drawing.Size(131, 60);
            this.BTN_SignUp.TabIndex = 10;
            this.BTN_SignUp.Text = "Sign Up";
            this.BTN_SignUp.UseVisualStyleBackColor = true;
            // 
            // FRM_SignUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 370);
            this.Controls.Add(this.BTN_SignUp);
            this.Controls.Add(this.BTN_Back);
            this.Controls.Add(this.CBX_TAndC);
            this.Controls.Add(this.RTB_Password2);
            this.Controls.Add(this.RTB_Password1);
            this.Controls.Add(this.LBL_Title);
            this.Controls.Add(this.RTB_Username);
            this.Controls.Add(this.LBL_Password2);
            this.Controls.Add(this.LBL_Password1);
            this.Controls.Add(this.LBL_Username);
            this.Name = "FRM_SignUp";
            this.Text = "Sign Up";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LBL_Username;
        private System.Windows.Forms.Label LBL_Password1;
        private System.Windows.Forms.Label LBL_Password2;
        private System.Windows.Forms.RichTextBox RTB_Username;
        private System.Windows.Forms.Label LBL_Title;
        private System.Windows.Forms.RichTextBox RTB_Password1;
        private System.Windows.Forms.RichTextBox RTB_Password2;
        private System.Windows.Forms.CheckBox CBX_TAndC;
        private System.Windows.Forms.Button BTN_Back;
        private System.Windows.Forms.Button BTN_SignUp;
    }
}