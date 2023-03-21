using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static FirstIteration.FRM_Login;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace FirstIteration
{
    public partial class FRM_Calculator : Form
    {
        private readonly string patient_id;
        public FRM_Calculator()
        {
            InitializeComponent();
            CBX_Calculation.Text = "MDRD";
        }

        public FRM_Calculator(string patient_id)
        {
            InitializeComponent();
            this.patient_id = patient_id;
            if (patient_id == null)
            {
                return;
            }
            ConfigureForm(patient_id);
            CBX_Calculation.Text = "MDRD";
            var connectionString = "server=rsscalculatorapp.mariadb.database.azure.com;uid=XPAdmin@rsscalculatorapp;pwd=07Ix5@o3geXG;database=calculatorapp;";
            using (var connection = new MySqlConnection(connectionString))
            {
                var command = new MySqlCommand("SELECT * FROM patients WHERE user_id=@patient_id", connection);
                command.Parameters.AddWithValue("@patient_id", patient_id);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string race = reader.IsDBNull(reader.GetOrdinal("race")) ? "0" : reader.GetString("race");
                        string gender = reader.IsDBNull(reader.GetOrdinal("gender")) ? "0" : reader.GetString("gender");
                        int height = reader.IsDBNull(reader.GetOrdinal("height")) ? 0 : reader.GetInt32("height");
                        int weight = reader.IsDBNull(reader.GetOrdinal("weight")) ? 0 : reader.GetInt32("weight");
                        int age = reader.IsDBNull(reader.GetOrdinal("age")) ? 0 : reader.GetInt32("age");
                        int creatinine = reader.IsDBNull(reader.GetOrdinal("age")) ? 0 : reader.GetInt32("creatinine");
                        switch (race)
                        {
                            case "B":
                                race = "Black";
                                break;
                            case "O":
                                race = "Other";
                                break;
                            default:
                                race = "";
                                break;
                        }
                        switch (gender)
                        {
                            case "M":
                                gender = "Male";
                                break;
                            case "F":
                                gender = "Female";
                                break;
                            default:
                                gender = "";
                                break;
                        }
                        CBX_Ethnicity.Text = race;
                        CBX_Gender.Text = gender;
                        RTB_Height.Text = height.ToString();
                        RTB_Weight.Text = weight.ToString();
                        RTB_Age.Text = age.ToString();
                        RTB_Creatinine.Text = creatinine.ToString();
                        RBN_umolL.Checked = true;
                    }
                }
            }
        }

        private void ConfigureForm(string patient_id)
        {
            BTN_Edit.Visible = true;
            RTB_Creatinine.Enabled = false;
            RBN_mgdL.Enabled = false;
            RBN_umolL.Enabled = false;
            RTB_Age.Enabled = false;
            CBX_Gender.Enabled = false;
            CBX_Ethnicity.Enabled = false;
            CBX_Calculation.Enabled = false;
            RTB_Weight.Enabled = false;
            RTB_Height.Enabled = false;
            RTB_eGFR.Enabled = false;
            LBL_Title.Text = "Calculator: " + patient_id;
        }

        private bool ValidateCreatinine()
        {
            string creatinineInput = RTB_Creatinine.Text.Trim();
            if (string.IsNullOrEmpty(creatinineInput))
            {
                ERR_Validation.SetError(RTB_Creatinine, "Please enter your creatinine value");
                return false;
            }
            if (!double.TryParse(creatinineInput, out double creatinineValue))
            {
                ERR_Validation.SetError(RTB_Creatinine, "Please enter a valid number for creatinine");
                return false;
            }
            if (creatinineValue <= 0)
            {
                ERR_Validation.SetError(RTB_Creatinine, "Creatinine value should be greater than zero");
                return false;
            }
            ERR_Validation.SetError(RTB_Creatinine, string.Empty);
            return true;
        }

        private bool ValidateHeight()
        {
            string heightInput = RTB_Height.Text.Trim();
            if (string.IsNullOrEmpty(heightInput))
            {
                ERR_Validation.SetError(RTB_Height, "Please enter your height");
                return false;
            }
            if (!int.TryParse(heightInput, out int heightValue))
            {
                ERR_Validation.SetError(RTB_Height, "Please enter a valid number for height");
                return false;
            }
            if (heightValue <= 0)
            {
                ERR_Validation.SetError(RTB_Height, "Height should be greater than zero");
                return false;
            }
            ERR_Validation.SetError(RTB_Height, string.Empty);
            return true;
        }

        private bool ValidateWeight()
        {
            string weightInput = RTB_Weight.Text.Trim();
            if (string.IsNullOrEmpty(weightInput))
            {
                ERR_Validation.SetError(RTB_Weight, "Please enter your weight");
                return false;
            }
            if (!int.TryParse(weightInput, out int weightValue))
            {
                ERR_Validation.SetError(RTB_Weight, "Please enter a valid number for weight");
                return false;
            }
            if (weightValue <= 0)
            {
                ERR_Validation.SetError(RTB_Weight, "Weight should be greater than zero");
                return false;
            }
            ERR_Validation.SetError(RTB_Weight, string.Empty);
            return true;
        }

        private bool ValidateAge()
        {
            string ageInput = RTB_Age.Text.Trim();
            if (string.IsNullOrEmpty(ageInput))
            {
                ERR_Validation.SetError(RTB_Age, "Please enter your age");
                return false;
            }
            if (!int.TryParse(ageInput, out int ageValue))
            {
                ERR_Validation.SetError(RTB_Age, "Please enter a valid number for age");
                return false;
            }
            if (ageValue < 18 || ageValue > 100)
            {
                ERR_Validation.SetError(RTB_Age, "Age should be between 18 and 100");
                return false;
            }
            ERR_Validation.SetError(RTB_Weight, string.Empty);
            return true;
        }

        private void BTN_Calculate_Click(object sender, EventArgs e)
        {
            bool ValidAge = ValidateAge();
            bool ValidCrea = ValidateCreatinine();
            bool ValidHeight = ValidateHeight();
            bool ValidWeight = ValidateWeight();
            if (CBX_Calculation.Text == "All" || CBX_Calculation.Text == "Cockroft-Gault")
            {
                if (ValidCrea == true && ValidWeight == true && ValidHeight == true && ValidAge == true)
                {
                    Calculate();
                    UpdateDatabase();
                    BTN_MoreInfo.Visible = true;
                }
            }
            else if (CBX_Calculation.Text == "MDRD" || CBX_Calculation.Text == "CKDEPI")
            {
                if (ValidCrea == true && ValidAge ==true)
                {
                    Calculate();
                    UpdateDatabase();
                    BTN_MoreInfo.Visible = true;
                }
            }

        }
        private double Calculate()
        {
            double creatinine = double.Parse(RTB_Creatinine.Text);
            int age = int.Parse(RTB_Age.Text);
            string gender = CBX_Gender.Text;
            string ethnicity = CBX_Ethnicity.Text;
            double weight = 0;
            double.TryParse(RTB_Weight.Text, out weight);
            double height = 0;
            double.TryParse(RTB_Height.Text, out height);
            string parentForm = FormStack.Forms.Peek().ToString();
            double creatinine_umol = RBN_umolL.Checked ? creatinine : creatinine * 88.4;
            double creatinine_mgdl = RBN_mgdL.Checked ? creatinine : creatinine / 88.4;
            double eGFR;
            string calculation = CBX_Calculation.Text;
            switch (calculation)
            {
                case "MDRD":
                    eGFR = MDRD(creatinine_umol, age, gender, ethnicity);
                    break;
                case "CKDEPI":
                    eGFR = CKDEPI(creatinine_mgdl, age, gender, ethnicity);
                    break;
                case "Cockroft-Gault":
                    eGFR = Cockroft(creatinine_mgdl, age, weight, height, gender);
                    break;
                case "All":
                    double eGFR_MDRD = MDRD(creatinine_umol, age, gender, ethnicity);
                    double eGFR_CKDEPI = CKDEPI(creatinine_mgdl, age, gender, ethnicity);
                    double eGFR_Cockroft = Cockroft(creatinine_mgdl, age, weight, height, gender);
                    string printtext = nModular(eGFR_MDRD, eGFR_Cockroft, eGFR_CKDEPI, weight, height, age, gender, ethnicity, creatinine_mgdl, creatinine_umol);
                    RTB_eGFR.Text = printtext;
                    return eGFR_MDRD; // return one of the eGFR values since it doesn't matter which one is returned
                default:
                    MessageBox.Show("Please select a calculation.");
                    return 0;
            }
            int decimalPlaces = parentForm == "FirstIteration.FRM_DrMain, Text: Doctor Page" ? 3 : 0;
            eGFR = Math.Round(eGFR, decimalPlaces);
            string resultText = calculation + ": " + eGFR + " mL/min/1.73 m²";
            RTB_eGFR.Text = resultText;
            BTN_MoreInfo.Visible = true;
            return eGFR;
        }

        public double MDRD(double Creatinineumol, int Age, string Gender, string Ethnicity)//Function for MDRD Equation
        {
            double g = Gender == "Female" ? 0.742 : 1;
            double a = -1.154;
            double b = -0.203;
            double e = Ethnicity == "Black" ? 1.210 : 1;
            double GFR = 186 * Math.Pow(Creatinineumol / 88.4, a) * Math.Pow(Age, b) * g * e;
            return GFR;
        }

        public double CKDEPI(double Creatininemgdl, int Age, string Gender, string Ethnicity)
        {
            double k = Gender == "Female" ? 0.7 : 0.9;
            double a = Gender == "Female" ? -0.329 : -0.411;
            double g = Gender == "Female" ? 1.018 : 1;
            double e = Ethnicity == "Black" ? 1.159 : 1;
            double GFR = 141 * Math.Pow(Math.Min(Creatininemgdl / k, 1), a) * Math.Pow(Math.Max(Creatininemgdl / k, 1), -1.209) * Math.Pow(0.993, Age) * g * e;
            return GFR;
        }

        public double Cockroft(double Creatininemgdl, int Age, double Weight, double Height, String Gender)//Function for Cockroft Equation
        {
            double g = Gender == "Female" ? 0.85 : 1;
            //The eGFRC-G(ml / min) was adjusted to BSA(modified C-G) to obtain eGFRmC - G(ml / min per 1.73 m2): eGFRmC - G = eGFRC - G × 1.73 / BSA.
            double BSA = 0.0167 * Math.Pow(Height, 0.5) * Math.Pow(Weight, 0.5);
            double GFR = ((140 - Age) * (Weight * g) / (72 * Creatininemgdl)) * (1.73 / BSA);
            return GFR;
        }

        private void RBN_mgdL_CheckedChanged(object sender, EventArgs e)
        {
            if (RBN_mgdL.Checked)
            {
                RBN_umolL.Checked = false;
            }
        }

        private void RBN_umolL_CheckedChanged(object sender, EventArgs e)
        {
            if (RBN_umolL.Checked)
            {
                RBN_mgdL.Checked = false;
            }
        }

        private void BTN_Back_Click(object sender, EventArgs e)
        {
            Form previousForm = FormStack.Forms.Pop();
            this.Hide();
            previousForm.Show();
        }

        private void BTN_MoreInfo_Click(object sender, EventArgs e)
        {
            double eGFR = Calculate();//why are we calling calculate again - can we just not pass eGFR in??
            FormStack.Forms.Push(this);
            this.Hide();
            FRM_MoreInfo MoreInfo = new FRM_MoreInfo(Math.Round(eGFR));
            MoreInfo.ShowDialog();
        }

        private void CBX_Calculation_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (CBX_Calculation.Text)
            {
                case "Cockroft-Gault":
                case "All":
                    LBL_Weight.Visible = true;
                    LBL_Height.Visible = true;
                    RTB_Height.Visible = true;
                    RTB_Weight.Visible = true;
                    break;
                case "MDRD":
                default:
                    LBL_Weight.Visible = false;
                    LBL_Height.Visible = false;
                    RTB_Height.Visible = false;
                    RTB_Weight.Visible = false;
                    break;
            }
        }

        private void BTN_Edit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to edit this form?", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                RTB_Creatinine.Enabled = true;
                RBN_mgdL.Enabled = true;
                RBN_umolL.Enabled = true;
                RTB_Age.Enabled = true;
                CBX_Gender.Enabled = true;
                CBX_Ethnicity.Enabled = true;
                CBX_Calculation.Enabled = true;
                RTB_Weight.Enabled = true;
                RTB_Height.Enabled = true;
                RTB_eGFR.Enabled = true;
                BTN_Edit.Enabled = false;
            }
        }
        private void UpdateDatabase()
        {
            MySqlConnection connection = new MySqlConnection("server=rsscalculatorapp.mariadb.database.azure.com;uid=XPAdmin@rsscalculatorapp;pwd=07Ix5@o3geXG;database=calculatorapp;");
            MySqlCommand command = new MySqlCommand("UPDATE patients SET race = @race, gender = @gender, height = @height, weight = @weight, age = @age, creatinine = @creatinine WHERE user_id = @user_id", connection);
            char SmallEthnicity = 'A';
            char SmallGender = 'B';
            double Convertedmgdl = 0;
            if (CBX_Ethnicity.Text == "Black")
            {
                SmallEthnicity = 'B';
            }
            else if (CBX_Ethnicity.Text == "Other")
            {
                SmallEthnicity = 'O';
            }
            if (CBX_Gender.Text == "Male")
            {
                SmallGender = 'M';
            }
            else if (CBX_Gender.Text == "Female")
            {
                SmallGender = 'F';
            }
            if (RBN_mgdL.Checked)
            {
                Convertedmgdl = Double.Parse(RTB_Creatinine.Text) * 88.4;
            }
            else
            {
                Convertedmgdl = Double.Parse(RTB_Creatinine.Text);
            }
            command.Parameters.AddWithValue("@user_id", patient_id);
            command.Parameters.AddWithValue("@race", SmallEthnicity);
            command.Parameters.AddWithValue("@gender", SmallGender);
            command.Parameters.AddWithValue("@height", RTB_Height.Text);
            command.Parameters.AddWithValue("@weight", RTB_Weight.Text);
            command.Parameters.AddWithValue("@age", RTB_Age.Text);
            command.Parameters.AddWithValue("@creatinine", Convertedmgdl);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public string nModular(double eGFR_MDRD, double eGFR_Cockroft, double eGFR_CKDEPI, double Weight, double Height, int Age, String Gender, string Ethnicity,double Creatininemgdl, double Creatinineumol)
        {
            string returntext;
            double percentage;
            double outlier;
            double percentage1 = Math.Abs(eGFR_MDRD - eGFR_Cockroft) / ((eGFR_MDRD + eGFR_Cockroft) / 2.0) * 100.0;
            double percentage2 = Math.Abs(eGFR_MDRD - eGFR_CKDEPI) / ((eGFR_MDRD + eGFR_CKDEPI) / 2.0) * 100.0;
            double percentage3 = Math.Abs(eGFR_Cockroft - eGFR_CKDEPI) / ((eGFR_Cockroft + eGFR_CKDEPI) / 2.0) * 100.0;
            double[] arr = { percentage1, percentage2, percentage3 };
            Array.Sort(arr);
            double diff1 = arr[1] - arr[0];
            double diff2 = arr[2] - arr[1];
            double closestValues;
            if (diff1 < diff2)
            {
                closestValues = (arr[0] + arr[1]) / 2.0;
                outlier = arr[2];
                percentage = (closestValues - outlier) / ((closestValues + outlier) / 2.0) * 100.0;
            }
            else
            {
                closestValues = (arr[1] + arr[2]) / 2.0;
                outlier = arr[0];
                percentage = (closestValues - outlier) / ((closestValues + outlier) / 2.0) * 100.0;
            }
            string parentForm = FormStack.Forms.Peek().ToString();
            int decimalPlaces = parentForm == "FirstIteration.FRM_DrMain, Text: Doctor Page" ? 3 : 0;
            eGFR_Cockroft = Math.Round(eGFR_Cockroft, decimalPlaces);
            eGFR_MDRD= Math.Round(eGFR_MDRD, decimalPlaces);
            eGFR_CKDEPI = Math.Round(eGFR_CKDEPI, decimalPlaces);
            if (Math.Abs(percentage) > 150)
            {
                if (outlier == percentage1)
                {
                    returntext = "MDRD " + eGFR_MDRD + " mL/min/1.73 m²\n" + "Cockroft: " + eGFR_Cockroft + " mL/min/1.73 m²";
                    MessageBox.Show("Rejecting CKDEPI. It lies out of acceptable range. This will be logged for system administrators");
                    string issue = "CKDEPI";
                    Log(eGFR_MDRD, eGFR_Cockroft, eGFR_CKDEPI, Weight, Height, Age, Gender, Ethnicity, Creatininemgdl, Creatinineumol, percentage, percentage1, percentage2, percentage3, closestValues, outlier, issue);                   
                }
                else if (outlier == percentage2)
                {
                    returntext = "MDRD " + eGFR_MDRD + " mL/min/1.73 m²\n" + "CKDEPI: " + eGFR_CKDEPI + " mL/min/1.73 m²";
                    MessageBox.Show("Rejecting Cockroft. It lies out of acceptable range. This will be logged for system administrators");
                    string issue = "Cockroft";
                    Log(eGFR_MDRD, eGFR_Cockroft, eGFR_CKDEPI, Weight, Height, Age, Gender, Ethnicity, Creatininemgdl, Creatinineumol, percentage, percentage1, percentage2, percentage3, closestValues, outlier, issue);
                }
                else
                {
                    returntext = "MDRD " + eGFR_MDRD + " mL/min/1.73 m²\n" + "CKDEPI: " + eGFR_CKDEPI + " mL/min/1.73 m²\n" + "Cockroft: " + eGFR_Cockroft + " mL/min/1.73 m²";
                    MessageBox.Show("MDRD shows a different result to the other equations. The program will continue with it, but this should not be considered exact. Please verify the calculation " + outlier.ToString());
                    string issue = "MDRD";
                    Log(eGFR_MDRD, eGFR_Cockroft, eGFR_CKDEPI, Weight, Height, Age, Gender, Ethnicity, Creatininemgdl, Creatinineumol, percentage, percentage1, percentage2, percentage3, closestValues, outlier, issue);
                }
            }
            else
            {
                returntext = "MDRD " + eGFR_MDRD + " mL/min/1.73 m²\n" + "CKDEPI: " + eGFR_CKDEPI + " mL/min/1.73 m²\n" + "Cockroft: " + eGFR_Cockroft + " mL/min/1.73 m²";
            }
            return returntext;
        }

        public void Log(double eGFR_MDRD, double eGFR_Cockroft, double eGFR_CKDEPI, double Weight, double Height, int Age, String Gender, string Ethnicity, double Creatininemgdl, double Creatinineumol, double percentage, double percentage1, double percentage2, double percentage3, double closestValues, double outlier, string issue)
        {
            string creatinine;
            string folderName = "Logs";
            string fileName = "Invalid calculations.txt";
            string workingDirectory = Environment.CurrentDirectory;
            string folderPath = Path.Combine(workingDirectory, folderName);
            string filePath = Path.Combine(folderPath, fileName);
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            if(RBN_mgdL.Checked)
            {
                creatinine = Creatininemgdl + " mg/dL ";
            }
            else
            {
                creatinine = Creatinineumol + " µmol/L ";
            }
            string index = GetCurrentIndex(filePath).ToString();
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {              
                writer.WriteLine("Index: " + index);
                writer.WriteLine("Rejected calculation: " + issue);
                writer.WriteLine("Average of the two closest values as a percentage difference: " + closestValues);
                writer.WriteLine("Percentage difference of outlier from the average of the other two values: " + percentage);
                writer.WriteLine("Outlier percentage difference: " + outlier);
                writer.WriteLine("Variables: ");
                writer.WriteLine("Age: " +  Age + " Gender: " + Gender + " Creatinine: " + creatinine + " Ethnicity: " + Ethnicity + " Height: " + Height + " Weight: " + Weight);
                writer.WriteLine("eGFR values: ");
                writer.WriteLine("MDRD: " + eGFR_MDRD + " Cockroft: " + eGFR_Cockroft + " CKDEPI: " + eGFR_CKDEPI);
                writer.WriteLine("Percentage differences between calculations: ");
                writer.WriteLine("MDRD and Cockroft: " + percentage1 + " MDRD and CKDEPI: " + percentage2 + " Cockroft and CKDEPI: " + percentage3 + "\n");             
            }
        }

        public static int GetCurrentIndex(string filePath)
        {
            int index = 1;
            string line;
            if (File.Exists(filePath))
            {
                using (var reader = new StreamReader(filePath))
                {
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (line.StartsWith("Index:", StringComparison.OrdinalIgnoreCase))
                        {
                            if (int.TryParse(line.Substring(line.IndexOf(":") + 1).Trim(), out int currentIndex))
                            {
                                index = currentIndex + 1;
                            }
                        }
                    }
                }
            }
            return index;
        }
    }
    }