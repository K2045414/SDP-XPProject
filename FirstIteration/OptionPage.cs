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
    public partial class FRM_OptionPage : Form
    {
        public FRM_OptionPage()
        {
            InitializeComponent();
        }

        private void BTN_Back_Click(object sender, EventArgs e)
        {
            // Pop the previous form from the stack
            Form previousForm = FormStack.Forms.Pop();

            // Hide the current form
            this.Hide();

            // Show the previous form again
            previousForm.Show();
        }

        private void BTN_Manual_Click(object sender, EventArgs e)
        {
            FormStack.Forms.Push(this);
            this.Hide();
            FRM_Calculator Calculator = new FRM_Calculator();
            Calculator.Show();
        }
    }
}
