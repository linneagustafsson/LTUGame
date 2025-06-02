
internal class Map
{
    private Cell[,] _cells; // Declare the cells array to hold Cell objects

    public int Height { get; }// Height of the map
    public int Width { get; }// Width of the map

    public Map(int height, int width)// Constructor to initialize the map with given height and width
    {
        this.Height = height;// Set the height of the map
        this.Width = width;// Set the width of the map

        _cells = new Cell[height, width];// Initialize the cells array

        for (int y = 0; y < height; y++) // Loop through each row of the map
        {
            for (int x = 0; x < width; x++)
            {
                _cells[y,x] = new Cell(); // Initialize each cell with a new Cell object
            }
            
        }
    }

   //[return: MaybeNull]
    internal Cell? GetCell(int y, int x)
    {
        //ToDo: Fix this method to return the correct cell based on coordinates
        try
        {
            return _cells[y, x];
        }
        catch (Exception) {

            return null;
        }
    }
}