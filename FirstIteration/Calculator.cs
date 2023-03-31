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
using System.Windows.Input;
using static FirstIteration.FRM_Login;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace FirstIteration
{
    public partial class FRM_Calculator : Form
    {
        //Carries over the patient id from the previous form (patient login or DrMain)
        private readonly string patient_id;
        public double MoreInfoEGFR;

        //Automatically selects the calculation as MDRD and enables the hover feature for the buttons
        public FRM_Calculator()
        {
            InitializeComponent();
            CBX_Calculation.Text = "MDRD";
            CBX_Ethnicity.Text = "Other";
            CBX_Gender.Text = "Male";

            BTN_Back.MouseEnter += Mouse_Enter;
            BTN_Back.MouseLeave += Mouse_Leave;

            BTN_Calculate.MouseEnter += Mouse_Enter;
            BTN_Calculate.MouseLeave += Mouse_Leave;

            BTN_Edit.MouseEnter += Mouse_Enter;
            BTN_Edit.MouseLeave += Mouse_Leave;

            BTN_MoreInfo.MouseEnter += Mouse_Enter;
            BTN_MoreInfo.MouseLeave += Mouse_Leave;
        }

        //If the patient is logged in, set up the calculator with their details
        public FRM_Calculator(string patient_id)
        {
            InitializeComponent();
            //Checks if there is a patient id passed. If not, returns and continues the calculator. If so, pulls their details from the database
            this.patient_id = patient_id;
            if (patient_id == null)
            {
                return;
            }
            //Populates the form with the relevant calculation components and sets up a database connection
            ConfigureForm(patient_id);
            var server = "server=rsscalculatorapp.mariadb.database.azure.com;uid=XPAdmin@rsscalculatorapp;pwd=07Ix5@o3geXG;database=calculatorapp;";
            //Pulls the patient details from the database
            using (var connection = new MySqlConnection(server))
            {
                string sql = "SELECT * FROM patients WHERE user_id=@patient_id";
                var command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@patient_id", patient_id);
                connection.Open();
                //Checks if any of the user's information pulled is null. If so, returns 0 instead to populate the fields
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
                        //Converts the single character showing their race and converts it into a full string, defaulting with other
                        switch (race)
                        {
                            case "B":
                                race = "Black";
                                break;
                            case "O":
                                race = "Other";
                                break;
                            default:
                                race = "Other";
                                break;
                        }
                        //Converts the single character showing their gender and converts it into a full string, defaulting with male
                        switch (gender)
                        {
                            case "M":
                                gender = "Male";
                                break;
                            case "F":
                                gender = "Female";
                                break;
                            default:
                                gender = "Male";
                                break;
                        }
                        //Populates the input fields with the relevant information
                        CBX_Calculation.Text = "MDRD";
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

        //Resets the form and selects the default settings
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

        //Checks the creatinine value provided isn't empty, is a number, contains only ASCII characters and greater than 0. If any of these trigger, alerts the user. If this passes, reset the error and return true
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
            if (creatinineInput.Any(c => c > 127))
            {
                ERR_Validation.SetError(RTB_Creatinine, "Your Password contains non-ASCII characters");
                return false;
            }
            ERR_Validation.SetError(RTB_Creatinine, "");
            return true;
        }

        //Checks the height value provided isn't empty, is a number, contains only ASCII characters and greater than 0. If any of these trigger, alerts the user. If this passes, reset the error and return true
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
            if (heightInput.Any(c => c > 127))
            {
                ERR_Validation.SetError(RTB_Height, "Your Password contains non-ASCII characters");
                return false;
            }
            ERR_Validation.SetError(RTB_Height, "");
            return true;
        }

        //Checks the weight value provided isn't empty, is a number, contains only ASCII characters and greater than 0. If any of these trigger, alerts the user. If this passes, reset the error and return true
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
            if (weightInput.Any(c => c > 127))
            {
                ERR_Validation.SetError(RTB_Weight, "Your Password contains non-ASCII characters");
                return false;
            }
            ERR_Validation.SetError(RTB_Weight, "");
            return true;
        }

        //Checks the age value provided isn't empty, is a number, contains only ASCII characters and greater than 0. If any of these trigger, alerts the user. If this passes, reset the error and return true
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
            if (ageInput.Any(c => c > 127))
            {
                ERR_Validation.SetError(RTB_Age, "Your Password contains non-ASCII characters");
                return false;
            }
            ERR_Validation.SetError(RTB_Age, "");
            return true;
        }

        //Once the button is pressed, validates all of the inputs given
        private void BTN_Calculate_Click(object sender, EventArgs e)
        {
            bool ValidAge = ValidateAge();
            bool ValidCrea = ValidateCreatinine();
            bool ValidHeight = ValidateHeight();
            bool ValidWeight = ValidateWeight();
            //Checks which option is selected
            if (CBX_Calculation.Text == "All" || CBX_Calculation.Text == "Cockroft-Gault")
            {
                //Makes sure all the relevant inputs are validated, updates the database accordingly, and runs the calculate function. Checks if it needs to update the database too.
                if (ValidCrea == true && ValidWeight == true && ValidHeight == true && ValidAge == true)
                {
                    Calculate();
                    if (patient_id != "")
                    {
                        UpdateDatabase();
                    }
                    if (CBX_Calculation.Text == "All")
                    {
                        BTN_MoreInfo.Visible = true;
                        label1.Visible = true;
                    }
                    else
                    {
                        BTN_MoreInfo.Visible = false;
                        label1.Visible = false;
                    }
                }
            }
            else if (CBX_Calculation.Text == "MDRD" || CBX_Calculation.Text == "CKDEPI")
            {
                //Makes sure all the relvant inputs are validated, updates the database accordingly, and runs the calculate function. Checks if it needs to update the database too.
                if (ValidCrea == true && ValidAge ==true)
                {
                    Calculate();
                    if (patient_id != "")
                    {
                        UpdateDatabase();
                    }
                    if (CBX_Calculation.Text == "MDRD")
                    {
                       BTN_MoreInfo.Visible = true;
                       label1.Visible = true;
                    }
                    else
                    {
                        BTN_MoreInfo.Visible = false;
                        label1.Visible = false;
                    }
                    
                }
            }

        }

        //Sets up the variables and runs the relevant calculations
        private double Calculate()
        {
            //Defines the variables to be used according the their respective inputs and converts them accordingly
            double creatinine = double.Parse(RTB_Creatinine.Text);
            int age = int.Parse(RTB_Age.Text);
            string gender = CBX_Gender.Text;
            string ethnicity = CBX_Ethnicity.Text;
            double.TryParse(RTB_Weight.Text, out double weight);
            double.TryParse(RTB_Height.Text, out double height);
            string parentForm = FormStack.Forms.Peek().ToString();
            double creatinine_umol = RBN_umolL.Checked ? creatinine : creatinine * 88.4;
            double creatinine_mgdl = RBN_mgdL.Checked ? creatinine : creatinine / 88.4;
            double eGFR;
            string calculation = CBX_Calculation.Text;
            //Runs the calculation as required and passes the relevant parameters. If none are selected, alert the user
            switch (calculation)
            {
                case "MDRD":
                    eGFR = MDRD(creatinine_umol, age, gender, ethnicity);
                    MoreInfoEGFR = eGFR;
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
                    string printtext = NModular(eGFR_MDRD, eGFR_Cockroft, eGFR_CKDEPI, weight, height, age, gender, ethnicity, creatinine_mgdl, creatinine_umol);                 
                    RTB_eGFR.Text = printtext;
                    eGFR = eGFR_MDRD;
                    break;
                default:
                    MessageBox.Show("Please select a calculation.");
                    return 0;
            }
            //Rounds the result depending on whether the patient is a doctor (3 decimal places) or not (whole number) and displays the value to the user. Also shows the next form button.
            int decimalPlaces = parentForm == "FirstIteration.FRM_DrMain, Text: Doctor Page" ? 3 : 0;
            eGFR = Math.Round(eGFR, decimalPlaces);
            if (CBX_Calculation.Text != "All")
            {
                if (eGFR > 300)
                {
                    RTB_eGFR.Text = calculation + ": " + eGFR + " mL/min/1.73 m² \nAt least one of these values seems to be out of range for eGFR. Are you sure your details are correct?";
                }
                else
                {
                    RTB_eGFR.Text = calculation + ": " + eGFR + " mL/min/1.73 m²";
                }        
            }
            BTN_MoreInfo.Visible = true;
            MoreInfoEGFR = eGFR;
            return eGFR;
        }

        //Runs the given MDRD calculation, adjusting for ethinicity and gender
        public double MDRD(double Creatinineumol, int Age, string Gender, string Ethnicity)
        {
            double g = Gender == "Female" ? 0.742 : 1;
            double a = -1.154;
            double b = -0.203;
            double e = Ethnicity == "Black" ? 1.210 : 1;
            double GFR = 186 * Math.Pow(Creatinineumol / 88.4, a) * Math.Pow(Age, b) * g * e;
            return GFR;
        }

        //Runs the CKDEPI calculation, adjusting for ethinicity and gender
        public double CKDEPI(double Creatininemgdl, int Age, string Gender, string Ethnicity)
        {
            double k = Gender == "Female" ? 0.7 : 0.9;
            double a = Gender == "Female" ? -0.329 : -0.411;
            double g = Gender == "Female" ? 1.018 : 1;
            double e = Ethnicity == "Black" ? 1.159 : 1;
            double GFR = 141 * Math.Pow(Math.Min(Creatininemgdl / k, 1), a) * Math.Pow(Math.Max(Creatininemgdl / k, 1), -1.209) * Math.Pow(0.993, Age) * g * e;
            return GFR;
        }

        //Runs the Cockroft-Gault calculation, adjusting for gender and body surface area
        public double Cockroft(double Creatininemgdl, int Age, double Weight, double Height, String Gender)
        {
            double g = Gender == "Female" ? 0.85 : 1;
            //The eGFRC-G(ml / min) was adjusted to BSA(modified C-G) to obtain eGFRmC - G(ml / min per 1.73 m2): eGFRmC - G = eGFRC - G × 1.73 / BSA.
            double BSA = 0.0167 * Math.Pow(Height, 0.5) * Math.Pow(Weight, 0.5);
            double GFR = (140 - Age) * (Weight * g) / (72 * Creatininemgdl) * (1.73 / BSA);
            return GFR;
        }

        //Ensure that when the button for mg/dL is selected, umol is not
        private void RBN_mgdL_CheckedChanged(object sender, EventArgs e)
        {
            if (RBN_mgdL.Checked)
            {
                RBN_umolL.Checked = false;
            }
        }

        //Ensure that when the button for umol is selected, mg/dL is not
        private void RBN_umolL_CheckedChanged(object sender, EventArgs e)
        {
            if (RBN_umolL.Checked)
            {
                RBN_mgdL.Checked = false;
            }
        }

        //Displays the previous form
        private void BTN_Back_Click(object sender, EventArgs e)
        {
            Form previousForm = FormStack.Forms.Pop();
            this.Hide();
            previousForm.Show();
        }

        //Safely displays the moreinfo form
        private void BTN_MoreInfo_Click(object sender, EventArgs e)
        {
            FormStack.Forms.Push(this);
            this.Hide();
            FRM_MoreInfo MoreInfo = new FRM_MoreInfo(Math.Round(MoreInfoEGFR));
            MoreInfo.ShowDialog();
        }

        //Automatically switches the relevant form inputs to visible/invisible depending on the calculation selected
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

        //Enables the user to edit the form if the edit button is clicked and they acknowledge that they have that ability, and turns off the edit button
        private void BTN_Edit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to edit this form?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                RTB_Creatinine.Enabled = RBN_mgdL.Enabled = RBN_umolL.Enabled = RTB_Age.Enabled = CBX_Gender.Enabled = CBX_Ethnicity.Enabled = CBX_Calculation.Enabled = RTB_Weight.Enabled = RTB_Height.Enabled = RTB_eGFR.Enabled = true;
                BTN_Edit.Enabled = false;
            }
        }


        //Updates the database with the form's current inputs
        private void UpdateDatabase()
        {
            //sets up the database connection
            string server = "server=rsscalculatorapp.mariadb.database.azure.com;uid=XPAdmin@rsscalculatorapp;pwd=07Ix5@o3geXG;database=calculatorapp;";
            MySqlConnection connection = new MySqlConnection(server);
            string sql = "UPDATE patients SET race = @race, gender = @gender, height = @height, weight = @weight, age = @age, creatinine = @creatinine WHERE user_id = @user_id";
            MySqlCommand command = new MySqlCommand(sql, connection);
            //Calls the functions to convert the displayed values to ones accepted by the database
            char ethnicity = GetEthnicity();
            char gender = GetGender();
            double creatinine = ConvertCreatinine();
            //Sets up the parameters for the database statement with the form input fields
            command.Parameters.AddWithValue("@user_id", patient_id);
            command.Parameters.AddWithValue("@race", ethnicity);
            command.Parameters.AddWithValue("@gender", gender);
            command.Parameters.AddWithValue("@height", RTB_Height.Text);
            command.Parameters.AddWithValue("@weight", RTB_Weight.Text);
            command.Parameters.AddWithValue("@age", RTB_Age.Text);
            command.Parameters.AddWithValue("@creatinine", creatinine);
            //Runs the command and updates the database if necessary
            if (patient_id != null)
            {
                using (connection)
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            return;
        }

        //Converts the full ethnicity string to expected single chars accepted by the database
        private char GetEthnicity()
        {
            switch (CBX_Ethnicity.Text)
            {
                case "Black":
                    return 'B';
                case "Other":
                    return 'O';
                default:
                    return 'A';
            }
        }

        //Converts the full gender string to expected single chars accepted by the database
        private char GetGender()
        {
            switch (CBX_Gender.Text)
            {
                case "Male":
                    return 'M';
                case "Female":
                    return 'F';
                default:
                    return 'A';
            }
        }

        //Converts the creatinine to umol, as expected by the database
        private double ConvertCreatinine()
        {
            double.TryParse(RTB_Creatinine.Text, out double creatinine);
            if (RBN_mgdL.Checked)
            {
                creatinine *= 88.4;
            }
            return creatinine;
        }


        //Runs the necessary calculations to provide N-modular system functionality
        public string NModular(double eGFR_MDRD, double eGFR_Cockroft, double eGFR_CKDEPI, double Weight, double Height, int Age, String Gender, string Ethnicity,double Creatininemgdl, double Creatinineumol)
        {
            //Sets up the variables necessary and finds the percentage difference between the calculations
            string returntext;
            double percentage;
            double outlier;
            double percentage1 = Math.Abs(eGFR_MDRD - eGFR_Cockroft) / ((eGFR_MDRD + eGFR_Cockroft) / 2.0) * 100.0;
            double percentage2 = Math.Abs(eGFR_MDRD - eGFR_CKDEPI) / ((eGFR_MDRD + eGFR_CKDEPI) / 2.0) * 100.0;
            double percentage3 = Math.Abs(eGFR_Cockroft - eGFR_CKDEPI) / ((eGFR_Cockroft + eGFR_CKDEPI) / 2.0) * 100.0;
            //Puts the percentage differences into an array and sorts by size
            double[] arr = { percentage1, percentage2, percentage3 };
            Array.Sort(arr);
            //Finds the difference between the organised percentage differences
            double diff1 = arr[1] - arr[0];
            double diff2 = arr[2] - arr[1];
            double closestValues;
            //Finds the two closest calculations
            if (diff1 < diff2)
            {
                //Sets the outlier and finds the average between the two closest calculations. Then finds the percentage difference between the outlier and the averaged two closest calculations
                closestValues = (arr[0] + arr[1]) / 2.0;
                outlier = arr[2];
                percentage = (closestValues - outlier) / ((closestValues + outlier) / 2.0) * 100.0;
            }
            else
            {
                //Sets the outlier and finds the average between the two closest calculations. Then finds the percentage difference between the outlier and the averaged two closest calculations
                closestValues = (arr[1] + arr[2]) / 2.0;
                outlier = arr[0];
                percentage = (closestValues - outlier) / ((closestValues + outlier) / 2.0) * 100.0;
            }
            //Rounds the result depending on whether the patient is a doctor (3 decimal places) or not (whole number) and sets the variables according to the calculations given by
            string parentForm = FormStack.Forms.Peek().ToString();
            int decimalPlaces = parentForm == "FirstIteration.FRM_DrMain, Text: Doctor Page" ? 3 : 0;
            eGFR_Cockroft = Math.Round(eGFR_Cockroft, decimalPlaces);
            eGFR_MDRD= Math.Round(eGFR_MDRD, decimalPlaces);
            eGFR_CKDEPI = Math.Round(eGFR_CKDEPI, decimalPlaces);
            string alert = "";
            if (eGFR_CKDEPI > 300 || eGFR_Cockroft > 300 || eGFR_MDRD > 300)
            {
                alert = "At least one of these values seems to be out of range for eGFR. Are you sure your details are correct?";
            }
            //If the outlier's percentage difference is 50% out of the other two, creates a variable to display the outlier
            if (Math.Abs(percentage) > 150)
            {
                string issue;
                //If the outlier is CKDEPI, show MDRD and Cockroft, alert the user and call the log function
                if (outlier == percentage1)
                {
                    issue = "CKDEPI";
                    returntext = "MDRD " + eGFR_MDRD + " mL/min/1.73 m²\n" + "Cockroft-Gault: " + eGFR_Cockroft + " mL/min/1.73 m²\n" + alert;
                    MessageBox.Show("Rejecting CKDEPI. It lies out of acceptable range. This will be logged for system administrators");                   
                    Log(eGFR_MDRD, eGFR_Cockroft, eGFR_CKDEPI, Weight, Height, Age, Gender, Ethnicity, Creatininemgdl, Creatinineumol, percentage, percentage1, percentage2, percentage3, closestValues, outlier, issue);                   
                }
                //If the outlier is Cockroft, show MDRD and CKDEPI, alert the user and call the log function
                else if (outlier == percentage2)
                {
                    issue = "Cockrof-Gault";
                    returntext = "MDRD " + eGFR_MDRD + " mL/min/1.73 m²\n" + "CKDEPI: " + eGFR_CKDEPI + " mL/min/1.73 m²\n" + alert;
                    MessageBox.Show("Rejecting Cockroft-Gault. It lies out of acceptable range. This will be logged for system administrators");                
                    Log(eGFR_MDRD, eGFR_Cockroft, eGFR_CKDEPI, Weight, Height, Age, Gender, Ethnicity, Creatininemgdl, Creatinineumol, percentage, percentage1, percentage2, percentage3, closestValues, outlier, issue);
                }
                //If the outlier is MDRD, show all the calculations, alert the user and call the log function
                else
                {   
                    issue = "MDRD";
                    returntext = "MDRD " + eGFR_MDRD + " mL/min/1.73 m²\n" + "CKDEPI: " + eGFR_CKDEPI + " mL/min/1.73 m²\n" + "Cockroft-Gault: " + eGFR_Cockroft + " mL/min/1.73 m²\n" + alert;
                    MessageBox.Show("MDRD shows a different result to the other equations. The program will continue with it, but this should not be considered exact. Please verify the calculation " + outlier.ToString());
                    Log(eGFR_MDRD, eGFR_Cockroft, eGFR_CKDEPI, Weight, Height, Age, Gender, Ethnicity, Creatininemgdl, Creatinineumol, percentage, percentage1, percentage2, percentage3, closestValues, outlier, issue);
                }
            }
            //Otherwise, just return all the calculations
            else
            {
                returntext = "MDRD " + eGFR_MDRD + " mL/min/1.73 m²\n" + "CKDEPI: " + eGFR_CKDEPI + " mL/min/1.73 m²\n" + "Cockroft-Gault: " + eGFR_Cockroft + " mL/min/1.73 m²\n" + alert;
            }
            return returntext;
        }

        //Logs the calculations used to create the n-modular system and what variables were used
        public void Log(double eGFR_MDRD, double eGFR_Cockroft, double eGFR_CKDEPI, double Weight, double Height, int Age, String Gender, string Ethnicity, double Creatininemgdl, double Creatinineumol, double percentage, double percentage1, double percentage2, double percentage3, double closestValues, double outlier, string issue)
        {
            //Sets up the filenames/paths and creatinine values. Calls to create a folder
            string creatinine;
            string folderName = "Logs";
            string fileName = "Invalid calculations.txt";
            string workingDirectory = Environment.CurrentDirectory;
            string folderPath = Path.Combine(workingDirectory, folderName);
            string filePath = Path.Combine(folderPath, fileName);
            CreateFolderIfNotExists(folderPath);
            //Converts the creatinine value to log the appropriate units
            if (RBN_mgdL.Checked)
            {
                creatinine = Creatininemgdl + " mg/dL ";
            }
            else
            {
                creatinine = Creatinineumol + " µmol/L ";
            }
            //Runs the GetCurrentIndex function to index the entry based off the previous entry
            string index = GetCurrentIndex(filePath).ToString();
            //Write the variables used by the calculations for such an error to occur, with relevant titles, each on a new line
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
                writer.WriteLine("MDRD: " + eGFR_MDRD + " Cockroft-Gault: " + eGFR_Cockroft + " CKDEPI: " + eGFR_CKDEPI);
                writer.WriteLine("Percentage differences between calculations: ");
                writer.WriteLine("MDRD and Cockroft-Gault: " + percentage1 + " MDRD and CKDEPI: " + percentage2 + " Cockroft-Gault and CKDEPI: " + percentage3 + "\n");             
            }
        }

        //Checks if the folder that needs to be created to hold the logs locally already exists
        private void CreateFolderIfNotExists(string folderPath)
        {
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
        }

        //Function to index the entry based off the previous entry
        public static int GetCurrentIndex(string filePath)
        {
            //Sets the index at 1, if there is no index already
            int index = 1;
            string line;
            //Check the file exists
            if (File.Exists(filePath))
            {
                //Sets up to read the first line of the index
                using (var reader = new StreamReader(filePath))
                {
                    //Checks the line reader is not at the end of the file
                    while ((line = reader.ReadLine()) != null)
                    {
                        //Checks if the line starts with "Index:"
                        if (line.StartsWith("Index:", StringComparison.OrdinalIgnoreCase))
                        {
                            //Trims the line at the : to find the index number and adds one to it and outputs the result to be used as the next index
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

        //Unhovers the button when the mouse leaves its hover zone
        private void Mouse_Leave(object sender, EventArgs e)
        {
            var btn = (System.Windows.Forms.Button)sender;
            btn.BackgroundImage = Properties.Resources.Button3;
        }

        //Hovers the button when the mouse enters its hover zone
        private void Mouse_Enter(object sender, EventArgs e)
        {
            var btn = (System.Windows.Forms.Button)sender;
            btn.BackgroundImage = Properties.Resources.ButtonHover;
        }

    }
    }