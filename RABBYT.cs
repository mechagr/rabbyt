//RABBYT (Virtual Pet Game)

using System;
using System.IO;
using System.Text.Json;

public class RABBYT
{
    public string Name { get; set; }
    public int Hunger { get; private set; }
    public int Happiness { get; private set; }
    public int Age { get; private set; }

    public int MaxHunger { get; } = 10;
    public int MaxHappiness { get; } = 10;

    public RABBYT(string name)
    {
        Name = name;
        Hunger = 0;
        Happiness = MaxHappiness;
        Age = 0;
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
        Happiness = Math.Min(Happiness + 2, MaxHappiness);
        Hunger = Math.Min(Hunger + 1, MaxHunger);

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"{Name} had lots of fun playing!");
        Console.ResetColor();
    }

    public void Nap()
    {
        Happiness = Math.Min(Happiness + 3, MaxHappiness);
        Hunger = Math.Min(Hunger + 2, MaxHunger);

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"{Name} took a nice nap and feels refreshed!");
        Console.ResetColor();
    }

    public void Live()
    {
        Age++;
        Hunger = Math.Min(Hunger + 1, MaxHunger);

        if (Hunger >= 7)
            Happiness = Math.Max(Happiness - 1, 0);
    }

    private void ShowRABBYT()
    {
        if (Happiness >= 8)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(" (\\_/) ");
            Console.WriteLine(" ( ^.^ ) ");
            Console.WriteLine(" (> <) ");
        }
        else if (Happiness >= 4)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(" (\\_/) ");
            Console.WriteLine(" ( -.- ) ");
            Console.WriteLine(" (> <) ");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(" (\\_/) ");
            Console.WriteLine(" ( T_T ) ");
            Console.WriteLine(" (> <) ");
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
        Console.WriteLine($"{Age}");

        ShowRABBYT();
    }

    public bool IsAlive()
    {
        if (Hunger >= MaxHunger)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Oh, no! {Name} got too hungry and hopped away...");
            Console.WriteLine($"{Name} lived {Age} years!");
            Console.ResetColor();
            return false;
        }
        if (Happiness <= 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Oh... {Name} became too sad and ran away...");
            Console.WriteLine($"{Name} lived {Age} years!");
            Console.ResetColor();
            return false;
        }
        return true;
    }

    public void SaveGame()
    {
        string json = JsonSerializer.Serialize(this);
        File.WriteAllText("rabbyt.json", json);
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("Game saved!");
        Console.ResetColor();
    }

    public static RABBYT? LoadGame()
    {
        if (File.Exists("rabbyt.json"))
        {
            string json = File.ReadAllText("rabbyt.json");
            return JsonSerializer.Deserialize<RABBYT>(json);
        }
        return null;
    }
}
