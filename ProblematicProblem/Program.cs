using System;
using System.Collections.Generic;
using System.Threading;

namespace ProblematicProblem
{
    class Program
    {
        static Random rng = new Random(); 

        static bool cont = true;

        static List<string> activities = new List<string>()
        {
            "Movies", "Paintball", "Bowling", "Lazer Tag",
            "LAN Party", "Hiking", "Axe Throwing", "Wine Tasting"
        };

        static void Main(string[] args)
        {
            Console.Write("Hello, welcome to the random activity generator! \nWould you like to generate a random activity? yes/no: ");
            string contInput = GetValidInput(new List<string> { "yes", "no" });
            cont = contInput == "yes";  // Correct parsing of "yes" or "no"

            if (!cont) return; 

            Console.WriteLine();
            Console.Write("We are going to need your information first! What is your name? ");
            string userName = Console.ReadLine();

            Console.WriteLine();
            Console.Write("What is your age? ");
            int userAge = GetValidAge();

            Console.WriteLine();
            Console.Write("Would you like to see the current list of activities? Sure/No thanks: ");
            string seeListInput = GetValidInput(new List<string> { "sure", "no thanks" });
            bool seeList = seeListInput == "sure";

            if (seeList)
            {
                foreach (string activity in activities)
                {
                    Console.Write($"{activity} ");
                    Thread.Sleep(250);
                }

                Console.WriteLine();
                Console.Write("Would you like to add any activities before we generate one? yes/no: ");
                string addToListInput = GetValidInput(new List<string> { "yes", "no" });
                bool addToList = addToListInput == "yes";

                Console.WriteLine();
                while (addToList)
                {
                    Console.Write("What would you like to add? ");
                    string userAddition = Console.ReadLine();
                    activities.Add(userAddition);

                    foreach (string activity in activities)
                    {
                        Console.Write($"{activity} ");
                        Thread.Sleep(250);
                    }

                    Console.WriteLine();
                    Console.Write("Would you like to add more? yes/no: ");
                    addToListInput = GetValidInput(new List<string> { "yes", "no" });
                    addToList = addToListInput == "yes";
                }
            }

            while (cont)
            {
                int randomNumber = rng.Next(activities.Count);
                string randomActivity = activities[randomNumber];

                Console.Write("Connecting to the database");
                for (int i = 0; i < 10; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(500);
                }

                Console.WriteLine();
                Console.Write("Choosing your random activity");
                for (int i = 0; i < 9; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(500);
                }

                Console.WriteLine();

                if (userAge < 21 && randomActivity == "Wine Tasting")
                {
                    Console.WriteLine($"Oh no! Looks like you are too young to do {randomActivity}.");
                    Console.WriteLine("Picking something else!");
                    activities.Remove(randomActivity);
                    randomNumber = rng.Next(activities.Count);
                    randomActivity = activities[randomNumber];
                }

                Console.Write($"Ah got it! {userName}, your random activity is: {randomActivity}! Is this ok or do you want to grab another activity? Keep/Redo: ");
                string userChoice = GetValidInput(new List<string> { "keep", "redo" });
                cont = userChoice == "redo";
            }
        }

        static string GetValidInput(List<string> validOptions)
        {
            string input = Console.ReadLine().ToLower();
            while (!validOptions.Contains(input))
            {
                Console.WriteLine($"Please enter one of the following: {string.Join("/", validOptions)}");
                input = Console.ReadLine().ToLower();
            }
            return input;
        }
        
        static int GetValidAge()
        {
            int age;
            Console.WriteLine("Please enter your age as a valid number:");
            string input = Console.ReadLine();
            
            while (!int.TryParse(input, out age) || age < 0)
            {
                Console.WriteLine("Invalid input. Please enter a valid positive number for age:");
                input = Console.ReadLine();
            }

            return age;
        }
    }
}

