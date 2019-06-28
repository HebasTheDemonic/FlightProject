using FlightProject.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightProject
{
    internal class AirlineCompany : IPoco, IUser
    {
        internal int Id { get; set; }
        internal string AirlineName { get; set; }
        internal string UserName { get; set; }
        internal string Password { get; set; }
        internal string OriginCountry { get; set; }

        public AirlineCompany()
        {
        }

        public AirlineCompany(string airlineName, string userName, string password, string originCountry)
        {
            AirlineName = airlineName ?? throw new ArgumentNullException(nameof(airlineName));
            UserName = userName ?? throw new ArgumentNullException(nameof(userName));
            Password = password ?? throw new ArgumentNullException(nameof(password));
            OriginCountry = originCountry ?? throw new ArgumentNullException(nameof(originCountry));
        }

        public AirlineCompany(int id, string airlineName, string userName, string password, string originCountry) : this(airlineName, userName, password, originCountry)
        {
            Id = id;
        }

        public static bool operator ==(AirlineCompany airlineCompany1, AirlineCompany airlineCompany2) => airlineCompany1.Equals(airlineCompany2);


        public static bool operator !=(AirlineCompany airlineCompany1, AirlineCompany airlineCompany2) => !(airlineCompany1 == airlineCompany2);

        public override bool Equals(object obj)
        {
            var company = obj as AirlineCompany;
            if (UserName == null || company.UserName  == null)
            {
                throw new CorruptedDataException();
            }
            return company != null &&
                   UserName == company.UserName;
        }

        public override int GetHashCode()
        {
            return 2000000 + Id.GetHashCode();
        }
    }
}
