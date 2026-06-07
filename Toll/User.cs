using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toll
{
    internal class User
    {
        public static List<User> Users = new List<User>();

        public LicensePlate LicensePlate { get; set; }
        public int TransitsCount { get; set; }

        public User(LicensePlate licensePlate)
        {
            LicensePlate = licensePlate;
            TransitsCount = 1;
        }

        public List<Transit> GetTransits()
        {
            List<Transit> transits = new List<Transit>();
            foreach (var transit in Transit.TransitList)
            {
                if (transit.LicensePlate.ToString() == this.LicensePlate.ToString())
                {
                    transits.Add(transit);
                }
            }
            return transits;
        }

        public static User GetByLicensePlate(LicensePlate licensePlate)
        {
            foreach (User user in Users)
            {
                if (user.LicensePlate.ToString() == licensePlate.ToString())
                {
                    return user;
                }
            }
            return null;
        }
    }
}
