/*
 * Author: Shah Yash Ketanbhai
 * Date: 15th February, 2025
 * Project: Customer Wiring Management System Updated
 * Description: This code provides an overview of the updated Customer Wiring Management System, 
 * which will help to handle wiring requirements for different types of buildings. The code takes customer details, 
 * processes wiring tasks based on structure types, and ensures secure handling of sensitive information such 
 * as credit card numbers using interface, Enumeration, Abstract Base Class, Concrete Class.
 * <Fill>
*/

using System;
using System.Collections.Generic;

// We have used Enum to define the building type
enum BuildingType
{
    House,
    Barn,
    Garage
}

class Customer
{
    public string Name { get; set; }
    public BuildingType StructureType { get; set; }
    public double Size { get; set; }
    public double LightBulbs { get; set; }
    public double Outlets { get; set; }
    public string CreditCard { get; set; }

    // Here we have use the Constructor
    public Customer(String name, BuildingType type, double size,  double lightBulbs, double outlets, string creditCard)
    {  Name = name; StructureType = type; Size = size; LightBulbs = lightBulbs; Outlets = outlets; CreditCard = MaskCreditCard(creditCard); }// Mask card before storing 

    // Here we will be masking the credit card detials from the customer
    private string MaskCreditCard(string cardNumber)
    {
        return cardNumber.Substring(0,4) + " XXXX XXXX " + cardNumber.Substring(12, 4);
    }

    // Here we have created a method to display the customer details
    public void DisplayCustomerInfo()
    {
        Console.WriteLine($"{Name} | {StructureType} | {Size} sq.ft | {LightBulbs} bulbs | {Outlets} outlets | Card: {CreditCard}");
    }

    // Here we have created a method to perform specific wiring tasks based on structure type
    public void PerformWiringTasks()
    {
        Console.WriteLine($"Creating wiring schema for {StructureType}...");
        Console.WriteLine("Purchasing necessary parts...");

        if (StructureType == BuildingType.House)
        {
            Console.WriteLine("Installing fire alarms...");
        }
        else if (StructureType == BuildingType.Barn)
        {
            Console.WriteLine("Wiring milking equipment...");
        }
        else if (StructureType == BuildingType.Garage)
        {
            Console.WriteLine("Installing automatic doors...");
        }
    }
    class Program
    {
        static void Main()
        {
            List<Customer> customers = new List<Customer>();
            string continueInput;

            do
            {
                // Collect customer details
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

                // Create a new customer and add to list
                Customer newCustomer = new Customer(name, type, size, bulbs, outlets, creditCard);
                customers.Add(newCustomer);

                // Perform wiring tasks
                newCustomer.PerformWiringTasks();

                // Ask if another customer should be added
                Console.Write("Do you want to enter another customer? (yes/no): ");
                continueInput = Console.ReadLine().ToLower();

            } while (continueInput == "yes");

            // Display all customers at the end
            Console.WriteLine("\nCustomer Summary:");
            Console.WriteLine("------------------------------------------------------------");
            foreach (var customer in customers)
            {
                customer.DisplayCustomerInfo();
            }
        }
    }
}

