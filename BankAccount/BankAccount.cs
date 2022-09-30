namespace OseBank;
public class BankAccount
{
    // It has a 10-digit number that uniquely identifies the bank account.
    private static int accountNumberSeed = 1234567890;
    public string accountNumber { get; }

    // It has a string that stores the name or names of the owners.
    public string fullName { get; set; }

    // The balance can be retrieved.
    public decimal balance 
    { get
        {
            decimal balance = 0;
            foreach (var item in allTransactions)
            {
                balance += item.Amount;
            }

            return balance;
        }
    }

    public BankAccount(string name, decimal balance)
    {
        this.accountNumber = accountNumberSeed.ToString();
        accountNumberSeed++;        
        
        this.fullName = name;
        // this.balance = initialBalance;

        makeDeposit(balance, DateTime.Now, "Initial Balance");

    }

    private List<Transaction> allTransactions = new List<Transaction>();

    // It accepts deposits.
    public void makeDeposit(decimal amount, DateTime date, string note)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
        }
        var deposit = new Transaction(amount, date, note);
        allTransactions.Add(deposit);

    }

    // It accepts withdrawals.
    public void makeWithdrawal(decimal amount, DateTime date, string note)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
        }
        if (balance <= 0)
        {
            throw new InvalidOperationException("Not sufficient funds for this withdrawal");
        }
        var withdrawal = new Transaction(-amount, date, note);
        allTransactions.Add(withdrawal);

    }
    // The initial balance must be positive.

    // Withdrawals cannot result in a negative balance.
}







