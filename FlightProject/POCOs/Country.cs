using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightProject.Exceptions;

namespace FlightProject.POCOs
{
    internal class Country : IPoco
    {
        internal int ID { get; set; }
        internal string CountryName { get; set; }

        public Country()
        {
        }

        public Country(string countryName)
        {
            CountryName = countryName ?? throw new ArgumentNullException(nameof(countryName));
        }

        public Country(int iD, string countryName) : this(countryName)
        {
            ID = iD;
        }

        public static bool operator ==(Country country1, Country Country) => country1.Equals(Country);

        public static bool operator !=(Country country1, Country country) => !(country == country1);

        public override bool Equals(object obj)
        {
            var country = obj as Country;
            if (this.CountryName == null || country.CountryName == null)
            {
                throw new CorruptedDataException();
            }
            return country != null &&
                   CountryName == country.CountryName;
        }

        public override int GetHashCode()
        {
            return 4000000 + ID.GetHashCode();
        }
    }
}
