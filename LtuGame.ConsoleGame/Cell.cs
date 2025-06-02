internal class Cell
{

    public string Symbol => ". "; // Default symbol for the cell, can be overridden by derived classes

    public ConsoleColor Color { get; } // Default color for the cell, can be overridden by derived classes
    public Cell()// Constructor to initialize the cell
    {
        Color = ConsoleColor.Red; // Default color set to Red

    }
}