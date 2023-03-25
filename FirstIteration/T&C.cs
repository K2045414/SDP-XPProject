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
    public partial class FRM_Terms : Form
    {
        //Enables the hover feature for the buttons
        public FRM_Terms()
        {
            InitializeComponent();
            BTN_Back.MouseEnter += Mouse_Enter;
            BTN_Back.MouseLeave += Mouse_Leave;
        }

        //Returns to the previous form
        private void BTN_Back_Click(object sender, EventArgs e)
        {
            Form previousForm = FormStack.Forms.Pop();
            this.Hide();
            previousForm.Show();
        }

        //Unhovers the button when the mouse leaves its hover zone
        private void Mouse_Leave(object sender, EventArgs e)
        {
            var btn = (System.Windows.Forms.Button)sender;
            btn.BackgroundImage = Properties.Resources.Button3;
        }

        //Hovers the button when the mouse enters its hover zone
        private void Mouse_Enter(object sender, EventArgs e)
        {
            var btn = (System.Windows.Forms.Button)sender;
            btn.BackgroundImage = Properties.Resources.ButtonHover;
        }
    }
}
