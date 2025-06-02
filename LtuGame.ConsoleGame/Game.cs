

using System.Data;
using System.Drawing;

internal class Game
{
    private Map _map = null!;// Initialize map to null, will be set in Init method
    private Player _player = null!;// Initialize player to null, will be set in Init method

    public Game()// Constructor to initialize the game
    {
        
    }
    

    internal void Run()
    {
        Init();
        Play(); 
    }

    private void Play()
    {
        bool gameInProgress = true; // Flag to track if the game is still in progress

        do {
           
            Drawmap();

            //GetCommand(); // Method to get user input (not implemented here)  

            //Act(); // Method to process the command (not implemented here)   

            //Drawmap(); // Redraw the map after processing the command (not implemented here)

            //Enemyaction(); // Method to handle enemy actions (not implemented here)

            //Drawmap(); // Final redraw of the map after enemy actions (not implemented here)
            Console.ReadLine();

        } while (gameInProgress); // Loop until the game is no longer in progress
    }

    private void Drawmap()
    {
       Console.Clear(); // Clear the console before drawing the map

        for (int y = 0; y < _map.Height; y++) // Loop through each row of the map
        {
            for (int x = 0; x < _map.Width; x++) 
            {
                //ToDo: handle null cells
                Cell? cell = _map.GetCell(y, x); // Get the cell at the current coordinates
                Console.ForegroundColor = cell.Color;
                Console.Write(cell.Symbol); // Print the symbol of the cell

            }
            Console.WriteLine(); // Move to the next line after printing a row
        }

            Console.ResetColor(); // Reset the console color to default after drawing the map
    }

    private void Init() // Method to initialize the game components
    {
        //ToDo: Read from config file   

         _map = new Map(height:10, width: 10);
         _player = new Player();
    }
}