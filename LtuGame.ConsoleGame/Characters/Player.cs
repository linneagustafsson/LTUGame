using LtuGame.ConsoleGame;
using LtuGame.LimitedList;

internal class Player : Creature // Represents the player in the game
{
    public LimitedList<Item> BackPack { get; }
    public Player(Cell cell) : base(cell, "P", maxHealth: 100) 
    {
        Color = ConsoleColor.White;
        BackPack = new LimitedList<Item>(3); // Initialize backpack with a maximum of 10 items
        Damage = 100;
    }
    
}