using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightProject.POCOs;

namespace FlightProject.DAOs
{
    internal class FlightDAOMSSQL : IFlightDAO
    {
        public void Add(Flight t)
        {
            throw new NotImplementedException();
        }

        public Flight get(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Flight> getAll()
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

        public IList<Flight> GetFlightsByAirlineCompany(AirlineCompany airline)
        {
            throw new NotImplementedException();
        }

        public IList<Flight> GetFlightsByCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public IList<Flight> GetFlightsByDepartureDate(DateTime departureDate)
        {
            throw new NotImplementedException();
        }

        public IList<Flight> GetFlightsByLandingTime(DateTime landingDate)
        {
            throw new NotImplementedException();
        }

        public IList<Flight> GetFlightsByOriginCountry(int CountryCode)
        {
            throw new NotImplementedException();
        }

        public void Remove(Flight t)
        {
            throw new NotImplementedException();
        }

        public void Update(Flight t)
        {
            throw new NotImplementedException();
        }
    }
}
