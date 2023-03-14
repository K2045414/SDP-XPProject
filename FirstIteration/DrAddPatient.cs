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
            previousForm.Show();
            this.Hide();
        }

        private void BTN_SelectPatient_Click(object sender, EventArgs e)
        {
            if (LBX_AllPatients.SelectedIndex >= 0)
            {          
                MySqlConnection connection = new MySqlConnection("server=localhost;uid=root;pwd=12345;database=calculatorapp;");
                MySqlCommand command3 = new MySqlCommand("UPDATE patients SET clinician_id = @clinician_id WHERE user_id = @patient_id", connection);
                command3.Parameters.AddWithValue("@patient_id", LBX_AllPatients.Text);
                command3.Parameters.AddWithValue("@clinician_id", id);
                connection.Open();
                command3.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Clinician ID updated successfully");
                RefreshTable();
            }
            else
            {
                MessageBox.Show("Please select a patient record to add to your care");
            }
        }

        public void RefreshTable()
        {
            LBX_AllPatients.Items.Clear();
            MySqlConnection connection = new MySqlConnection("server=localhost;uid=root;pwd=12345;database=calculatorapp;");
            MySqlCommand command4 = new MySqlCommand("SELECT * FROM patients WHERE clinician_id != @id OR clinician_id IS NULL", connection);
            command4.Parameters.AddWithValue("@id", id);
            connection.Open();
            MySqlDataReader reader = command4.ExecuteReader();
            while (reader.Read())
            {
                string user = reader.GetString("user_id");
                LBX_AllPatients.Items.Add(user);
            }
            connection.Close();          
        }

        private void LBL_Title_Click(object sender, EventArgs e)
        {

        }
    }
}
