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
        private bool ValidateUserName(string userName)
        {
            if (!Regex.IsMatch(userName, @"^[0-9A-Z]{10}$"))
            {
                ERR_Validation.SetError(RTB_Username, "Your ID has been input incorrectly");
                return false;
            }
            return true;
        }
        private bool ValidatePassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                ERR_Validation.SetError(RTB_Password1, "Your Password is empty");
                return false;
            }

            if (password.Any(x => !char.IsLetterOrDigit(x)) && password.Any(x => char.IsDigit(x)) && password.Any(x => char.IsUpper(x)) && password.Any(x => !char.IsUpper(x)) && password.Length >= 8)
            {
                ERR_Validation.SetError(RTB_Password1, "");
                return true;
            }

            ERR_Validation.SetError(RTB_Password1, "The Password you entered does not meet our requirements");
            return false;
        }

        private bool MatchPassword(string password1, string password2)
        {
            if (password1 == password2)
            {
                return true;
            }

            ERR_Validation.SetError(RTB_Password2, "Your Passwords do not match");
            return false;
        }

        private bool ValidateTerms() // Checks if the Terms and Conditions checkbox is checked
        {
            if (CBX_TAndC.Checked)
            {
                return true;
            }
            else
            {
                ERR_Validation.SetError(CBX_TAndC, "You have not Accepted the Terms and Conditions");
                return false;
            }
        }


        private void BTN_Back_Click(object sender, EventArgs e)
        {
            Form previousForm = FormStack.Forms.Pop();
            this.Hide();
            previousForm.ShowDialog();
        }

        private void LIN_Terms_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormStack.Forms.Push(this);
            this.Hide();
            FRM_Terms Terms = new FRM_Terms();
            Terms.ShowDialog();
        }

        private void BTN_SignUp_Click(object sender, EventArgs e)
        {
            if (ValidateUserName(RTB_Username.Text) && ValidatePassword(RTB_Password1.Text) && MatchPassword(RTB_Password2.Text, RTB_Password1.Text) && ValidateTerms())
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
                using (MySqlConnection connection = new MySqlConnection("server=rsscalculatorapp.mariadb.database.azure.com;uid=XPAdmin@rsscalculatorapp;pwd=07Ix5@o3geXG;database=calculatorapp;"))
                {
                    connection.Open();

                    // Check if username already exists in users table
                    int existingUserCount = GetExistingUserCount(connection, RTB_Username.Text);

                    // Check if username already exists in patients table
                    int existingPatientCount = GetExistingPatientCount(connection, RTB_Username.Text);

                    if (existingUserCount > 0)
                    {
                        MessageBox.Show("That NHS ID is already in use.");
                        return;
                    }

                    // Insert new user into users table
                    InsertUser(connection, RTB_Username.Text, RTB_Password2.Text);

                    // Insert new user into patients table if necessary
                    if (existingPatientCount == 0)
                    {
                        InsertPatient(connection, RTB_Username.Text);
                    }

                    MessageBox.Show("Successfully signed up.");
                    FormStack.Forms.Push(this);
                    this.Hide();
                    FRM_Login Login = new FRM_Login();
                    Login.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private int GetExistingUserCount(MySqlConnection connection, string username)
        {
            using (MySqlCommand command = new MySqlCommand("SELECT COUNT(*) FROM users WHERE user_id = @user_id;", connection))
            {
                command.Parameters.AddWithValue("@user_id", username);
                return Convert.ToInt32(command.ExecuteScalar());
            }
        }

        private int GetExistingPatientCount(MySqlConnection connection, string username)
        {
            using (MySqlCommand command = new MySqlCommand("SELECT COUNT(*) FROM patients WHERE user_id = @user_id;", connection))
            {
                command.Parameters.AddWithValue("@user_id", username);
                return Convert.ToInt32(command.ExecuteScalar());
            }
        }

        private void InsertUser(MySqlConnection connection, string username, string password)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(password);
            using (MySqlCommand command = new MySqlCommand("INSERT INTO users (user_id, password, title) VALUES (@user_id, @password, 'patient')", connection))
            {
                command.Parameters.AddWithValue("@user_id", username);
                command.Parameters.AddWithValue("@password", passwordHash);
                command.ExecuteNonQuery();
            }
        }

        private void InsertPatient(MySqlConnection connection, string username)
        {
            using (MySqlCommand command = new MySqlCommand("INSERT INTO patients (user_id) VALUES (@user_id)", connection))
            {
                command.Parameters.AddWithValue("@user_id", username);
                command.ExecuteNonQuery();
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
