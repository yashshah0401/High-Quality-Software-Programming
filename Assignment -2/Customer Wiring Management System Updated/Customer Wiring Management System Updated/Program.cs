/*
 * Author: Shah Yash Ketanbhai
 * Date: 15th February, 2025
 * Project: Customer Wiring Management System
 * Description: The Customer Wiring Management System is a C# code that will collect the customers details, 
 * classification of their building  and determining the appropriate wiring tasks. This code is created by using  
 * OOP concepts which include encapsulation, constructors, methods and enumerations.
 * <Fill>
*/

using System;
using System.Collections.Generic;

// Here we have defined an interface for customer functionality
interface ICustomer
{
    string Name { get; set; }
    BuildingType StructureType { get; set; }
    double Size { get; set; }
    double LightBulbs { get; set; }
    double Outlets { get; set; }
    string CreditCard { get; set; }
    void DisplayCustomerInfo();
    void PerformWiringTasks();
}

// Enum for building type
enum BuildingType
{
    House,
    Barn,
    Garage
}

// Abstract base class implementing ICustomer
abstract class BaseCustomer : ICustomer
{
    public string Name { get; set; }
    public BuildingType StructureType { get; set; }
    public double Size { get; set; }
    public double LightBulbs { get; set; }
    public double Outlets { get; set; }
    public string CreditCard { get; set; }

    public BaseCustomer(string name, BuildingType type, double size, double lightBulbs, double outlets, string creditCard)
    {
        Name = name;
        StructureType = type;
        Size = size;
        LightBulbs = lightBulbs;
        Outlets = outlets;
        CreditCard = MaskCreditCard(creditCard);
    }

    private string MaskCreditCard(string cardNumber)
    {
        return cardNumber.Substring(0, 4) + " XXXX XXXX " + cardNumber.Substring(12, 4);
    }

    public virtual void DisplayCustomerInfo()
    {
        Console.WriteLine($"{Name} | {StructureType} | {Size} sq.ft | {LightBulbs} bulbs | {Outlets} outlets | Card: {CreditCard}");
    }

    public abstract void PerformWiringTasks();
}

// Derived class for different buildings
class Customer : BaseCustomer
{
    public Customer(string name, BuildingType type, double size, double lightBulbs, double outlets, string creditCard)
        : base(name, type, size, lightBulbs, outlets, creditCard) { }

    public override void PerformWiringTasks()
    {
        Console.WriteLine($"Creating wiring schema for {StructureType}...");
        Console.WriteLine("Purchasing necessary parts...");

        switch (StructureType)
        {
            case BuildingType.House:
                Console.WriteLine("Installing fire alarms...");
                break;
            case BuildingType.Barn:
                Console.WriteLine("Wiring milking equipment...");
                break;
            case BuildingType.Garage:
                Console.WriteLine("Installing automatic doors...");
                break;
        }
    }
}
class Program
{
    static void Main()
    {
        List<ICustomer> customers = new List<ICustomer>();
        string continueInput;

        do
        {
            Console.Write("Enter customer name: ");
            string name = Console.ReadLine();

            Console.Write("Enter building type (House, Barn, Garage): ");
            BuildingType type;
            while (!Enum.TryParse(Console.ReadLine(), true, out type))
            {
                Console.Write("Invalid input. Enter building type (House, Barn, Garage): ");
            }

            double size;
            do
            {
                Console.Write("Enter building size (1000 - 50000 sq.ft): ");
            } while (!double.TryParse(Console.ReadLine(), out size) || size < 1000 || size > 50000);

            double bulbs;
            do
            {
                Console.Write("Enter number of light bulbs (max 20): ");
            } while (!double.TryParse(Console.ReadLine(), out bulbs) || bulbs < 0 || bulbs > 20);

            double outlets;
            do
            {
                Console.Write("Enter number of outlets (max 50): ");
            } while (!double.TryParse(Console.ReadLine(), out outlets) || outlets < 0 || outlets > 50);

            string creditCard;
            do
            {
                Console.Write("Enter 16-digit credit card number: ");
                creditCard = Console.ReadLine();
            } while (creditCard.Length != 16 || !long.TryParse(creditCard, out _));

            // Create a new customer
            ICustomer newCustomer = new Customer(name, type, size, bulbs, outlets, creditCard);
            customers.Add(newCustomer);

            // Perform wiring tasks
            newCustomer.PerformWiringTasks();

            Console.Write("Do you want to enter another customer? (yes/no): ");
            continueInput = Console.ReadLine().ToLower();

        } while (continueInput == "yes");

        // Display all customers
        Console.WriteLine("\nCustomer Summary:");
        Console.WriteLine("------------------------------------------------------------");
        foreach (var customer in customers)
        {
            customer.DisplayCustomerInfo();
        }
    }
}
