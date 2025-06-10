
using LtuGame.ConsoleGame.Extensions;
using LtuGame.LimitedList;
using System.Runtime.CompilerServices;

internal class ConsoleUI
{
    // This class is responsible for handling console input and output for the game.
    // It abstracts the drawing of the map and the retrieval of user input.
    private static MessageLog<string> _messageLog = new(6);

    internal static void AddMessage(string message) => _messageLog.Add(message);
    internal static void PrintLog()
    {
        _messageLog.Print(m=> Console.WriteLine(m));// Prints each message in the log to the console
        //_messageLog.Print(HowToPrint); // Prints an empty line after the log messages
        //_messageLog.Print(x => HowToPrint(x));
    }

    private static void HowToPrint(string message)
    { 
        Console.WriteLine();
    }
    internal static void Draw(IMap map) 
    {

     for (int y = 0; y < map.Height; y++)
     {
            for (int x = 0; x < map.Width; x++)
            {

                Cell? cell = map.GetCell(y, x);
                ArgumentNullException.ThrowIfNull(cell, nameof(cell));

                // Use the cell's drawable representation, prioritizing creatures over items
                IDrawable drawable = map.Creatures.CreatureAt(cell)// Use the creature at the cell if present
                                                             ?? cell;// Fallback to the cell itself if no creature or item is present

                foreach (Creature creature in map.Creatures)
                {
                    if (creature.Cell == drawable)
                        drawable = creature; // If the cell contains a creature, use the creature for drawing
                }
                Console.ForegroundColor = drawable.Color;
                Console.Write(drawable.Symbol);
            }
            Console.WriteLine();
     }

        Console.ResetColor();
    }

    internal static ConsoleKey GetKey() => Console.ReadKey(intercept: true).Key;

    internal static void Clear()
    {
        Console.CursorVisible = false; // Hide the cursor for a cleaner UI = slutar fladdra när vi ritar om konsolen
        Console.SetCursorPosition(0, 0); // Set the cursor to the top left corner of the console

    }
}


  
