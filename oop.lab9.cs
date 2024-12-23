using System;
using System.Collections;
using System.Collections.Generic;

interface ITaxCalculator
{
    double CalculateTax();
}

class LandTax : ITaxCalculator
{
    private double value;
    private double rate;

    public LandTax(double value, double rate)
    {
        this.value = value;
        this.rate = rate;
    }

    public double CalculateTax() => value * rate;
}

class CarTax : ITaxCalculator
{
    private double value;
    private double rate;

    public CarTax(double value, double rate)
    {
        this.value = value;
        this.rate = rate;
    }

    public double CalculateTax() => value * rate;
}

class IncomeTax : ITaxCalculator
{
    private double income;
    private double rate;

    public IncomeTax(double income, double rate)
    {
        this.income = income;
        this.rate = rate;
    }

    public double CalculateTax() => income * rate;
}

class Product : IComparable<Product>
{
    public string Name { get; set; }
    public double Weight { get; set; }
    public double Price { get; set; }
    public int Quality { get; set; }

    public int CompareTo(Product other) => Weight.CompareTo(other.Weight);
}

class ProductCollection : IEnumerable<Product>
{
    private List<Product> products = new List<Product>();

    public void Add(Product product) => products.Add(product);

    public IEnumerator<Product> GetEnumerator()
    {
        products.Sort((x, y) => x.Price.CompareTo(y.Price));
        return products.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Завдання 1: Податки");

        ITaxCalculator landTax = new LandTax(100000, 0.01);
        ITaxCalculator carTax = new CarTax(50000, 0.02);
        ITaxCalculator incomeTax = new IncomeTax(70000, 0.15);

        Console.WriteLine($"Податок на землю: {landTax.CalculateTax():0.00} грн");
        Console.WriteLine($"Податок на авто: {carTax.CalculateTax():0.00} грн");
        Console.WriteLine($"Податок на дохід: {incomeTax.CalculateTax():0.00} грн");

        Console.WriteLine("\n====================\nЗавдання 2: Список виробів\n");

        var products = new ProductCollection();
        products.Add(new Product { Name = "Виріб A", Weight = 2.5, Price = 500, Quality = 8 });
        products.Add(new Product { Name = "Виріб B", Weight = 1.2, Price = 300, Quality = 6 });
        products.Add(new Product { Name = "Виріб C", Weight = 3.0, Price = 700, Quality = 9 });

        Console.WriteLine("Сортування за ціною:");
        foreach (var product in products)
        {
            Console.WriteLine($"{product.Name}, Ціна: {product.Price} грн, Вага: {product.Weight} кг, Якість: {product.Quality}");
        }

        Console.WriteLine("\nСортування за вагою:");
        var sortedByWeight = new List<Product>(products);
        sortedByWeight.Sort();
        foreach (var product in sortedByWeight)
        {
            Console.WriteLine($"{product.Name}, Вага: {product.Weight} кг, Ціна: {product.Price} грн");
        }

        Console.ReadKey();
    }
}
