namespace FirstIteration
{
    partial class FRM_OptionPage
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
            this.BTN_Manual = new System.Windows.Forms.Button();
            this.BTN_Retrival = new System.Windows.Forms.Button();
            this.BTN_Back = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BTN_Manual
            // 
            this.BTN_Manual.Location = new System.Drawing.Point(45, 24);
            this.BTN_Manual.Name = "BTN_Manual";
            this.BTN_Manual.Size = new System.Drawing.Size(145, 91);
            this.BTN_Manual.TabIndex = 0;
            this.BTN_Manual.Text = "Manual";
            this.BTN_Manual.UseVisualStyleBackColor = true;
            this.BTN_Manual.Click += new System.EventHandler(this.BTN_Manual_Click);
            // 
            // BTN_Retrival
            // 
            this.BTN_Retrival.Location = new System.Drawing.Point(45, 137);
            this.BTN_Retrival.Name = "BTN_Retrival";
            this.BTN_Retrival.Size = new System.Drawing.Size(145, 88);
            this.BTN_Retrival.TabIndex = 1;
            this.BTN_Retrival.Text = "Retrival";
            this.BTN_Retrival.UseVisualStyleBackColor = true;
            // 
            // BTN_Back
            // 
            this.BTN_Back.Location = new System.Drawing.Point(45, 250);
            this.BTN_Back.Name = "BTN_Back";
            this.BTN_Back.Size = new System.Drawing.Size(145, 88);
            this.BTN_Back.TabIndex = 2;
            this.BTN_Back.Text = "Back";
            this.BTN_Back.UseVisualStyleBackColor = true;
            this.BTN_Back.Click += new System.EventHandler(this.BTN_Back_Click);
            // 
            // FRM_OptionPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(237, 381);
            this.Controls.Add(this.BTN_Back);
            this.Controls.Add(this.BTN_Retrival);
            this.Controls.Add(this.BTN_Manual);
            this.Name = "FRM_OptionPage";
            this.Text = "Option Page";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BTN_Manual;
        private System.Windows.Forms.Button BTN_Retrival;
        private System.Windows.Forms.Button BTN_Back;
    }
}