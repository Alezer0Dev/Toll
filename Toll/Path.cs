using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toll
{
    internal class Path
    {
        public static List<Path> Paths = new List<Path>();

        public Location StartLocation { get; set; }
        public Location EndLocation { get; set; }
        public int KMLenght { get; set; }

        public Path(Location startLocation, Location endLocation, int KMLenght)
        {
            this.StartLocation = startLocation;
            this.EndLocation = endLocation;
            this.KMLenght = KMLenght;
        }
    }
}
