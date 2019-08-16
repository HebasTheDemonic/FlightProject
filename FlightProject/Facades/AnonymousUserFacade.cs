using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightProject.POCOs;

namespace FlightProject.Facades
{
    class AnonymousUserFacade : IAnonymousUserFacade
    {
        public IList<AirlineCompany> GetAirlineCompanies()
        {
            throw new NotImplementedException();
        }

        public IList<Flight> GetAllFlights()
        {
            throw new NotImplementedException();
        }

        public Dictionary<Flight, int> GetAllFlightsVacancy()
        {
            throw new NotImplementedException();
        }

        public Flight GetFlightById(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Flight> GetFlightsByDepartureDate(DateTime departureDate)
        {
            throw new NotImplementedException();
        }

        public IList<Flight> GetFlightsByLandingDate(DateTime landingTime)
        {
            throw new NotImplementedException();
        }

        public IList<Flight> GetFlightsByOriginCountry(int CountryCode)
        {
            throw new NotImplementedException();
        }
    }
}
