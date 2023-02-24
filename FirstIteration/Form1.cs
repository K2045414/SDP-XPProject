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
            string Age = ((days - 365) / 365).ToString("0");
            string Gender = CBX_Gender.Text;
            string Ethnicity = CBX_Ethnicity.Text;
        

        }
    }
}
