public abstract class Account
{
    public abstract void Deposit(double amount);
    public abstract void Withdraw(double amount);
}

public class SavingsAccount : Account
{
    private double balance;

    public override void Deposit(double amount)
    {
        balance += amount;
        Console.WriteLine($"Deposited: {amount}");
    }

    public override void Withdraw(double amount)
    {
        if (balance - amount >= 0)
        {
            balance -= amount;
            Console.WriteLine($"Withdrawn: {amount}");
        }
        else
        {
            Console.WriteLine("Insufficient funds.");
        }
    }
}

public class CheckingAccount : Account
{
    private double balance;

    public override void Deposit(double amount)
    {
        balance += amount;
        Console.WriteLine($"Deposited: {amount}");
    }

    public override void Withdraw(double amount)
    {
        if (balance - amount >= -500)
        {
            balance -= amount;
            Console.WriteLine($"Withdrawn: {amount}");
        }
        else
        {
            Console.WriteLine("Insufficient funds.");
        }
    }
}

public class Program
{
    public static void Main()
    {
        SavingsAccount savingsAccount = new SavingsAccount();
        CheckingAccount checkingAccount = new CheckingAccount();

        savingsAccount.Deposit(1000);
        savingsAccount.Withdraw(1000);
        savingsAccount.Withdraw(1);

        checkingAccount.Deposit(2000);
        checkingAccount.Withdraw(1500);
        checkingAccount.Withdraw(2000);
    }
}