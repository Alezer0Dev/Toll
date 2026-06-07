using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Toll
{
    internal class TelepassUser : User
    {
        public static List<TelepassUser> Users = new List<TelepassUser>();

        public SubscriptionStatus Status { get; set; }
        public enum SubscriptionStatus
        {
            Expired,
            Suspended,
            Active
        }

        public TelepassUser(LicensePlate licensePlate, SubscriptionStatus status): base(licensePlate)
        {
            this.LicensePlate = licensePlate;
            this.Status = status;
            this.TransitsCount = 0;
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
