
using LtuGame.LimitedList;

IEnumerable<int> list = new List<int>();
IEnumerable<int> list2 = new int[25];
//list2.CreatureAt(new Cell(new LtuGame0, 0)));


//LimitedList<int> lm = new LimitedList<int>(10);
var lm = new LimitedList<int>(10);
var li = new List<int>(10);
var str = "sdfdf";

foreach (var item in str)
{
    Console.WriteLine(item);
}


foreach (var item in li) 
{
    Console.WriteLine(item);
}

foreach (var item in lm)
{
    Console.WriteLine(item);
}


var game = new Game();
game.Run();

Console.WriteLine("Game over."); 