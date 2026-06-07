using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toll
{
    internal struct Location
    {
        public static List<Location> Locations = new List<Location>();

        public string Name { get; set; }

        public Location(string name)
        {
            this.Name = name;
        }
    }
}
