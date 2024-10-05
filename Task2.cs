class Bank
{
    private int _money;
    private string _name;
    private int _percent;
    private object _lock = new object();

    public int Money
    {
        get { return _money; }
        set { _money = value; StartThread(); }
    }

    public string Name
    {
        get { return _name; }
        set { _name = value; StartThread(); }
    }

    public int Percent
    {
        get { return _percent; }
        set { _percent = value; StartThread(); }
    }

    public Bank(int money, string name, int percent)
    {
        _money = money;
        _name = name;
        _percent = percent;
    }

    private void StartThread()
    {
        Thread thread = new Thread(WriteToFile);
        thread.Start();
        Console.WriteLine("New thread made");
    }

    public void WriteToFile()
    {
        lock (_lock)
        {
            using (StreamWriter sw = new StreamWriter("../../../bank_data.txt"))
            {
                sw.WriteLine($"Bank: {_name}, Money: {_money}, Percent: {_percent}");
            }
        }
    }
}

class Program
{
    static void Main()
    {
        Bank bank = new Bank(100, "My bank", 10);
        bank.Money = 200;
        bank.Name = "test";
        bank.Percent = 5;

        Thread.Sleep(100);
    }
}