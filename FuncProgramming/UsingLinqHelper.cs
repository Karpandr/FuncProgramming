using FuncProgramming.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FuncProgramming
{
    public class UsingLinqHelper
    {
        /// <summary>
        /// Calculate the coordinates of all eight neighbors of a given point.
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public IEnumerable<Point> GetNeighbours(Point p)
        {
            int[] d = { -1, 0, 1 }; //then the Cartesian product of this set is used
            return d.SelectMany(x => d.Select(y => new Point(p.X + x, p.Y + y)))
                    .Where(x => !x.Equals(p));
        }
       
        public ILookup<char, string> TestLookup()
        {
            string[] names = { "Pavel", "Peter", "Andrew", "Anna", "Alice", "John" };
            ILookup<char, string> namesByLetter = names.ToLookup(name => name[0], name => name.ToLower());
            return namesByLetter;
        }
    }
}
