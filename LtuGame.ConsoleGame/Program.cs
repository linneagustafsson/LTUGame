﻿
using LtuGame.ConsoleGame.Extensions;
using LtuGame.LimitedList;

//IEnumerable<int> list = new List<int>(); //Ienumerable är ett interface som gör att vi kan använda foreach på listan
//IEnumerable<Creature> list2 = new Creature[25]; //IEnumerable<Creature> är ett interface som gör att vi kan använda foreach på listan av Creature objekt
//list2.CreatureAt(new Cell(new LtuGame.ConsoleGame.GameWorld.Position(1,2)));

////LimitedList<int> lm = new LimitedList<int>(10);

//IEnumerable<int> lm = new LimitedList<int>(10);

//var li = new List<int>(10);

//var str = "sdfdf";

//foreach (var item in str)
//{
//    Console.WriteLine(item);
//}


//foreach (var item in li) 
//{
//    Console.WriteLine(item);
//}

//foreach (var item in lm)
//{
//    Console.WriteLine(item);
//}


var game = new Game();
game.Run();

Console.WriteLine("Game over."); 