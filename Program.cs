using System;

class RABBYT
{
    public string Name { get; set; }
    public int Hunger { get; set; }
    public int Happiness { get; set; }

    private const int MaxHunger = 10;
    private const int MaxHappiness = 10;

    public int YearsSurvived { get; private set; }

    public RABBYT(string name)
    {
        Name = name;
        Hunger = 0;
        Happiness = MaxHappiness;
        YearsSurvived = 0;
    }

    public void Feed()
    {
        Hunger -= 3;
        if (Hunger < 0) Hunger = 0;

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Yay, {Name} has been fed!");
        Console.ResetColor();
    }

    public void Play()
    {
        Happiness += 2;
        if (Happiness > MaxHappiness) Happiness = MaxHappiness;

        Hunger += 1;
        if (Hunger > MaxHunger) Hunger = MaxHunger;

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"{Name} had lots of fun playing!");
        Console.ResetColor();
    }

    public void Live()
    {
        YearsSurvived++;
        Hunger += 1;
        if (Hunger > MaxHunger) Hunger = MaxHunger;

        if (Hunger >= 7)
        {
            Happiness -= 1;
            if (Happiness < 0) Happiness = 0;
        }
    }

    private void ShowRABBYT()
    {
        if (Happiness >= 8)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(" (\\_/)");
            Console.WriteLine(" ( ^.^ )");
            Console.WriteLine(" (> <)");
        }
        else if (Happiness >= 4)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(" (\\_/)");
            Console.WriteLine(" ( -.- )");
            Console.WriteLine(" (> <)");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(" (\\_/)");
            Console.WriteLine(" ( T_T )");
            Console.WriteLine(" (> <)");
        }
        Console.ResetColor();
    }

    public void ShowStatus()
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine($"\n{Name}'s Stats:");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("Hunger: ");
        Console.ResetColor();
        Console.WriteLine($"{Hunger}/{MaxHunger}");

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("Happiness: ");
        Console.ResetColor();
        Console.WriteLine($"{Happiness}/{MaxHappiness}");

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("Age: ");
        Console.ResetColor();
        Console.WriteLine($"{YearsSurvived}");

        ShowRABBYT();
    }

    public bool IsAlive()
    {
        if (Hunger >= MaxHunger)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Oh, no! {Name} got too hungry and hopped away...");
            Console.WriteLine($"Congratulations! {Name} lived {YearsSurvived} happy years!");
            Console.ResetColor();
            return false;
        }
        if (Happiness <= 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Oh... {Name} became too sad and ran away...");
            Console.WriteLine($"Congratulations! {Name} lived {YearsSurvived} happy years!");
            Console.ResetColor();
            return false;
        }
        return true;
    }
}

class Program
{
    static void Main()
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("══════════════════════════════════════════");
        Console.WriteLine("  A little RABBYT hops into your terminal ");
        Console.WriteLine("══════════════════════════════════════════");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("What is your RABBYT's name? ");
        Console.ResetColor();

        string rabbytName = Console.ReadLine() ?? "RABBYT";  
        RABBYT rabbyt = new RABBYT(rabbytName);

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
            Console.WriteLine("[3] Quit");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Choose an option: ");
            Console.ResetColor();

            string choice = Console.ReadLine() ?? "3";

            if (choice == "1")
            {
                rabbyt.Feed();
            }
            else if (choice == "2")
            {
                rabbyt.Play();
            }
            else if (choice == "3")
            {
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
