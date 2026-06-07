using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toll
{
    internal struct Transit
    {
        static public List<Transit> TransitList = new List<Transit>();

        public LicensePlate LicensePlate { get; }
        public Route Route { get; }
        public PaymentMethod PaymentBy { get;}
        public DateTime Timestamp { get; }

        public enum PaymentMethod
        {
            Cash,
            Card,
            Telepass
        }

        public Transit (LicensePlate licensePlate, Route route, PaymentMethod paymentBy, DateTime timestamp)
        {
            LicensePlate = licensePlate;
            Route = route;
            PaymentBy = paymentBy;
            Timestamp = timestamp;
            if (paymentBy == PaymentMethod.Telepass) { TelepassUser.GetByLicensePlate(licensePlate).TransitsCount++; }
            else {
                User user = User.GetByLicensePlate(licensePlate);
                if (user != null)
                {
                    user.TransitsCount++;
                }
                else
                {
                    User.Users.Add(new User(licensePlate));
                }
            }
        }
    }
}
