using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightProject.POCOs;
using FlightProject.Exceptions;

namespace FlightProject.Facades
{
    public class LoggedInAirlineFacade : AnonymousUserFacade, ILoggedInAirlineFacade
    {
        public LoginToken<AirlineCompany> LoginToken { get; }

        internal LoggedInAirlineFacade(LoginToken<AirlineCompany> token)
        {
            LoginToken = token;
            _ticketDAO = new DAOs.TicketDAOMSSQL();
            _flightDAO = new DAOs.FlightDAOMSSQL();
            _airlineDAO = new DAOs.AirlineDAOMSSQL();
        }

        public void CancelFlight(LoginToken<AirlineCompany> token, Flight flight)
        {
            if (token.CheckToken())
            {
                if (_flightDAO.DoesFlightExist(flight.Id) == 1)
                {
                    List<Ticket> tickets = (List<Ticket>)_ticketDAO.GetAllTicketsByFlight(flight);
                    foreach (Ticket ticket in tickets)
                    {
                        _ticketDAO.Remove(ticket);
                    }
                    _flightDAO.Remove(flight);
                }
                else
                {
                    throw new NullResultException("Flight not found.");
                }
            }
        }

        public void ChangeMyPassword(LoginToken<AirlineCompany> token, string OldPassword, string NewPassword)
        {
            if (token.CheckToken())
            {
                if (OldPassword == token.User.Password)
                {
                    AirlineCompany airlineCompany = new AirlineCompany(token.User.Id, token.User.AirlineName, token.User.UserName, NewPassword, token.User.OriginCountry);
                    _airlineDAO.Update(airlineCompany);
                    token.User = airlineCompany;
                }
                else
                {
                    throw new WrongPasswordException("Incorrect Password.");
                }
            }
        }

        public void CreateFlight(LoginToken<AirlineCompany> token, Flight flight)
        {
            if (token.CheckToken())
            {
                if (_flightDAO.DoesFlightExist(flight.Id) == 0)
                {
                    _flightDAO.Add(flight);
                }
                else
                {
                    throw new DataAlreadyExistsException("Flight Already Exists");
                }
            }
        }

        public IList<Flight> GetAllFlights(LoginToken<AirlineCompany> token)
        {
            List<Flight> allFlightsOfCompany = new List<Flight>();

            if (token.CheckToken())
            {
                allFlightsOfCompany = (List<Flight>)_flightDAO.GetFlightsByAirlineCompany(token.User);
            }

            if (allFlightsOfCompany.Count == 0)
            {
                throw new NullResultException("Company has no active flights.");
            }
            return allFlightsOfCompany;
        }

        public IList<Ticket> GetAllTicketsByFlight(LoginToken<AirlineCompany> token, Flight flight)
        {
            List<Ticket> tickets = new List<Ticket>();

            if (token.CheckToken())
            {
                if(_flightDAO.DoesFlightExist(flight.Id) == 1)
                {
                    tickets = (List<Ticket>)_ticketDAO.GetAllTicketsByFlight(flight);
                }
                else
                {
                    throw new NullResultException("Flight not found");
                }
            }

            if (tickets.Count == 0)
            {
                throw new NullResultException("No tickets have been bought for this flight.");
            }

            return tickets;
        }

        public void ModifyAirlineDetails(LoginToken<AirlineCompany> token, AirlineCompany airline)
        {
            if (token.CheckToken())
            {
                if (token.User.Password == airline.Password)
                {
                    airline = new AirlineCompany(token.User.Id, airline.AirlineName, airline.UserName, token.User.Password, airline.OriginCountry);
                    _airlineDAO.Update(airline);
                    token.User = airline;
                }
                else
                {
                    throw new WrongPasswordException("Incorrect Password.");
                }
            }
        }

        public void UpdateFlight(LoginToken<AirlineCompany> token, Flight flight)
        {
            if (token.CheckToken())
            {
                if (_flightDAO.DoesFlightExist(flight.Id) == 1)
                {
                    _flightDAO.Update(flight);
                }
                else
                {
                    throw new NullResultException("Flight not found.");
                }
            }
        }
    }
}
