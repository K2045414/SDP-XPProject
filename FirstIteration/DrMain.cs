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

namespace FirstIteration
{
    public partial class FRM_DrMain : Form
    {
        private string id;
        public FRM_DrMain(string id)
        {
            InitializeComponent();
            this.id = id;
        }
   

        private void BTN_AddPatient_Click(object sender, EventArgs e)
        {
            FormStack.Forms.Push(this);
            this.Hide();
            FRM_AddPatient AddPatient = new FRM_AddPatient();
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
                string CSVFile = ofd.FileName;
                DataTable CSVdata = new DataTable();
                using (StreamReader reader = new StreamReader(CSVFile))
                {
                    string[] columnNames = reader.ReadLine().Split(',');
                    foreach (string columnName in columnNames)
                    {
                        CSVdata.Columns.Add(columnName);
                    }
                    while (!reader.EndOfStream)
                    {
                        string[] rowValues = reader.ReadLine().Split(',');
                        DataRow row = CSVdata.NewRow();
                        for (int i = 0; i < columnNames.Length; i++)
                        {
                            row[i] = rowValues[i];
                        }
                        CSVdata.Rows.Add(row);
                    }
                }
                MySqlConnection connection = new MySqlConnection("server=localhost;uid=root;pwd=12345;database=calculatorapp;allowLoadLocalInfile=true;");
                MySqlBulkCopy bulkcopy = new MySqlBulkCopy(connection);
                bulkcopy.DestinationTableName = "patients";
                try
                {
                    bulkcopy.WriteToServer(CSVdata);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                MessageBox.Show(Dump(CSVdata));
            }
        }
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
                        if (ValidateCSV(z, y) == false)
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
        private bool ValidateCSV(string col, string row)
        {
            bool ValidCSV = false;
            switch (col)
            {
                case "PatientID":
                    if (row.Length == 10 && Regex.IsMatch(row, @"^[0-9A-Z]+$"))
                    {
                        ValidCSV = true;
                    }
                    break;
                case "Gender":
                    if (row == "1" || row == "0")
                    {
                        ValidCSV = true;
                    }
                    break;
                case "Ethnicity":
                    if (row == "B" || row == "O")
                    {
                        ValidCSV = true;
                    }
                    break;
                case "Age":
                    if (Regex.IsMatch(row, @"^[0-9]+$"))
                    {
                        ValidCSV = true;
                    }
                    break;
                case "Creatinine":
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

        public void FRM_DrMain_Load(object sender, EventArgs e)
        {
            MessageBox.Show(id);
            MySqlConnection connection = new MySqlConnection("server=localhost;uid=root;pwd=12345;database=calculatorapp;");
            MySqlCommand command = new MySqlCommand("SELECT * FROM patients WHERE clinician_id=@clinician_id", connection);
            command.Parameters.AddWithValue("@clinician_id", id);
            connection.Open();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string user = reader.GetString("user_id");
                LBX_Patients.Items.Add(user);
            }
            connection.Close();
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
    }
}
