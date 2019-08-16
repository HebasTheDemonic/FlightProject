using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightProject.POCOs;

namespace FlightProject.DAOs 
{
    internal interface IFlightDAO : IBasicDAO <Flight>
    {
        Dictionary<Flight, int> GetAllFlightsVacancy();
        Flight GetFlightById(int id);
        IList<Flight> GetFlightsByOriginCountry(int CountryCode);
        IList<Flight> GetFlightsByDepartureDate(DateTime departureDate);
        IList<Flight> GetFlightsByLandingTime(DateTime landingDate);
        IList<Flight> GetFlightsByCustomer(Customer customer);
        IList<Flight> GetFlightsByAirlineCompany(AirlineCompany airline);
    }
}
