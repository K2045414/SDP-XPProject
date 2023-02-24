using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            int Creatinine = Int32.Parse(RTB_Creatinine.Text);
            DateTime DOB = DTP_DOB.Value;
            DateTime Current = DateTime.Now;
            TimeSpan Diff = Current - DOB;
            double days = Diff.TotalDays;
            int Age = (int)((days - 365) / 365);
            string Gender = CBX_Gender.Text;
            string Ethnicity = CBX_Ethnicity.Text;
            double GFR = MDRD(Creatinine, Age, Gender, Ethnicity);
            string Test = "MDRD: " + GFR;
            RTB_eGFR.Text = Test;
        }
        public double MDRD(int Creatinine, int Age, string Gender, string Ethnicity)
        {
            double k = 1;
            if (Gender == "Female")
            {
                k = 0.742;
            }
            double a = -1.154;
            double b = -0.203;
            double c = 1;
            if (Ethnicity == "Black")
            {
                c = 1.210;
            }
            double GFR = 186 * Math.Pow((Creatinine / 88.4), a) * Math.Pow(Age, b) * k * c;
            return GFR;
        }
    }
}
