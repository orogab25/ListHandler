using System;
using System.Collections.Generic;

namespace Basic
{
    class Program
    {
        static void Main(string[] args)
        {
            menu();
        }

        static void menu()
        {
            ListHandler<string> listHandler = new ListHandler<string>(10, 25, 25, 25);

            Console.WriteLine("Please enter the number of the task:");
            Console.WriteLine("1.Write to file\n2.Read from file\n3.Print list");
            Console.Write("Choice: ");
            int choice;
            bool result = Int32.TryParse(Console.ReadLine(),out choice);

            if (result)
            {
                switch (choice)
                {
                    case 1:
                        listHandler.writeToFile("list.txt");
                        Console.WriteLine("Writing was successful!");
                        break;
                    case 2:
                        listHandler.readFromFile("list.txt");
                        Console.WriteLine("Reading was successful!");
                        break;
                    case 3:
                        listHandler.printList();
                        break;
                    default:
                        Console.WriteLine("Wrong number!");
                        break;
                }
            }
            else
            {
                Console.WriteLine("The character you entered is not a number!");
            }
        }
    }
}
