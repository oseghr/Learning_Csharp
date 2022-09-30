using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Machine
{

    class cardHolder
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string cardNumber { get; set; }
        public int pin { get; set; }

        private double balance;


        public cardHolder(
            string cardNumber, int pin, string firstName, string lastName, double balance)
        {
            this.cardNumber = cardNumber;
            this.pin = pin;
            this.firstName = firstName;
            this.lastName = lastName;
            this.balance = balance;
        }


        //Get and Set balance
        public double getBalance() { return balance; }
        public void setBalance(double newBalance) => balance = newBalance;

    }
}
