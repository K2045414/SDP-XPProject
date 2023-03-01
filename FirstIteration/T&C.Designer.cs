namespace FirstIteration
{
    partial class FRM_Terms
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
            this.RTB_TandC = new System.Windows.Forms.RichTextBox();
            this.LBL_Title = new System.Windows.Forms.Label();
            this.BTN_Back = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // RTB_TandC
            // 
            this.RTB_TandC.Location = new System.Drawing.Point(22, 63);
            this.RTB_TandC.Name = "RTB_TandC";
            this.RTB_TandC.Size = new System.Drawing.Size(431, 313);
            this.RTB_TandC.TabIndex = 0;
            this.RTB_TandC.Text = "";
            // 
            // LBL_Title
            // 
            this.LBL_Title.AutoSize = true;
            this.LBL_Title.Location = new System.Drawing.Point(22, 28);
            this.LBL_Title.Name = "LBL_Title";
            this.LBL_Title.Size = new System.Drawing.Size(37, 13);
            this.LBL_Title.TabIndex = 1;
            this.LBL_Title.Text = "TITLE";
            // 
            // BTN_Back
            // 
            this.BTN_Back.Location = new System.Drawing.Point(25, 382);
            this.BTN_Back.Name = "BTN_Back";
            this.BTN_Back.Size = new System.Drawing.Size(129, 56);
            this.BTN_Back.TabIndex = 2;
            this.BTN_Back.Text = "Back";
            this.BTN_Back.UseVisualStyleBackColor = true;
            this.BTN_Back.Click += new System.EventHandler(this.BTN_Back_Click);
            // 
            // FRM_Terms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 450);
            this.Controls.Add(this.BTN_Back);
            this.Controls.Add(this.LBL_Title);
            this.Controls.Add(this.RTB_TandC);
            this.Name = "FRM_Terms";
            this.Text = "Terms And Conditions";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox RTB_TandC;
        private System.Windows.Forms.Label LBL_Title;
        private System.Windows.Forms.Button BTN_Back;
    }
}