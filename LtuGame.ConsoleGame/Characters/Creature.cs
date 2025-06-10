using System.Diagnostics.CodeAnalysis;

internal abstract class Creature :IDrawable
{
    private Cell _cell; // Backing field for the Cell property
    private int _health;

    public string Symbol { get; } 
    public ConsoleColor Color { get; protected set; } = ConsoleColor.Green;
    
    public int MaxHealth { get; }
    public int Damage { get; protected set; } = 50;
    public bool IsDead => _health <= 0;
   
    public int Health
    {
        get => _health;
        private set => _health = value >= MaxHealth ? MaxHealth : value;
    }
    public Cell Cell
    
    { get => _cell;
        [MemberNotNull(nameof(_cell))] // Ensures _cell is not null when accessed
        
        set 
        { 
        ArgumentNullException.ThrowIfNull(value, nameof(value));
         _cell = value;
        }
       } 
    public Creature(Cell cell, string symbol, int maxHealth=50)
    {
        if (string.IsNullOrWhiteSpace(symbol))
        { throw new ArgumentException("Symbol cannot be null or whitespace.", nameof(symbol)); }

        Cell = cell; // ?? throw new ArgumentNullException(nameof(cell));
        Symbol = symbol;
        MaxHealth = maxHealth;
        Health = maxHealth;
    }
    internal void Attack(Creature player)
    {
        //throw new NotImplementedException();
    }
}
