using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static FirstIteration.FRM_Login;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FirstIteration
{
    public partial class FRM_DrMain : Form
    {
        private string id;
        public FRM_DrMain(string id)
        {
            InitializeComponent();        
            this.id = id;
            GetPatients();
            LBL_Title.Text = "Hello, " + id;
        }
   

        private void BTN_AddPatient_Click(object sender, EventArgs e)
        {
            FormStack.Forms.Push(this);
            this.Hide();
            FRM_AddPatient AddPatient = new FRM_AddPatient(id);
            AddPatient.ShowDialog();
        }

        private void BTN_SignOut_Click(object sender, EventArgs e)
        {
            Form previousForm = FormStack.Forms.Pop();
            this.Hide();
            previousForm.ShowDialog();
        }

        private void BTN_ImportCSV_Click(object sender, EventArgs e)//Validate stuff
        {           
            ImportCSV();
        }
        private void ImportCSV()
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "CSV file (*.csv)|*.csv|All Files (*.*)|*.*"
            };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                var connectionString = "server=rsscalculatorapp.mariadb.database.azure.com;uid=XPAdmin@rsscalculatorapp;pwd=07Ix5@o3geXG;database=calculatorapp;Allow User Variables=True;";
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();

                    var CSVFile = ofd.FileName;
                    var errorBuilder = new StringBuilder();
                    errorBuilder.Append("During the import process, these ID's returned invalid entries, please manually validate the Data of these patients:");

                    using (var reader = new StreamReader(CSVFile))
                    {
                        var columnNames = reader.ReadLine().Split(',');
                        var csvData = new DataTable();
                        foreach (var columnName in columnNames)
                        {
                            csvData.Columns.Add(columnName);
                        }
                        csvData.Columns.Add("clinician_id", typeof(string));

                        while (!reader.EndOfStream)
                        {
                            var rowValues = reader.ReadLine().Split(',');
                            var row = csvData.NewRow();

                            for (int i = 0; i < columnNames.Length; i++)
                            {
                                row[i] = rowValues[i];
                            }

                            row["clinician_id"] = id;


                            command.CommandText = "SELECT COUNT(*) FROM patients WHERE user_id = @user_id";
                            command.Parameters.Clear();
                            command.Parameters.AddWithValue("@user_id", row["PatientID"]);                            


                            var existingUserCount = Convert.ToInt32(command.ExecuteScalar());

                            if (existingUserCount > 0)
                            {
                                command.CommandText = "UPDATE patients set gender = @gender, race = @race, age = @age, creatinine = @creatinine where user_id = @user_id";
                            }
                            else
                            {
                                command.CommandText = "INSERT INTO patients (user_id, gender, race, age, creatinine, clinician_id) VALUES (@user_id, @gender, @race, @age, @creatinine, @clinician_id)";
                            }

                            if (row["gender"].ToString() == "1")
                            {
                                row["gender"] = "M";
                            }
                            else if (row["gender"].ToString() == "0")
                            {
                                row["gender"] = "F";
                            }
                            else
                            {
                                row["gender"] = "?";
                            }

                            command.Parameters.Clear();
                            command.Parameters.AddWithValue("@user_id", row["PatientID"]);
                            command.Parameters.AddWithValue("@gender", row["Gender"]);
                            command.Parameters.AddWithValue("@race", row["Ethnicity"]);
                            command.Parameters.AddWithValue("@age", row["Age"]);
                            command.Parameters.AddWithValue("@creatinine", row["Creatinine"]);
                            command.Parameters.AddWithValue("@clinician_id", row["clinician_id"]);

                            var validationTuple = ValidateCSVloop(row["PatientID"].ToString(), row["Gender"].ToString(), row["Ethnicity"].ToString(), row["Age"].ToString(), row["Creatinine"].ToString(), row["clinician_id"].ToString());
                            if (validationTuple.Item1)
                            {
                                command.ExecuteNonQuery();
                                csvData.Rows.Add(row);
                            }
                            else
                            {
                                errorBuilder.AppendLine();
                                errorBuilder.Append(row["PatientID"] + ": " + validationTuple.Item2);
                            }
                        }
                    }
                    connection.Close();

                    MessageBox.Show(errorBuilder.ToString());

                    GetPatients();
                }
            }
        }

        private Tuple<bool, string> ValidateCSVloop(string Pid, string Gend, string Eth, string age, string Crea, string Clin)
        {
            if (Pid.Length != 10) return Tuple.Create(false, "Patient ID Invalid");
            if (Gend != "M" && Gend != "F") return Tuple.Create(false, "Gender Invalid");
            if (Eth != "B" && Eth != "O") return Tuple.Create(false, "Ethnicity Invalid");
            if (!int.TryParse(age, out int ageInt) || ageInt < 18 || ageInt > 100) return Tuple.Create(false, "Age Invalid");
            if (!int.TryParse(Crea, out int creaInt)) return Tuple.Create(false, "Creatinine Invalid");
            if (Clin.Length != 10) return Tuple.Create(false, "Clinician ID Invalid");
            return Tuple.Create(true, "");
        }

        private void BTN_EditPatient_Click(object sender, EventArgs e)
        {
            if (LBX_Patients.SelectedIndex >= 0)
            {
                string patient_id = LBX_Patients.Text;
                FormStack.Forms.Push(this);
                this.Hide();
                FRM_Calculator Calculator = new FRM_Calculator(patient_id);
                Calculator.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a patient record to view");
            }            
        }

        public void GetPatients()
        {
            LBX_Patients.Items.Clear();

            var connection = new MySqlConnection("server=rsscalculatorapp.mariadb.database.azure.com;uid=XPAdmin@rsscalculatorapp;pwd=07Ix5@o3geXG;database=calculatorapp;");
            var command = new MySqlCommand("SELECT * FROM patients WHERE clinician_id=@clinician_id", connection);
            command.Parameters.AddWithValue("@clinician_id", id);

            connection.Open();
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                string user = reader.GetString("user_id");
                LBX_Patients.Items.Add(user);
            }
        }


        private void BTN_RemovePatient_Click(object sender, EventArgs e)
        {
            using (MySqlConnection connection = new MySqlConnection("server=rsscalculatorapp.mariadb.database.azure.com;uid=XPAdmin@rsscalculatorapp;pwd=07Ix5@o3geXG;database=calculatorapp;"))
            {
                MySqlCommand command = new MySqlCommand("update patients SET clinician_id = Null WHERE user_id=@patient_id", connection);

                if (LBX_Patients.SelectedIndex >= 0)
                {
                    string patient_id = LBX_Patients.Text;
                    command.Parameters.AddWithValue("@patient_id", patient_id);

                    DialogResult result = MessageBox.Show("Are you sure you want to remove this patient record?", "Confirmation", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            connection.Open();
                            command.ExecuteNonQuery();
                            MessageBox.Show("Patient record removed successfully.");
                            LBX_Patients.Items.Clear();
                            GetPatients();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex.Message);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please select a patient record to remove");
                }
            }
        }

    }
}
