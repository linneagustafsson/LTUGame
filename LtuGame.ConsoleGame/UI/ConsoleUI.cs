
using LtuGame.ConsoleGame.Extensions;

internal class ConsoleUI
{
    // This class is responsible for handling console input and output for the game.
    // It abstracts the drawing of the map and the retrieval of user input.
    internal static void Draw(IMap map) 
    {

     for (int y = 0; y < map.Height; y++)
     {
            for (int x = 0; x < map.Width; x++)
            {

                Cell? cell = map.GetCell(y, x);
                ArgumentNullException.ThrowIfNull(cell, nameof(cell));

                // Use the cell's drawable representation, prioritizing creatures over items
                IDrawable drawable = map.Creatures.CreatureAt(cell)
                            ??cell.Items.FirstOrDefault() as IDrawable
                            ?? cell;

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


}


  
