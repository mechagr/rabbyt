//RABBYT (Virtual Pet Game)

using System;

class Program
{
    static void Main()
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("=== * RABBYT * ===");
        Console.WriteLine("  A RABBYT hops into your terminal...");
        Console.WriteLine("=== * * * ===");
        Console.ResetColor();

        RABBYT rabbyt;

        RABBYT? loaded = RABBYT.LoadGame();
        if (loaded != null)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Welcome back! {loaded.Name} missed you.");
            Console.ResetColor();
            rabbyt = loaded;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("What is your RABBYT's name? ");
            Console.ResetColor();
            string rabbytName = Console.ReadLine() ?? "RABBYT";
            rabbyt = new RABBYT(rabbytName);
        }

        while (true)
        {
            rabbyt.ShowStatus();

            if (!rabbyt.IsAlive())
                break;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nWhat do you want to do?");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("[1] Feed");
            Console.WriteLine("[2] Play");
            Console.WriteLine("[3] Nap");
            Console.WriteLine("[4] Save & Quit");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Choose an option: ");
            Console.ResetColor();

            string choice = Console.ReadLine() ?? "4";

            if (choice == "1") rabbyt.Feed();
            else if (choice == "2") rabbyt.Play();
            else if (choice == "3") rabbyt.Nap();
            else if (choice == "4")
            {
                rabbyt.SaveGame();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Goodbye!");
                Console.ResetColor();
                break;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid choice.");
                Console.ResetColor();
            }

            rabbyt.Live();
        }
    }
}
