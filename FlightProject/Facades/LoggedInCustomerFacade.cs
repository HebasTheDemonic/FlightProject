using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightProject.POCOs;
using FlightProject.Exceptions;

namespace FlightProject.Facades
{
    public class LoggedInCustomerFacade : AnonymousUserFacade, ILoggedInCustomerFacade
    {
        public LoginToken<Customer> LoginToken { get; }

        internal LoggedInCustomerFacade(LoginToken<Customer> token)
        {
            LoginToken = token;
            _ticketDAO = new DAOs.TicketDAOMSSQL();
            _flightDAO = new DAOs.FlightDAOMSSQL();
        }

        public void CancelTicket(LoginToken<Customer> token, Ticket ticket)
        {
            if (token.CheckToken())
            {
                if (_ticketDAO.DoesTicketExistByCustomerAndFlight(ticket) == 1)
                {
                    _ticketDAO.Remove(ticket);
                }
                else
                {
                    throw new NullReferenceException("Requested ticket does not exist.");
                }
            }
        }

        public IList<Flight> GetAllMyFlights(LoginToken<Customer> token)
        {
            List<Flight> customerFlights = new List<Flight>();
            if (token.CheckToken())
            {
                customerFlights = (List<Flight>)_flightDAO.GetFlightsByCustomer(token.User);
            }
            return customerFlights;
        }

        public Ticket PurchaseTicket(LoginToken<Customer> token, int flightId)
        {
            Ticket ticket = new Ticket(flightId, token.User.Id);
            if (token.CheckToken())
            {
                if (_ticketDAO.DoesTicketExistByCustomerAndFlight(ticket) == 0)
                {
                    if((_flightDAO.CheckRemainingSeatsOnFlight(flightId)) > 0)
                    {
                        _ticketDAO.Add(ticket);
                        _ticketDAO.GetTicketID(ticket);
                    }
                    else
                    {
                        throw new UnauthorisedActionException("No tickets remaining for this flight.");
                    }
                }
                else
                {
                    throw new UnauthorisedActionException("Customer already bought ticket for this flight.");
                }
            }

            if(ticket.FlightId == 0)
            {
                throw new Exceptions.NullResultException("Order Failed.");
            }
            return ticket;
        }
    }
}
