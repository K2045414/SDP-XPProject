using System;
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
                RTB_CKD1.BackColor = Color.Red;
            }
            else if (eGFR >= 60 && eGFR <= 89)
            {
                RTB_CKD2.BackColor = Color.Red;
            }
            else if (eGFR >= 45 && eGFR <= 59)
            {
                RTB_CKD3.BackColor = Color.Red;
            }
            else if (eGFR >= 30 && eGFR <= 44)
            {
                RTB_CKD4.BackColor = Color.Red;
            }
            else if (eGFR >= 15 && eGFR <= 29)
            {
                RTB_CKD5.BackColor = Color.Red;
            }
            else if (eGFR >= 14)
            {
                RTB_CKD6.BackColor = Color.Red;
            }
        }
    }
}
