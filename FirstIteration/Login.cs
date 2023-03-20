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

        //sets up the form stack to allow double backing between forms ඞ
        public static class FormStack
        {
            public static Stack<Form> Forms = new Stack<Form>();
        }

        //THIS MUST CHANGE TO ACTUAL VALIDATION 
        private bool ValidateUserName(string userName)
        {
            if ((Regex.IsMatch(userName, @"^[A-Z]{2}") && Regex.IsMatch(userName, @"[0-9]{8}$")) || Regex.IsMatch(userName, @"^[0-9]{10}$"))
            {
                ERR_Validation.SetError(BTN_Login, ""); //Clears errors when successful ඞ
                return true;
            }
            ERR_Validation.SetError(BTN_Login, "Your ID has been input incorrectly");
            return false;
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
            if (ValidateUserName(RTB_Username.Text))
            {
                Login();
            }
        }

        private void Login()
        {
            //sets up a database connection and command that will
            MySqlConnection connection = new MySqlConnection("server=rsscalculatorapp.mariadb.database.azure.com;uid=XPAdmin@rsscalculatorapp;pwd=07Ix5@o3geXG;database=calculatorapp;");
            MySqlCommand command = new MySqlCommand("UPDATE users SET created_at_updated_at = NOW() WHERE user_id=@user_id; SELECT * FROM users WHERE user_id=@user_id", connection);
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

        private void BTN_SignUp_Click(object sender, EventArgs e)
        {
            FormStack.Forms.Push(this);
            this.Hide();
            FRM_SignUp SignUp = new FRM_SignUp();
            SignUp.ShowDialog();
        }

        private void CBX_Pass_Log_CheckedChanged(object sender, EventArgs e)
        {
            RTB_Password.UseSystemPasswordChar = !CBX_Pass_Log.Checked ? true : false;
        }
    }
}
