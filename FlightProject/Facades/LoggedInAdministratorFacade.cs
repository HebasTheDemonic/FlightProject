using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightProject.POCOs;

namespace FlightProject.Facades
{
    internal class LoggedInAdministratorFacade : AnonymousUserFacade,ILoggedInAdministratorFacade
    {
        public void CreateNewAdministrator(LoginToken<Administrator> token, Administrator administrator)
        {
            throw new NotImplementedException();
        }

        public void CreateNewAirline(LoginToken<Administrator> token, AirlineCompany airline)
        {
            throw new NotImplementedException();
        }

        public void CreateNewCustomer(LoginToken<Administrator> token, Customer customer)
        {
            throw new NotImplementedException();
        }

        public void RemoveAdministrator(LoginToken<Administrator> token, Administrator administrator)
        {
            throw new NotImplementedException();
        }

        public void RemoveAirline(LoginToken<Administrator> token, AirlineCompany airline)
        {
            throw new NotImplementedException();
        }

        public void RemoveCustomer(LoginToken<Administrator> token, Customer customer)
        {
            throw new NotImplementedException();
        }

        public void UpdateAdministrator(LoginToken<Administrator> token, Administrator administrator)
        {
            throw new NotImplementedException();
        }

        public void UpdateAirlineDetails(LoginToken<Administrator> token, AirlineCompany airline)
        {
            throw new NotImplementedException();
        }

        public void UpdateCustomerDetails(LoginToken<Administrator> token, Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
