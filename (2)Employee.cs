public class Employee
{
    public double Salary { get; set; }
    public virtual double CalculateSalary()
    {
        return Salary;
    }
}

public class FullTimeEmployee : Employee
{
    public override double CalculateSalary()
    {
        return Salary + 1000;
    }
}

public class PartTimeEmployee : Employee
{
    public override double CalculateSalary()
    {
        return Salary - 500;
    }
}

public class Program
{
    public static void Main()
    {
        FullTimeEmployee fullTimeEmployee = new FullTimeEmployee { Salary = 2000 };
        PartTimeEmployee partTimeEmployee = new PartTimeEmployee { Salary = 1000 };

        Console.WriteLine($"Full time employee salary: {fullTimeEmployee.CalculateSalary()}");
        Console.WriteLine($"Part time employee salary: {partTimeEmployee.CalculateSalary()}");
    }
}