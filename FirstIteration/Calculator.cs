using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static FirstIteration.FRM_Login;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace FirstIteration
{
    public partial class FRM_Calculator : Form
    {
        public FRM_Calculator()
        {
            InitializeComponent();
        }

        private bool ValidateCrea()
        {         
            bool bStatus = true;
            if (RTB_Creatinine.Text == "")
            {
                ERR_Validation.SetError(RTB_Creatinine, "Please enter your creatinine value");
                bStatus = false;
            }
            else
                ERR_Validation.SetError(RTB_Creatinine, "");
            return bStatus;
        }

        private void BTN_Calculate_Click(object sender, EventArgs e)
        {
            bool ValidCrea = ValidateCrea();
            if (ValidCrea == false)
            {
                MessageBox.Show("Empty");
            }
            else if (ValidCrea == true)
            {
                Calculate();
            }
        }
 
        private void Calculate()
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

            double Weight = double.Parse(RTB_Weight.Text);
            double Height = double.Parse(RTB_Height.Text);
            string Gender = CBX_Gender.Text;
            string Ethnicity = CBX_Ethnicity.Text;
            double eGFR_MDRD = MDRD(Creatinineumol, Age, Gender, Ethnicity);
            double eGFR_CKDEPI = CKDEPI(Creatininemgdl, Age, Gender, Ethnicity);
            double eGFR_Cockroft = Cockroft(Creatininemgdl, Age, Weight, Height, Gender);
            if (CBX_Calculation.Text == "MDRD")
            {
                RTB_eGFR.Text = "MDRD " + eGFR_MDRD;
            }
            else if (CBX_Calculation.Text == "CKDEPI")
            {
                RTB_eGFR.Text = "CKDEPI: " + eGFR_CKDEPI;
            }
            else if (CBX_Calculation.Text == "Cockroft-Gault")
            {
                RTB_eGFR.Text = "Cockroft: " + eGFR_Cockroft;
            }
            else if (CBX_Calculation.Text == "All")
            {
                RTB_eGFR.Text = "Cockroft: " + eGFR_Cockroft + " CKDEPI: " + eGFR_CKDEPI + " MDRD " + eGFR_MDRD;
            }
            else
            {
                MessageBox.Show("Please Select a Calculation");
            }

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

        public double Cockroft(double Creatininemgdl, int Age, double Weight, double Height, String Gender)
        {
            double g = 1;
            if (Gender == "Female")
            { 
                g = 0.85;
            }
            //The eGFRC-G(ml / min) was adjusted to BSA(modified C-G) to obtain eGFRmC - G(ml / min per 1.73 m2): eGFRmC - G = eGFRC - G × 1.73 / BSA.
            double BSA = 0.0167 * Math.Pow(Height, 0.5) * Math.Pow(Weight, 0.5);
            double GFR = ((140 - Age) * (Weight * g) / (72 * Creatininemgdl)) * (1.73/BSA);
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

        private void BTN_Back_Click(object sender, EventArgs e)
        {
            Form previousForm = FormStack.Forms.Pop();
            this.Hide();
            previousForm.Show();
        }

        private void BTN_MoreInfo_Click(object sender, EventArgs e)
        {
            FormStack.Forms.Push(this);
            this.Hide();
            FRM_MoreInfo MoreInfo = new FRM_MoreInfo();
            MoreInfo.Show();
        }

        private void CBX_Calculation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(CBX_Calculation.Text == "Cockroft-Gault")
            {
                LBL_Weight.Visible = true;
                LBL_Height.Visible = true;
                RTB_Height.Visible = true;
                RTB_Weight.Visible = true;
            }
            else if (CBX_Calculation.Text == "All")
            {
                LBL_Weight.Visible = true;
                LBL_Height.Visible = true;
                RTB_Height.Visible = true;
                RTB_Weight.Visible = true;
            }
            else
            {
                LBL_Weight.Visible = false;
                LBL_Height.Visible = false;
                RTB_Height.Visible = false;
                RTB_Weight.Visible = false;
            }
        }
    }
}
