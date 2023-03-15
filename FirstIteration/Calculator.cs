using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Drawing;
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
        }
        public FRM_Calculator(string patient_id)
        {
            InitializeComponent();
            this.patient_id = patient_id;

            if (patient_id != null)
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

                MySqlConnection connection = new MySqlConnection("server=localhost;uid=root;pwd=12345;database=calculatorapp;");
                MySqlCommand command = new MySqlCommand("SELECT * FROM patients WHERE user_id=@patient_id", connection);
                command.Parameters.AddWithValue("@patient_id", patient_id);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    // check if the values are null and replace them with 0 if they are
                    string user_id = reader.IsDBNull(reader.GetOrdinal("user_id")) ? "0" : reader.GetString("user_id");
                    string race = reader.IsDBNull(reader.GetOrdinal("race")) ? "0" : reader.GetString("race");
                    string gender = reader.IsDBNull(reader.GetOrdinal("gender")) ? "0" : reader.GetString("gender");
                    int height = reader.IsDBNull(reader.GetOrdinal("height")) ? 0 : reader.GetInt32("height");
                    int weight = reader.IsDBNull(reader.GetOrdinal("weight")) ? 0 : reader.GetInt32("weight");
                    int age = reader.IsDBNull(reader.GetOrdinal("age")) ? 0 : reader.GetInt32("age");
                    int creatinine = reader.IsDBNull(reader.GetOrdinal("age")) ? 0 : reader.GetInt32("creatinine");

                    string ethnicity = "";
                    string genderlong = "";
                    if (race == "B")
                    {
                        ethnicity = "Black";
                    }
                    else if (race == "O")
                    {
                        ethnicity = "Other";
                    }

                    if (gender == "M")
                    {
                        genderlong = "Male";
                    }
                    else if (gender == "F")
                    {
                        genderlong = "Female";
                    }
                    CBX_Ethnicity.Text = ethnicity;
                    CBX_Gender.Text = genderlong;
                    RTB_Height.Text = height.ToString();
                    RTB_Weight.Text = weight.ToString();
                    RTB_Age.Text = age.ToString();
                    RTB_Creatinine.Text = creatinine.ToString();
                    RBN_umolL.Checked = true;
                }
                connection.Close();
                LBL_Title.Text = "Calculator: " + patient_id;
            }
        }


        private bool ValidateCrea()//Validates if Creatine is a Valid Input
        {
            bool bStatus = false;
            if (Regex.IsMatch(RTB_Creatinine.Text, @"(^\d*\.?\d*[1-9]+\d*$)|(^[1-9]+\d*\.\d*$)"))
            {
                ERR_Validation.SetError(RTB_Creatinine, String.Empty);
                bStatus = true;
            }
            else if (RTB_Creatinine.Text == "")
            {
                ERR_Validation.SetError(RTB_Creatinine, "Please enter your creatinine value");
                bStatus = false;
            }
            else if (Regex.IsMatch(RTB_Creatinine.Text, @"^[a-zA-Z]+$"))
            {
                ERR_Validation.SetError(RTB_Creatinine, "Please Enter Creatine as a Number");
                bStatus = false;
            }
            else
            {
                ERR_Validation.SetError(RTB_Creatinine, "There was an Error, Such as a Symbol in your Creatine Field");
                bStatus = false;
            }
            return bStatus;
        }
        private bool ValidateHeight()//Validates if Height is a Valid Input
        {
            bool hStatus = false;
            if (Regex.IsMatch(RTB_Height.Text, @"^[0-9]+$"))
            {
                ERR_Validation.SetError(RTB_Height, String.Empty);
                hStatus = true;
            }
            else
            {
                ERR_Validation.SetError(RTB_Height, "Please Enter Height as a Number");
            }
            return hStatus;
        }
        private bool ValidateWeight()//Validates if Weight is a Valid Input
        {
            bool wStatus = false;
            if (Regex.IsMatch(RTB_Weight.Text, @"^[0-9]+$"))
            {
                ERR_Validation.SetError(RTB_Weight, String.Empty);
                wStatus = true;
            }
            else
            {
                ERR_Validation.SetError(RTB_Weight, "Please Enter Weight as a Number");
            }
            return wStatus;
        }
        private bool ValidateAge(int VAge)//Validates if Age is a Valid Input
        {
            bool aStatus = false;
            
            if (VAge <= 100 && VAge >= 18)// Age needs to be over 18 but under 100, otherwise error
            {
                aStatus = true;
            }
            return aStatus;
        }
        private void BTN_Calculate_Click(object sender, EventArgs e)//MMMMMM Button ඞ
        {
            int ValidAge = CalculateAge();
            bool ValidCrea = ValidateCrea();
            bool ValidHeight = ValidateHeight();
            bool ValidWeight = ValidateWeight();
            if (ValidCrea == false)
            {
                MessageBox.Show("Could not Validate Creatinine Value.");
            }
            if (CBX_Calculation.Text == "All" || CBX_Calculation.Text == "Cockroft-Gault")
            {
                if (ValidCrea == true && ValidWeight == true && ValidHeight == true && ValidAge != 999)
                {
                    Calculate();
                    UpdateDatabase();
                    BTN_MoreInfo.Visible = true;
                }
            }
            else if (CBX_Calculation.Text == "MDRD" || CBX_Calculation.Text == "CKDEPI")
            {
                if (ValidCrea == true && ValidAge != 999)
                {
                    Calculate();
                    UpdateDatabase();
                    BTN_MoreInfo.Visible = true;
                }
            }

        }
        private int CalculateAge()//Calculates Age then runs ValidateAge Function, Returns '999' as an error code
        {
            int Age = 0;
            if(RTB_Age.Text == "")
            {
                Age = 999;
            }
            else
            {
                Age = Int32.Parse(RTB_Age.Text);
            }
            
            bool VAge = ValidateAge(Age);
            if (VAge == false)
            {
                ERR_Validation.SetError(RTB_Age, "These calculations are only accurate if you are over 18 or under 100");
                Age = 999;
            }
            else
            {
                ERR_Validation.SetError(RTB_Age, String.Empty);
            }
            return Age;
        }
        private double Calculate()//ඞCalculate Function containing Calculations for the Calculator and its Equations
        {
            double Creatinine = double.Parse(RTB_Creatinine.Text);
            double Creatinineumol = Creatinine;
            double Creatininemgdl = Creatinine;

            if (RBN_umolL.Checked)
            {
                Creatininemgdl = Creatinine / 88.4;
            }
            if (RBN_mgdL.Checked)
            {
                Creatinineumol = Creatinine * 88.4;
            }
            int Age = CalculateAge();

            string Gender = CBX_Gender.Text;
            string Ethnicity = CBX_Ethnicity.Text;
            string parentForm = FormStack.Forms.Peek().ToString();
            if (CBX_Calculation.Text == "MDRD")
            {
                double eGFR_MDRD = MDRD(Creatinineumol, Age, Gender, Ethnicity);
                if (parentForm == "FirstIteration.FRM_DrMain, Text: Doctor Page")
                {
                    eGFR_MDRD = Math.Round(eGFR_MDRD, 3);
                }
                else
                {
                    eGFR_MDRD = Math.Round(eGFR_MDRD);
                }
                RTB_eGFR.Text = "MDRD " + eGFR_MDRD + " mL/min/1.73 m²";             
                BTN_MoreInfo.Visible = true;
                return eGFR_MDRD;
            }
            else if (CBX_Calculation.Text == "CKDEPI")
            {
                double eGFR_CKDEPI = CKDEPI(Creatininemgdl, Age, Gender, Ethnicity);             
                if (parentForm == "FirstIteration.FRM_DrMain, Text: Doctor Page")
                {
                    eGFR_CKDEPI = Math.Round(eGFR_CKDEPI, 3);
                }
                else
                {
                    eGFR_CKDEPI = Math.Round(eGFR_CKDEPI);
                }
                RTB_eGFR.Text = "CKDEPI: " + eGFR_CKDEPI + " mL/min/1.73 m²";
            }
            else if (CBX_Calculation.Text == "Cockroft-Gault")
            {
                double Weight = double.Parse(RTB_Weight.Text);
                double Height = double.Parse(RTB_Height.Text);
                double eGFR_Cockroft = Cockroft(Creatininemgdl, Age, Weight, Height, Gender);
                if (parentForm == "FirstIteration.FRM_DrMain, Text: Doctor Page")
                {
                    eGFR_Cockroft = Math.Round(eGFR_Cockroft, 3);
                }
                else
                {
                    eGFR_Cockroft = Math.Round(eGFR_Cockroft);
                }
                RTB_eGFR.Text = "Cockroft: " + eGFR_Cockroft + " mL/min/1.73 m²";
            }
            else if (CBX_Calculation.Text == "All")
            {
                double eGFR_MDRD = MDRD(Creatinineumol, Age, Gender, Ethnicity);
                double eGFR_CKDEPI = CKDEPI(Creatininemgdl, Age, Gender, Ethnicity);
                double Weight = double.Parse(RTB_Weight.Text);
                double Height = double.Parse(RTB_Height.Text);
                double eGFR_Cockroft = Cockroft(Creatininemgdl, Age, Weight, Height, Gender);
                if (parentForm == "FirstIteration.FRM_DrMain, Text: Doctor Page")
                {
                    eGFR_Cockroft = Math.Round(eGFR_Cockroft,3);
                    eGFR_CKDEPI = Math.Round(eGFR_CKDEPI,3);
                    eGFR_MDRD = Math.Round(eGFR_MDRD,3);
                }
                else
                {
                    eGFR_Cockroft = Math.Round(eGFR_Cockroft);
                    eGFR_CKDEPI = Math.Round(eGFR_CKDEPI);
                    eGFR_MDRD = Math.Round(eGFR_MDRD);
                }
                RTB_eGFR.Text = "Cockroft: " + eGFR_Cockroft + " mL/min/1.73 m²" + " CKDEPI: " + eGFR_CKDEPI + " mL/min/1.73 m²" + " MDRD " + eGFR_MDRD + " mL/min/1.73 m²";
                //do we need to return a value here? the others don't
                return eGFR_MDRD;
            }
            else
            {
                MessageBox.Show("Please Select a Calculation");
            }
            return 0;
            


        }
        public double MDRD(double Creatinineumol, int Age, string Gender, string Ethnicity)//Function for MDRD Equation
        {
            double g = 1;
            if (Gender == "Female")
            {
                g = 0.742;
            }
            double a = -1.154;
            double b = -0.203;
            double e = 1;
            if (Ethnicity == "Black")
            {
                e = 1.210;
            }
            double GFR = 186 * Math.Pow(Creatinineumol / 88.4, a) * Math.Pow(Age, b) * g * e;
            return GFR;
        }
        public double CKDEPI(double Creatininemgdl, int Age, string Gender, string Ethnicity)//Function for CKD-EPI Equation
        {
            double k;
            double a;
            double g = 1;
            double e = 1;
            if (Gender == "Female")
            {
                k = 0.7;
                a = -0.329;
                g = 1.018;
            }
            else
            {
                k = 0.9;
                a = -0.411;
            }

            if (Ethnicity == "Black")
            {
                e = 1.159;
            }

            double GFR = 141 * Math.Pow(Math.Min(Creatininemgdl / k, 1), a) * Math.Pow(Math.Max(Creatininemgdl / k, 1), -1.209) * Math.Pow(0.993, Age) * g * e;
            return GFR;
        }

        public double Cockroft(double Creatininemgdl, int Age, double Weight, double Height, String Gender)//Function for Cockroft Equation
        {
            double g = 1;
            if (Gender == "Female")
            {
                g = 0.85;
            }
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
            double eGFR = Calculate();
            FormStack.Forms.Push(this);
            this.Hide();
            FRM_MoreInfo MoreInfo = new FRM_MoreInfo(eGFR);
            MoreInfo.Show();      
        }

        private void CBX_Calculation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBX_Calculation.Text == "Cockroft-Gault")
            {
                LBL_Weight.Visible = true;
                LBL_Height.Visible = true;
                RTB_Height.Visible = true;
                RTB_Weight.Visible = true;
                BTN_MoreInfo.Visible = false;
            }
            else if (CBX_Calculation.Text == "All")
            {
                LBL_Weight.Visible = true;
                LBL_Height.Visible = true;
                RTB_Height.Visible = true;
                RTB_Weight.Visible = true;
                BTN_MoreInfo.Visible = false; 
            }
            else if (CBX_Calculation.Text == "MDRD")
            {
                BTN_MoreInfo.Visible = true;
            }
            else
            {
                LBL_Weight.Visible = false;
                LBL_Height.Visible = false;
                RTB_Height.Visible = false;
                RTB_Weight.Visible = false;
                BTN_MoreInfo.Visible = false;
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
            }
        }
        private void UpdateDatabase()
        {
            MySqlConnection connection = new MySqlConnection("server=localhost;uid=root;pwd=12345;database=calculatorapp;");
            MySqlCommand command = new MySqlCommand("UPDATE patients SET race = @race, gender = @gender, height = @height, weight = @weight, age = @age, creatinine = @creatinine WHERE user_id = @user_id", connection);
            char SmallEthnicity = 'A';
            char SmallGender = 'B';
            double Convertedmgdl = 0;
            if (CBX_Ethnicity.Text == "Black")
            {
                SmallEthnicity = 'B';
            }
            else if(CBX_Ethnicity.Text == "Other")
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

        private void LBL_eGFR_Click(object sender, EventArgs e)
        {

        }

        private void RTB_Creatinine_TextChanged(object sender, EventArgs e)
        {

        }

        private void LBL_Creatinine_Click(object sender, EventArgs e)
        {

        }

        private void RTB_Height_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
