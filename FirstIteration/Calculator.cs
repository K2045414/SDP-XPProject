﻿using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            if (patient_id != null )
            {
                MySqlConnection connection = new MySqlConnection("server=localhost;uid=root;pwd=admin;database=calculatorapp;");
                MySqlCommand command = new MySqlCommand("SELECT * FROM patients WHERE user_id=@patient_id", connection);
                command.Parameters.AddWithValue("@patient_id", patient_id);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    //need to check if these are null
                    string user_id = reader.GetString("user_id");
                    string email = reader.GetString("email");
                    string race = reader.GetString("race");
                    string gender = reader.GetString("gender");
                    int height = reader.GetInt32("height");
                    int weight = reader.GetInt32("weight");
                    int age = reader.GetInt32("age");
                    string message = $"User ID: {user_id}\nemail: {email}\nrace: {race}\ngender: {gender}\nheight: {height}\nweight: {weight}\nage: {age}";
                    MessageBox.Show(message);
                }
                connection.Close();
            }
        }


        private bool ValidateCrea()//Validates if Creatine is a Valid Input
        {         
            bool bStatus = false;
            if (Regex.IsMatch(RTB_Creatinine.Text, @"^[0-9]+$"))
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
                }
            }
            else if (CBX_Calculation.Text == "MDRD" || CBX_Calculation.Text == "CKDEPI")
            {
                if (ValidCrea == true && ValidAge != 999)
                {
                    Calculate();
                }
            }
                
        }
        private int CalculateAge()//Calculates Age then runs ValidateAge Function, Returns '999' as an error code
        {
            int Age = Int32.Parse(RTB_Age.Text);
            
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
        private void Calculate()//ඞCalculate Function containing Calculations for the Calculator and its Equations
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

                if (CBX_Calculation.Text == "MDRD")
                {
                    double eGFR_MDRD = MDRD(Creatinineumol, Age, Gender, Ethnicity);
                    RTB_eGFR.Text = "MDRD " + eGFR_MDRD;
                }
                else if (CBX_Calculation.Text == "CKDEPI")
                {
                    double eGFR_CKDEPI = CKDEPI(Creatininemgdl, Age, Gender, Ethnicity);
                    RTB_eGFR.Text = "CKDEPI: " + eGFR_CKDEPI;
                }
                else if (CBX_Calculation.Text == "Cockroft-Gault")
                {
                    double Weight = double.Parse(RTB_Weight.Text);
                    double Height = double.Parse(RTB_Height.Text);
                    double eGFR_Cockroft = Cockroft(Creatininemgdl, Age, Weight, Height, Gender);
                    RTB_eGFR.Text = "Cockroft: " + eGFR_Cockroft;
                }
                else if (CBX_Calculation.Text == "All")
                {
                    double eGFR_MDRD = MDRD(Creatinineumol, Age, Gender, Ethnicity);
                    double eGFR_CKDEPI = CKDEPI(Creatininemgdl, Age, Gender, Ethnicity);
                    double Weight = double.Parse(RTB_Weight.Text);
                    double Height = double.Parse(RTB_Height.Text);
                    double eGFR_Cockroft = Cockroft(Creatininemgdl, Age, Weight, Height, Gender);
                    RTB_eGFR.Text = "Cockroft: " + eGFR_Cockroft + " CKDEPI: " + eGFR_CKDEPI + " MDRD " + eGFR_MDRD;
                }
                else
                {
                    MessageBox.Show("Please Select a Calculation");
                }

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
            double GFR = ((140 - Age) * (Weight * g) / (72 * Creatininemgdl)) * (1.73/BSA);
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
            FormStack.Forms.Push(this);
            this.Hide();
            FRM_MoreInfo MoreInfo = new FRM_MoreInfo();
            MoreInfo.Show();
        }

        private void CBX_Calculation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(CBX_Calculation.Text == "Cockroft-Gault")
            {
                LBL_Weight.Visible = true;
                LBL_Height.Visible = true;
                RTB_Height.Visible = true;
                RTB_Weight.Visible = true;
            }
            else if (CBX_Calculation.Text == "All")
            {
                LBL_Weight.Visible = true;
                LBL_Height.Visible = true;
                RTB_Height.Visible = true;
                RTB_Weight.Visible = true;
            }
            else
            {
                LBL_Weight.Visible = false;
                LBL_Height.Visible = false;
                RTB_Height.Visible = false;
                RTB_Weight.Visible = false;
            }
        }
    }
}
