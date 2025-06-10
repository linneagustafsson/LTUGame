
using LtuGame.ConsoleGame.Extensions;
using LtuGame.LimitedList;
using System.Runtime.CompilerServices;
using LtuGame.LimitedList;
internal class ConsoleUI
{
    // This class is responsible for handling console input and output for the game.
    // It abstracts the drawing of the map and the retrieval of user input.
    private static MessageLog<string> _messageLog = new(6);

    internal static void AddMessage(string message) => _messageLog.Add(message);
    internal static void PrintLog()
    {
        _messageLog.Print(m=> Console.WriteLine(m + new string (' ', Console.WindowWidth - m.Length)));// Prints each message in the log to the console
        //_messageLog.Print(HowToPrint); // Prints an empty line after the log messages
        //_messageLog.Print(x => HowToPrint(x));
    }

    private static void HowToPrint(string message)
    { 
        Console.WriteLine(message);
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
                IDrawable drawable = map.CreatureAt(cell)
                                                                    ?? cell.Items.FirstOrDefault() as IDrawable
                                                                    ?? cell;
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
       Console.CursorVisible= false; // hide the cursor for a cleaner ui = slutar fladdra när vi ritar om konsolen
       Console.SetCursorPosition(0, 0); // set the cursor to the top left corner of the console

    }

    internal static void PrintStats(string stats)
    {
        Console.ForegroundColor = ConsoleColor.Cyan; // Set the color for stats
        Console.WriteLine(stats); // Print the stats to the console
        Console.ForegroundColor = ConsoleColor.White; // Reset the color to white after printing stats
    }
}


  
