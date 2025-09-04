//RABBYT (VIRTUAL PET GAME)

RABBYT is a console-based virtual pet game built with C# and .NET.

This project was created to strengthen my skills in C# fundamentals, object-oriented programming, persistence, and clean code structure. It highlights my ability to design encapsulated systems, manage evolving state over time and implement data persistence with JSON.

//PROJECT OVERVIEW

The goal of RABBYT is to take care of a digital rabbit pet, inspired by hand-held digital pets popular in the 1990's.

Players must keep their RABBYT happy and fed as time passes. Each action advances your pet’s age, and survival depends on balancing hunger, happiness, and rest.

The app demonstrates:  
> Encapsulation and clean object-oriented design.  
> Persistence through JSON save/load functionality.  
> Time simulation (each action advances age by one year).  
> ASCII art for mood representation.  
> Input validation and graceful error handling.  
> Professional project structure (separate `Rabbyt.cs` and `Program.cs`).  

//FEATURES

> Feed - reduces hunger to keep your Rabbyt alive.  
> Play - increases happiness but also increases hunger.  
> Nap - restores happiness, at the cost of extra hunger.  
> Aging - every action advances time by one year.  
> Save & Load - Rabbyt’s state is saved to `rabbyt.json` so you can continue later.  
> Dynamic ASCII Art - shows Rabbyt’s mood based on happiness levels.  
> Game Over Conditions - neglect leads to hunger or sadness, ending the game.  

//TECHNOLOGIES USED
> Language - C#  
> Framework - .NET Console Application  
> Concepts - object-oriented programming, encapsulation, persistence with JSON, input validation  

//HOW TO RUN
> Clone the repository and run the app locally:  
```bash
git clone https://github.com/your-username/rabbyt.git
cd rabbyt
dotnet run
