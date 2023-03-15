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
            AddPatient.Show();
        }

        private void BTN_SignOut_Click(object sender, EventArgs e)
        {
            Form previousForm = FormStack.Forms.Pop();
            this.Hide();
            previousForm.Show();
        }

        private void BTN_ImportCSV_Click(object sender, EventArgs e)//Validate stuff
        {           
            ImportCSV();
        }
        private void ImportCSV()//run the import
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "CSV file (*.csv)|*.csv|All Files (*.*)|*.*";
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                MySqlConnection connection = new MySqlConnection("server=rsscalculatorapp.mariadb.database.azure.com;uid=XPAdmin@rsscalculatorapp;pwd=07Ix5@o3geXG;database=calculatorapp;");
                MySqlCommand command = connection.CreateCommand();
                string CSVFile = ofd.FileName;
                StringBuilder Error = new StringBuilder();
                Error.Append("During the import process, these ID's returned invalid entries, please manually validate the Data of these patients:");
                DataTable CSVdata = new DataTable();
                //CSVdata.Columns["clinician_id"].DefaultValue = id;
                using (StreamReader reader = new StreamReader(CSVFile))
                {
                    string[] columnNames = reader.ReadLine().Split(',');
                    foreach (string columnName in columnNames)// give us column names from CSV
                    {
                        CSVdata.Columns.Add(columnName);
                    }
                    CSVdata.Columns.Add("clinician_id", typeof(string));
                    while (!reader.EndOfStream)
                    {
                        string[] rowValues = reader.ReadLine().Split(',');
                        DataRow row = CSVdata.NewRow();
                        for (int i = 0; i < columnNames.Length; i++)// give us 1 row of the Datatable using the columns as a counter
                        {
                            row[i] = rowValues[i];     
                        }
                        row[5] = id;
                        
                        
                        command.CommandText = "SELECT COUNT(*) FROM patients WHERE user_id = @user_id;";
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@user_id", row[0]);
                        connection.Open();
                        int existingUserCount = Convert.ToInt32(command.ExecuteScalar());// check if ID is in use
                        connection.Close();

                        if (existingUserCount > 0)
                        {
                            command.CommandText = "UPDATE patients set gender = @gender, race = @race, age = @age, creatinine = @creatinine where user_id = @user_id";// if id is in use run UPDATE
                        }
                        else
                        {
                            command.CommandText = "INSERT INTO patients (user_id, gender, race, age, creatinine, clinician_id) VALUES (@user_id, @gender, @race, @age, @creatinine, @clinician_id)";// if id is not in use run INSERT
                        }
                        string x = row[1].ToString();
                        if (x == "1")
                        {
                            row[1] = "M";
                        }
                        else if (x == "0")
                        {
                            row[1] = "F";
                        }
                        else
                        {
                            row[1] = "?";
                        }
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@user_id", row[0]);
                        command.Parameters.AddWithValue("@gender", row[1]);
                        command.Parameters.AddWithValue("@race", row[2]);
                        command.Parameters.AddWithValue("@age", row[3]);
                        command.Parameters.AddWithValue("@creatinine", row[4]);
                        command.Parameters.AddWithValue("@clinician_id", row[5]);
                        if (ValidateCSVloop(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString()).Item1)
                        {
                            connection.Open();
                            command.ExecuteNonQuery();
                            connection.Close();
                            CSVdata.Rows.Add(row);
                        }
                        else
                        {
                            Error.AppendLine();
                            Error.Append(row[0] + ": " + ValidateCSVloop(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString()).Item2);
                        }
                        
                        //MessageBox.Show(Dump(CSVdata));
                    }
                }
                MessageBox.Show(Error.ToString());
                GetPatients();
            }
        }
        private Tuple<bool, string> ValidateCSVloop(string Pid, string Gend, string Eth, string age, string Crea, string Clin)// validate the Fields of the Imported CSV as a whole, if one is off the insert/update is skipped
        {
            if (Pid.Length == 10)
            {
                if (Gend == "M" || Gend == "F")
                {
                    if (Eth == "B" || Eth == "O")
                    {
                        if (Regex.IsMatch(age, @"^[0-9]+$") && (Int32.Parse(age) <= 100 && Int32.Parse(age) >= 18))
                        {
                            if (Regex.IsMatch(Crea, @"^[0-9]+$"))
                            {
                                if (Clin.Length == 10)
                                {
                                    return Tuple.Create(true, "");
                                }
                                else
                                {
                                    return Tuple.Create(false, "Clinician ID Invalid");
                                }
                            }
                            else
                            {
                                return Tuple.Create(false, "Creatinine Invalid");
                            }
                        }
                        else
                        {
                            return Tuple.Create(false, "Age Invalid");
                        }
                    }
                    else
                    {
                        return Tuple.Create(false, "Ethnicity Invalid");
                    }
                }
                else
                {
                    return Tuple.Create(false, "Gender Invalid");
                }
            }
            else
            {
                return Tuple.Create(false, "Patient ID Invalid");
            }
        }
        //--------------------------------------------------------------Redundant held for recycling, remove later--------------------------------------------------------------//
        private string Dump(DataTable table)
        {
            string data = string.Empty;
            StringBuilder x = new StringBuilder();

            if (null != table && null != table.Rows)
            {
                foreach (DataRow dataRow in table.Rows)
                {
                    foreach (DataColumn column in table.Columns)
                    {
                        string z = column.ColumnName;
                        string y = dataRow[column].ToString(); 
                        if (ValCSV(z, y) == false)
                        {
                            x.Append(column.ColumnName + " ");

                            x.Append("Invalid Field");
                            x.Append(',');
                        }
                        else
                        {
                            x.Append(column.ColumnName + " ");
                            x.Append(dataRow[column].ToString());
                            x.Append(',');
                        }
                    }
                    x.AppendLine();
                }

                data = x.ToString();
            }
            return data;
        }
        private bool ValCSV(string col, string row)
        {
            bool ValidCSV = false;
            switch (col)
            {
                case "user_id":
                    if (row.Length == 10 && Regex.IsMatch(row, @"^[0-9A-Z]+$"))
                    {
                        ValidCSV = true;
                    }
                    break;
                case "gender":
                    if (row == "1" || row == "0")
                    {
                        ValidCSV = true;
                    }
                    break;
                case "race":
                    if (row == "B" || row == "O")
                    {
                        ValidCSV = true;
                    }
                    break;
                case "age":
                    if (Regex.IsMatch(row, @"^[0-9]+$"))
                    {
                        ValidCSV = true;
                    }
                    break;
                case "creatinine":
                    if (Regex.IsMatch(row, @"^[0-9]+$"))
                    {
                        ValidCSV = true;
                    }
                    break;
                case "clinician_id":
                    if (Regex.IsMatch(row, @"^[0-9]+$"))
                    {
                        ValidCSV = true;
                    }
                    break;
                default:
                    break;
            }
            return ValidCSV;
        }
        //--------------------------------------------------------------Redundant held for recycling, remove later--------------------------------------------------------------//

        public void FRM_DrMain_Load(object sender, EventArgs e)
        {
            
        }
        private void BTN_EditPatient_Click(object sender, EventArgs e)
        {
            if (LBX_Patients.SelectedIndex >= 0)
            {
                string patient_id = LBX_Patients.Text;
                FormStack.Forms.Push(this);
                this.Hide();
                FRM_Calculator Calculator = new FRM_Calculator(patient_id);
                Calculator.Show();
            }
            else
            {
                MessageBox.Show("Please select a patient record to view");
            }
            
        }

        public void GetPatients()
        {
            LBX_Patients.Items.Clear();
            MySqlConnection connection = new MySqlConnection("server=rsscalculatorapp.mariadb.database.azure.com;uid=XPAdmin@rsscalculatorapp;pwd=07Ix5@o3geXG;database=calculatorapp;");
            MySqlCommand command1 = new MySqlCommand("SELECT * FROM patients WHERE clinician_id=@clinician_id", connection);
            command1.Parameters.AddWithValue("@clinician_id", id);
            connection.Open();
            MySqlDataReader reader = command1.ExecuteReader();
            while (reader.Read())
            {
                string user = reader.GetString("user_id");
                LBX_Patients.Items.Add(user);
            }
        connection.Close();
        }

        private void BTN_RemovePatient_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection("server=localhost;uid=root;pwd=12345;database=calculatorapp;");
            MySqlCommand command2 = new MySqlCommand("update patients SET clinician_id = Null WHERE user_id=@patient_id", connection);

            if (LBX_Patients.SelectedIndex >= 0)
            {
                string patient_id = LBX_Patients.Text;
                command2.Parameters.AddWithValue("@patient_id", patient_id);

                DialogResult result = MessageBox.Show("Are you sure you want to remove this patient record?", "Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        connection.Open();
                        command2.ExecuteNonQuery();
                        connection.Close();
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
                MessageBox.Show("Please select a patient record to view");
            }
        }

        private void LBL_Title_Click(object sender, EventArgs e)
        {

        }
    }
}
