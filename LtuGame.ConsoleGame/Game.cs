using LtuGame.ConsoleGame;
using LtuGame.ConsoleGame.Extensions;
using LtuGame.ConsoleGame.GameWorld;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;

internal class Game
{
    private Map _map = null!;
    private Player _player = null!;

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


        case ConsoleKey.P://Pick up item
                PickUp();
                break;
            case ConsoleKey.I:
                Inventory();
                break;

            //var actionmeny = new Dictionary<ConsoleKey, Action>
            
            //{
              
            //    { ConsoleKey.P, PickUp }, // Pick up item
            //    { ConsoleKey.I, Inventory } // Show inventory
            //};

            //    if (actionmeny.ContainsKey(keyPressed))
            //    {
            //        actionmeny[keyPressed]?.Invoke(); // Invoke the action associated with the pressed key
            //    }
        }

    }
    private void Inventory()
    {
        for (int i = 0; i < _player.BackPack.Count; i++)
        {
            ConsoleUI.AddMessage($"{i + 1}: {_player.BackPack[i]}");
        }
    }

    private void PickUp()
    {
        if (_player.BackPack.IsFull)
        { 
            ConsoleUI.AddMessage("Your backpack is full. You cannot pick up more items.");
            return;
        }

        var items = _player.Cell.Items; // Get items from the player's current cell
        var item = items.FirstOrDefault(); // Get the first item in the cell

        if (item is null) return; // If there are no items, exit the method

        if(_player.BackPack.Add(item)) // Try to add the item to the player's backpack
        
        {
           
            Console.WriteLine($"You picked up a {item}.");
            items.Remove(item); // Remove the item from the cell if successfully added to the backpack
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

    public void Drawmap()
    {
        ConsoleUI.Clear();
        ConsoleUI.Draw(_map); // Draw the map using the ConsoleUI class
        ConsoleUI.PrintStats($"Health:  { _player.Health}"); // Print player stats to the console
        ConsoleUI.PrintLog(); // Print the message log to the console
    }
    //[MemberNotNull(nameof(_map), nameof(_player))] 
    private void Init()  // Initialize the game world and player
    {

        //ToDo: Read from config file   

        _map = new Map(height:10, width: 10);
        Cell? playerCell = _map.GetCell(0, 0);
        _player = new Player(playerCell!);
        
        _map.Creatures.Add(_player);

        _map.GetCell(1, 1)?.Items.Add(Item.Coin());// Add a coin item to the map 
        _map.GetCell(1, 2)?.Items.Add(Item.Coin());
        _map.GetCell(1, 3)?.Items.Add(Item.Stone());// Add a stone item to the map 
        _map.GetCell(1, 4)?.Items.Add(Item.Coin());
    }
}
