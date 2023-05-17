using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanRacoonDryCleaning.CleanRacoon.Classes
{
    class Customer
    {
       
        public string Firstname { get; set; }
        public string Lastname { get; set; }


        //another way to set/ get
        private string phoneNumber;
        public string PhoneNumber
        {
            set { phoneNumber = value; }
            get { return phoneNumber; }
        }


        private int _custId;

        //set
        public void setId(int id)
        {
            if (id <= 0)
            {
                throw new Exception("ID cant be negative number");
            }
            //set
            this._custId = id;
        }

        //get
        public int getId()
        {
            return this._custId;
        }


        public Customer( string F, string L,  string phone)
        {
            Firstname = F;
            Lastname = L;
  
            PhoneNumber = phone;
        }
        public string DisplayCustomer()
        {
            return this.Firstname + " " + this.Lastname + " " + " Phone Number: " + this.phoneNumber + Environment.NewLine;
        }

        private static Dictionary<Customer, int> objectCounts = new Dictionary<Customer, int>();


    }
}
