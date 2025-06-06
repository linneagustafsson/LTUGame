using LtuGame.ConsoleGame;
using LtuGame.ConsoleGame.GameWorld;

internal class Cell : IDrawable
{

    public string Symbol => ". ";  

    public ConsoleColor Color { get; } 

    public Position Position { get;  }

    public List<Item> Items { get; } 
    // Represents a cell in the game world, which can contain items and has a position

    public Cell(Position position)
    {
        Color = ConsoleColor.Red;
        Position = position;
        Items = new List<Item>();
    }
}