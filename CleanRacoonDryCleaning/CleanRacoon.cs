using CleanRacoonDryCleaning.CleanRacoon.Classes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;
using System.IO;


using CleanRacoonDryCleaning.CleanRacoon.Classes.Soils;

namespace CleanRacoonDryCleaning
{
    public partial class CleanRacoonDC : Form
    {

        ArrayList CRCustomerList = new ArrayList();
        ArrayList Orders = new ArrayList(0);
        public CleanRacoonDC()
        {
            InitializeComponent();

        }

        private void saveCustBtn_Click(object sender, EventArgs e)
        {

            Customer CRCustomer = new Customer(fNametextBox.Text, lastNametextBox.Text, phoneNumtextBox.Text);

            //add customer to list
            CRCustomerList.Add(CRCustomer);
        }

        private void displayCustBtn_Click(object sender, EventArgs e)
        {
            foreach (Customer cust in CRCustomerList)
            {

                outputListBox.Items.Add(cust.DisplayCustomer());
                // outPutLabel.Text = cust.DisplayCustomer();
            }


        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        #region Clear All Method
        private void ClearAll()
        {
            fNametextBox.Text = "";
            lastNametextBox.Text = "";
            phoneNumtextBox.Text = "";

            outPutLabel.Text = string.Empty;
            outputListBox.Items.Clear();

            priceLabel.Text = "Price:";

            smRadioBtn.Checked = false;
            medRadioBtn.Checked = false;
            bigRadioBtn.Checked = false;

            lowLevelOfSoilingRdBtn.Checked = false;
            highLevelOfSoilingRdBtn.Checked = false;
            Orders.Clear();
            ttlClothesLabel.Text = "Total:" + Orders.Count.ToString();
        }
        #endregion

        #region Calculate Cost Button Click
        private void calcCostBtn_Click(object sender, EventArgs e)
        {
            double totalCost = 0;
            double price = 0;

            var buttons = this.Controls.OfType<RadioButton>().FirstOrDefault(n => n.Checked);

            string soilType;

            string size;

            if (lowLevelOfSoilingRdBtn.Checked == true)
            {
                soilType = "lowLevelOfSoiling";

                if (smRadioBtn.Checked == true)
                {
                    size = "Small";
                    price = 3.25;
                }
                else if (medRadioBtn.Checked == true)
                {
                    size = "Medium";
                    price = 4.50;
                }
                else
                {
                    size = "Large";
                    price = 5;
                }
                //create new  object
                LowPollution LowPolluted = new LowPollution(size, price);

                //Add object to list
                Orders.Add(LowPolluted);

                //Set Price
                foreach (Clothes coffee in Orders)
                {

                    totalCost += coffee.price;

                }


                priceLabel.Text = "Price: " + totalCost.ToString("C2");



                //Count total
                ttlClothesLabel.Text = "Total:" + Orders.Count.ToString();
            }
            else if (highLevelOfSoilingRdBtn.Checked == true)
            {


                soilType = "highLevelOfSoiling";


                if (smRadioBtn.Checked == true)
                {
                    size = "Small";
                    price = 5.25;

                }
                else if (medRadioBtn.Checked == true)
                {
                    size = "Medium";
                    price = 7.25;
                }
                else
                {
                    size = "Large";
                    price = 9;
                }
                //create  object
                HihgPollution HighPolluted = new HihgPollution(size, price);
                //Set Price


                Orders.Add(HighPolluted);

                //Set Price
                foreach (Clothes clothe in Orders)
                {
                    totalCost += clothe.price;
                }


                priceLabel.Text = "Price: " + totalCost.ToString("C2");
                //Add object to list

                //Count total
                ttlClothesLabel.Text = "Total:" + Orders.Count.ToString();
            }

        }

        private void Sale_Click(object sender, EventArgs e)
        {
            double saledCost = 0;

            foreach (Clothes clothe in Orders)
            {
                saledCost += clothe.price * 0.97;
            }
            priceLabel.Text = "Price: " + saledCost.ToString("C2");
        }


        #endregion

        private void FindCustomerButton_Click(object sender, EventArgs e)
        {
            string keyword = FindCustomerTextBox.Text; // Отримання ключового слова для пошуку
            ArrayList searchResults = new ArrayList(); // Створення ArrayList для збереження результатів пошуку

            foreach (Customer cust in CRCustomerList)
            {
                if (cust.Firstname.Contains(keyword) || cust.Lastname.Contains(keyword) || cust.PhoneNumber.Contains(keyword))
                {
                    searchResults.Add(cust); // Додавання знайденого об'єкта в ArrayList результатів пошуку
                }
            }

            // Використання результатів пошуку (наприклад, виведення в ListBox або виконання інших дій)
            if (searchResults.Count > 0)
            {
                foreach (Customer result in searchResults)
                {
                    FindOutputListBox.Items.Add(result.DisplayCustomer());
                }
            }
            else
            {
                FindOutputListBox.Items.Add("No results found.");

            }
        }

        private void FastServiceButton_Click(object sender, EventArgs e)
        {
            double fastCost = 0;

            foreach (Clothes clothe in Orders)
            {
                fastCost += clothe.price * 1.5;
            }
            priceLabel.Text = "Price: " + fastCost.ToString("C2");
        }
    }
}
