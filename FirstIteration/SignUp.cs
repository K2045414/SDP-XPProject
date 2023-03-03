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
using System.Windows.Input;
using static FirstIteration.FRM_Login;

namespace FirstIteration
{
    public partial class FRM_SignUp : Form
    {
        public FRM_SignUp()
        {
            InitializeComponent();

        }
        private bool ValidateUserName(string VUsername)//Validates UserName
        {
            bool iStatus = false;
            if (Regex.IsMatch(RTB_Username.Text, @"^[0-9A-Z]+$") && VUsername.Length == 10)
            {
                ERR_Validation.SetError(RTB_Username, "");
                iStatus = true;
            }
            else
            {
                ERR_Validation.SetError(RTB_Username, "Your ID has been input incorrectly");
            }
            return iStatus;
        }
        private bool ValidatePassword(string Password)//Validates Password (we need a Password Policy to change this to match)ඞ
        {
            bool pStatus = false;
            if (Password == "") 
            {
                ERR_Validation.SetError(RTB_Password1, "Your Password empty");
            }
            else
            {
                if (Password.Any(x => !char.IsLetterOrDigit(x)) && Password.Any(x => char.IsDigit(x)) && Password.Any(x => char.IsUpper(x)) && Password.Any(x => !char.IsUpper(x)) && Password.Length >= 8)
                {
                    ERR_Validation.SetError(RTB_Password1, "");
                    pStatus = true;
                }
                else 
                {
                    ERR_Validation.SetError(RTB_Password1, "The Password you entered does not meet our requirements");
                }
            }
            return pStatus;
        }
        private bool MatchPassword(string PassMain, string PassMatch)//Matches Passwords
        {
            bool mStatus = false;
            if (PassMain == PassMatch)
            {
                ERR_Validation.SetError(RTB_Password2, "");
                mStatus = true;
            }
            else
            {
                ERR_Validation.SetError(RTB_Password2, "Your Passwords do not match");
            }
            return mStatus;
        }
        private bool ValidateTerms()//checks Terms and Conditions Checked
        {
            bool tStatus = false;
            if (CBX_TAndC.Checked)
            {
                ERR_Validation.SetError(CBX_TAndC, "");
                tStatus = true;
            }
            else
            {
                ERR_Validation.SetError(CBX_TAndC, "You have not Accepted the Terms and Conditions");
            }
            return tStatus;
        }
        private void BTN_Back_Click(object sender, EventArgs e)
        {
            Form previousForm = FormStack.Forms.Pop();
            this.Hide();
            previousForm.Show();
        }

        private void LIN_Terms_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormStack.Forms.Push(this);
            this.Hide();
            FRM_Terms Terms = new FRM_Terms();
            Terms.Show();
        }

        private void BTN_SignUp_Click(object sender, EventArgs e)
        {
            bool ValidUser = ValidateUserName(RTB_Username.Text);
            bool ValidPass = ValidatePassword(RTB_Password1.Text);
            bool ValidMatch = MatchPassword(RTB_Password2.Text, RTB_Password1.Text);
            bool validTerm = ValidateTerms();
            if (ValidUser == true && ValidPass == true && ValidMatch == true && validTerm == true)
            {
                SignUp();
            }
            else
            {
                ERR_Validation.SetError(BTN_SignUp, "Error during Sign up");
            }
            
        }
        private void SignUp()
        {
            try
            {
                MySqlConnection connection = new MySqlConnection("server=localhost;uid=root;pwd=12345;database=calculatorapp;");
                MySqlCommand command = connection.CreateCommand();

                // Check if username already exists
                command.CommandText = "SELECT COUNT(*) FROM users WHERE username = @username;";
                command.Parameters.AddWithValue("@username", RTB_Username.Text);
                connection.Open();
                int existingUserCount = Convert.ToInt32(command.ExecuteScalar());
                connection.Close();

                if (existingUserCount > 0)
                {
                    MessageBox.Show("That NHS ID is already signed up.");
                    return;
                }

                // Insert new user
                command.CommandText = "INSERT INTO users (username, password, title) VALUES (@username, @password, 'patient')";
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@username", RTB_Username.Text);
                string passwordHash = BCrypt.Net.BCrypt.HashPassword(RTB_Password2.Text);
                command.Parameters.AddWithValue("@password", passwordHash);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

                MessageBox.Show("Successfully signed up.");
                FormStack.Forms.Push(this);
                this.Hide();
                FRM_Login Login = new FRM_Login();
                Login.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CBX_Pass_CheckedChanged(object sender, EventArgs e)
        {
            if (CBX_Pass.Checked)
            {
                RTB_Password1.UseSystemPasswordChar = false;
                RTB_Password2.UseSystemPasswordChar = false;
            }
            else
            {
                RTB_Password1.UseSystemPasswordChar = true;
                RTB_Password2.UseSystemPasswordChar = true;
            }
                
        }
    }
}
