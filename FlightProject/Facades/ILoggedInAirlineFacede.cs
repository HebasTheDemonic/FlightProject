using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightProject.POCOs;

namespace FlightProject.Facades
{
    interface ILoggedInAirlineFacede
    {
        IList<Ticket> GetAllTicketsByFlight(LoginToken<AirlineCompany> token, Flight flight);
        IList<Ticket> GetAllFlights(LoginToken<AirlineCompany> token);
        void CancelFlight(LoginToken<AirlineCompany> token, Flight flight);
        void CreateFlight(LoginToken<AirlineCompany> token, Flight flight);
        void UpdateFlight(LoginToken<AirlineCompany> token, Flight flight);
        void ChangeMyPassword(LoginToken<AirlineCompany> token, string OldPassword, string NewPassword);
        void ModifyAirlineDetails(LoginToken<AirlineCompany> token, AirlineCompany airline);
    }
}
