using LtuGame.ConsoleGame.GameWorld;

internal interface IMap
{
    List<Creature> Creatures { get; }
    int Height { get; }
    int Width { get; }

    Cell? GetCell(int y, int x); //overload for coordinates
    Cell? GetCell(Position newPosition);
}