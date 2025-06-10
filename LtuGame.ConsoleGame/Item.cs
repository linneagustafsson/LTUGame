using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LtuGame.ConsoleGame
{
   
    internal class Item : IDrawable // Represents an item in the game, such as a weapon or potion
    {
        private readonly string _name;

        public ConsoleColor Color { get; }

        public string Symbol { get; }

        public Item(string symbol, ConsoleColor color, string name)
        { 

            Symbol = symbol;
            Color = color;
            _name = name;
        }

        public override string ToString() => _name;
   
       
        public static Item Coin() => new Item("c", ConsoleColor.Magenta, "Coin"); // Represents a coin item
        public static Item Stone() => new Item("s", ConsoleColor.Gray, "Stone");// Represents a stone item
         //de är static och kan anropas utan att skapa en instans av Item-klassen
    }
}
