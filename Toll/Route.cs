using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toll
{
    internal class Route
    {
        public static List<Route> Routes = new List<Route>();

        public string RouteName { get; set; }
        public Path RoutePath { get; set; }
        public float Price { get; set; }

        public Route(string routeName, Path routePath, float price)
        {
            RouteName = routeName;
            RoutePath = routePath;
            Price = price;
        }

        public override string ToString() { return RouteName; }
    }
}
