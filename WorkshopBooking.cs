using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Learn2Prog
{
    public partial class WorkshopBooking : Form
    {
        //Following variables have been declared globally to maintain modularity between methods. 
        //Variables that arent used in more than one function have been declared locally.
        string[] selected_workshops; 
        int[] selected_workshopDays;
        int[] selected_workshopFees;
        string[] selected_Locations;
        int[] selected_LodgingFees;
        int training_days = 0;
        int workshop_fees = 0;
        int lodging_fees = 0;
        int workshopCount;
        int locationCount;
        string location;
        string workshop;
        string meal_Preference;
        double meal_cost;
        const double FULL_BOARD = 39.50;
        const double HALF_BOARD = 27.50;
        const double BREAK_FAST = 12.50;
        const double PRINTED_CERTIFICATE = 29.95;
        double overallFees;
        bool isValid = false;
        bool isCalculated = false;
        
        int totalBookings;
        double totalRegFees;
        double totalLodgingFees;
        double totalOptionalFees;
        double avgRevenue;

        //Constructor that initializes the objects
        public WorkshopBooking()
        {
            InitializeComponent();
        }

        //When the form loads, it will be in maximized mode and loads all data dynamically to the list view
        private void WorkshopBooking_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            WelcomeLbl.Text = "Welcome " + UserValidation.userName + "!";
            LoadWorkshopDetails();
            LoadLocationDetails();
        }

        //This Method adds or loads workshop details (workshop name, training days, training cost) to the list view
        public void LoadWorkshopDetails()
        {
            string[] listary = new string[3];
            ListViewItem listitem;

            listary[0] = "ASP.NET with C#";
            listary[1] = "4 days";
            listary[2] = string.Format("{0:C0}",1200);
            listitem = new ListViewItem(listary);
            WorkShopLstView.Items.Add(listitem);

            listary[0] = "Desktop Apps with C#";
            listary[1] = "3 days";
            listary[2] = string.Format("{0:C0}", 1000);
            listitem = new ListViewItem(listary);
            WorkShopLstView.Items.Add(listitem);

            listary[0] = ".NET Prog using C# PartA";
            listary[1] = "3 days";
            listary[2] = string.Format("{0:C0}", 1500);
            listitem = new ListViewItem(listary);
            WorkShopLstView.Items.Add(listitem);

            listary[0] = ".NET Prog using C# PartB";
            listary[1] = "5 days";
            listary[2] = string.Format("{0:C0}", 1800);
            listitem = new ListViewItem(listary);
            WorkShopLstView.Items.Add(listitem);

            listary[0] = "Digital Detox";
            listary[1] = "1 day";
            listary[2] = string.Format("{0:C0}", 650);
            listitem = new ListViewItem(listary);
            WorkShopLstView.Items.Add(listitem);
         
          }

        //This Method adds or loads location details (Location name, Lodging cost per day) to the list view
        public void LoadLocationDetails()
        {
            string[] listary = new string[2];
            ListViewItem listitem;

            listary[0] = "Cork";
            listary[1] = string.Format("{0:C0}", 150);
            listitem = new ListViewItem(listary);
            LocationLstView.Items.Add(listitem);

            listary[0] = "Dublin";
            listary[1] = string.Format("{0:C0}", 225);
            listitem = new ListViewItem(listary);
            LocationLstView.Items.Add(listitem);

            listary[0] = "Galway";
            listary[1] = string.Format("{0:C0}", 175);
            listitem = new ListViewItem(listary);
            LocationLstView.Items.Add(listitem);

            listary[0] = "Kiltimagh";
            listary[1] = string.Format("{0:C0}", 295);
            listitem = new ListViewItem(listary);
            LocationLstView.Items.Add(listitem);


            listary[0] = "Limerick";
            listary[1] = string.Format("{0:C0}", 135);
            listitem = new ListViewItem(listary);
            LocationLstView.Items.Add(listitem);

            listary[0] = "Wexford";
            listary[1] = string.Format("{0:C0}", 89);
            listitem = new ListViewItem(listary);
            LocationLstView.Items.Add(listitem);
        }

        //Event-Display Button Click
        //On clicking display button- variables are cleared, list view is validated and if the validation is true, user selection is calculated
        //and the details are finally displayed 
        private void display_Click(object sender, EventArgs e)
        {
            clearVariables();
            validateDetails();
            if (isValid)
            {
              CalculateDetails();
              DisplayDetails();
            }
        }
        //Function - clearVariables
        //Variables are cleared and flags are resetted before calculation to avoid unwanted logical glitches 
        public void clearVariables()
        {
            training_days = 0;
            workshop_fees = 0;
            lodging_fees = 0;
            workshopCount = 0;
            locationCount = 0;
            overallFees = 0;
            isCalculated = false;
            isValid = false;
        }

        //Function - validateDetails
        //Validate if user specified the workshop and venue details before cost calculations. Notify if user didnt provide those details  
        public void validateDetails()
        {
            workshopCount = WorkShopLstView.SelectedIndices.Count;
            if (workshopCount > 0)
            {
                locationCount = LocationLstView.SelectedIndices.Count;
                if (locationCount > 0)
                {
                  isValid = true;
                }
                else
                {
                    MessageBox.Show("Select the Venue for the workshop");
                }
            }
            else
            {
                MessageBox.Show("Select the Workshop to attend");
            }
        }

        //Function - CalculateDetails
        //Get workshop, location details. Calculate registration fees, lodging fees
        //Check if user opted for meal and printed copy. Finally add these optional cost to registration and lodging costs based on user preference
        public void CalculateDetails()
        {
                GetWorkShopDetails();
                CalculateWorkshopDetails();
                GetLocationDetails();
                CalculateLocationDetails();
                CalculateMealDetails();
                if (hardCopyChkBox.Checked)
                {
                    overallFees = workshop_fees + lodging_fees + meal_cost + PRINTED_CERTIFICATE;
                }
                else
                {
                    overallFees = workshop_fees + lodging_fees + meal_cost;
                }

                isCalculated = true;
            
        }

        //Function - GetWorkShopDetails
        //Workshopcount holds the total number of workshops that user has selected in listview 
        //For workshops that are selected by user, get workshop name,training days and training cost and store it in an array for later calculation
        //and display purposes
        public void GetWorkShopDetails()
        {
            string trimmed_days;
            string trimmed_fees;

            selected_workshops = new string[workshopCount];
            selected_workshopDays = new int[workshopCount];
            selected_workshopFees = new int[workshopCount];

            for (int i = 0; i < workshopCount; i++)
            {
                selected_workshops[i] = WorkShopLstView.SelectedItems[i].SubItems[0].Text;
                trimmed_days = WorkShopLstView.SelectedItems[i].SubItems[1].Text;
                selected_workshopDays[i] = int.Parse(trimmed_days.Substring(0, 1));
                trimmed_fees = WorkShopLstView.SelectedItems[i].SubItems[2].Text;
                selected_workshopFees[i] = int.Parse(trimmed_fees.Substring(1), NumberStyles.Currency);
            }

        }

        //Function - GetLocationDetails
        //Locationcount holds the total number of venues that user has selected in listview 
        //For each of the locations selected, get location name and lodging cost and store it in an array for later calculation
        //and display purposes
        public void GetLocationDetails()
        {
            string trimmed_fees = "";
            selected_Locations = new string[locationCount];
            selected_LodgingFees = new int[locationCount];

            for (int i = 0; i < locationCount; i++)
            {
                selected_Locations[i] = LocationLstView.SelectedItems[i].SubItems[0].Text;
                trimmed_fees = LocationLstView.SelectedItems[i].SubItems[1].Text;
                selected_LodgingFees[i] = int.Parse(trimmed_fees.Substring(1), NumberStyles.Currency);
            }
        }

        //Function - CalculateWorkshopDetails
        //For each of the workshop choices selected, maintain the total number of training days and summed registration fees for all workshops
        //To Say Precisely, the application also allows for multiple workshop selection for the user 
        public void CalculateWorkshopDetails()
        {
                workshop = "";
                for (int i = 0; i < workshopCount; i++)
                {
                    if (workshop == "")
                    {
                        workshop = selected_workshops[i];
                    }
                    else 
                    {
                        workshop = workshop + Environment.NewLine + selected_workshops[i];
                    }
                   training_days = training_days + selected_workshopDays[i];
                   workshop_fees = workshop_fees + selected_workshopFees[i];
                }
               
        }

        //Function - CalculateLocationDetails
        //For each of the location choices selected, maintain the location names and calculate lodging fees for all the training days
        public void CalculateLocationDetails()
        {      
                location = "";
                for (int i = 0; i < locationCount; i++)
                {
                    if (location == "")
                    {
                        location = selected_Locations[i];
                    }
                    else
                    {
                        location = location + Environment.NewLine + selected_Locations[i];
                    }
                    lodging_fees = lodging_fees + (selected_LodgingFees[i] * training_days);
                }
                
        }

        //Function - CalculateMealDetails
        //Meal selection is optional. If the user has selected his preference, then initialize the preference and meal cost which will be later 
        //used during overall fees calculation
        public void CalculateMealDetails()
        {
            if (fullBoardRdoBtn.Checked)
            {
                meal_Preference = "Full Board Meals";
                meal_cost = FULL_BOARD;
            }
            else if (halfBoardRdoBtn.Checked)
            {
                meal_Preference = "Half Board Meals";
                meal_cost = HALF_BOARD;
            }
            else if (breakFastRdoBtn.Checked)
            {
                meal_Preference = "Break Fast";
                meal_cost = BREAK_FAST;
            }
            else
            {
                meal_Preference = "No Prefered Meals";
                meal_cost = 0;
            }
           meal_cost = meal_cost * training_days;
        }

        //Function - CalculateSummary
        //Calculates Overall Registration fees, Lodging fees, Optional Fees for all of the bookings that has been made. These values are used
        //during booking summary
        public void CalculateSummary()
        {
            totalRegFees = totalRegFees + workshop_fees;
            totalLodgingFees = totalLodgingFees + lodging_fees;
            if (hardCopyChkBox.Checked)
            {
                totalOptionalFees = totalOptionalFees + meal_cost + PRINTED_CERTIFICATE;
            }
            else
            {
                totalOptionalFees = totalOptionalFees + meal_cost;
            }
        }

        //Function - DisplayDetails
        //Displays the calculated registration costs, lodging costs, optional cost and any other user preference in a detailed manner
        public void DisplayDetails()
        {
            summaryGrpBx.Visible = false;
            DetailsGrpBox.Visible = true;
            wrkshopTxtBx.Text = workshop;
            trainingDaysTxtBx.Text = training_days + " Days";
            registrationFeesTxtBx.Text = string.Format("{0:C0}", workshop_fees);
            locationTxtBx.Text = location;
            lodgingTxtBx.Text = string.Format("{0:C0}", lodging_fees);
            mealTxtBx.Text = meal_Preference;
            mealCostTxtBx.Text = string.Format("{0:C2}", meal_cost);
            DisplayPrintCertificate();
            overallTxtBx.Text = string.Format("{0:C2}", overallFees);
        }

        //Function - DisplayPrintCertificate
        //Displays the cost for hard copy of course material if user has preferred.
        public void DisplayPrintCertificate()
        {
            if (hardCopyChkBox.Checked)
            {
                materialTxtBx.Text = "Yes, the cost is " + string.Format("{0:C2}", PRINTED_CERTIFICATE);
            }
            else
            {
               materialTxtBx.Text = "Not Opted";
            }

        }

        //Event - Book Button Click
        //Validate if the user has specified workshop and location details
        //Ensure if we have made calculations already on display button click. Otherwise calculate the costs. 
        //Popup Confirmation if the user wants to proceed with workshop booking. If yes, acknowledge about the successfull booking made and 
        //calculate the totals for booking summary. If he wishes to cancel, let him 
        private void bookBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = new DialogResult();
            DetailsGrpBox.Visible = false;
            summaryGrpBx.Visible = false;
            if (isValid && isCalculated)
            {

                result = MessageBox.Show("Are you sure you want to continue with booking?", "Booking Confirmation", MessageBoxButtons.OKCancel);
                if (result.ToString() == "OK")
                {
                    MessageBox.Show("Booking is Confirmed for the workshop(s) " + workshop + " at " + location + ". Overall Payment of "
                    + string.Format("{0:C2}", overallFees) + " has been made.");
                    totalBookings++;
                    CalculateSummary();
                    isCalculated = false;
                    bookBtn.Enabled = false;
                }

            }
            else
            {
                clearVariables();
                validateDetails();
                if (isValid)
                {
                    result = MessageBox.Show("Are you sure you want to continue with booking?", "Booking Confirmation", MessageBoxButtons.OKCancel);
                    if (result.ToString() == "OK")
                    {
                        CalculateDetails();
                        MessageBox.Show("Booking is Confirmed for the workshop(s) " + workshop + " at " + location + ". Overall Payment of "
                        + string.Format("{0:C2}", overallFees) + " has been made.");
                        totalBookings++;
                        CalculateSummary();
                        bookBtn.Enabled = false;
                    }
                }
                isCalculated = false;
            }
        }

        //Event - Booking Summary Button Click
        //Validate if there is atleast one booking made. If there exists a booking, display the no.of bookings, total registration fees,
        //total lodging fees, total Optional fees and average revenue collected
        //If no booking exists, display a message 
        private void booking_Summary_Click(object sender, EventArgs e)
        {
            if (totalBookings != 0)
            {
                DetailsGrpBox.Visible = false;
                summaryGrpBx.Visible = true;
                totalBookingsTxtBx.Text = totalBookings.ToString();
                totalRegTxtBx.Text = string.Format("{0:C2}", totalRegFees);
                totLodgingFeesTxtBx.Text = string.Format("{0:C2}", totalLodgingFees);
                totOptionalFeesTxtBx.Text = string.Format("{0:C2}", totalOptionalFees);
                avgRevenue = (totalRegFees + totalLodgingFees + totalOptionalFees) / totalBookings;
                avgRevenueTxtBx.Text = string.Format("{0:C2}", avgRevenue);
            }
            else
            {
                MessageBox.Show("Currently you don't have any bookings registered! ");
            }

        }


        //Event - Reset Button Click
        //To Enable user to enter new booking information
        //Reset all the group boxes, workshop, location, meal preferences, printed copy check and clear the variables.
        private void resetBtn_Click(object sender, EventArgs e)
        {
            DetailsGrpBox.Visible = false;
            summaryGrpBx.Visible = false;
            clearVariables();
            WorkShopLstView.SelectedItems.Clear();
            LocationLstView.SelectedItems.Clear();
            fullBoardRdoBtn.Checked = false;
            halfBoardRdoBtn.Checked = false;
            breakFastRdoBtn.Checked = false;
            hardCopyChkBox.Checked = false;
            meal_Preference = "";
            meal_cost = 0;
            bookBtn.Enabled = true;

        }

        //Event - LogOut Button Click
        //To Enable user to go back to the login page. Login form is shown
        private void logOutBtn_Click(object sender, EventArgs e)
        {
            clearVariables();
            this.Close();
            UserValidation uv = new UserValidation();
            uv.Show();
        }

        //Event - Exit Button Click
        //Closes the application
        private void exitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
