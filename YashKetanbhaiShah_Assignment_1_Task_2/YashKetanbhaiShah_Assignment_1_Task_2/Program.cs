/*
 * Author: Shah Yash Ketanbhai
 * Date: 29th January, 2025
 * Project: Basketball budget tracker
 * Description: We have to create a program to track the Joe's spending on his fav game raptors. 
 * The  program will collect all the data on the numbers of tickets which joe has purchased for 
 * each seat type and calcuate total expences and will determine the average cost per game.
 * <Fill>
*/

using System;

class BasketballBudgetTracker
{
 class Program
    {
        // I have used enumeration for the different types of tickets
        enum TicketType { Purple, Green, Blue }

        static void Main(string[] args)
        {
            // Here we have constants representing the prices of all the tickets which are predefine
            const double purplePrice = 50, greenPrice = 80, bluePrice = 100;
            // Here we will store the number of tickets which the  user had purchased
            double purpleCount = 0, greenCount = 0, blueCount = 0;

            Console.WriteLine("---------- Welcome to Basketball Budget Tracker! ----------");

            // This will help to collect the input of the purchased tickets from the user type
            purpleCount = GetTicketCount(TicketType.Purple);
            greenCount = GetTicketCount(TicketType.Green);
            blueCount = GetTicketCount(TicketType.Blue);

            // Here it will calculate the total money spend by the user on the tickets
            double totalSpent = (purpleCount * purplePrice) + (greenCount * greenPrice) + (blueCount * bluePrice);
            
            // Here we will be calcuatate the total numbers of tickets used had purchased
            double totalTickets = purpleCount + greenCount + blueCount;
            
            // Here we will calculate the average of ticket price with ensuring the division by zero is avoided
            double averagePrice = totalTickets > 0 ? totalSpent / totalTickets : 0;

            // We are displaying the summary of the tickets which the user has purchased
            Console.WriteLine("\n=======================================");
            Console.WriteLine(" Summary of Joe's Ticket Purchases ");
            Console.WriteLine("=======================================");
            Console.WriteLine($"Total Purple Tickets: {purpleCount}");
            Console.WriteLine($"Total Green Tickets: {greenCount}");
            Console.WriteLine($"Total Blue Tickets: {blueCount}");
            Console.WriteLine($"Total Amount Spent: ${totalSpent:F2}");
            Console.WriteLine($"Average Ticket Price: ${averagePrice:F2}");
            Console.WriteLine("=======================================");

            // If the user's spending exceeds more than $500 we will display warning message
            if (totalSpent > 500)
            {
                Console.WriteLine("Warning: You have spent over $500 on tickets!");
            }

            // If the user's spending exceeds less or equal to $500 we will display warning message
            if (totalSpent <= 500)
            {
                Console.WriteLine("You have spent less than $$500 on tickets!");
            }

            // If the use had purchased no tickets
            if (totalTickets == 0)
            {
                Console.WriteLine("No tickets were purchased.");
            }
        }

        // Here we have used the method to collect and validaet the user's input for the ticket count
        static double GetTicketCount(TicketType ticketType)
        {
            double count = 0;
            while (true)
            {
                Console.Write($"Please enter the number of {ticketType} tickets bought: ");
                // Here we have validate if the user enters non-negative number or any alphabets
                if (double.TryParse(Console.ReadLine(), out count) && count >= 0)
                    break;
                Console.WriteLine("Invalid input. Please enter a non-negative number.");
            }
            return count;
        }
    }
}