class Complex
{
    public double Real { get; set; }
    public double Imaginary { get; set; }

    public Complex(double real, double imaginary)
    {
        Real = real;
        Imaginary = imaginary;
    }

    public static Complex operator +(Complex c1, Complex c2)
    {
        return new Complex(c1.Real + c2.Real, c1.Imaginary + c2.Imaginary);
    }

    public static Complex operator -(Complex c1, Complex c2)
    {
        return new Complex(c1.Real - c2.Real, c1.Imaginary - c2.Imaginary);
    }

    public override string ToString()
    {
        return $"{Real} + {Imaginary}";
    }
}

class Program
{
    static void Main()
    {
        Complex c1 = new Complex(1, 2);
        Complex c2 = new Complex(3, 4);

        Complex sum = c1 + c2;
        Complex difference = c1 - c2;

        Console.WriteLine($"Sum: {sum}");
        Console.WriteLine($"Difference: {difference}");
    }
}