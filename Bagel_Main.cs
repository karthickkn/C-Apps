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

namespace Mr.Bagel
{
    public partial class OrderBagel : Form
    {
        int[,] Bagel_Qty = new int[16,5];
        double[,] Bagel_Price = new double[16, 5];
        string[] Bagel_Type = new string[16];
        string[] Bagel_Size = new string[5];
        double Order_Total = 0;
        string Selected_Unit = "";
        int Selected_Unit_index;
        int Selected_Size_index;
        int total_bagel_sold = 0;
        double total_sales_value = 0;
        int total_transactions = 0;
        int transaction_counter = 0;
        string Transactions_file;
        static int transaction_number;
        string stock_file = "Stock_Info.txt";
        
        
        public OrderBagel()
        {
            InitializeComponent();
        }

        private void halluomiImg_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Halluomi Bagel is Selected");
            qtyUpDown.Enabled = true;
            Selected_Unit = Bagel_Type[0];
            Selected_Unit_index = 0;
           
        }

        private void bangkokImg_Click(object sender, EventArgs e)
        {
            qtyUpDown.Enabled = true;
            Selected_Unit = Bagel_Type[1];
            Selected_Unit_index = 1;
        }

        private void chickenPhillyImg_Click(object sender, EventArgs e)
        {
            qtyUpDown.Enabled = true;
            Selected_Unit = Bagel_Type[2];
            Selected_Unit_index = 2;
        }

        
        private void classicClubImg_Click(object sender, EventArgs e)
        {
            qtyUpDown.Enabled = true;
            Selected_Unit = Bagel_Type[3] ;
            Selected_Unit_index = 3;
        }

        private void kiltimaghSpecialImg_Click(object sender, EventArgs e)
        {
            qtyUpDown.Enabled = true;
            Selected_Unit = Bagel_Type[4];
            Selected_Unit_index = 4;
        }

        private void veggieImg_Click(object sender, EventArgs e)
        {
            qtyUpDown.Enabled = true;
            Selected_Unit = Bagel_Type[5];
            Selected_Unit_index = 5;
        }

        private void ploughmansImg_Click(object sender, EventArgs e)
        {
            qtyUpDown.Enabled = true;
            Selected_Unit = Bagel_Type[6];
            Selected_Unit_index = 6;
        }

        private void mexicanaImg_Click(object sender, EventArgs e)
        {
            qtyUpDown.Enabled = true;
            Selected_Unit = Bagel_Type[7];
            Selected_Unit_index = 7;
        }

        private void tripleCheeseImg_Click(object sender, EventArgs e)
        {
            qtyUpDown.Enabled = true;
            Selected_Unit = Bagel_Type[8];
            Selected_Unit_index = 8;
        }

        private void atlanticWayImg_Click(object sender, EventArgs e)
        {
            qtyUpDown.Enabled = true;
            Selected_Unit = Bagel_Type[9];
            Selected_Unit_index = 9;
        }

        private void breakfastImg_Click(object sender, EventArgs e)
        {
            qtyUpDown.Enabled = true;
            Selected_Unit = Bagel_Type[10];
            Selected_Unit_index = 10;

        }

        private void mauiImg_Click(object sender, EventArgs e)
        {
            qtyUpDown.Enabled = true;
            Selected_Unit = Bagel_Type[11];
            Selected_Unit_index = 11;
        }

        private void classicImg_Click(object sender, EventArgs e)
        {
            qtyUpDown.Enabled = true;
            Selected_Unit = Bagel_Type[12];
            Selected_Unit_index = 12;
        }

        private void chickenCaeserImg_Click(object sender, EventArgs e)
        {
            qtyUpDown.Enabled = true;
            Selected_Unit = Bagel_Type[13];
            Selected_Unit_index = 13;
        }

        private void studentSurpriseImg_Click(object sender, EventArgs e)
        {
            qtyUpDown.Enabled = true;
            Selected_Unit = Bagel_Type[14];
            Selected_Unit_index = 14;
        }

        private void cajunImg_Click(object sender, EventArgs e)
        {
            qtyUpDown.Enabled = true;
            Selected_Unit = Bagel_Type[15];
            Selected_Unit_index = 15;
        }

        private void OrderBagel_Load(object sender, EventArgs e)
        {
            Load_Bagel_Type_And_Size();
            Load_Price_Initial();
            if (!File.Exists(stock_file))
            {
                Load_Stock_Initial();
            }
            else
            {
                ReadStockFromFile();
            }
            Display_Stock_Price("Small");
            Transactions_file = "Transactions_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt";
            
        }
        public void Load_Bagel_Type_And_Size()
        {
            //Halloumi
            Bagel_Type[0] = "Halloumi";
            //Bangkok
            Bagel_Type[1] = "Bangkok";
            //Chicken Philly
            Bagel_Type[2] = "Chicken Philly";
            //Classic Club
            Bagel_Type[3] = "Classic Club";
            //Kiltimagh Special 
            Bagel_Type[4] = "Kiltimagh Special";
            //Veggie
            Bagel_Type[5] = "Veggie";
            //Ploughmans
            Bagel_Type[6] = "Ploughmans";
            //Mexicana
            Bagel_Type[7] = "Mexicana";
            //Triple Cheese
            Bagel_Type[8] = "Triple Cheese";
            //Atlantic Way
            Bagel_Type[9] = "Atlantic Way";
            //Breakfast
            Bagel_Type[10] = "Breakfast";
            //Maui
            Bagel_Type[11] = "Maui";
            //Classic
            Bagel_Type[12] = "Classic";
            //Chicken Caeser
            Bagel_Type[13] = "Chicken Caeser";
            //Student Surprise
            Bagel_Type[14] = "Student Surprise";
            //Cajun
            Bagel_Type[15] = "Cajun";
            
            //Bagel Sizes
            Bagel_Size[0] = "Small";
            Bagel_Size[1] = "Medium";
            Bagel_Size[2] = "Regular";
            Bagel_Size[3] = "Large";
            Bagel_Size[4] = "Extra Large";
        }
        public void Load_Stock_Initial()
        {
            //Stock of Halloumi
            Bagel_Qty[0, 0] = 2;
            Bagel_Qty[0, 1] = 3;
            Bagel_Qty[0, 2] = 4;
            Bagel_Qty[0, 3] = 5;
            Bagel_Qty[0, 4] = 6;
            //Stock of Bangkok
            Bagel_Qty[1, 0] = 4;
            Bagel_Qty[1, 1] = 4;
            Bagel_Qty[1, 2] = 7;
            Bagel_Qty[1, 3] = 13;
            Bagel_Qty[1, 4] = 2;
            //Stock of Chicken Philly
            Bagel_Qty[2, 0] = 6;
            Bagel_Qty[2, 1] = 5;
            Bagel_Qty[2, 2] = 10;
            Bagel_Qty[2, 3] = 11;
            Bagel_Qty[2, 4] = 0;
            //Stock of Classic Club
            Bagel_Qty[3, 0] = 8;
            Bagel_Qty[3, 1] = 6;
            Bagel_Qty[3, 2] = 13;
            Bagel_Qty[3, 3] = 12;
            Bagel_Qty[3, 4] = 2;
            //Stock of Kiltimagh Special 
            Bagel_Qty[4, 0] = 12;
            Bagel_Qty[4, 1] = 45;
            Bagel_Qty[4, 2] = 34;
            Bagel_Qty[4, 3] = 23;
            Bagel_Qty[4, 4] = 4;
            //Stock of Veggie
            Bagel_Qty[5, 0] = 12;
            Bagel_Qty[5, 1] = 8;
            Bagel_Qty[5, 2] = 19;
            Bagel_Qty[5, 3] = 12;
            Bagel_Qty[5, 4] = 6;
            //Stock of Ploughmans
            Bagel_Qty[6, 0] = 8;
            Bagel_Qty[6, 1] = 5;
            Bagel_Qty[6, 2] = 12;
            Bagel_Qty[6, 3] = 4;
            Bagel_Qty[6, 4] = 3;
            //Stock of Mexicana
            Bagel_Qty[7, 0] = 4;
            Bagel_Qty[7, 1] = 2;
            Bagel_Qty[7, 2] = 5;
            Bagel_Qty[7, 3] = 7;
            Bagel_Qty[7, 4] = 4;
            //Stock of Triple Cheese
            Bagel_Qty[8, 0] = 0;
            Bagel_Qty[8, 1] = 7;
            Bagel_Qty[8, 2] = 4;
            Bagel_Qty[8, 3] = 10;
            Bagel_Qty[8, 4] = 5;
            //Stock of Atlantic Way
            Bagel_Qty[9, 0] = 3;
            Bagel_Qty[9, 1] = 8;
            Bagel_Qty[9, 2] = 6;
            Bagel_Qty[9, 3] = 8;
            Bagel_Qty[9, 4] = 6;
            //Stock of Breakfast
            Bagel_Qty[10, 0] = 6;
            Bagel_Qty[10, 1] = 9;
            Bagel_Qty[10, 2] = 8;
            Bagel_Qty[10, 3] = 6;
            Bagel_Qty[10, 4] = 7;
            //Stock of Maui
            Bagel_Qty[11, 0] = 9;
            Bagel_Qty[11, 1] = 10;
            Bagel_Qty[11, 2] = 10;
            Bagel_Qty[11, 3] = 4;
            Bagel_Qty[11, 4] = 8;
            //Stock of Classic
            Bagel_Qty[12, 0] = 12;
            Bagel_Qty[12, 1] = 11;
            Bagel_Qty[12, 2] = 12;
            Bagel_Qty[12, 3] = 21;
            Bagel_Qty[12, 4] = 9;
            //Stock of Chicken Caeser
            Bagel_Qty[13, 0] = 10;
            Bagel_Qty[13, 1] = 7;
            Bagel_Qty[13, 2] = 8;
            Bagel_Qty[13, 3] = 4;
            Bagel_Qty[13, 4] = 6;
            //Stock of Student Surprise
            Bagel_Qty[14, 0] = 55;
            Bagel_Qty[14, 1] = 3;
            Bagel_Qty[14, 2] = 4;
            Bagel_Qty[14, 3] = 6;
            Bagel_Qty[14, 4] = 23;
            //Stock of Cajun
            Bagel_Qty[15, 0] = 6;
            Bagel_Qty[15, 1] = 5;
            Bagel_Qty[15, 2] = 0;
            Bagel_Qty[15, 3] = 8;
            Bagel_Qty[15, 4] = 8;
            
        }
        public void Load_Price_Initial()
        {
            //Price of Halloumi
            Bagel_Price[0, 0] = 2.45;
            Bagel_Price[0, 1] = 2.95;
            Bagel_Price[0, 2] = 3.45;
            Bagel_Price[0, 3] = 3.99;
            Bagel_Price[0, 4] = 4.53;
            //Price of Bangkok
            Bagel_Price[1, 0] = 2.50;
            Bagel_Price[1, 1] = 3.00;
            Bagel_Price[1, 2] = 3.50;
            Bagel_Price[1, 3] = 3.99;
            Bagel_Price[1, 4] = 4.48;
            //Price of Chicken Philly
            Bagel_Price[2, 0] = 2.55;
            Bagel_Price[2, 1] = 3.05;
            Bagel_Price[2, 2] = 3.55;
            Bagel_Price[2, 3] = 4.00;
            Bagel_Price[2, 4] = 4.45;
            //Price of Classic Club
            Bagel_Price[3, 0] = 2.60;
            Bagel_Price[3, 1] = 2.99;
            Bagel_Price[3, 2] = 3.38;
            Bagel_Price[3, 3] = 3.99;
            Bagel_Price[3, 4] = 4.60;
            //Price of Kiltimagh Special 
            Bagel_Price[4, 0] = 4.55;
            Bagel_Price[4, 1] = 5.69;
            Bagel_Price[4, 2] = 6.83;
            Bagel_Price[4, 3] = 6.99;
            Bagel_Price[4, 4] = 9.99;
            //Price of Veggie
            Bagel_Price[5, 0] = 2.40;
            Bagel_Price[5, 1] = 2.90;
            Bagel_Price[5, 2] = 3.40;
            Bagel_Price[5, 3] = 3.59;
            Bagel_Price[5, 4] = 3.78;
            //Price of Ploughmans
            Bagel_Price[6, 0] = 3.49;
            Bagel_Price[6, 1] = 3.99;
            Bagel_Price[6, 2] = 4.49;
            Bagel_Price[6, 3] = 4.99;
            Bagel_Price[6, 4] = 5.49;
            //Price of Mexicana
            Bagel_Price[7, 0] = 2.19;
            Bagel_Price[7, 1] = 3.12;
            Bagel_Price[7, 2] = 4.05;
            Bagel_Price[7, 3] = 4.49;
            Bagel_Price[7, 4] = 4.93;
            //Price of Triple Cheese
            Bagel_Price[8, 0] = 3.99;
            Bagel_Price[8, 1] = 4.49;
            Bagel_Price[8, 2] = 5.50;
            Bagel_Price[8, 3] = 6.51;
            Bagel_Price[8, 4] = 7.52;
            //Price of Atlantic Way
            Bagel_Price[9, 0] = 7.89;
            Bagel_Price[9, 1] = 8.89;
            Bagel_Price[9, 2] = 8.50;
            Bagel_Price[9, 3] = 8.11;
            Bagel_Price[9, 4] = 7.72;
            //Price of Breakfast
            Bagel_Price[10, 0] = 3.45;
            Bagel_Price[10, 1] = 3.75;
            Bagel_Price[10, 2] = 4.25;
            Bagel_Price[10, 3] = 4.75;
            Bagel_Price[10, 4] = 5.25;
            //Price of Maui
            Bagel_Price[11, 0] = 3.67;
            Bagel_Price[11, 1] = 3.97;
            Bagel_Price[11, 2] = 4.50;
            Bagel_Price[11, 3] = 5.03;
            Bagel_Price[11, 4] = 5.56;
            //Price of Classic
            Bagel_Price[12, 0] = 4.55;
            Bagel_Price[12, 1] = 5.00;
            Bagel_Price[12, 2] = 5.36;
            Bagel_Price[12, 3] = 5.72;
            Bagel_Price[12, 4] = 6.08;
            //Price of Chicken Caeser
            Bagel_Price[13, 0] = 5.00;
            Bagel_Price[13, 1] = 5.50;
            Bagel_Price[13, 2] = 6.00;
            Bagel_Price[13, 3] = 6.50;
            Bagel_Price[13, 4] = 7.00;
            //Price of Student Surprise
            Bagel_Price[14, 0] = 1.23;
            Bagel_Price[14, 1] = 2.23;
            Bagel_Price[14, 2] = 3.23;
            Bagel_Price[14, 3] = 4.23;
            Bagel_Price[14, 4] = 5.23;
            //Price of Cajun
            Bagel_Price[15, 0] = 3.45;
            Bagel_Price[15, 1] = 3.95;
            Bagel_Price[15, 2] = 4.45;
            Bagel_Price[15, 3] = 4.95;
            Bagel_Price[15, 4] = 5.45;
        }

       
        
        public void Display_Stock_Price(string size)
        {
            switch(size)
            {
                case "Small":
                                // Halloumi
                                halluomiQty.Text = "Available Stock [" + Bagel_Qty[0, 0].ToString() + "]";
                                halluomiPrice.Text = "Price: " + Bagel_Price[0, 0].ToString("C2");

                                // Bangkok
                                bangkokQty.Text = "Available Stock [" + Bagel_Qty[1, 0].ToString() + "]";
                                bangkokPrice.Text = "Price: " + Bagel_Price[1, 0].ToString("C2");

                                // Chicken Philly
                                chickenPhillyQty.Text = "Available Stock [" + Bagel_Qty[2, 0].ToString() + "]";
                                chickenPhillyPrice.Text = "Price: " + Bagel_Price[2, 0].ToString("C2");

                                // Classic Club
                                classicClubQty.Text = "Available Stock [" + Bagel_Qty[3, 0].ToString() + "]";
                                classicClubPrice.Text = "Price: " + Bagel_Price[3, 0].ToString("C2");

                                // Kiltimagh Special 
                                kiltimaghSpecialQty.Text = "Available Stock [" + Bagel_Qty[4, 0].ToString() + "]";
                                kiltimaghSpecialPrice.Text = "Price: " + Bagel_Price[4, 0].ToString("C2");

                                // Veggie
                                veggieQty.Text = "Available Stock [" + Bagel_Qty[5, 0].ToString() + "]";
                                veggiePrice.Text = "Price: " + Bagel_Price[5, 0].ToString("C2");

                                // Ploughmans
                                ploughmansQty.Text = "Available Stock [" + Bagel_Qty[6, 0].ToString() + "]";
                                ploughmansPrice.Text = "Price: " + Bagel_Price[6, 0].ToString("C2");

                                // Mexicana
                                mexicanaQty.Text = "Available Stock [" + Bagel_Qty[7, 0].ToString() + "]";
                                mexicanaPrice.Text = "Price: " + Bagel_Price[7, 0].ToString("C2");

                                // Triple Cheese
                                tripleCheeseQty.Text = "Available Stock [" + Bagel_Qty[8, 0].ToString() + "]";
                                tripleCheesePrice.Text = "Price: " + Bagel_Price[8, 0].ToString("C2");

                                // Atlantic Way
                                atlanticWayQty.Text = "Available Stock [" + Bagel_Qty[9, 0].ToString() + "]";
                                atlanticWayPrice.Text = "Price: " + Bagel_Price[9, 0].ToString("C2");

                                // Breakfast
                                breakfastQty.Text = "Available Stock [" + Bagel_Qty[10, 0].ToString() + "]";
                                breakfastPrice.Text = "Price: " + Bagel_Price[10, 0].ToString("C2");
                                // Maui
                                mauiQty.Text = "Available Stock [" + Bagel_Qty[11, 0].ToString() + "]";
                                mauiPrice.Text = "Price: " + Bagel_Price[11, 0].ToString("C2");

                                // Classic
                                classicQty.Text = "Available Stock [" + Bagel_Qty[12, 0].ToString() + "]";
                                classicPrice.Text = "Price: " + Bagel_Price[12, 0].ToString("C2");

                                // Chicken Caeser
                                chickenCaeserQty.Text = "Available Stock [" + Bagel_Qty[13, 0].ToString() + "]";
                                chickenCaeserPrice.Text = "Price: " + Bagel_Price[13, 0].ToString("C2");

                                // Student Surprise
                                studentSurpriseQty.Text = "Available Stock [" + Bagel_Qty[14, 0].ToString() + "]";
                                studentSurprisePrice.Text = "Price: " + Bagel_Price[14, 0].ToString("C2");

                                // Cajun
                                cajunQty.Text = "Available Stock [" + Bagel_Qty[15, 0].ToString() + "]";
                                cajunPrice.Text = "Price: " + Bagel_Price[15, 0].ToString("C2");
                                break;
                case "Medium":
                                // Halloumi
                                halluomiQty.Text = "Available Stock [" + Bagel_Qty[0, 1].ToString() + "]";
                                halluomiPrice.Text = "Price: " + Bagel_Price[0, 1].ToString("C2");

                                // Bangkok
                                bangkokQty.Text = "Available Stock [" + Bagel_Qty[1, 1].ToString() + "]";
                                bangkokPrice.Text = "Price: " + Bagel_Price[1, 1].ToString("C2");

                                // Chicken Philly
                                chickenPhillyQty.Text = "Available Stock [" + Bagel_Qty[2, 1].ToString() + "]";
                                chickenPhillyPrice.Text = "Price: " + Bagel_Price[2, 1].ToString("C2");

                                // Classic Club
                                classicClubQty.Text = "Available Stock [" + Bagel_Qty[3, 1].ToString() + "]";
                                classicClubPrice.Text = "Price: " + Bagel_Price[3, 1].ToString("C2");

                                // Kiltimagh Special 
                                kiltimaghSpecialQty.Text = "Available Stock [" + Bagel_Qty[4, 1].ToString() + "]";
                                kiltimaghSpecialPrice.Text = "Price: " + Bagel_Price[4, 1].ToString("C2");

                                // Veggie
                                veggieQty.Text = "Available Stock [" + Bagel_Qty[5, 1].ToString() + "]";
                                veggiePrice.Text = "Price: " + Bagel_Price[5, 1].ToString("C2");

                                // Ploughmans
                                ploughmansQty.Text = "Available Stock [" + Bagel_Qty[6, 1].ToString() + "]";
                                ploughmansPrice.Text = "Price: " + Bagel_Price[6, 1].ToString("C2");

                                // Mexicana
                                mexicanaQty.Text = "Available Stock [" + Bagel_Qty[7, 1].ToString() + "]";
                                mexicanaPrice.Text = "Price: " + Bagel_Price[7, 1].ToString("C2");

                                // Triple Cheese
                                tripleCheeseQty.Text = "Available Stock [" + Bagel_Qty[8, 1].ToString() + "]";
                                tripleCheesePrice.Text = "Price: " + Bagel_Price[8, 1].ToString("C2");

                                // Atlantic Way
                                atlanticWayQty.Text = "Available Stock [" + Bagel_Qty[9, 1].ToString() + "]";
                                atlanticWayPrice.Text = "Price: " + Bagel_Price[9, 1].ToString("C2");

                                // Breakfast
                                breakfastQty.Text = "Available Stock [" + Bagel_Qty[10, 1].ToString() + "]";
                                breakfastPrice.Text = "Price: " + Bagel_Price[10, 1].ToString("C2");
                                // Maui
                                mauiQty.Text = "Available Stock [" + Bagel_Qty[11, 1].ToString() + "]";
                                mauiPrice.Text = "Price: " + Bagel_Price[11, 1].ToString("C2");

                                // Classic
                                classicQty.Text = "Available Stock [" + Bagel_Qty[12, 1].ToString() + "]";
                                classicPrice.Text = "Price: " + Bagel_Price[12, 1].ToString("C2");

                                // Chicken Caeser
                                chickenCaeserQty.Text = "Available Stock [" + Bagel_Qty[13, 1].ToString() + "]";
                                chickenCaeserPrice.Text = "Price: " + Bagel_Price[13, 1].ToString("C2");

                                // Student Surprise
                                studentSurpriseQty.Text = "Available Stock [" + Bagel_Qty[14, 1].ToString() + "]";
                                studentSurprisePrice.Text = "Price: " + Bagel_Price[14, 1].ToString("C2");

                                // Cajun
                                cajunQty.Text = "Available Stock [" + Bagel_Qty[15, 1].ToString() + "]";
                                cajunPrice.Text = "Price: " + Bagel_Price[15, 1].ToString("C2");
                                break;
                case "Regular":
                                // Halloumi
                                halluomiQty.Text = "Available Stock [" + Bagel_Qty[0, 2].ToString() + "]";
                                halluomiPrice.Text = "Price: " + Bagel_Price[0, 2].ToString("C2");

                                // Bangkok
                                bangkokQty.Text = "Available Stock [" + Bagel_Qty[1, 2].ToString() + "]";
                                bangkokPrice.Text = "Price: " + Bagel_Price[1, 2].ToString("C2");

                                // Chicken Philly
                                chickenPhillyQty.Text = "Available Stock [" + Bagel_Qty[2, 2].ToString() + "]";
                                chickenPhillyPrice.Text = "Price: " + Bagel_Price[2, 2].ToString("C2");

                                // Classic Club
                                classicClubQty.Text = "Available Stock [" + Bagel_Qty[3, 2].ToString() + "]";
                                classicClubPrice.Text = "Price: " + Bagel_Price[3, 2].ToString("C2");

                                // Kiltimagh Special 
                                kiltimaghSpecialQty.Text = "Available Stock [" + Bagel_Qty[4, 2].ToString() + "]";
                                kiltimaghSpecialPrice.Text = "Price: " + Bagel_Price[4, 2].ToString("C2");

                                // Veggie
                                veggieQty.Text = "Available Stock [" + Bagel_Qty[5, 2].ToString() + "]";
                                veggiePrice.Text = "Price: " + Bagel_Price[5, 2].ToString("C2");

                                // Ploughmans
                                ploughmansQty.Text = "Available Stock [" + Bagel_Qty[6, 2].ToString() + "]";
                                ploughmansPrice.Text = "Price: " + Bagel_Price[6, 2].ToString("C2");

                                // Mexicana
                                mexicanaQty.Text = "Available Stock [" + Bagel_Qty[7, 2].ToString() + "]";
                                mexicanaPrice.Text = "Price: " + Bagel_Price[7, 2].ToString("C2");

                                // Triple Cheese
                                tripleCheeseQty.Text = "Available Stock [" + Bagel_Qty[8, 2].ToString() + "]";
                                tripleCheesePrice.Text = "Price: " + Bagel_Price[8, 2].ToString("C2");

                                // Atlantic Way
                                atlanticWayQty.Text = "Available Stock [" + Bagel_Qty[9, 2].ToString() + "]";
                                atlanticWayPrice.Text = "Price: " + Bagel_Price[9, 2].ToString("C2");

                                // Breakfast
                                breakfastQty.Text = "Available Stock [" + Bagel_Qty[10, 2].ToString() + "]";
                                breakfastPrice.Text = "Price: " + Bagel_Price[10, 2].ToString("C2");
                                // Maui
                                mauiQty.Text = "Available Stock [" + Bagel_Qty[11, 2].ToString() + "]";
                                mauiPrice.Text = "Price: " + Bagel_Price[11, 2].ToString("C2");

                                // Classic
                                classicQty.Text = "Available Stock [" + Bagel_Qty[12, 2].ToString() + "]";
                                classicPrice.Text = "Price: " + Bagel_Price[12, 2].ToString("C2");

                                // Chicken Caeser
                                chickenCaeserQty.Text = "Available Stock [" + Bagel_Qty[13, 2].ToString() + "]";
                                chickenCaeserPrice.Text = "Price: " + Bagel_Price[13, 2].ToString("C2");

                                // Student Surprise
                                studentSurpriseQty.Text = "Available Stock [" + Bagel_Qty[14, 2].ToString() + "]";
                                studentSurprisePrice.Text = "Price: " + Bagel_Price[14, 2].ToString("C2");

                                // Cajun
                                cajunQty.Text = "Available Stock [" + Bagel_Qty[15, 2].ToString() + "]";
                                cajunPrice.Text = "Price: " + Bagel_Price[15, 2].ToString("C2");
                                break;
                case "Large":
                                // Halloumi
                                halluomiQty.Text = "Available Stock [" + Bagel_Qty[0, 3].ToString() + "]";
                                halluomiPrice.Text = "Price: " + Bagel_Price[0, 3].ToString("C2");

                                // Bangkok
                                bangkokQty.Text = "Available Stock [" + Bagel_Qty[1, 3].ToString() + "]";
                                bangkokPrice.Text = "Price: " + Bagel_Price[1, 3].ToString("C2");

                                // Chicken Philly
                                chickenPhillyQty.Text = "Available Stock [" + Bagel_Qty[2, 3].ToString() + "]";
                                chickenPhillyPrice.Text = "Price: " + Bagel_Price[2, 3].ToString("C2");

                                // Classic Club
                                classicClubQty.Text = "Available Stock [" + Bagel_Qty[3, 3].ToString() + "]";
                                classicClubPrice.Text = "Price: " + Bagel_Price[3, 3].ToString("C2");

                                // Kiltimagh Special 
                                kiltimaghSpecialQty.Text = "Available Stock [" + Bagel_Qty[4, 3].ToString() + "]";
                                kiltimaghSpecialPrice.Text = "Price: " + Bagel_Price[4, 3].ToString("C2");

                                // Veggie
                                veggieQty.Text = "Available Stock [" + Bagel_Qty[5, 3].ToString() + "]";
                                veggiePrice.Text = "Price: " + Bagel_Price[5, 3].ToString("C2");

                                // Ploughmans
                                ploughmansQty.Text = "Available Stock [" + Bagel_Qty[6, 3].ToString() + "]";
                                ploughmansPrice.Text = "Price: " + Bagel_Price[6, 3].ToString("C2");

                                // Mexicana
                                mexicanaQty.Text = "Available Stock [" + Bagel_Qty[7, 3].ToString() + "]";
                                mexicanaPrice.Text = "Price: " + Bagel_Price[7, 3].ToString("C2");

                                // Triple Cheese
                                tripleCheeseQty.Text = "Available Stock [" + Bagel_Qty[8, 3].ToString() + "]";
                                tripleCheesePrice.Text = "Price: " + Bagel_Price[8, 3].ToString("C2");

                                // Atlantic Way
                                atlanticWayQty.Text = "Available Stock [" + Bagel_Qty[9, 3].ToString() + "]";
                                atlanticWayPrice.Text = "Price: " + Bagel_Price[9, 3].ToString("C2");

                                // Breakfast
                                breakfastQty.Text = "Available Stock [" + Bagel_Qty[10, 3].ToString() + "]";
                                breakfastPrice.Text = "Price: " + Bagel_Price[10, 3].ToString("C2");
                                // Maui
                                mauiQty.Text = "Available Stock [" + Bagel_Qty[11, 3].ToString() + "]";
                                mauiPrice.Text = "Price: " + Bagel_Price[11, 3].ToString("C2");

                                // Classic
                                classicQty.Text = "Available Stock [" + Bagel_Qty[12, 3].ToString() + "]";
                                classicPrice.Text = "Price: " + Bagel_Price[12, 3].ToString("C2");

                                // Chicken Caeser
                                chickenCaeserQty.Text = "Available Stock [" + Bagel_Qty[13, 3].ToString() + "]";
                                chickenCaeserPrice.Text = "Price: " + Bagel_Price[13, 3].ToString("C2");

                                // Student Surprise
                                studentSurpriseQty.Text = "Available Stock [" + Bagel_Qty[14, 3].ToString() + "]";
                                studentSurprisePrice.Text = "Price: " + Bagel_Price[14, 3].ToString("C2");

                                // Cajun
                                cajunQty.Text = "Available Stock [" + Bagel_Qty[15, 3].ToString() + "]";
                                cajunPrice.Text = "Price: " + Bagel_Price[15, 3].ToString("C2");
                                break;
                case "Extra Large":
                                // Halloumi
                                halluomiQty.Text = "Available Stock [" + Bagel_Qty[0, 4].ToString() + "]";
                                halluomiPrice.Text = "Price: " + Bagel_Price[0, 4].ToString("C2");

                                // Bangkok
                                bangkokQty.Text = "Available Stock [" + Bagel_Qty[1, 4].ToString() + "]";
                                bangkokPrice.Text = "Price: " + Bagel_Price[1, 4].ToString("C2");

                                // Chicken Philly
                                chickenPhillyQty.Text = "Available Stock [" + Bagel_Qty[2, 4].ToString() + "]";
                                chickenPhillyPrice.Text = "Price: " + Bagel_Price[2, 4].ToString("C2");

                                // Classic Club
                                classicClubQty.Text = "Available Stock [" + Bagel_Qty[3, 4].ToString() + "]";
                                classicClubPrice.Text = "Price: " + Bagel_Price[3, 4].ToString("C2");

                                // Kiltimagh Special 
                                kiltimaghSpecialQty.Text = "Available Stock [" + Bagel_Qty[4, 4].ToString() + "]";
                                kiltimaghSpecialPrice.Text = "Price: " + Bagel_Price[4, 4].ToString("C2");

                                // Veggie
                                veggieQty.Text = "Available Stock [" + Bagel_Qty[5, 4].ToString() + "]";
                                veggiePrice.Text = "Price: " + Bagel_Price[5, 4].ToString("C2");

                                // Ploughmans
                                ploughmansQty.Text = "Available Stock [" + Bagel_Qty[6, 4].ToString() + "]";
                                ploughmansPrice.Text = "Price: " + Bagel_Price[6, 4].ToString("C2");

                                // Mexicana
                                mexicanaQty.Text = "Available Stock [" + Bagel_Qty[7, 4].ToString() + "]";
                                mexicanaPrice.Text = "Price: " + Bagel_Price[7, 4].ToString("C2");

                                // Triple Cheese
                                tripleCheeseQty.Text = "Available Stock [" + Bagel_Qty[8, 4].ToString() + "]";
                                tripleCheesePrice.Text = "Price: " + Bagel_Price[8, 4].ToString("C2");

                                // Atlantic Way
                                atlanticWayQty.Text = "Available Stock [" + Bagel_Qty[9, 4].ToString() + "]";
                                atlanticWayPrice.Text = "Price: " + Bagel_Price[9, 4].ToString("C2");

                                // Breakfast
                                breakfastQty.Text = "Available Stock [" + Bagel_Qty[10, 4].ToString() + "]";
                                breakfastPrice.Text = "Price: " + Bagel_Price[10, 4].ToString("C2");
                                // Maui
                                mauiQty.Text = "Available Stock [" + Bagel_Qty[11, 4].ToString() + "]";
                                mauiPrice.Text = "Price: " + Bagel_Price[11, 4].ToString("C2");

                                // Classic
                                classicQty.Text = "Available Stock [" + Bagel_Qty[12, 4].ToString() + "]";
                                classicPrice.Text = "Price: " + Bagel_Price[12, 4].ToString("C2");

                                // Chicken Caeser
                                chickenCaeserQty.Text = "Available Stock [" + Bagel_Qty[13, 4].ToString() + "]";
                                chickenCaeserPrice.Text = "Price: " + Bagel_Price[13, 4].ToString("C2");

                                // Student Surprise
                                studentSurpriseQty.Text = "Available Stock [" + Bagel_Qty[14, 4].ToString() + "]";
                                studentSurprisePrice.Text = "Price: " + Bagel_Price[14, 4].ToString("C2");

                                // Cajun
                                cajunQty.Text = "Available Stock [" + Bagel_Qty[15, 4].ToString() + "]";
                                cajunPrice.Text = "Price: " + Bagel_Price[15, 4].ToString("C2");
                                break;
        }
        }

        private void bagelSizeDropDownBox_SelectedIndexChanged(object sender, EventArgs e)
        {       
            string selectedSize = "";
            selectedSize = bagelSizeDropDownBox.SelectedItem.ToString();
            switch (selectedSize)
            {
                case "Small":
                    Selected_Size_index = 0;
                    Display_Stock_Price(selectedSize);
                    break;
                case "Medium":
                    Selected_Size_index = 1;
                    Display_Stock_Price(selectedSize);
                    break;
                case "Regular":
                    Selected_Size_index = 2;
                    Display_Stock_Price(selectedSize);
                    break;
                case "Large":
                    Selected_Size_index = 3;
                    Display_Stock_Price(selectedSize);
                    break;
                case "Extra Large":
                    Selected_Size_index = 4;
                    Display_Stock_Price(selectedSize);
                    break;
            }
          
        }

        private void addToCartBtn_Click(object sender, EventArgs e)
        {
            bool isValid = false;
            isValid = Validate_selection(isValid);
            if (isValid)
            {
                int Selected_Qty = 0;
                double Selected_Price = 0;
                Selected_Qty = GetSelectedQty_Stock(Selected_Unit_index, Selected_Size_index);
                Selected_Price = GetSelectedPrice(Selected_Unit_index, Selected_Size_index);
                Bagel_Qty[Selected_Unit_index, Selected_Size_index] = Selected_Qty - (int)qtyUpDown.Value;
                AddToList(Selected_Qty, Selected_Price);
                Display_Stock_Price(bagelSizeDropDownBox.SelectedItem.ToString());
                ResetVariables();
                submitOrderBtn.Visible = true;
            }
            
        }
        public bool Validate_selection(bool isValid)
        {
            if (Selected_Unit != "")
            {
                if (bagelSizeDropDownBox.SelectedItem.ToString() != "")
                {
                    if (qtyUpDown.Value != 0)
                    {
                        isValid = true;
                    }
                    else
                    {
                        MessageBox.Show("Select the quantity");
                    }
                }
                else
                {
                    MessageBox.Show("Select the Bagel Size!");
                }
            }
            else
            {
                MessageBox.Show("Select a Bagel Type!");
            }
            return isValid;
        }
        public int GetSelectedQty_Stock(int item, int size)
        {
            int Selected_Qty = 0;
            Selected_Qty = Bagel_Qty[item,size];
            return Selected_Qty;
        }
        public double GetSelectedPrice(int item, int size)
        {
            double Selected_Price = 0;
            Selected_Price = Bagel_Price[item, size];
            return Selected_Price;
        }

        public void AddToList(int Selected_Qty, double Selected_Price)
        {
            double item_price = 0;
            string[] listary = new string[4];
            item_price = (int)qtyUpDown.Value * Selected_Price;
            Order_Total += item_price;
            ListViewItem listitem;

            listary[0] = Selected_Unit + "(" + bagelSizeDropDownBox.SelectedItem.ToString() + ")";
            listary[1] = Selected_Price.ToString("C2");
            listary[2] = qtyUpDown.Value.ToString();
            listary[3] = item_price.ToString("C2");
            listitem = new ListViewItem(listary);

            bagelItemsLstView.Items.Add(listitem);
            totalSumLbl.Text = Order_Total.ToString("C2");

        }

        private void qtyUpDown_ValueChanged(object sender, EventArgs e)
        {
            DialogResult result = new DialogResult();
            int Selected_Qty = 0;
            Selected_Qty = GetSelectedQty_Stock(Selected_Unit_index,Selected_Size_index);

            if (qtyUpDown.Value > Selected_Qty)
            {
                result = MessageBox.Show("Sorry, the selected quantity has exceeded the available stock!");
                if (result.ToString() == "OK")
                {
                    qtyUpDown.Value = Selected_Qty;
                    qtyUpDown.Select(0,2);
                    qtyUpDown.Focus();
                }
            }
        }
        public void ResetVariables()
        {
            Selected_Unit = "";
            qtyUpDown.Value = 0;
            qtyUpDown.Enabled = false;
        }

        private void submitOrderBtn_Click(object sender, EventArgs e)
        {
            int bagel_sold_per_order = 0;
            DialogResult result = new DialogResult();
            string str = "";
            result = MessageBox.Show("Are you sure you want to continue with the order?", "Order Confirmation", MessageBoxButtons.OKCancel);
            if (result.ToString() == "OK")
            {
                transaction_counter++;
                submitOrderBtn.Visible = false;
                string bagel_type = "";
                string bagel_price = "";
                string qty = "";
                string item_total = "";
                bool isLastItem = false;
                bool isFirstItem;

                
                transaction_number = transaction_number+1;
                foreach (ListViewItem itemRow in bagelItemsLstView.Items)
                {
                  isFirstItem = false;  
                  bagel_sold_per_order = bagel_sold_per_order + int.Parse(itemRow.SubItems[2].Text);
                  bagel_type = itemRow.SubItems[0].Text;
                  bagel_price = itemRow.SubItems[1].Text;
                  qty = itemRow.SubItems[2].Text;
                  item_total = itemRow.SubItems[3].Text;

                  str = str + Environment.NewLine + "Bagel type: " + bagel_type + ' ' +
                            "Price: " + bagel_price + ' ' + "Quantity: " + qty
                            + ' ' + "Item total: " + item_total + Environment.NewLine;
                  if (itemRow.Index == 0)
                  {
                      isFirstItem = true;
                  }
                  if (itemRow.Index == bagelItemsLstView.Items.Count - 1)
                  {
                      isLastItem = true;
                  }
                  SaveTransactionsToFile(transaction_number, bagel_type, bagel_price, qty, item_total, totalSumLbl.Text, isLastItem, isFirstItem);
                      
                  
                }

                MessageBox.Show("Order is confirmed. Below are the Order details: "  +Environment.NewLine
                + "Transaction Number: " + transaction_number.ToString() + str + Environment.NewLine + "Grand Total: " +
                totalSumLbl.Text,"Order Receipt");
                total_transactions++;
                total_bagel_sold = total_bagel_sold + bagel_sold_per_order;
                total_sales_value = total_sales_value + double.Parse(totalSumLbl.Text.Substring(1)); 
                bagelItemsLstView.Items.Clear();
                Order_Total = 0;
                totalSumLbl.Text = "0000";
            }
            
        }

        private void exitImgBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = new DialogResult();
            result = MessageBox.Show("Are you sure you want to exit the application?", "Exit Confirmation", MessageBoxButtons.OKCancel);
            if (result.ToString() == "OK")
            {
                SaveStockReportToFile();
                Application.Exit();
            }
        }

        private void summaryImgBtn_Click(object sender, EventArgs e)
        {
            double avg_value_per_transaction = 0;
            avg_value_per_transaction = total_sales_value/total_transactions;
            MessageBox.Show("Below are the summary statistics for the day: " + Environment.NewLine + "Total no. of Bagels sold: "
                + total_bagel_sold + Environment.NewLine + "Total Sales Value: " + total_sales_value +
                Environment.NewLine + "Total transactions: " + total_transactions + Environment.NewLine + "Avg Value per transaction: "
                + avg_value_per_transaction, "Day's Summary Report");
        }

        private void newImgBtn_Click(object sender, EventArgs e)
        {
            bagelItemsLstView.Items.Clear();
            totalSumLbl.Text = "0000";
            submitOrderBtn.Visible = false;
        }
        
        public void SaveTransactionsToFile(int transaction_id, string bagel_type, string price,string qty, string total, string grand_total, 
            bool isLastItem, bool isFirstItem)
        {
            
            using (StreamWriter filewrite = new StreamWriter(Transactions_file, true))
            {
                if (isFirstItem)
                {
                    filewrite.WriteLine("Transaction ID: " + transaction_id.ToString());
                }
                filewrite.WriteLine("Bagel Type: " + bagel_type);
                filewrite.WriteLine("Bagel Price: " + price.ToString());
                filewrite.WriteLine("Bagel Quantity: " + qty.ToString());
                filewrite.WriteLine("Item Total: " + total.ToString());
                if (isLastItem)
                {
                    filewrite.WriteLine("Grand Total: " + grand_total);
                    filewrite.WriteLine("******************************************");
                }
                
            }

            
        }

        public void SaveStockReportToFile()
        {
            using (StreamWriter filewrite = new StreamWriter(stock_file, false))
            {
                for (int i = 0; i < Bagel_Type.Length; i++)
                {
                    filewrite.WriteLine("********************|" + Bagel_Type[i] + "|********************");
                    filewrite.WriteLine("********************|Stock Report|********************");
                    filewrite.WriteLine("********************|" + DateTime.Now + "|********************");
                    filewrite.WriteLine("**Size" + '\t' + "Type" + '\t' + "Quantity**");
                    for (int j = 0; j < Bagel_Size.Length; j++)
                    {
                        filewrite.WriteLine(Bagel_Size[j] + '\t' + Bagel_Type[i] + '\t' + Bagel_Qty[i,j]);
                    }
                }

            }
        }

        public void ReadStockFromFile()
        {
            try
            {
                if (!File.Exists(stock_file))
                {
                    throw new FileNotFoundException();
                }
                else
                {
                    string[] linecontent = new string[3];

                    using (StreamReader fileread = new StreamReader(stock_file))
                    {
                        string filecontent = "";
                        while ((filecontent = fileread.ReadLine()) != null)
                        {
                            if (!filecontent.Contains("*"))
                            {
                                linecontent = filecontent.Split('\t');
                                for (int i = 0; i < Bagel_Type.Length; i++)
                                {
                                    for (int j = 0; j < Bagel_Size.Length; j++)
                                    {
                                        if (linecontent[1] == Bagel_Type[i] && linecontent[0] == Bagel_Size[j])
                                        {
                                            Bagel_Qty[i,j] = int.Parse(linecontent[2]);
                                        }
                                    }
                                }
                            }
                            
                        }

                        
                    }
                }

            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show("No Stock File Available");
            }
        }



    }
}
