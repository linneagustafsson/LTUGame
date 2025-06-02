internal class Player : Creature // Represents the player in the game
{
    public Player(Cell cell) : base(cell, "P") 
    {
        Color = ConsoleColor.White;
    }
    
}