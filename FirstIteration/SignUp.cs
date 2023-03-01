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
                string passwordHash = BCrypt.Net.BCrypt.HashPassword(RTB_Password1.Text);
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

    }
}
