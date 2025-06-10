﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace LtuGame.ConsoleGame.Extensions
{
    internal static class MapExtensions
    {

        public static IDrawable? CreatureAt(this IEnumerable<Creature> creatures, Cell cell)
        {
            //IDrawable? result = null;

            //foreach (Creature creature in creatures)
            //{
            //    if (creature.Cell == cell)

            //        result = creature;
            //    break;
            //}
            //return result;
            return creatures.FirstOrDefault(c => c.Cell ==cell);// Use LINQ to find the first creature that matches the cell
        }
        
     
    }
}
