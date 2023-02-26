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
    public partial class FRM_Login : Form
    {
        public FRM_Login()
        {
            InitializeComponent();
        }
        
        public static class FormStack
        {
            public static Stack<Form> Forms = new Stack<Form>();
        }

        private void BTN_Calculate_Click(object sender, EventArgs e)
        {
            FormStack.Forms.Push(this);
            this.Hide();
            FRM_OptionPage OptionPage = new FRM_OptionPage();
            OptionPage.Show();
        }
    }
}
