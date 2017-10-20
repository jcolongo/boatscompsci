// Imports for C#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop_Program
{
    // Class inits the shop and variables needed.
    public class Shop
    {
        string selection;

        bool redo;
        bool select;

        int balance;
        int chocolate;
        int crisps;
        int coke;
        int milk;
        int bread;
        int minimumCost;

        // Defines items and prices.
        public Shop()
        {
            Random bal = new Random(); // Creates a new random number.
            balance = bal.Next(5, 20); // Defines the integer, balance, to a random number from 5 to 20.
            Console.WriteLine("Welcome to the shop. Your balance is: " + balance + ".");
            crisps = bal.Next(2, 5); // Defines the integer, crisps, to a random number from 2 to 5.
            coke = bal.Next(2, 4); // Defines the integer, coke, to a random number from 2 to 4. 
            milk = bal.Next(3, 4); // Does the same as above. ^
            bread = bal.Next(1, 3);
            chocolate = bal.Next(5, 20); // Random integers end.
            calculateMinimum(); // Runs the void calculateMinimum(), calculating the smallest price point.
            Select(); // Runs the void Select(), the void to prompt the user to select an option.
            runAgain(); // Runs the void runAgain(), so when getting the input from Select(), it moves on to runAgain(), which
                        // prompts the user if they want to run Select() again.
        }

        public void calculateMinimum()
        {
            // Works out the minimum cost.
            var costList = new[] { crisps, coke, milk, bread, chocolate };
            minimumCost = costList.Min();
        }


        public void Select()
        {

            // select = false; makes it so when later on select = true, runAgain() can happen.
            select = false;
            while (!select)
            {
                Console.WriteLine("What do you want to buy? Options are:\n1. Pack of crisps (" + crisps + ")\n2. Can of Coke (" + coke + ")\n3. Milk (" + milk + ")\n4. Loaf of bread (" + bread + ")\n5. Chocolate (" + chocolate + ")\n6. Leave the shop.");
                // Above lists what the user can buy.
                selection = Console.ReadLine(); // Reads the console and stores it to a variable.
                switch (selection)
                { // Creates a switch for the variable selection
                    case ("crisps"): // Do this if the user selects crisps or 1.
                    case ("1"):
                        purchase(crisps);
                        break;

                    case ("coke"): // Do this if the user selects coke or 2.
                    case ("2"):
                        purchase(coke);
                        break;

                    case ("milk"): // Do this if the user selects milk or 3.
                    case ("3"):
                        purchase(milk);
                        break;

                    case ("bread"): // Do this if the user selects bread or 4.
                    case ("4"):
                        purchase(bread);
                        break;

                    case ("chocolate"): // Do this if the user selects chocolate or 5.
                    case ("5"):
                        purchase(chocolate);
                        break;

                    case ("leave"): // Do this if the user wants to leave.
                    case ("6"):
                        Console.WriteLine("Thanks for visiting our shop! (Press enter to close)");

                        Console.ReadLine();
                        Environment.Exit(0);
                        break;

                    default: // Defaults to this if the user does not select a vaild option. 
                        Console.WriteLine("Please choose a vaild option!");
                        break;
                }
            }
        }

        public void runAgain()
        { // Prompts to wish the user if they wish to buy another item (if the have the balance to do so.)
            Console.WriteLine("Would you like to buy another item? (yes/no)"); // Writes to console, prompting them if they wish to run Select() again.
            string replay = Console.ReadLine(); // Stores the input from console to a string named replay
            if (replay == "yes")
            { // Checks if replay is yes.
                if (balance >= minimumCost)
                { // If the user has said yes, then this will check if they actually have enough for another item.
                    Select(); // Runs select()
                    runAgain(); // After Select() runs and select = true, runAgain() will then run.
                }
                else
                { // If the check found that the user could not buy anything else, then this will run.
                    Console.WriteLine("Sorry, but you don't have enough balance.\nThanks for visiting our shop! (Press enter to close)");
                    Console.ReadLine(); // Waits for enter to be pressed before proceeding.
                    Environment.Exit(0); // Kills the program.
                }
            }
            else
            {
                if (replay == "no")
                { // If the user enters no, it kills the program.
                    Console.WriteLine("Thanks for visiting our shop! (Enter to close)");
                    Console.ReadLine();
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Invalid option!"); // If the user enters anything but yes or no, this occurs and runs runAgain() again.
                    runAgain();
                }
            }
        }

        public void purchase(int cost)
        {
            if (balance >= cost)
            { // Checks if the current balance is more or equal to the item wanted.
                balance = balance - cost; // Updates balance.
                Console.WriteLine("Thanks for your purchase! Your balance is now: " + balance + "."); // Tells the user what thier balance is.
                select = true; // This allows runAgain() to run to prompt the user if they want another item.
            }
            else
            {
                Console.WriteLine("You don't have enough money for that!"); // Tells the user they don't have enough for that item.
            }
        }

        public static void Main()
        {
            Shop shop = new Shop(); // Runs the shop:)
        }
    }
}
