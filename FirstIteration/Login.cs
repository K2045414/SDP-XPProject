using MySqlConnector;
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
            FRM_Calculator OptionPage = new FRM_Calculator();
            OptionPage.Show();
        }

        private void BTN_Login_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection("server=localhost;uid=root;pwd=12345;database=calculatorapp;");
            MySqlCommand command = new MySqlCommand("SELECT * FROM users WHERE username=@username", connection);
            command.Parameters.AddWithValue("@username", RTB_Username.Text);

            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    string hashedPassword = reader.GetString("password");
                    bool passwordMatches = BCrypt.Net.BCrypt.Verify(RTB_Password.Text, hashedPassword);

                    if (passwordMatches)
                    {
                        MessageBox.Show("Login successful.");
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password.");
                    }
                }
                else
                {
                    MessageBox.Show("Invalid username or password.");
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
    }
}
