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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace FirstIteration
{
    public partial class FRM_SignUp : Form
    {
        public FRM_SignUp()
        {
            InitializeComponent();
        }

        //Makes sure the username follows the format [NNNNNNNNNN], if so, clears the errors and returns true. If no, alerts the user and returns false
        private bool ValidateUserName(string userName)
        {
            if (!Regex.IsMatch(userName, @"^[0-9]{10}$"))
            {
                ERR_Validation.SetError(RTB_Username, "Your ID has been input incorrectly");
                return false;
            }
            ERR_Validation.SetError(RTB_Username, "");// Clears errors when successful ඞ
            return true;
        }

        //Checks if the password is empty or over 25 characters. If so, returns false and alerts the user. 
        private bool ValidatePassword(string password)
        {
            if (password.Length > 25)
            {
                ERR_Validation.SetError(RTB_Password1, "Your Password exceeds 25 characters");
                return false;
            }
            if (string.IsNullOrEmpty(password))
            {
                ERR_Validation.SetError(RTB_Password1, "Your Password is empty");
                return false;
            }
            //If the password contains an uppercase character, lowercase character, number and is over 8 characters in length, clears the error and returns true
            if (password.Any(x => !char.IsLetterOrDigit(x)) && password.Any(x => char.IsDigit(x)) && password.Any(x => char.IsUpper(x)) && password.Any(x => !char.IsUpper(x)) && password.Length >= 8)
            {
                ERR_Validation.SetError(RTB_Password1, "");
                return true;
            }
            //Returns false and alerts the user
            ERR_Validation.SetError(RTB_Password1, "The Password you entered does not meet our requirements");
            return false;
        }

        //Checks that the first password matches the second password. If so, returns true. If false, alerts the user
        private bool MatchPassword(string password1, string password2)
        {
            if (password1 == password2)
            {
                ERR_Validation.SetError(RTB_Password2, "");// Clears errors when successful ඞ
                return true;

            }
            ERR_Validation.SetError(RTB_Password2, "Your Passwords do not match");
            return false;
        }

        //Checks the user has clicked the terms and conditions checkbox. If so, returns true. If false, alerts the user
        private bool ValidateTerms()
        {
            if (CBX_TAndC.Checked)
            {
                ERR_Validation.SetError(CBX_TAndC, "");
                return true;
            }
            else
            {
                ERR_Validation.SetError(CBX_TAndC, "You have not Accepted the Terms and Conditions");
                return false;
            }
        }

        //Opens the pervious form
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
            Terms.ShowDialog();
        }

        //Makes sure all the validations are checked, and runs the signup function. If not, alerts the user
        private void BTN_SignUp_Click(object sender, EventArgs e)
        {
            if (ValidateTerms() && ValidatePassword(RTB_Password1.Text) && MatchPassword(RTB_Password2.Text, RTB_Password1.Text) && ValidatePassword(RTB_Password1.Text) && ValidateUserName(RTB_Username.Text))
            {
                SignUp();
            }
            else
            {
                ERR_Validation.SetError(BTN_SignUp, "Error during Sign up");
            }
        }

        //Sets up a database connection, if it fails, display the error
        private void SignUp()
        {
            try
            {
                string server = "server=rsscalculatorapp.mariadb.database.azure.com;uid=XPAdmin@rsscalculatorapp;pwd=07Ix5@o3geXG;database=calculatorapp;";
                using (MySqlConnection connection = new MySqlConnection(server))
                {
                    connection.Open();
                    //Checks if the username input already exists in the patient or user tables. If it isn't in either, alerts the user, adds the user to both of them and opens a calculator instance safely. If it only exists in the patient database, adds it to the user database.
                    int existingUserCount = GetExistingUserCount(connection, RTB_Username.Text);
                    int existingPatientCount = GetExistingPatientCount(connection, RTB_Username.Text);
                    //If it is in the user database, alert the user and returns
                    if (existingUserCount > 0)
                    {
                        MessageBox.Show("That NHS ID is already in use.");
                        return;
                    }
                    InsertUser(connection, RTB_Username.Text, RTB_Password2.Text);
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

        //Gets the number of users in the user database where user_id is the same as the id they're trying to sign up with
        private int GetExistingUserCount(MySqlConnection connection, string username)
        {
            string sql = "SELECT COUNT(*) FROM users WHERE user_id = @user_id;";
            using (MySqlCommand command = new MySqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@user_id", username);
                return Convert.ToInt32(command.ExecuteScalar());
            }
        }

        //Gets the number of users in the patients database where user_id is the same as the id they're trying to sign up with
        private int GetExistingPatientCount(MySqlConnection connection, string username)
        {
            string sql = "SELECT COUNT(*) FROM patients WHERE user_id = @user_id;";
            using (MySqlCommand command = new MySqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@user_id", username);
                return Convert.ToInt32(command.ExecuteScalar());
            }
        }

        //Adds a new patient to the users database using the id they signed up with, and encrypting their password
        private void InsertUser(MySqlConnection connection, string username, string password)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(password);
            string sql = "INSERT INTO users (user_id, password, title) VALUES (@user_id, @password, 'patient')";
            using (MySqlCommand command = new MySqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@user_id", username);
                command.Parameters.AddWithValue("@password", passwordHash);
                command.ExecuteNonQuery();
            }
        }

        //Adds a new patient to the patients database with using the given id
        private void InsertPatient(MySqlConnection connection, string username)
        {
            string sql = "INSERT INTO patients (user_id) VALUES (@user_id)";
            using (MySqlCommand command = new MySqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@user_id", username);
                command.ExecuteNonQuery();
            }
        }

        //Allows the user to toggle password visibility from cleartext to obscured after pressing the checkbox
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
