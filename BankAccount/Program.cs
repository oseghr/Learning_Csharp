// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Jon Pierre: Hello, Ose!");

using OseBank;

var account1 = new BankAccount("Ose Benson", 1000);
Console.WriteLine($"Account {account1.accountNumber} was created for {account1.fullName} with {account1.balance} initial balance.");


// account1.makeWithdrawal(800, DateTime.Now, "Rent payment");
// Console.WriteLine(account1.balance);
// account1.makeDeposit(100, DateTime.Now, "Friend paid me back");
// Console.WriteLine(account1.balance);

//BankAccount invalidAccount;
// try
// {
//     invalidAccount = new BankAccount("invalid", -55);
// }
// catch (ArgumentOutOfRangeException e)
// {
//     Console.WriteLine("Exception caught creating account with negative balance");
//     Console.WriteLine(e.ToString());
//     return;
// }

try
{
    account1.makeWithdrawal(1750, DateTime.Now, "Attempt to overdraw");
}
catch (InvalidOperationException e)
{
    Console.WriteLine("Exception caught trying to overdraw");
    Console.WriteLine(e.ToString());
}