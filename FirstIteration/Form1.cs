using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace FirstIteration
{
    public partial class FRM_Calculator : Form
    {
        public FRM_Calculator()
        {
            InitializeComponent();
        }

        private void BTN_Calculate_Click(object sender, EventArgs e)
        {
            double Creatinine = double.Parse(RTB_Creatinine.Text);
            double Creatinineumol = Creatinine;
            double Creatininemgdl = Creatinine;

            if (RBN_umolL.Checked)
            {
                Creatininemgdl = Creatinine / 88.4;
            }
            if (RBN_mgdL.Checked)
            {
                Creatinineumol = Creatinine * 88.4;
            }


            DateTime DOB = DTP_DOB.Value;
            int a = DateTime.Today.Year - DOB.Year;
            if (DOB > DateTime.Today.AddYears(-a))
            {
                a--;
            }
            int Age = a;

            string Gender = CBX_Gender.Text;
            string Ethnicity = CBX_Ethnicity.Text;
            double eGFR_MDRD = MDRD(Creatinineumol, Age, Gender, Ethnicity);
            double eGFR_CKDEPI = CKDEPI(Creatininemgdl, Age, Gender, Ethnicity);
            double eGFR_MAYO = MAYO(Creatinine, Age, Gender);
            string Test = "MDRD: " + eGFR_MDRD + " CKDEPI: " + eGFR_CKDEPI + " MAYO " + eGFR_MAYO;
            MessageBox.Show(Test);
        }
        public double MDRD(double Creatinineumol, int Age, string Gender, string Ethnicity)
        {
            double g = 1;
            if (Gender == "Female")
            {
                g = 0.742;
            }
            double a = -1.154;
            double b = -0.203;
            double e = 1;
            if (Ethnicity == "Black")
            {
                e = 1.210;
            }
            double GFR = 186 * Math.Pow(Creatinineumol / 88.4, a) * Math.Pow(Age, b) * g * e;
            return GFR;
        }
        public double CKDEPI(double Creatininemgdl, int Age, string Gender, string Ethnicity)
        {
            double k;
            double a;
            double g = 1;
            double e = 1;
            if (Gender == "Female")
            {
                k = 0.7;
                a = -0.329;
                g = 1.018;
            }
            else
            {
                k = 0.9;
                a = -0.411;                
            }

            if (Ethnicity == "Black")
            {
                e = 1.159;
            }

            double GFR = 141 * Math.Pow(Math.Min(Creatininemgdl / k, 1), a) * Math.Pow(Math.Max(Creatininemgdl / k, 1), -1.209) * Math.Pow(0.993, Age) * g * e;
            return GFR;
        }

        public double MAYO(double Creatinine, int Age, string Gender)
        {
            double g = 1;
            if (Gender == "Female")
            {
                g = 1.15;
            }
            double GFR = 82.3 * (140 - Age) * Math.Pow(Creatinine, -0.691) * g;
            return GFR;
        }

        private void RBN_mgdL_CheckedChanged(object sender, EventArgs e)
        {
            if (RBN_mgdL.Checked)
            {
                RBN_umolL.Checked = false;
            }
        }

        private void RBN_umolL_CheckedChanged(object sender, EventArgs e)
        {
            if (RBN_umolL.Checked)
            {
                RBN_mgdL.Checked = false;
            }
        }
    }
}
