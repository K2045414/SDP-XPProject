using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        private bool ValidateUserName(string VUsername)//Validates UserName
        {
            bool iStatus = false;
            if (Regex.IsMatch(RTB_Username.Text, @"^[0-9A-Z]+$") && (VUsername.Length == 10))
            {
                iStatus = true;
            }
            else
            {
                ERR_Validation.SetError(RTB_Username, "Your ID has been input incorrectly");
            }
            return iStatus;
        }

        public static class FormStack
        {
            public static Stack<Form> Forms = new Stack<Form>();
        }

        private void BTN_Calculate_Click(object sender, EventArgs e)
        {
            FormStack.Forms.Push(this);
            this.Hide();
            FRM_Calculator Calculator = new FRM_Calculator();
            Calculator.Show();
        }

        private void BTN_Login_Click(object sender, EventArgs e)
        {
            bool ValidUser = ValidateUserName(RTB_Username.Text);
            if(ValidUser == true)
            {
                Login();
            }
            else
            {
                ERR_Validation.SetError(BTN_SignUp, "Your Login was Incorrect");
            }
        }
        private void Login()
        {
            MySqlConnection connection = new MySqlConnection("server=localhost;uid=root;pwd=12345;database=calculatorapp;");
            MySqlCommand command = new MySqlCommand("SELECT * FROM users WHERE user_id=@user_id", connection);
            command.Parameters.AddWithValue("@user_id", RTB_Username.Text);

            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    string hashedPassword = reader.GetString("password");
                    string id = reader.GetString("user_id");
                    bool passwordMatches = BCrypt.Net.BCrypt.Verify(RTB_Password.Text, hashedPassword);

                    if (passwordMatches)
                    {
                        string title = reader.GetString("title");
                        MessageBox.Show("Login successful.");
                        if (title == "doctor")
                        {
                            FormStack.Forms.Push(this);
                            this.Hide();
                            FRM_DrMain DrMain = new FRM_DrMain(id);
                            DrMain.Show();
                        }
                        else if (title == "patient")
                        {
                            FormStack.Forms.Push(this);
                            this.Hide();
                            FRM_Calculator Calculator = new FRM_Calculator(id);
                            Calculator.Show();
                        }
                        else
                        {
                            ERR_Validation.SetError(RTB_Username, "User is neither a doctor or patient. Please contact your administrator");
                        }
                    }
                    else
                    {
                        ERR_Validation.SetError(RTB_Password, "Invalid username or password.");
                    }
                }
                else
                {
                    ERR_Validation.SetError(BTN_SignUp, "Invalid username or password.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        private void BTN_SignUp_Click(object sender, EventArgs e)
        {
            FormStack.Forms.Push(this);
            this.Hide();
            FRM_SignUp SignUp = new FRM_SignUp();
            SignUp.Show();
        }

        private void CBX_Pass_Log_CheckedChanged(object sender, EventArgs e)
        {
            if (CBX_Pass_Log.Checked)
            {
                RTB_Password.UseSystemPasswordChar = false;
            }
            else
            {
                RTB_Password.UseSystemPasswordChar = true;
            }
        }

        private void LBL_Password_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void LBL_Title_Click(object sender, EventArgs e)
        {

        }
    }
}
