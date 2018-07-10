using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InvestQ
{
    //Variable declaration - static variables have their use in second form whereas all the values which have fixed value is made as const 
    public partial class InvestQ_Invest : Form
    {
        public static int invested_amount;
        public static string selected_term;
        public static double selected_interest;
        public static double selected_compoundInvestment;
        double compounded_investment_1;
        double compounded_investment_3;
        double compounded_investment_6;
        double compounded_investment_12;
        const double low_investment_rate_1 = 0.5;
        const double low_investment_rate_3 = 0.625;
        const double low_investment_rate_6 = 0.7125;
        const double low_investment_rate_12 = 1.125;
        const double high_investment_rate_1 = 0.6;
        const double high_investment_rate_3 = 0.725;
        const double high_investment_rate_6 = 0.8125;
        const double high_investment_rate_12 = 1.225;
        const int bonus = 5000;
        const int threshold_investment = 100000;
        const int bonus_threshold = 1000000;
        const int term_1 = 1;
        const int term_3 = 3;
        const int term_6 = 6;
        const int term_12 = 12;
        string file_name = "EmployeeTransactions.txt";


        double total_transactions;
        double total_investment;
        double total_maturity_value;
        double total_terms;

        // Constructor that initialises all the components
        public InvestQ_Invest()
        {
            InitializeComponent();
        }

        // Event to handle display button click
        //Clears the list box, Validates user input, Calculate the compound investment and finally displays the investment
        private void displayBtn_Click(object sender, EventArgs e)
        {
            bool isValid = false;
            compoundedInvestmentLstBx.Items.Clear();
            isValid = Validate_Investment();
            if (isValid)
            {
                compoundedGrpBx.Visible = true;
                Calculate_CompoundedInvestment();
                Display_Investment();
            }

        }

        //Method - Validate_Investment
        //Validates the user specified investment amount
        public bool Validate_Investment()
        {
            bool isValid = false;
            if (amountInvestTxtBx.Text != "")
            {
                try
                {
                    invested_amount = int.Parse(amountInvestTxtBx.Text);
                    if (invested_amount != 0)
                    {
                        isValid = true;
                    }
                    else
                    {
                        MessageBox.Show("Investment amount cannot be zero");
                        amountInvestTxtBx.SelectAll();
                        amountInvestTxtBx.Focus();
                    }

                }
                catch
                {
                    MessageBox.Show("Invalid Characters.Please enter valid amount");
                    amountInvestTxtBx.SelectAll();
                    amountInvestTxtBx.Focus();
                }
            }
            else
            {
                MessageBox.Show("Specify the investment fund!");
                amountInvestTxtBx.Focus();
            }
            return isValid;
        }

        //Method - Calculate_CompoundedInvestment
        //Checks if the investment amount is above or below the threshold investment 100000
        //Formula for Compound investment: Amount = Principle * (1 + interest_rate/(no_of_months * 100)^(no_of_months * time))
        //Calculates compounded amount for terms 1, 3 , 6 and 12 which have different rate of interests.
        // Compounded amount gets a bonus of 5000 for terms more than or equal to 6 months
        public void Calculate_CompoundedInvestment()
        {
            double interest_rate;
            int no_of_months = 12;
            if (invested_amount < threshold_investment)
            {
                for (int i = 1; i <= 12; i++)
                {
                    switch (i)
                    {
                        case 1:
                            interest_rate = low_investment_rate_1;
                            compounded_investment_1 = invested_amount * Math.Pow((1 + (interest_rate / (100 * no_of_months))), (no_of_months*i/12));
                            break;
                        case 3:
                            interest_rate = low_investment_rate_3;
                            compounded_investment_3 = invested_amount * Math.Pow((1 + (interest_rate / (100 * no_of_months))), (no_of_months*i/12));
                            break;
                        case 6:
                            interest_rate = low_investment_rate_6;
                            compounded_investment_6 = invested_amount * Math.Pow((1 + (interest_rate / (100 * no_of_months))), (no_of_months*i/12));
                            break;
                        case 12:
                            interest_rate = low_investment_rate_12;
                            compounded_investment_12 = invested_amount * Math.Pow((1 + (interest_rate / (100 * no_of_months))), (no_of_months*i/12));
                            break;
                    }
                }
            }
            else
            {
                for (int i = 1; i <= 12; i++)
                {
                    switch (i)
                    {
                        case 1:
                            interest_rate = high_investment_rate_1;
                            compounded_investment_1 = invested_amount * Math.Pow((1 + (interest_rate  / (100 * no_of_months))), (no_of_months*i/12));
                            break;
                        case 3:
                            interest_rate = high_investment_rate_3;
                            compounded_investment_3 = invested_amount * Math.Pow((1 + (interest_rate / (100 * no_of_months))), (no_of_months*i/12));
                            break;
                        case 6:
                            interest_rate = high_investment_rate_6;
                            compounded_investment_6 = invested_amount * Math.Pow((1 + (interest_rate / (100 * no_of_months))), (no_of_months*i/12));
                             if(invested_amount>bonus_threshold)
                             {
                               compounded_investment_6 = compounded_investment_6 + bonus;
                             }
                            break;
                        case 12:
                            interest_rate = high_investment_rate_12;
                            compounded_investment_12 = invested_amount * Math.Pow((1 + (interest_rate / (100 * no_of_months))), (no_of_months*i/12));
                            if (invested_amount > bonus_threshold)
                            {
                                compounded_investment_12 = compounded_investment_12 + bonus;
                            }
                            break;
                    }
                }
            }

        }
        
        //Method - Display_Investment
        //Displays the calculated compounded amount, terms and interest in a listbox for the user
        public void Display_Investment()
        {
            string item;
            if (invested_amount < 100000)
            {
                for (int i = 1; i <= 4; i++)
                {
                    switch (i)
                    {
                        case 1:
                            item = term_1 + " Month  \t" + low_investment_rate_1 + "\t " + compounded_investment_1.ToString("C2");
                            compoundedInvestmentLstBx.Items.Add(item);
                            break;
                        case 2:
                            item = term_3 + " Months \t" + low_investment_rate_3 + "\t " + compounded_investment_3.ToString("C2");
                            compoundedInvestmentLstBx.Items.Add(item);
                            break;
                        case 3:
                            item =  term_6 + " Months \t" + low_investment_rate_6 + "\t " + compounded_investment_6.ToString("C2");
                            compoundedInvestmentLstBx.Items.Add(item);
                            break;
                        case 4:
                            item = term_12 + " Months \t" + low_investment_rate_12 +"\t " + compounded_investment_12.ToString("C2");
                            compoundedInvestmentLstBx.Items.Add(item);
                            break;
                    }
                }
            }
            else
            {
                for (int i = 1; i <= 4; i++)
                {
                    switch (i)
                    {
                        case 1:
                            item = term_1 + " Month  \t" + high_investment_rate_1 + "\t " + compounded_investment_1.ToString("C2");
                            compoundedInvestmentLstBx.Items.Add(item);
                            break;
                        case 2:
                            item = term_3 + " Months \t" + high_investment_rate_3 + "\t " + compounded_investment_3.ToString("C2");
                            compoundedInvestmentLstBx.Items.Add(item);
                            break;
                        case 3:
                            item = term_6 + " Months \t" + high_investment_rate_6 + "\t " + compounded_investment_6.ToString("C2");
                            compoundedInvestmentLstBx.Items.Add(item);
                            break;
                        case 4:
                            item = term_12 + " Months \t" + high_investment_rate_12 + "\t " + compounded_investment_12.ToString("C2");
                            compoundedInvestmentLstBx.Items.Add(item);
                            break;
                    }
                }
 
            }
 
        }

        //Event - resetBtn_Click
        //Resets the calculated compound investment and clears the amount textbox
        private void resetBtn_Click(object sender, EventArgs e)
        {
             invested_amount = 0;
             selected_term = "";
             selected_interest = 0;
             selected_compoundInvestment = 0;
             compounded_investment_1 = 0;
             compounded_investment_3 = 0;
             compounded_investment_6 = 0;
             compounded_investment_12 = 0;
             amountInvestTxtBx.Text = "";
             compoundedGrpBx.Visible = false;
             amountInvestTxtBx.Focus();

        }

        //Event - proceedBtn_Click
        // After user specifies the term, get the user selection, pass the selected term, rate of interest and compounded amount to user info page
        
        private void proceedBtn_Click(object sender, EventArgs e)
        {
            string valueSelected;
            int first_tab_index = 0;
            int last_tab_index = 0;
            if (compoundedInvestmentLstBx.SelectedIndex != -1)
            {
                valueSelected = compoundedInvestmentLstBx.SelectedItem.ToString();
                first_tab_index = valueSelected.IndexOf('\t');
                last_tab_index = valueSelected.LastIndexOf('\t');
                selected_term = valueSelected.Substring(0, first_tab_index-1);
                selected_interest = double.Parse(valueSelected.Substring(first_tab_index + 1, last_tab_index - first_tab_index));
                selected_compoundInvestment = double.Parse(valueSelected.Substring(last_tab_index+3));
                this.Hide();
                Registration reg = new Registration();
                reg.Show();
            }
            else
            {
                MessageBox.Show("Please select the term before proceeding!");
            }

        }

        //Event - Exit button click
        //Exits the application

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Event - Generate Button Summary CLick
        // Clears the variables, reads the Employee Transaction file to get recent transactions and displays them as a list 

        private void generateSummaryBtn_Click(object sender, EventArgs e)
        {
            bool isRead = false;
            ClearSummaryVariables();
            if (summaryGrpBx.Visible == false)
            {
                isRead = ReadFromFile();
                if (isRead)
                {
                    DisplaySummary();
                }
            }
        }

        //Method - ClearSummaryVariables
        // Clear the summarised variables
        public void ClearSummaryVariables()
        {
            total_transactions = 0;
            total_investment = 0;
            total_maturity_value = 0;
            total_terms = 0;
        }

        //Method - DisplaySummary
        //Displays the transaction ID as a list and displays total transactions count, total investment accrued, total interest value accrued
        // and average terms
        public void DisplaySummary()
        {
            double avg_terms = 0;
            double total_interest_accrued = 0;
            summaryGrpBx.Visible = true;
            total_interest_accrued = total_maturity_value - total_investment;
            totTransactionTxtBx.Text = total_transactions.ToString();
            totInvestmentTxtBx.Text = total_investment.ToString("C2");
            totAmountTxtBx.Text = total_interest_accrued.ToString("C2");
            avg_terms = total_terms / total_transactions;
            if (avg_terms == 1)
            {
                avgTermsTxtBx.Text = avg_terms.ToString("N1") + " Month";
            }
            else
            {
                avgTermsTxtBx.Text = avg_terms.ToString("N1") + " Months";
            }
        }

        //Method - ReadFromFile
        //Checks if the file exists. If exists, read each line from the file and get only the transaction ID, Investment amount, Maturity Value
        // and No.Of Terms. Concatenate all theses values in a string.
        //Finally add the concatenated value to the list. 
        public bool ReadFromFile()
        {
            bool isRead = false;
            try
            {
                if (!File.Exists(file_name))
                {
                    throw new FileNotFoundException();
                }
                else
                {
                    using (StreamReader fileread = new StreamReader(file_name))
                    {
                        int colon_pos = 0;
                        string key = "";
                        string TransactionID = "";
                        string Investment = "";
                        string Maturity = "";
                        string Terms = "";
                        bool isTransactIDExist = false;
                        bool isInvestmentExist = false;
                        bool isMaturityExist = false;
                        bool isTermsExist = false;
                        string filecontent = "";
                        string itembuild = "";
                        while ((filecontent = fileread.ReadLine()) != null)
                        {
                            
                            colon_pos = filecontent.IndexOf(":");
                            key = filecontent.Substring(0, colon_pos);
                            if (key == "Transaction ID")
                            {
                                TransactionID = filecontent.Substring(colon_pos + 2);
                                total_transactions++;
                                isTransactIDExist = true;
                            }
                            else if (key == "Investment amount")
                            {
                                Investment = filecontent.Substring(colon_pos + 2);
                                total_investment = total_investment + double.Parse(Investment.Substring(1));
                                isInvestmentExist = true;
                            }
                            else if (key == "Maturity Value")
                            {
                                Maturity = filecontent.Substring(colon_pos + 2);
                                total_maturity_value = total_maturity_value + double.Parse(Maturity.Substring(1));
                                isMaturityExist = true;
                            }
                            else if (key == "No. Of Terms")
                            {
                                Terms = filecontent.Substring(colon_pos + 2);
                                total_terms = total_terms + int.Parse(Terms.Substring(0,1));
                                isTermsExist = true;
                            }
                            if (isTransactIDExist && isInvestmentExist && isMaturityExist && isTermsExist)
                            {
                                itembuild = TransactionID + "\t" + Investment + "\t" + Maturity + "\t" + Terms;
                                summaryLstBx.Items.Add(itembuild);
                                isTransactIDExist = false;
                                isInvestmentExist = false;
                                isMaturityExist = false;
                                isTermsExist = false;
                            }
                            
                        }
                        
                        isRead = true;

                    }
                }
                
            }
            catch(FileNotFoundException ex)
            {
                MessageBox.Show("Currently there are no investments");
            }

            return isRead;

        }

        //Event - Search Button Click
        //CLear the listbox to avoid stacking on the items.
        //Validate if the user has selected any search by means. 
        //Search by the specfied means (Either by Transaction ID or Mail ID)

        private void searchBtn_Click(object sender, EventArgs e)
        {
            bool isValid = false;
            bool isSearched = false;
            searchLstBx.Items.Clear();
            isValid = Search_Validate(isValid);
                if (isValid)
                {
                    if (transactionNumRdoBtn.Checked)
                    {
                        isSearched = SearchTransaction("TransactionID", isSearched);
                    }
                    else if (mailIDRdoBtn.Checked)
                    {
                        isSearched = SearchTransaction("MailID", isSearched);
                    }
                    if (isSearched)
                    {
                        searchGrpBx.Visible = true;
                    }
                    else
                    {
                        MessageBox.Show("No Relevant Transactions found");
                        searchTxtBx.SelectAll();
                        searchTxtBx.Focus();
                    }
                }
           
        }

        //Method - Search_Validate
        //Validate if the user has specified search by option and if the file exists to search

        public bool Search_Validate(bool isValid)
        {
            if (mailIDRdoBtn.Checked || transactionNumRdoBtn.Checked)
            {
                if (searchTxtBx.Text != "")
                {
                    try
                    {
                        if (!File.Exists(file_name))
                        {
                            throw new FileNotFoundException();
                        }
                        else
                        {
                            isValid = true;
                        }
                    }
                    catch (FileNotFoundException ex)
                    {
                        isValid = false;
                        MessageBox.Show("Currently there are no investments");
                    }

                    
                }
                else
                {
                    isValid = false;
                    MessageBox.Show("Select the appropriate search");
                    searchTxtBx.Focus();
                }
            }
            else
            {
                isValid = false;
                MessageBox.Show("Select the appropriate search");
            }
            return isValid;

        }

        //Method - SearchTransaction
        //Read the file line by line and get the transaction details. Based on users choice, compare either Email ID or Transaction ID
        // to the user entered value. If the user has opted for Transaction ID search, add the found item to list box and 
        //break out of the loop on finding the match as transaction ID will be unique and fetch you one record.
        //For Mail ID search, continue adding items to listbox till end of file.

        public bool SearchTransaction(string search_mode, bool isSearched)
        {
            using (StreamReader fileread = new StreamReader(file_name))
            {
                int colon_pos = 0;
                string key = "";
                string TransactionID = "";
                string Investment = "";
                string Maturity = "";
                string Terms = "";
                string FirstName = "";
                string LastName = "";
                string Contact = "";
                string Email_ID = "";
                string Rate = "";
                bool isFNameExist = false;
                bool isLNameExist = false;
                bool isContactExist = false;
                bool isEmailIDExist = false;
                bool isRateExist = false;
                bool isTransactIDExist = false;
                bool isInvestmentExist = false;
                bool isMaturityExist = false;
                bool isTermsExist = false;
                string filecontent = "";
                string itembuild = "";
                while ((filecontent = fileread.ReadLine()) != null)
                {

                    colon_pos = filecontent.IndexOf(":");
                    key = filecontent.Substring(0, colon_pos);
                    if (key == "First Name")
                    {
                        FirstName = filecontent.Substring(colon_pos + 2);
                        isFNameExist = true;
                    }
                    else if (key == "Last Name")
                    {
                        LastName = filecontent.Substring(colon_pos + 2);
                        isLNameExist = true;
                    }
                    else if (key == "Contact")
                    {
                        Contact = filecontent.Substring(colon_pos + 2);
                        isContactExist = true;
                    }
                    else if (key == "Email ID")
                    {
                        Email_ID = filecontent.Substring(colon_pos + 2);
                        isEmailIDExist = true;
                    }
                    else if (key == "Transaction ID")
                    {
                        TransactionID = filecontent.Substring(colon_pos + 2);
                        isTransactIDExist = true;
                    }

                    else if (key == "Investment amount")
                    {
                        Investment = filecontent.Substring(colon_pos + 2);
                        isInvestmentExist = true;
                    }
                    else if (key == "No. Of Terms")
                    {
                        Terms = filecontent.Substring(colon_pos + 2);
                        isTermsExist = true;
                    }
                    else if (key == "Interest Rate")
                    {
                        Rate = filecontent.Substring(colon_pos + 2);
                        isRateExist = true;
                    }
                    else if (key == "Maturity Value")
                    {
                        Maturity = filecontent.Substring(colon_pos + 2);
                        isMaturityExist = true;
                    }

                    if (search_mode == "TransactionID")
                    {
                        
                            if (isTransactIDExist && isInvestmentExist && isMaturityExist && isTermsExist &&
                                isFNameExist && isLNameExist && isContactExist && isEmailIDExist && isRateExist)
                                {
                                if (TransactionID == searchTxtBx.Text)
                                    {
                                itembuild = TransactionID + "\t" + FirstName + "\t" + LastName + "\t" + Contact + "\t" +
                                Email_ID + "\t" + Investment + "\t" + Maturity + "\t" + Terms + "\t" + Rate;
                                searchLstBx.Items.Add(itembuild);
                                isSearched = true;
                                isTransactIDExist = false;
                                isInvestmentExist = false;
                                isMaturityExist = false;
                                isTermsExist = false;
                                isFNameExist = false;
                                isLNameExist = false;
                                isContactExist = false;
                                isEmailIDExist = false;
                                isRateExist = false;
                                break;
                                     }
                                }
                    }

                    else if (search_mode == "MailID")
                    {
                        
                            if (isTransactIDExist && isInvestmentExist && isMaturityExist && isTermsExist &&
                                isFNameExist && isLNameExist && isContactExist && isEmailIDExist && isRateExist)
                            {
                                if (Email_ID == searchTxtBx.Text)
                                {
                                itembuild = TransactionID + "\t" + FirstName + "\t" + LastName + "\t" + Contact + "\t" +
                                Email_ID + "\t" + Investment + "\t" + Maturity + "\t" + Terms + "\t" + Rate;
                                searchLstBx.Items.Add(itembuild);
                                isSearched = true;
                                isTransactIDExist = false;
                                isInvestmentExist = false;
                                isMaturityExist = false;
                                isTermsExist = false;
                                isFNameExist = false;
                                isLNameExist = false;
                                isContactExist = false;
                                isEmailIDExist = false;
                                isRateExist = false;
                                }
                            }
                        }
                    
                }

                

            }
            return isSearched;

        }

        
    }
}
