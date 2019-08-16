using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightProject.DAOs;

namespace FlightProject.Facades
{
    internal abstract class FacadeBase
    {
        protected IAdministratorDAO _administratorDAO;
        protected IAirlineDAO _airlineDAO;
        protected ICountryDAO _countryDAO;
        protected ICustomerDAO _customerDAO;
        protected IFlightDAO _flightDAO;
        protected ITicketDAO _ticketDAO;
    }
}
