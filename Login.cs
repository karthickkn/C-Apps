using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Learn2Prog 
{
    public partial class UserValidation : Form
    {
        //Following variables have been declared globally to maintain modularity between methods. 
        //Static Variable is to allow passing username to next form
        //Variables that arent used in more than one function have been declared locally.
        public int moreAttempts = 3;
        public static string userName;
        
        //Constructor that initializes the objects
        public UserValidation()
        {
            InitializeComponent();
        }

        //Event - UnameTxtBx Click
        //Sample indicator text gets removed on user name textbox click
        private void UnameTxtBx_Click(object sender, EventArgs e)
        {
            UnameTxtBx.Clear();
        }

        //Event - PasswordTxtBx Click
        //To Facilitate clearing the password text box on click event
        private void PasswordTxtBx_MouseClick(object sender, MouseEventArgs e)
        {
            PasswordTxtBx.Clear();
        }

        //Load Event
        //The form is shown in the maximised mode 
        private void UserValidation_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            UnameTxtBx.SelectionStart = 0;
        }

        //Event - Login Button CLick
        //Validate if the user has entered password and the attempts doesnt exceed three times. 
        //Show the number of attempts remaining on each wrong password.
        //If the user enters right password, go into workshop booking form. Else close the application notifying him
        //about the exceeded number of attempts.
        private void loginBtn_Click(object sender, EventArgs e)
        {
            string passKey = "iLoveVisualC#";
            string sampleText = "Ex.John";
            checkSecurity();
            if (UnameTxtBx.Text != "" && PasswordTxtBx.Text != "" && UnameTxtBx.Text != sampleText)
            {
                if (PasswordTxtBx.Text == passKey)
                {
                    userName = UnameTxtBx.Text;
                    this.Hide();
                    WorkshopBooking newBooking = new WorkshopBooking();
                    newBooking.Show();
                }
                else
                {

                    moreAttempts--;
                    checkSecurity();
                    DialogResult result = new DialogResult();
                    result = MessageBox.Show("Incorrect Password.[" + moreAttempts + "/3] attempts remaining");
                    if (result.ToString() == "OK")
                    {
                        PasswordTxtBx.SelectAll();
                        PasswordTxtBx.Focus();

                    }
                }

            }
            else
            {
                moreAttempts--;
                checkSecurity();
                DialogResult result = new DialogResult();
                result = MessageBox.Show("Username and Password is mandatory.[" + moreAttempts + "/3] attempts remaining");
                if (result.ToString() == "OK")
                {
                    if (UnameTxtBx.Text == "" || UnameTxtBx.Text == sampleText)
                    {
                        
                        UnameTxtBx.Focus();
                        
                    }
                    else if (PasswordTxtBx.Text == "")
                    {
                        
                        PasswordTxtBx.Focus();
                        
                    }
                }
            }
        }

        //Function - checkSecurity
        //Validate if the attempts exists. If not notify user about exceeding the allowed attempts and closing the application.
        public void checkSecurity()
        {
            if (moreAttempts == 0)
            {
                DialogResult dr = new DialogResult();
                dr = MessageBox.Show("Sorry, you have no more attempts remaining. Application exits");
                if (dr.ToString() == "OK")
                {
                    this.Close();
                }
            }
        }


        //Event - PasswordTxtBx_KeyDown
        //Handling ENter Key press. LoginBtn Click event is called to validate and allow user to make his workshop booking
        private void PasswordTxtBx_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loginBtn_Click(sender, e);
            }
        }

        
    }
}
