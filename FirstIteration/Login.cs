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
      

        public static class FormStack
        {
            public static Stack<Form> Forms = new Stack<Form>();
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
        private void BTN_Calculate_Click(object sender, EventArgs e)
        {
                FormStack.Forms.Push(this);
                this.Hide();
                FRM_Calculator calculator = new FRM_Calculator();
                calculator.ShowDialog();          
        }

        private void BTN_Login_Click(object sender, EventArgs e)
        {
            if (ValidateUserName(RTB_Username.Text))
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
                                ERR_Validation.SetError(RTB_Username, "User is neither a doctor nor a patient. Please contact your administrator.");
                                break;
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
