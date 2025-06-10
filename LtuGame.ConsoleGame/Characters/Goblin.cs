using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace LtuGame.ConsoleGame.Characters
{
    internal class Goblin : Creature
    {
        public Goblin(Cell cell) : base(cell, "G ", 20)
        {
            Color = ConsoleColor.DarkBlue;
            Damage = 60;
        }
    }
}
