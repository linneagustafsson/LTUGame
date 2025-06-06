using LtuGame.LimitedList;

internal class Player : Creature // Represents the player in the game
{
    public LimitedList<Item> BackPack { get; }
    public Player(Cell cell) : base(cell, "P") 
    {
        Color = ConsoleColor.White;
    }
    
}