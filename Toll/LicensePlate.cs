using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toll
{
    internal struct LicensePlate
    {
        public string CountryCode { get; set; }
        public string Number { get; set; }

        public LicensePlate(string CountryCode, string Number)
        {
            this.CountryCode = CountryCode;
            this.Number = Number;
        }

        public override string ToString() { return CountryCode + Number; }
    }
}
