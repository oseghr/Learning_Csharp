using System;

namespace VSCodeC_
{
    class Program
    {
        public class cardHolder
        {
            string cardNum;
            int pin;
            string firstname;
            string lastname;
            double balance;

            public cardHolder(string cardNum,int pin,string firstname,string lastname,double balance )
            {
                this.cardNum = cardNum;
                this.balance = balance;
                this.firstname = firstname;
                this.lastname = lastname;
                this.pin = pin;
            }

            // set getters
            public int Num()
            {
                get { return cardNum; }
                set { cardNum = value; }
            }
            public string getPin()
            {
                return pin;
            }

            public string getFirstName()
            {
                return firstname;
            }
            public string getLastname()
            {
                return lastname;
            }
            public string getBalance()
            {
                return balance;
            }

            //set setters
            public string setNum( string newCardNum)
            {
                string cardNum =  newCardNum;
            }
            public string setPin(string newPin)
            {
                return newPin;
            }

            public string setFirstName()
            {
                return firstname;
            }
            public string setLastname()
            {
                return lastname;
            }
            public string setBalance()
            {
                return balance;
            }



        }
        static void Main(string[] args)
        {

            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }
}



class Person
{
    private string name; //field
    public Person()     //constructor
    {
        //Logic
    }

    public string Name  //property
    {
        get { return name; }
        set { name = value; }
    }

    public void Run()   //method
    {
        //logic

    }


    
}