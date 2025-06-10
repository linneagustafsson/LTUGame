using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace LtuGame.ConsoleGame.Characters
{
    internal class Troll : Creature
    {
        public Troll(Cell cell) : base(cell, "T ", 60)
        {
            Color = ConsoleColor.DarkGreen;
            Damage = 45;
        }
    }
}
