using System;

class RABBYT
{
    //RABBYT STATS
    public string Name { get; set; }
    public int Hunger { get; set; }
    public int Happiness { get; set; }

    private const int MaxHunger = 10;
    private const int MaxHappiness = 10;

    //SURVIVED YEARS
    public int YearsSurvived { get; private set; }

    //NEW RABBYT
    public RABBYT(string name)
    {
        Name = name;
        //RABBYT STARTS FULL
        Hunger = 0;
        //RABBYT STARTS HAPPY
        Happiness = MaxHappiness;
        //START AT 0 YEARS
        YearsSurvived = 0;
    }

    //FEED RABBYT
    public void Feed()
    {
        //FEEDING RABBYT LOWERS HUNGER
        Hunger -= 3;
        if (Hunger < 0) Hunger = 0;
        Console.WriteLine($"Yay, {Name} has been fed!");
    }

    //PLAY WITH RABBYT
    public void Play()
    {
        //PLAYING INCREASES RABBYT'S HAPPINESS
        Happiness += 2;
        if (Happiness > MaxHappiness) Happiness = MaxHappiness;

        //PLAYING MAKES RABBYT HUNGRY
        Hunger += 1;
        if (Hunger > MaxHunger) Hunger = MaxHunger;

        Console.WriteLine($"{Name} had lots of fun playing!");
    }

    //EACH YEAR RABBYT GETS MORE HUNGRY AND LOSES HAPPINESS
    public void Live()
    {
        //INCREASE YEAR COUNTER
        YearsSurvived++;

        //RABBYT GETS MORE HUNGY OVER TIME
        Hunger += 1;
        if (Hunger > MaxHunger) Hunger = MaxHunger;

        //HUNGER MAKES RABBYT SAD
        if (Hunger >= 7)
        {
            Happiness -= 1;
            if (Happiness < 0) Happiness = 0;
        }
    }

    //RABBYT ASCII CHANGES ON MOOD
    private void ShowRABBYT()
    {
        if (Happiness >= 8)
        {
            Console.WriteLine(" (\\_/)");
            Console.WriteLine(" ( ^.^ )");
            Console.WriteLine(" (> <)");
        }
        else if (Happiness >= 4)
        {
            Console.WriteLine(" (\\_/)");
            Console.WriteLine(" ( -.- )");
            Console.WriteLine(" (> <)");
        }
        else
        {
            Console.WriteLine(" (\\_/)");
            Console.WriteLine(" ( T_T )");
            Console.WriteLine(" (> <)");
        }
    }

    //SHOW RABBYT'S STATS
    public void ShowStatus()
    {
        Console.WriteLine($"\n{Name}'s Stats:");
        Console.WriteLine($"Hunger: {Hunger}/{MaxHunger}");
        Console.WriteLine($"Happiness: {Happiness}/{MaxHappiness}");
        Console.WriteLine($"Age: {YearsSurvived}");
        ShowRABBYT();
    }

    //CHECK IF RABBYT STILL ALIVE, RETURN FALSE IF GAME OVER
    public bool IsAlive()
    {
        if (Hunger >= MaxHunger)
        {
            Console.WriteLine($"Oh, no! {Name} got too hungry and hopped away...");
            Console.WriteLine($"Congratulations! {Name} lived {YearsSurvived} happy years!");
            return false;
        }
        if (Happiness <= 0)
        {
            Console.WriteLine($"Oh... {Name} became too sad and ran away...");
            Console.WriteLine($"Congratulations! {Name} lived {YearsSurvived} happy years!");
            return false;
        }
        return true;
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("A little RABBYT hops into your terminal...");
        Console.Write("What is your RABBYT's name? ");
        
        //FALLBACK IF NULL
        string rabbytName = Console.ReadLine() ?? "RABBYT";  

        RABBYT rabbyt = new RABBYT(rabbytName);

        while (true)
        {
            rabbyt.ShowStatus();

            //CHECK IF GAME OVER BEFORE NEXT YEAR
            if (!rabbyt.IsAlive())
            {
                break;
            }

            Console.WriteLine("\nWhat do you want to do?");
            Console.WriteLine("[1] Feed");
            Console.WriteLine("[2] Play");
            Console.WriteLine("[3] Quit");
            

            //FALLBACK TO QUIT IF NULL
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
                Console.WriteLine($"Goodbye!");
                break;
            }
            else
            {
                Console.WriteLine("Invalid choice.");
            }

            //END TURN, INCREASE HUNGER, HAPPINESS MAY DROP
            rabbyt.Live(); 
        }
    }
}
