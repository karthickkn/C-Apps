using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InvestQ
{
    //Variable declaration - Since we maintain only one file for storing all the transaction details, file name has been specified
    public partial class Registration : Form
    {
        string file_name = "EmployeeTransactions.txt";

        //Constructor that initializes the components
        public Registration()
        {
            InitializeComponent();
        }

        //Event - Submit Button CLick
        //Validate the user entered details and if its valid and on getting user confirmation, save the details to a text file 
        private void submitBtn_Click(object sender, EventArgs e)
        {
            bool isValid = false;
            bool isSaved = false;
            DialogResult result;
            isValid = ValidateDetails(isValid);
            if (isValid)
            {
                result = ConfirmDetails();
                if (result.ToString() == "OK")
                {
                    isSaved = SaveToFile();
                    if (isSaved)
                    {
                        MessageBox.Show("The Details for the transaction are submitted successfully");
                    }
                    submitBtn.Enabled = false;
                }
            }
            

        }

        
        //Method - ValidateDetails
        //Check if all the details have been filled. Names must have only characters, Contact must be of ten digits, valid mail ID
        //EmpID must be 3 characters, CLient ID must be 4 characters.

        public bool ValidateDetails(bool isValid)
        {
            if (fnameTxtBx.Text != "" && lnameTxtBx.Text != "" && phoneTxtBx.Text != "" && emailTxtBx.Text != "" &&
                empIdTxtBx.Text != "" && clientIdTxtBx.Text != "")
            {
                try
                {
                    if (fnameTxtBx.Text.Any(char.IsLetter))
                    {
                        if (lnameTxtBx.Text.Any(char.IsLetter))
                        {
                            if (phoneTxtBx.Text.Any(char.IsDigit) && phoneTxtBx.Text.Length == 10)
                            {
                                Regex valid_checker = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                                if(valid_checker.IsMatch(emailTxtBx.Text))
                                {
                                    if (empIdTxtBx.Text.Length == 3 && empIdTxtBx.Text.Any(char.IsLetterOrDigit))
                                    {
                                        if (clientIdTxtBx.Text.Length == 4 && clientIdTxtBx.Text.Any(char.IsLetterOrDigit))
                                        {
                                            isValid = true;
                                        }
                                        else
                                        {
                                            if (clientIdTxtBx.Text.Length != 4)
                                            {
                                                MessageBox.Show("Client ID must have 4 characters");
                                            }
                                            else
                                            {
                                                MessageBox.Show("Client ID cannot contain special characters");
                                            }
                                            clientIdTxtBx.SelectAll();
                                            clientIdTxtBx.Focus();
                                        }
                                    }
                                    else
                                    {
                                        if (empIdTxtBx.Text.Length != 3)
                                        {
                                            MessageBox.Show("Employee ID must have 3 characters");
                                        }
                                        else
                                        {
                                            MessageBox.Show("Employee ID cannot contain special characters");
                                        }
                                        empIdTxtBx.SelectAll();
                                        empIdTxtBx.Focus();
                                    }
                                    
 
                                }
                                else
                                {
                                    MessageBox.Show("Email ID is not valid");
                                    emailTxtBx.SelectAll();
                                    emailTxtBx.Focus();
                                }

                            }
                            else
                            {
                                MessageBox.Show("Phone number accept only digits of length 10");
                                phoneTxtBx.SelectAll();
                                phoneTxtBx.Focus();
                            }   
                        }
                        else
                        {
                            MessageBox.Show("Last Name cannot have digits or special characters");
                            lnameTxtBx.SelectAll();
                            lnameTxtBx.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("First Name cannot have digits or special characters");
                        fnameTxtBx.SelectAll();
                        fnameTxtBx.Focus();
                    }
                }
                catch
                { 
                }
            }
            else
            {
                
                if (fnameTxtBx.Text == "")
                {
                    MessageBox.Show("First Name is mandatory");
                    fnameTxtBx.Focus();
                }
                else if (lnameTxtBx.Text == "")
                {
                    MessageBox.Show("Last Name is mandatory");
                    lnameTxtBx.Focus();
                }
                else if (phoneTxtBx.Text == "")
                {
                    MessageBox.Show("Phone number is mandatory");
                    phoneTxtBx.Focus();
                }
                else if (emailTxtBx.Text == "")
                {
                    MessageBox.Show("Email ID is mandatory");
                    emailTxtBx.Focus();
                }
                else if (empIdTxtBx.Text == "")
                {
                    MessageBox.Show("Employee ID is mandatory");
                    empIdTxtBx.Focus();
                }
                else if (clientIdTxtBx.Text == "")
                {
                    MessageBox.Show("Client ID is mandatory");
                    clientIdTxtBx.Focus();
                }
            }
            return isValid;
        }

        //Method - ConfirmDetails
        //Get Confirmation if the details entered by user is ok 

        public DialogResult ConfirmDetails()
        {
            string details = "";
            DialogResult result;
            details = "Below are the provided details:" + Environment.NewLine + "First Name: " + fnameTxtBx.Text + Environment.NewLine +
                "Last Name: " + lnameTxtBx.Text + Environment.NewLine + "Contact: " + phoneTxtBx.Text + Environment.NewLine +
                "Email ID: " + emailTxtBx.Text + Environment.NewLine + "Transaction ID: " + empIdTxtBx.Text + clientIdTxtBx.Text +
                 uniqueIDTxtBx.Text + Environment.NewLine + "Investment amount: " + InvestQ_Invest.invested_amount.ToString("C") +
                 Environment.NewLine + "No. Of Terms: " + InvestQ_Invest.selected_term + Environment.NewLine +
                 "Interest Rate: " + InvestQ_Invest.selected_interest.ToString() + Environment.NewLine +
                 "Maturity Value: " + InvestQ_Invest.selected_compoundInvestment.ToString("C") + Environment.NewLine + Environment.NewLine + 
                 "Are you sure you wanted to continue? ";

            result = MessageBox.Show(details, "Transaction Confirmation", MessageBoxButtons.OKCancel);
            return result;

        }

        //Method - SaveToFile
        //Write details provided by user in each different line as a text appending it with a key.

        public bool SaveToFile()
        {
            bool isSaved = false;
            using (StreamWriter filewrite = new StreamWriter(file_name, true))
            {
                filewrite.WriteLine("First Name: " + fnameTxtBx.Text);
                filewrite.WriteLine("Last Name: " + lnameTxtBx.Text);
                filewrite.WriteLine("Contact: " + phoneTxtBx.Text);
                filewrite.WriteLine("Email ID: " + emailTxtBx.Text);
                filewrite.WriteLine("Transaction ID: " + empIdTxtBx.Text + clientIdTxtBx.Text + uniqueIDTxtBx.Text);
                filewrite.WriteLine("Investment amount: " + InvestQ_Invest.invested_amount.ToString("C"));
                filewrite.WriteLine("No. Of Terms: " + InvestQ_Invest.selected_term);
                filewrite.WriteLine("Interest Rate: " + InvestQ_Invest.selected_interest.ToString());
                filewrite.WriteLine("Maturity Value: " + InvestQ_Invest.selected_compoundInvestment.ToString("C"));
                isSaved = true;

            }

            return isSaved;

        }

        //Event - Previous Button CLick
        //Navigate the user to the previous page

        private void prevBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            InvestQ_Invest invest = new InvestQ_Invest();
            invest.Show();
        }

        //Event - Reset Button CLick
        //CLear all the textboxes and generate random 3 digit everytym 
        private void resetBtn_Click(object sender, EventArgs e)
        {
            submitBtn.Enabled = true;
            fnameTxtBx.Text = "";
            lnameTxtBx.Text = "";
            emailTxtBx.Text = "";
            phoneTxtBx.Text = "";
            empIdTxtBx.Text = "";
            clientIdTxtBx.Text = "";
            Assign_Unique_ID();
            
        }

        //Event - Exit Button Click
        //Exit the application

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Load event
        //Generate 3 digit random ID when the form loads
        private void Registration_Load(object sender, EventArgs e)
        {
            Assign_Unique_ID();
        }

        //Method - Assign_Unique_ID
        //Generate 3 digit Random ID 
        public void Assign_Unique_ID()
        {
            Random rndm = new Random();
            uniqueIDTxtBx.Text = rndm.Next(100, 999).ToString();

        }
    }
}
