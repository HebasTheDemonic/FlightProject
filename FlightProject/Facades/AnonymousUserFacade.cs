using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightProject.POCOs;
using FlightProject.DAOs;
using FlightProject.Exceptions;
using System.Data.SqlClient;

namespace FlightProject.Facades
{
    public class AnonymousUserFacade : FacadeBase, IAnonymousUserFacade
    {
        internal AnonymousUserFacade()
        {
            _airlineDAO = new AirlineDAOMSSQL();
            _flightDAO = new FlightDAOMSSQL();
        }

        // Returns a list of all airline companies if there is atleast one company in the database.
        // If returned object is null catches and incapsules it in NullResultException.
        // If an SQL error is cought throws it up

        public IList<AirlineCompany> GetAirlineCompanies()
        {
            try
            {
                List<AirlineCompany> airlineCompanies = (List<AirlineCompany>)_airlineDAO.GetAll();

                if (airlineCompanies.Count == 0)
                {
                    throw new NullReferenceException();
                }

                return airlineCompanies;
            }
            catch (NullReferenceException dataEx)
            {
                throw new NullResultException("No registered companies found", dataEx);
            }
            catch (SqlException)
            {
                throw;
            }
        }

        // Returns a list of all flights if there is atleast one in the database.
        // If returned object is null catches and incapsules it in NullResultException.
        // If an SQL error is cought throws it up

        public IList<Flight> GetAllFlights()
        {
            try
            {
                List<Flight> flights = (List<Flight>)_flightDAO.GetAll();

                if (flights.Count == 0)
                {
                    throw new NullReferenceException();
                }

                return flights;
            }
            catch (NullReferenceException dataEx)
            {
                throw new NullResultException("No active flights found.", dataEx);
            }
            catch (SqlException)
            {
                throw;
            }
        }

        // Returns data on a single flight that corresponds to the requested ID.
        // If returned object is null catches and incapsules it in NullResultException.
        // If an SQL error is cought throws it up

        public Flight GetFlightById(int id)
        {
            try
            {
                Flight flight = _flightDAO.Get(id);
                if (flight.FlightStatus == null)
                {
                    throw new NullReferenceException();
                }
                return flight;
            }
            catch (NullReferenceException dataEx)
            {
                throw new NullResultException("No flight with this ID was found", dataEx);
            }
            catch (SqlException)
            {
                throw;
            }
        }

        // Returns a list of flights taking off on provided date if any exist.
        // If returned object is null catches and incapsules it in NullResultException.
        // If an SQL error is cought throws it up

        public IList<Flight> GetFlightsByDepartureDate(DateTime departureDate)
        {
            try
            { 
                List<Flight> flightsDepartingOnDate = (List<Flight>)_flightDAO.GetFlightsByDepartureDate(departureDate);

                if (flightsDepartingOnDate.Count == 0)
                {
                    throw new NullReferenceException();
                }

                return flightsDepartingOnDate;
            }
            catch (NullReferenceException dataEx)
            {
                throw new NullResultException("No flights are departing on this date.", dataEx);
            }
            catch (SqlException)
            {
                throw;
            }
        }

        // Returns a list of flights landing in country if any exist.
        // If returned object is null catches and incapsules it in NullResultException.
        // If an SQL error is cought throws it up

        public IList<Flight> GetFlightsByDestinationCountry(int CountryCode)
        {
            try
            {
                List<Flight> flightsLandingInCountry = (List<Flight>)_flightDAO.GetFlightsByDestinationCountry(CountryCode);

                if (flightsLandingInCountry.Count == 0)
                {
                    throw new NullReferenceException();
                }
                return flightsLandingInCountry;
            }
            catch (NullReferenceException dataEx)
            {
                throw new NullResultException("No flights are flying to this country.", dataEx);
            }
            catch (SqlException)
            {
                throw;
            }
        }

        // Returns a list of flights landing on provided date if any exist.
        // If returned object is null catches and incapsules it in NullResultException.
        // If an SQL error is cought throws it up

        public IList<Flight> GetFlightsByLandingDate(DateTime landingTime)
        {
            try
            {
                List<Flight> flightsLandingOnDate = (List<Flight>)_flightDAO.GetFlightsByLandingDate(landingTime);

                if (flightsLandingOnDate.Count == 0)
                {
                    throw new NullReferenceException();
                }

                return flightsLandingOnDate;
            }
            catch (NullReferenceException dataEx)
            {
                throw new NullResultException("No flights are landing on this country.", dataEx);
            }
            catch (SqlException)
            {
                throw;
            }
        }

        // Returns a list of flights taking off from country if any exist.
        // If returned object is null catches and incapsules it in NullResultException.
        // If an SQL error is cought throws it up

        public IList<Flight> GetFlightsByOriginCountry(int CountryCode)
        {
            try
            {
                List<Flight> flightsDepartingFromCountry = (List<Flight>)_flightDAO.GetFlightsByOriginCountry(CountryCode);

                if (flightsDepartingFromCountry.Count == 0)
                {
                    throw new NullReferenceException();
                }
                return flightsDepartingFromCountry;
            }
            catch (NullReferenceException dataEx)
            {
                throw new NullResultException("No flights are leaving from this country.", dataEx);
            }
            catch (SqlException)
            {
                throw;
            }
        }
    }
}
