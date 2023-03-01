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
    public partial class FRM_DrMain : Form
    {
        public FRM_DrMain()
        {
            InitializeComponent();
        }

        private void BTN_EditPatient_Click(object sender, EventArgs e)
        {
            FormStack.Forms.Push(this);
            this.Hide();
            FRM_Calculator Calculator = new FRM_Calculator();
            Calculator.Show();
        }

        private void BTN_AddPatient_Click(object sender, EventArgs e)
        {
            FormStack.Forms.Push(this);
            this.Hide();
            FRM_AddPatient AddPatient = new FRM_AddPatient();
            AddPatient.Show();
        }

        private void BTN_SignOut_Click(object sender, EventArgs e)
        {
            Form previousForm = FormStack.Forms.Pop();
            this.Hide();
            previousForm.Show();
        }
    }
}
