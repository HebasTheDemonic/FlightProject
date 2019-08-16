using FlightProject.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightProject.POCOs
{
    public class AirlineCompany : IPoco, IUser
    {
        internal int Id { get; set; }
        internal string AirlineName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        internal string OriginCountry { get; set; }

        internal AirlineCompany()
        {
        }

        internal AirlineCompany(string userName, string password)
        {
            UserName = userName ?? throw new ArgumentNullException(nameof(userName));
            Password = password ?? throw new ArgumentNullException(nameof(password));
        }

        internal AirlineCompany(string airlineName, string userName, string password, string originCountry) : this (userName, password)
        {
            AirlineName = airlineName ?? throw new ArgumentNullException(nameof(airlineName));
            OriginCountry = originCountry ?? throw new ArgumentNullException(nameof(originCountry));
        }

        internal AirlineCompany(int id, string airlineName, string userName, string password, string originCountry) : this(airlineName, userName, password, originCountry)
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
