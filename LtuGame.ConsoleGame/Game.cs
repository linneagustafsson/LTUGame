using LtuGame.ConsoleGame;
using LtuGame.ConsoleGame.Extensions;
using LtuGame.ConsoleGame.GameWorld;
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
                
                Move(Direction.North);
            break;
        case ConsoleKey.DownArrow:
                Move(Direction.South);
                break;

        case ConsoleKey.LeftArrow:
                Move(Direction.West);
                break;

        case ConsoleKey.RightArrow:
                Move(Direction.East);
                break;
        }

    }

    private void Move(Position movement)
    {
        var newPosition = _player.Cell.Position + movement;
        var newCell = _map.GetCell(newPosition);
        if (newCell is not null) _player.Cell = newCell;

    }

    private void Move(int y, int x)
    {
        var newPosition = _map.GetCell(y, x);
        if (newPosition is not null) _player.Cell = newPosition; 
       
    }

    public void Dawmap()
    {
        Console.Clear();
        ConsoleUI.Draw(_map); // Draw the map using the ConsoleUI class
    }
    //[MemberNotNull(nameof(_map), nameof(_player))] 
    private void Init() 
    {
        //ToDo: Read from config file   

        _map = new Map(height:10, width: 10);
        Cell? playerCell = _map.GetCell(0, 0);
        _player = new Player(playerCell);
        
        _map.Creatures.Add(_player);

        _map.GetCell(2, 6)?.Items.Add(Item.Coin());// Add a coin item to the map at position (2, 6)
        _map.GetCell(3, 6)?.Items.Add(Item.Coin());
        _map.GetCell(5, 2)?.Items.Add(Item.Stone());// Add a stone item to the map at position (2, 6)
        _map.GetCell(4, 4)?.Items.Add(Item.Coin());
    }
}
