// See https://aka.ms/new-console-template for more information
using ATM_Machine;

//Display ATM Options
void printOptions()
{
    Console.WriteLine("Please choose an option");
    Console.WriteLine("*************************");
    Console.WriteLine("1. Deposit");
    Console.WriteLine("2. Withdraw");
    Console.WriteLine("3. Balance");
    Console.WriteLine("4. Exit\n");
}

//Make Deposits 
void deposit(cardHolder currentUser)
{
    Console.Write("Specify deposit amount: ");
    double deposit = Convert.ToDouble(Console.ReadLine());
    currentUser.setBalance(currentUser.getBalance() + deposit);

    Console.WriteLine("Thank you for deposit. Your new balance is "+currentUser.getBalance()+"\n");
}

//Make Withdrawals
void withdraw(cardHolder currentUser)
{
    Console.Write("Specify withdrawal amount: ");
    double withdraw = Convert.ToDouble(Console.ReadLine());
    //check if user has enough funds
    if (currentUser.getBalance() < withdraw)
    {
        Console.WriteLine("Insufficient Funds :(.\n");
    }
    else
    {
        currentUser.setBalance(currentUser.getBalance() - withdraw);
        Console.WriteLine("Thank you for withdrawal. You are good to go.\n");
    }
}

//Get Account Balance
void balance(cardHolder currentUser)
{
    Console.WriteLine("Current balance is " + currentUser.getBalance()+"\n");
}

//List of account holders
var cardHolders = new List<cardHolder>
{
    new cardHolder("1234567", 1234, "John", "Joe", 150.64),
    new cardHolder("2345678", 2345, "Tomilayo", "Oseghae", 250.64),
    new cardHolder("3456789", 3456, "Ose", "Oseghae", 50.64),
    new cardHolder("4567890", 4567, "David", "Doe", 350.64)
};




//Prompt the user
Console.WriteLine("Welcome to ATM Gallery");
Console.Write("Please insert your card: ");
string? debitCardNum = "";
cardHolder? currentUser;

//Confirm the Card Number
while (true)
{
    try
    {
        debitCardNum = Console.ReadLine();

        currentUser = cardHolders.FirstOrDefault(a => a.cardNumber == debitCardNum);

        if (currentUser != null)
        {
            break;
        }
        else
        {
            Console.WriteLine("Card not Recognised. Try again\n");
        }

    }
    catch (Exception)
    {

        Console.WriteLine("Card not Recognised. Try again\n");
    }
}


//PIN ENTRY
Console.Write("Please enter your Pin: ");
int? userPin = 0;

//Confirm Pin entered
while (true)
{
    try
    {
        userPin = Convert.ToInt32(Console.ReadLine());
        //currentUser = cardHolders.FirstOrDefault(a => a.pin == userPin);
        if (currentUser.pin == userPin)
        {
            break;
        }
        else
        {
            Console.WriteLine("Incorrect Pin. Try again\n");
        }

    }
    catch (Exception)
    {

        Console.WriteLine("Incorrect Pin. Try again\n");
    }
}

//SUCCESSFUL LOGIN TO ATM
Console.WriteLine("-------------------------------------------");
Console.WriteLine($"Welcome {currentUser.firstName.ToUpper()} {currentUser.lastName.ToUpper()}!");
Console.WriteLine("-------------------------------------------");
int options = 0;
do
{
    printOptions();
    try
    {
        options = Convert.ToInt32(Console.ReadLine());
        if (options == 1) { deposit(currentUser); }
        else if (options == 2) { withdraw(currentUser); }
        else if (options == 3) { balance(currentUser); }
        else if (options == 4) { break; }
        else { options = 0; }
    }
    catch (Exception)
    {
        Console.WriteLine("Enter a valid option. Try again\n");

    }


} while (options != 4);

//EXIT ATM
Console.WriteLine("\n********* Thank you! Goodbye *********\n");
