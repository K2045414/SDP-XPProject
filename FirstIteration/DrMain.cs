using MySqlConnector;
using System;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq.Expressions;
using System.Text;
using System.Windows.Forms;
using static FirstIteration.FRM_Login;

namespace FirstIteration
{
    //Passes the string id from login
    public partial class FRM_DrMain : Form
    {
        private readonly string id;

        //Runs the function GetPatients and sets the title to present the referenced user id
        public FRM_DrMain(string id)
        {
            InitializeComponent();
            this.id = id;
            GetPatients();
            LBL_Title.Text = "Hello, " + id;

            BTN_SignOut.MouseEnter += Mouse_Enter;
            BTN_SignOut.MouseLeave += Mouse_Leave;

            BTN_AddPatient.MouseEnter += Mouse_Enter;
            BTN_AddPatient.MouseLeave += Mouse_Leave;

            BTN_EditPatient.MouseEnter += Mouse_Enter;
            BTN_EditPatient.MouseLeave += Mouse_Leave;

            BTN_RemovePatient.MouseEnter += Mouse_Enter;
            BTN_RemovePatient.MouseLeave += Mouse_Leave;

            BTN_ImportCSV.MouseEnter += Mouse_Enter;
            BTN_ImportCSV.MouseLeave += Mouse_Leave;
        }

        //Opens the AddPatient form and safely hides the current one
        private void BTN_AddPatient_Click(object sender, EventArgs e)
        {
            FormStack.Forms.Push(this);
            this.Hide();
            FRM_AddPatient AddPatient = new FRM_AddPatient(id);
            AddPatient.ShowDialog();
        }

        //Hides the current form and reloads the previous form
        private void BTN_SignOut_Click(object sender, EventArgs e)
        {
            Form previousForm = FormStack.Forms.Pop();
            this.Hide();
            previousForm.Show();
        }

        //Runs the ImportCSV function when the button is clicked
        private void BTN_ImportCSV_Click(object sender, EventArgs e)
        {
            ImportCSV();
        }

        private void ImportCSV()
        {
            //Filters for only .csv files and folders
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "CSV file (*.csv)|*.csv|All Files (*.*)|*.*"
            };
            

            //Checks the file has passed the .csv filter and sets up a connection with the database
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                var server = "server=rsscalculatorapp.mariadb.database.azure.com;uid=XPAdmin@rsscalculatorapp;pwd=07Ix5@o3geXG;database=calculatorapp;Allow User Variables=True;";
                using (var connection = new MySqlConnection(server))
                {
                    //Sets up the variables for the command to be used, csv file to reference, and handling invalid data.
                    connection.Open();
                    var sql = connection.CreateCommand();
                    var CSVFile = ofd.FileName;
                    var errorBuilder = new StringBuilder();
                    errorBuilder.Append("During the import process, these ID's returned invalid entries, please manually validate the Data of these patients:");
                    //Checks the headings in the first line of the .csv, delimited by commas and sets them as columnNames and populates a datatable to hold these in as headings. It also adds a clinician_id heading to future assign the logged in clinician
                    using (var reader = new StreamReader(CSVFile))
                    {
                        var columnNames = reader.ReadLine().Split(',');
                        var csvData = new DataTable();
                        foreach (var columnName in columnNames)
                        {
                            csvData.Columns.Add(columnName);
                        }
                        csvData.Columns.Add("clinician_id", typeof(string));
                        //populates each row of the datatable with each input being the data delimited by commas in the .csv file and sets the added clinician_id field to the passed id from the login form
                        while (!reader.EndOfStream)
                        {
                            var rowValues = reader.ReadLine().Split(',');
                            var row = csvData.NewRow();
                            for (int i = 0; i < columnNames.Length; i++)
                            {
                                row[i] = rowValues[i];
                            }
                            row["clinician_id"] = id;
                            //Sets a database command up to select the number of patients where the user id already in the patients database so the program can decide to insert a new user or update an existing user. It sets the parameter as the current PatientID in the datatable and converts the resulting value to an int.
                            sql.CommandText = "SELECT COUNT(*) FROM patients WHERE user_id = @user_id";
                            sql.Parameters.Clear();
                            sql.Parameters.AddWithValue("@user_id", row["PatientID"]);
                            var existingUserCount = Convert.ToInt32(sql.ExecuteScalar());
                            //Checks if the number returned is greater than 0, indicating there is already that user id in the database, as such, sets the command to update it. Otherwise, sets the command to insert a new record
                            if (existingUserCount > 0)
                            {
                                sql.CommandText = "UPDATE patients set gender = @gender, race = @race, age = @age, creatinine = @creatinine where user_id = @user_id";
                            }
                            else
                            {
                                sql.CommandText = "INSERT INTO patients (user_id, gender, race, age, creatinine, clinician_id) VALUES (@user_id, @gender, @race, @age, @creatinine, @clinician_id)";
                            }
                            //Converts the gender input (1 or 0) to M, F or ? for ubiquity in the database
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
                            //Clears any current parameters and sets the command parameters for the database with the corresponsding data table entries 
                            sql.Parameters.Clear();
                            sql.Parameters.AddWithValue("@user_id", row["PatientID"]);
                            sql.Parameters.AddWithValue("@gender", row["Gender"]);
                            sql.Parameters.AddWithValue("@race", row["Ethnicity"]);
                            sql.Parameters.AddWithValue("@age", row["Age"]);
                            sql.Parameters.AddWithValue("@creatinine", row["Creatinine"]);
                            sql.Parameters.AddWithValue("@clinician_id", row["clinician_id"]);
                            //Creates a tuple containing all the state of data input, true, if they've been validated, or false and an error message if they fail the validation
                            var validationTuple = ValidateCSVloop(row["PatientID"].ToString(), row["Gender"].ToString(), row["Ethnicity"].ToString(), row["Age"].ToString(), row["Creatinine"].ToString(), row["clinician_id"].ToString());
                            //Runs the previously set up command to insert/update the database with the validated information row-by-row, otherwise adds what triggered the validation check along with the patient id that triggered it to an error list
                            if (validationTuple.Item1)
                            {
                                sql.ExecuteNonQuery();
                                csvData.Rows.Add(row);
                            }
                            else
                            {
                                errorBuilder.AppendLine();
                                errorBuilder.Append(row["PatientID"] + ": " + validationTuple.Item2);
                            }
                        }
                    }
                    //closes the database connection, displays the error list and refreshes the patient list with the newly added patients
                    connection.Close();
                    MessageBox.Show(errorBuilder.ToString());
                    GetPatients();
                }
            }
        }

        //Checks the patient_ids are a length of 10, the gender is either M or F (after being converted), Ethnicity is either B or O, Age is between 18 and 100 and a number, creatinine a number and clinician_id is 10 digits. Returns an error message if any of these are flagged to build the error list
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
            //Checks if a patient is selected, if not, alerts the user. If so, opens an instance of the calculator and passing the patient_id over
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

        //Clears the listbox, sets up a connection with the database, and a command that will select all the user_ids with their clinician matching the logged in clinician, execture the command and populate the listbox with the returned user_ids
        public void GetPatients()
        {
            LBX_Patients.Items.Clear();
            string server = "server=rsscalculatorapp.mariadb.database.azure.com;uid=XPAdmin@rsscalculatorapp;pwd=07Ix5@o3geXG;database=calculatorapp;";
            var connection = new MySqlConnection(server);
            string sql = "SELECT * FROM patients WHERE clinician_id=@clinician_id";
            var command = new MySqlCommand(sql, connection);
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
            //sets up a new database connection
            string server = "server=rsscalculatorapp.mariadb.database.azure.com;uid=XPAdmin@rsscalculatorapp;pwd=07Ix5@o3geXG;database=calculatorapp;";
            using (MySqlConnection connection = new MySqlConnection(server))
            {
                //Sets the command to set a patient's clinician id to NULL
                string sql = "update patients SET clinician_id = Null WHERE user_id=@patient_id";
                MySqlCommand command = new MySqlCommand(sql, connection);
                //Checks if the a patient is selected in the listbox, if not, alerts the user
                if (LBX_Patients.SelectedIndex >= 0)
                {
                    //sets the patient id to the selected patient, and sets that as a parameter for the database query. Alerts the user if they are sure, if they press no, returns
                    string patient_id = LBX_Patients.Text;
                    command.Parameters.AddWithValue("@patient_id", patient_id);
                    DialogResult result = MessageBox.Show("Are you sure you want to remove this patient record?", "Confirmation", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        //Tries to execute the database query. If successful, alerts the user, clears the listbox and refreshes it with the up-to-date patients. If not successful, alerts the user
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
