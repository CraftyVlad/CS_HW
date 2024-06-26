
class Temperature
{
    public double Celsius { get; set; }

    public Temperature(double celsius)
    {
        Celsius = celsius;
    }

    public static implicit operator FahrenheitTemperature(Temperature celsiusTemp)
    {
        double fahrenheit = celsiusTemp.Celsius * 9 / 5 + 32;
        return new FahrenheitTemperature(fahrenheit);
    }

    public static implicit operator KelvinTemperature(Temperature celsiusTemp)
    {
        double kelvin = celsiusTemp.Celsius + 273.15;
        return new KelvinTemperature(kelvin);
    }
}

class FahrenheitTemperature
{
    public double Fahrenheit { get; set; }

    public FahrenheitTemperature(double fahrenheit)
    {
        Fahrenheit = fahrenheit;
    }
}

class KelvinTemperature
{
    public double Kelvin { get; set; }

    public KelvinTemperature(double kelvin)
    {
        Kelvin = kelvin;
    }
}

class Program
{
    static void Main()
    {
        Temperature celsiusTemp = new Temperature(20);
        Console.WriteLine($"Temp in celsius: {celsiusTemp.Celsius}");

        FahrenheitTemperature fahrenheitTemp = celsiusTemp;
        Console.WriteLine($"Temp in fahrenheit: {fahrenheitTemp.Fahrenheit}");

        KelvinTemperature kelvinTemp = celsiusTemp;
        Console.WriteLine($"Temp in kelvin: {kelvinTemp.Kelvin}");
    }
}