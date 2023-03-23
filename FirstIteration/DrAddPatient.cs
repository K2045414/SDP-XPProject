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
    //pulls id from DrMain form
    public partial class FRM_AddPatient : Form
    {
        private readonly string id;

        //Refreshes the table with collected ids, makes sure when form is loaded, table is accurately populated
        public FRM_AddPatient(string id)
        {
            InitializeComponent();
            this.id = id;
            RefreshTable();
            BTN_Back.MouseEnter += Mouse_Enter;
            BTN_Back.MouseLeave += Mouse_Leave;

            BTN_SelectPatient.MouseEnter += Mouse_Enter;
            BTN_SelectPatient.MouseLeave += Mouse_Leave;
        }

        //Safely returns to the parent form - also sets a variable parentForm to be used in the GetPatients function when returning
        private void BTN_Back_Click(object sender, EventArgs e)
        {
            FRM_DrMain parentForm = (FRM_DrMain)FormStack.Forms.Peek();
            parentForm.GetPatients();
            Form previousForm = FormStack.Forms.Pop();
            previousForm.Show();
            this.Hide();
        }

        private void BTN_SelectPatient_Click(object sender, EventArgs e)
        {
            //Checks that there is a patient selected - if not alerts the user
            if (LBX_AllPatients.SelectedIndex >= 0)
            {
                //Sets up connection with the database
                string server = "server=rsscalculatorapp.mariadb.database.azure.com;uid=XPAdmin@rsscalculatorapp;pwd=07Ix5@o3geXG;database=calculatorapp;";
                using (MySqlConnection connection = new MySqlConnection(server))
                {
                    //Sets up a command to update the database entry at the patient selected with the signed in clinician id
                    string sql = "UPDATE patients SET clinician_id = @clinician_id WHERE user_id = @patient_id";
                    using (MySqlCommand command = new MySqlCommand(sql, connection))
                    {
                        //Sets the clinicican_id to the signed in clinician's id and sets the patient_id to the value selected
                        command.Parameters.AddWithValue("@patient_id", LBX_AllPatients.Text);
                        command.Parameters.AddWithValue("@clinician_id", id);
                        try
                        {
                            //Sends the command and alerts the user if done so successfully by checking rows affected is more than 0. If not, throws an error
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

        //Clears all current items in the listbox and sets up a command to retrive all patients not under the care of the signed in clinician
        public void RefreshTable()
        {
            LBX_AllPatients.Items.Clear();
            string sql = "SELECT * FROM patients WHERE clinician_id != @id OR clinician_id IS NULL";
            string server = "server=rsscalculatorapp.mariadb.database.azure.com;uid=XPAdmin@rsscalculatorapp;pwd=07Ix5@o3geXG;database=calculatorapp;";
            using (var connection = new MySqlConnection(server))
            using (MySqlCommand command = new MySqlCommand(sql, connection))
            {
                //adds the clinician id as a parameter
                command.Parameters.AddWithValue("@id", id);
                try
                {
                    //Sends the command, and for each user that is returned, adds the id to the listbox
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
        private void Mouse_Leave(object sender, EventArgs e)
        {
            var btn = (System.Windows.Forms.Button)sender;
            btn.BackgroundImage = Properties.Resources.Button3;
        }

        private void Mouse_Enter(object sender, EventArgs e)
        {
            var btn = (System.Windows.Forms.Button)sender;
            btn.BackgroundImage = Properties.Resources.ButtonHover;
        }

    }
}