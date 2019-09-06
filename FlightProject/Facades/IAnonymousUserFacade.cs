using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightProject.POCOs;

namespace FlightProject.Facades
{
    interface IAnonymousUserFacade
    {
        IList<Flight> GetAllFlights();
        IList<AirlineCompany> GetAirlineCompanies();
        Flight GetFlightById(int id);
        IList<Flight> GetFlightsByOriginCountry(int CountryCode);
        IList<Flight> GetFlightsByDepartureDate(DateTime departureDate);
        IList<Flight> GetFlightsByLandingDate(DateTime landingTime);
    }
}
