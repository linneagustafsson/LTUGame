using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LtuGame.ConsoleGame.Characters
{
    internal class Orc : Creature
    {
        public Orc(Cell cell) : base(cell, "O ", 80)
        {
            Color = ConsoleColor.DarkGreen;
        }
    }
}
