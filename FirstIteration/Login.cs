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
        //Enables the hover feature for the buttons
        public FRM_Login()
        {
            InitializeComponent();
            BTN_Login.MouseEnter += Mouse_Enter;
            BTN_Login.MouseLeave += Mouse_Leave;

            BTN_SignUp.MouseEnter += Mouse_Enter;
            BTN_SignUp.MouseLeave += Mouse_Leave;

            BTN_Calculate.MouseEnter += Mouse_Enter;
            BTN_Calculate.MouseLeave += Mouse_Leave;
        }

        //Sets up the form stack to allow double backing between forms ඞ
        public static class FormStack
        {
            public static Stack<Form> Forms = new Stack<Form>();
        }

        //Checks the username matches the form [CCNNNNNNNN] or [NNNNNNNNNN] while rejecting unicode characters, if so, clears errors and returns true. If false, alerts the user
        private bool ValidateUserName(string userName)
        {
            if ((Regex.IsMatch(userName, @"^[A-Z]{2}") && Regex.IsMatch(userName, @"[0-9]{8}$")) || Regex.IsMatch(userName, @"^[0-9]{10}$"))
            {
                ERR_Validation.SetError(BTN_Login, ""); //Clears errors when successful ඞ
                return true;
            }
            if (userName.Any(c => c > 127))
            {
                ERR_Validation.SetError(RTB_Username, "Your Password contains non-ASCII characters");
                return false;
            }
            ERR_Validation.SetError(BTN_Login, "Your ID has been input incorrectly");
            return false;
        }

        //Checks the password is less than 25 characters in length while rejecting unicode characters. If so, returns true and clears the error. If false, alerts the user
        private bool ValidatePassword(string password)
        {
            if (password.Length > 25)
            {
                ERR_Validation.SetError(RTB_Password, "Your Password exceeds 25 characters");
                return false;
            }
            if (password.Any(c => c > 127))
            {
                ERR_Validation.SetError(RTB_Password, "Your Password contains non-ASCII characters");
                return false;
            }
            ERR_Validation.SetError(RTB_Password, "");
            return true;
        }

        //Sets up and displays the calculate form
        private void BTN_Calculate_Click(object sender, EventArgs e)
        {
                FormStack.Forms.Push(this);
                this.Hide();
                FRM_Calculator calculator = new FRM_Calculator();
                calculator.ShowDialog();          
        }

        //When login is clicked, calls the login function if the username passes validation, if not, sets an error
        private void BTN_Login_Click(object sender, EventArgs e)
        {
            if (ValidateUserName(RTB_Username.Text) && ValidatePassword(RTB_Password.Text))
            {
                Login();
            }
        }

        //Sets up the logic for allowing the user to login, verifying their password and displaying the right form
        private void Login()
        {
            //Sets up a database connection and command that will update their last accessed time and select the user id of the user attemping to login
            string server = "server=rsscalculatorapp.mariadb.database.azure.com;uid=XPAdmin@rsscalculatorapp;pwd=07Ix5@o3geXG;database=calculatorapp;";
            MySqlConnection connection = new MySqlConnection(server);
            string sql = "UPDATE users SET created_at_updated_at = NOW() WHERE user_id=@user_id; SELECT * FROM users WHERE user_id=@user_id";
            MySqlCommand command = new MySqlCommand(sql, connection);
            //Adds the parameter for user id as the username login
            command.Parameters.AddWithValue("@user_id", RTB_Username.Text);
            try
            {
                //Executes the command and reads the output, if an error occurs, display it
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                //Checks if the user_id exists in the database - if not, alert the user
                if (reader.HasRows)
                {
                    //Adds the returned username and the hashed and salted password and compares the password entered by the user to it
                    reader.Read();
                    string hashedPassword = reader.GetString("password");
                    string id = reader.GetString("user_id");
                    bool passwordMatches = BCrypt.Net.BCrypt.Verify(RTB_Password.Text, hashedPassword);
                    //If the password matches, display to the user and checks the title contents returned by the database
                    if (passwordMatches)
                    {
                        string title = reader.GetString("title");
                        MessageBox.Show("Login successful.");
                        //Checks if the title is either doctor or patients and sets up the form to be displayed respectively. If the user is neither, alerts the user
                        switch (title)
                        {
                            case "doctor":
                                FormStack.Forms.Push(this);
                                this.Hide();
                                var drMain = new FRM_DrMain(id);
                                drMain.ShowDialog();
                                break;
                            case "patient":
                                FormStack.Forms.Push(this);
                                this.Hide();
                                var calculator = new FRM_Calculator(id);
                                calculator.ShowDialog();
                                break;
                            default:
                                ERR_Validation.SetError(BTN_Login, "User is neither a doctor nor a patient. Please contact your administrator.");
                                break;
                        }
                    }
                    else
                    {
                        ERR_Validation.SetError(BTN_Login, "Invalid username or password.");
                    }
                }
                else
                {
                    ERR_Validation.SetError(BTN_Login, "Invalid username or password.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Sets up the signup form safely
        private void BTN_SignUp_Click(object sender, EventArgs e)
        {
            FormStack.Forms.Push(this);
            this.Hide();
            FRM_SignUp SignUp = new FRM_SignUp();
            SignUp.ShowDialog();
        }

        //Toggles between the password field being in plaintext vs being hidden when clicking a textbox
        private void CBX_Pass_Log_CheckedChanged(object sender, EventArgs e)
        {
            RTB_Password.UseSystemPasswordChar = !CBX_Pass_Log.Checked;
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
