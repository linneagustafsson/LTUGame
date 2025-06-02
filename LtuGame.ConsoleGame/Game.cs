

using LtuGame.ConsoleGame;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;

internal class Game
{
    private Map _map = null!;
    private Creature _player = null!;

    public Game()
    {
        
    }
    

    internal void Run()
    {
        Init();
        Play(); 
    }

    private void Play()
    {
        bool gameInProgress = true; 

        do {
           
           Drawmap();

           GetCommand();  

            //Act(); // Method to process the command (not implemented here)   

            //Drawmap(); // Redraw the map after processing the command (not implemented here)

            //Enemyaction(); // Method to handle enemy actions (not implemented here)

            //Drawmap(); // Final redraw of the map after enemy actions (not implemented here)
           

        } while (gameInProgress); // Loop until the game is no longer in progress
    }

    private void GetCommand()
    {
        var keyPressed = ConsoleUI.GetKey();

        switch (keyPressed) { 
        
        case ConsoleKey.UpArrow:
                // Move(_player.Cell.Y - 1, _player.Cell.X);
                Move(Direction.North);
            break;
        case ConsoleKey.DownArrow:
               // Move(_player.Cell.Y + 1, _player.Cell.X);
                break;

        case ConsoleKey.LeftArrow:
           // Move(_player.Cell.Y, _player.Cell.X -1);
                break;

        case ConsoleKey.RightArrow:
               // Move(_player.Cell.Y, _player.Cell.X + 1);
                break;
        }

    }

    private void Move(Position north)
    {
        throw new NotImplementedException();
    }

    private void Move(int y, int x)
    {
        var newPosition = _map.GetCell(y, x);
        if (newPosition is not null) _player.Cell = newPosition; 
       
    }

    private void Drawmap()
    {
       Console.Clear(); // Clear the console before drawing the map

        for (int y = 0; y < _map.Height; y++) 
        {
            for (int x = 0; x < _map.Width; x++) 
            {
                
                Cell? cell = _map.GetCell(y, x);
                ArgumentNullException.ThrowIfNull(cell, nameof(cell));

                IDrawable drawable = cell;

                foreach (Creature creature in _map.Creatures) 
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

    //[MemberNotNull(nameof(_map), nameof(_player))] 
    private void Init() 
    {
        //ToDo: Read from config file   

        _map = new Map(height:10, width: 10);
        Cell? playerCell = _map.GetCell(0, 0);
        _player = new Player(playerCell);
        
        _map.Creatures.Add(_player); 
    }
}
