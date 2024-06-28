class Counter
{
    public event EventHandler ValueChanged;
    private int count = 0;

    public void Increment()
    {
        count++;
        OnValueChanged();
    }

    public virtual void OnValueChanged()
    {
        ValueChanged?.Invoke(this, EventArgs.Empty);
    }

    public int GetCount()
    {
        return count;
    }
}

class Program
{
    static void Main()
    {
        Counter counter = new Counter();

        counter.ValueChanged += OnValueChanged;

        counter.Increment();
        counter.Increment();
        counter.Increment();

        counter.ValueChanged -= OnValueChanged;
    }

    static void OnValueChanged(object sender, EventArgs e)
    {
        Counter counter = (Counter)sender;
        Console.WriteLine("Counter value: " + counter.GetCount());
    }
}