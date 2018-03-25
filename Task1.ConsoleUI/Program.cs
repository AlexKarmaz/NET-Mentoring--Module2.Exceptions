using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            string enteredString = "";

            Console.WriteLine("Enter your strings(To exit enter\"Exit\"):");

            while (enteredString != "Exit")
            {
                enteredString = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(enteredString))
                {
                    Console.WriteLine("You have entered empty string!");
                    continue;
                }
                if (enteredString != "Exit")
                {
                    Console.WriteLine(enteredString[0]);
                }
            }
        }
    }
}
