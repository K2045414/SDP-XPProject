﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static FirstIteration.FRM_Login;

namespace FirstIteration
{
    public partial class FRM_MoreInfo : Form
    {
        private double eGFR;
        public FRM_MoreInfo(double eGFR)
        {
            InitializeComponent();
            this.eGFR = eGFR;
        }

        private void BTN_Back_Click(object sender, EventArgs e)
        {
            Form previousForm = FormStack.Forms.Pop();
            this.Hide();
            previousForm.Show();
        }

        private void FRM_MoreInfo_Load(object sender, EventArgs e)
        {
            RTB_eGFR.Text = eGFR.ToString(); 
            if (eGFR >= 90)
            {
                RTB_eGFR1.BackColor = Color.Green;
                RTB_eGFR1.ForeColor = Color.White;
                RTB_Desc1.BackColor = Color.Green;
                RTB_Desc1.ForeColor = Color.White;
            }
            else if (eGFR >= 60 && eGFR <= 89)
            {
                RTB_eGFR2.BackColor = Color.Goldenrod;
                RTB_eGFR2.ForeColor = Color.White;
                RTB_Desc2.BackColor = Color.Goldenrod;
                RTB_Desc2.ForeColor = Color.White;
            }
            else if (eGFR >= 45 && eGFR <= 59)
            {
                RTB_eGFR3.BackColor = Color.Orange;
                RTB_eGFR3.ForeColor = Color.White;
                RTB_Desc3.BackColor = Color.Orange;
                RTB_Desc3.ForeColor = Color.White;
            }
            else if (eGFR >= 30 && eGFR <= 44)
            {
                RTB_eGFR4.BackColor = Color.Red;
                RTB_eGFR4.ForeColor = Color.White;
                RTB_Desc4.BackColor = Color.Red;
                RTB_Desc4.ForeColor = Color.White;
            }
            else if (eGFR >= 15 && eGFR <= 29)
            {
                RTB_eGFR5.BackColor = Color.Maroon;
                RTB_eGFR5.ForeColor = Color.White;
                RTB_Desc5.BackColor = Color.Maroon;
                RTB_Desc5.ForeColor = Color.White;
            }
            else if (eGFR <= 14)
            {
                RTB_eGFR6.BackColor = Color.DimGray;
                RTB_eGFR6.ForeColor = Color.White;
                RTB_Desc6.BackColor = Color.DimGray;
                RTB_Desc6.ForeColor = Color.White;
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
