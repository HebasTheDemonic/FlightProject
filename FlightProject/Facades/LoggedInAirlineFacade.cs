using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightProject.POCOs;

namespace FlightProject.Facades
{
    class LoggedInAirlineFacade : AnonymousUserFacade, ILoggedInAirlineFacede
    {
        public void CancelFlight(LoginToken<AirlineCompany> token, Flight flight)
        {
            throw new NotImplementedException();
        }

        public void ChangeMyPassword(LoginToken<AirlineCompany> token, string OldPassword, string NewPassword)
        {
            throw new NotImplementedException();
        }

        public void CreateFlight(LoginToken<AirlineCompany> token, Flight flight)
        {
            throw new NotImplementedException();
        }

        public IList<Ticket> GetAllFlights(LoginToken<AirlineCompany> token)
        {
            throw new NotImplementedException();
        }

        public IList<Ticket> GetAllTicketsByFlight(LoginToken<AirlineCompany> token, Flight flight)
        {
            throw new NotImplementedException();
        }

        public void ModifyAirlineDetails(LoginToken<AirlineCompany> token, AirlineCompany airline)
        {
            throw new NotImplementedException();
        }

        public void UpdateFlight(LoginToken<AirlineCompany> token, Flight flight)
        {
            throw new NotImplementedException();
        }
    }
}
