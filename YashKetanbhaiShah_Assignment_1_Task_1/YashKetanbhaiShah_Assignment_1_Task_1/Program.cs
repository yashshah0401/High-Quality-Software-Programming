/*
 * Author: Shah Yash Ketanbhai
 * Date: 27th January, 2025
 * Project: Business Trip Calculation for Carlo
 * Description: This project is used for the travel expences which can be viewed by the Carlo, who is living in the city Toronto
 * and is frequently traveling to Calgary, Montreal and Vancouver for his business trips. Each of the trips require him a round trip
 * to Toronto and before travelling to the next city. This project will let him calcuate the total money he is spending on these trips
 * and will determine the averaage cost per trip.
 * <Fill>
*/

using System;

namespace Assignment1Task1
{
    class Program
    {
        enum Destination { Calgary, Vancouver, Montreal }

        static void Main(string[] args)
        {
            // Here we have user all the staic amount for all the cities
            const double priceToCalgary = 1350;
            const double priceToVancouver = 1500;
            const double priceToMontreal = 575;

            Console.WriteLine("---------- Welcome to Carlo's Trip Expense Calculator! ----------\n");

            // Here we will get the infomration of trips from the user
            double tripsToCalgary = GetTripCount(Destination.Calgary);
            double tripsToVancouver = GetTripCount(Destination.Vancouver);
            double tripsToMontreal = GetTripCount(Destination.Montreal);

            // Here we willn calculate total amount and averages
            double totalSpend = (tripsToCalgary * priceToCalgary) + (tripsToVancouver * priceToVancouver) + (tripsToMontreal * priceToMontreal);
            double totalTrips = tripsToCalgary + tripsToVancouver + tripsToMontreal;
            double averagePrice = totalTrips > 0 ? totalSpend / totalTrips : 0;

            // Here we will display the result
            Console.WriteLine("\nSummary of Carlo's Trips:");
            Console.WriteLine("-------------------------");
            Console.WriteLine($"Total Money Spent by Carlo for all the round trips is: $ {totalSpend:F2}");
            Console.WriteLine($"Average price per trip: $ {averagePrice:F2}");
            Console.WriteLine("-------------------------");
            Console.WriteLine("Thank you for using Carlo's Trip Expense Calculator!");

            // If the user's spending exceeds $5000 we will display this message
            if (totalSpend > 5000)
            {
                Console.WriteLine("Warning: You have spent over $5000 on trips!");
            }

            // If the user's spending is less than or equal to $5000 we will display this message
            if (totalSpend <= 5000)
            {
                Console.WriteLine("You have spent over less than $5000 on trips!");
            }

            // If the user's spending is less than $0 we will display this message
            if (totalTrips == 0)
            {
                Console.WriteLine("No trips were taken.");
            }
        }

        static double GetTripCount(Destination destination)
        {
            double count = 0;
            while (true)
            {
                Console.Write($"Please enter the number of return trips to {destination}: ");
                if (double.TryParse(Console.ReadLine(), out count) && count >= 0)
                    break;
                Console.WriteLine("Invalid input. Please enter a non-negative number.");
            }
            return count;
        }
    }
}
