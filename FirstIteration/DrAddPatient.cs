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
using static FirstIteration.FRM_Login;

namespace FirstIteration
{
    public partial class FRM_AddPatient : Form
    {
        private string id;
        public FRM_AddPatient(string id)
        {
            InitializeComponent();
            this.id = id;
            RefreshTable();
        }
        public FRM_AddPatient()
        {
            InitializeComponent();
        }

        private void BTN_Back_Click(object sender, EventArgs e)
        {
          

            // Get a reference to the parent form (FRM_DrMain)
            FRM_DrMain parentForm = (FRM_DrMain)FormStack.Forms.Peek();

            // Update the patients list on the parent form
            parentForm.GetPatients();
            // Get the previous form in the stack
            Form previousForm = FormStack.Forms.Pop();
            // Hide the current form (FRM_AddPatient) and show the previous one (FRM_DrMain)
            previousForm.ShowDialog ();
            this.Hide();
        }

        private void BTN_SelectPatient_Click(object sender, EventArgs e)
        {
            if (LBX_AllPatients.SelectedIndex >= 0)
            {
                using (MySqlConnection connection = new MySqlConnection("server=rsscalculatorapp.mariadb.database.azure.com;uid=XPAdmin@rsscalculatorapp;pwd=07Ix5@o3geXG;database=calculatorapp;"))
                {
                    string query = "UPDATE patients SET clinician_id = @clinician_id WHERE user_id = @patient_id";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@patient_id", LBX_AllPatients.Text);
                        command.Parameters.AddWithValue("@clinician_id", id);

                        try
                        {
                            connection.Open();
                            int rowsAffected = command.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Clinician ID updated successfully");
                                RefreshTable();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("An error occurred: " + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a patient record to add to your care");
            }
        }


        public void RefreshTable()
        {
            LBX_AllPatients.Items.Clear();

            string connectionString = "server=localhost;uid=root;pwd=12345;database=calculatorapp;";
            string query = "SELECT * FROM patients WHERE clinician_id != @id OR clinician_id IS NULL";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@id", id);

                try
                {
                    connection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string user = reader.GetString("user_id");
                            LBX_AllPatients.Items.Add(user);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }

    }
}
