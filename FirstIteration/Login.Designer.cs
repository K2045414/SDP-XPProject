﻿namespace FirstIteration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_Login));
            this.BTN_Calculate = new System.Windows.Forms.Button();
            this.LBL_Title = new System.Windows.Forms.Label();
            this.LBL_Login = new System.Windows.Forms.Label();
            this.LBL_Password = new System.Windows.Forms.Label();
            this.ERR_Validation = new System.Windows.Forms.ErrorProvider(this.components);
            this.BTN_SignUp = new System.Windows.Forms.Button();
            this.BTN_Login = new System.Windows.Forms.Button();
            this.RTB_Password = new System.Windows.Forms.TextBox();
            this.RTB_Username = new System.Windows.Forms.TextBox();
            this.CBX_Pass_Log = new System.Windows.Forms.CheckBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CalcTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ERR_Validation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // BTN_Calculate
            // 
            this.BTN_Calculate.BackColor = System.Drawing.Color.Transparent;
            this.BTN_Calculate.BackgroundImage = global::FirstIteration.Properties.Resources.Button3;
            this.BTN_Calculate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BTN_Calculate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTN_Calculate.FlatAppearance.BorderSize = 0;
            this.BTN_Calculate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.BTN_Calculate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.BTN_Calculate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_Calculate.Font = new System.Drawing.Font("Arial", 16F);
            this.BTN_Calculate.ForeColor = System.Drawing.Color.White;
            this.BTN_Calculate.Location = new System.Drawing.Point(206, 439);
            this.BTN_Calculate.Name = "BTN_Calculate";
            this.BTN_Calculate.Size = new System.Drawing.Size(167, 58);
            this.BTN_Calculate.TabIndex = 6;
            this.BTN_Calculate.Text = "CALCULATOR";
            this.BTN_Calculate.UseVisualStyleBackColor = false;
            this.BTN_Calculate.Click += new System.EventHandler(this.BTN_Calculate_Click);
            // 
            // LBL_Title
            // 
            this.LBL_Title.AutoSize = true;
            this.LBL_Title.BackColor = System.Drawing.Color.Transparent;
            this.LBL_Title.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LBL_Title.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_Title.ForeColor = System.Drawing.Color.White;
            this.LBL_Title.Location = new System.Drawing.Point(97, 7);
            this.LBL_Title.Name = "LBL_Title";
            this.LBL_Title.Size = new System.Drawing.Size(203, 32);
            this.LBL_Title.TabIndex = 4;
            this.LBL_Title.Text = "CKD Calculator";
            this.LBL_Title.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // LBL_Login
            // 
            this.LBL_Login.AutoSize = true;
            this.LBL_Login.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_Login.ForeColor = System.Drawing.Color.White;
            this.LBL_Login.Location = new System.Drawing.Point(29, 28);
            this.LBL_Login.Name = "LBL_Login";
            this.LBL_Login.Size = new System.Drawing.Size(156, 27);
            this.LBL_Login.TabIndex = 6;
            this.LBL_Login.Text = "NHS/HCP ID:";
            // 
            // LBL_Password
            // 
            this.LBL_Password.AutoSize = true;
            this.LBL_Password.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LBL_Password.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_Password.ForeColor = System.Drawing.Color.White;
            this.LBL_Password.Location = new System.Drawing.Point(29, 97);
            this.LBL_Password.Name = "LBL_Password";
            this.LBL_Password.Size = new System.Drawing.Size(124, 27);
            this.LBL_Password.TabIndex = 7;
            this.LBL_Password.Text = "Password:";
            // 
            // ERR_Validation
            // 
            this.ERR_Validation.BlinkRate = 1;
            this.ERR_Validation.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.ERR_Validation.ContainerControl = this;
            // 
            // BTN_SignUp
            // 
            this.BTN_SignUp.BackColor = System.Drawing.Color.Transparent;
            this.BTN_SignUp.BackgroundImage = global::FirstIteration.Properties.Resources.Button3;
            this.BTN_SignUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BTN_SignUp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTN_SignUp.FlatAppearance.BorderSize = 0;
            this.BTN_SignUp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.BTN_SignUp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.BTN_SignUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_SignUp.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_SignUp.ForeColor = System.Drawing.Color.White;
            this.BTN_SignUp.Location = new System.Drawing.Point(20, 439);
            this.BTN_SignUp.Name = "BTN_SignUp";
            this.BTN_SignUp.Size = new System.Drawing.Size(167, 58);
            this.BTN_SignUp.TabIndex = 5;
            this.BTN_SignUp.Text = "SIGN UP";
            this.BTN_SignUp.UseVisualStyleBackColor = false;
            this.BTN_SignUp.Click += new System.EventHandler(this.BTN_SignUp_Click);
            // 
            // BTN_Login
            // 
            this.BTN_Login.BackColor = System.Drawing.Color.Transparent;
            this.BTN_Login.BackgroundImage = global::FirstIteration.Properties.Resources.Button3;
            this.BTN_Login.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BTN_Login.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTN_Login.FlatAppearance.BorderSize = 0;
            this.BTN_Login.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.BTN_Login.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.BTN_Login.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_Login.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_Login.ForeColor = System.Drawing.Color.White;
            this.BTN_Login.Location = new System.Drawing.Point(109, 222);
            this.BTN_Login.Name = "BTN_Login";
            this.BTN_Login.Size = new System.Drawing.Size(167, 46);
            this.BTN_Login.TabIndex = 4;
            this.BTN_Login.Text = "LOGIN";
            this.BTN_Login.UseVisualStyleBackColor = false;
            this.BTN_Login.Click += new System.EventHandler(this.BTN_Login_Click);
            // 
            // RTB_Password
            // 
            this.RTB_Password.BackColor = System.Drawing.Color.LightSteelBlue;
            this.RTB_Password.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RTB_Password.Font = new System.Drawing.Font("Arial", 16F);
            this.RTB_Password.ForeColor = System.Drawing.Color.White;
            this.RTB_Password.Location = new System.Drawing.Point(33, 125);
            this.RTB_Password.Margin = new System.Windows.Forms.Padding(2);
            this.RTB_Password.MaxLength = 100;
            this.RTB_Password.Name = "RTB_Password";
            this.RTB_Password.Size = new System.Drawing.Size(327, 32);
            this.RTB_Password.TabIndex = 2;
            this.RTB_Password.UseSystemPasswordChar = true;
            // 
            // RTB_Username
            // 
            this.RTB_Username.BackColor = System.Drawing.Color.LightSteelBlue;
            this.RTB_Username.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RTB_Username.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.RTB_Username.Font = new System.Drawing.Font("Arial", 16F);
            this.RTB_Username.ForeColor = System.Drawing.Color.White;
            this.RTB_Username.Location = new System.Drawing.Point(33, 57);
            this.RTB_Username.Margin = new System.Windows.Forms.Padding(2);
            this.RTB_Username.MaxLength = 100;
            this.RTB_Username.Name = "RTB_Username";
            this.RTB_Username.Size = new System.Drawing.Size(327, 32);
            this.RTB_Username.TabIndex = 1;
            // 
            // CBX_Pass_Log
            // 
            this.CBX_Pass_Log.AutoSize = true;
            this.CBX_Pass_Log.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CBX_Pass_Log.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CBX_Pass_Log.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CBX_Pass_Log.ForeColor = System.Drawing.Color.White;
            this.CBX_Pass_Log.Location = new System.Drawing.Point(105, 174);
            this.CBX_Pass_Log.Name = "CBX_Pass_Log";
            this.CBX_Pass_Log.Size = new System.Drawing.Size(180, 29);
            this.CBX_Pass_Log.TabIndex = 3;
            this.CBX_Pass_Log.Text = "View Password";
            this.CBX_Pass_Log.UseVisualStyleBackColor = true;
            this.CBX_Pass_Log.CheckedChanged += new System.EventHandler(this.CBX_Pass_Log_CheckedChanged);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImage = global::FirstIteration.Properties.Resources.LogoImg;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.ErrorImage = null;
            this.pictureBox2.InitialImage = null;
            this.pictureBox2.Location = new System.Drawing.Point(0, 2);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(64, 38);
            this.pictureBox2.TabIndex = 16;
            this.pictureBox2.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = global::FirstIteration.Properties.Resources.HeaderImg;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Controls.Add(this.LBL_Title);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Location = new System.Drawing.Point(1, 2);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(415, 46);
            this.panel1.TabIndex = 17;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImage = global::FirstIteration.Properties.Resources.Information_icon_svg;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox3.Location = new System.Drawing.Point(305, 9);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(27, 27);
            this.pictureBox3.TabIndex = 39;
            this.pictureBox3.TabStop = false;
            this.CalcTip.SetToolTip(this.pictureBox3, "Please note this calculator provides a suggestion on eGFR based on recognised stu" +
        "dies. For more accurate results, please consult a professional.");
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BackgroundImage = global::FirstIteration.Properties.Resources.BufferImg;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Controls.Add(this.CBX_Pass_Log);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.BTN_Login);
            this.panel2.Controls.Add(this.RTB_Username);
            this.panel2.Controls.Add(this.LBL_Login);
            this.panel2.Controls.Add(this.BTN_SignUp);
            this.panel2.Controls.Add(this.BTN_Calculate);
            this.panel2.Controls.Add(this.LBL_Password);
            this.panel2.Controls.Add(this.RTB_Password);
            this.panel2.Location = new System.Drawing.Point(16, 60);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(386, 508);
            this.panel2.TabIndex = 18;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.pictureBox1.Location = new System.Drawing.Point(33, 304);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(326, 8);
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 16F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(53, 339);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(293, 75);
            this.label1.TabIndex = 15;
            this.label1.Text = "Dont Have an Account?\r\nSign up or use the Calculator \r\nwith your own information";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CalcTip
            // 
            this.CalcTip.AutoPopDelay = 50000;
            this.CalcTip.InitialDelay = 500;
            this.CalcTip.ReshowDelay = 100;
            // 
            // FRM_Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::FirstIteration.Properties.Resources.BGImg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(419, 581);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FRM_Login";
            this.Text = "Login";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            ((System.ComponentModel.ISupportInitialize)(this.ERR_Validation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button BTN_Login;
        private System.Windows.Forms.Button BTN_Calculate;
        private System.Windows.Forms.Label LBL_Title;
        private System.Windows.Forms.Button BTN_SignUp;
        private System.Windows.Forms.Label LBL_Login;
        private System.Windows.Forms.Label LBL_Password;
        private System.Windows.Forms.ErrorProvider ERR_Validation;
        private System.Windows.Forms.TextBox RTB_Username;
        private System.Windows.Forms.TextBox RTB_Password;
        private System.Windows.Forms.CheckBox CBX_Pass_Log;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.ToolTip CalcTip;
    }
}