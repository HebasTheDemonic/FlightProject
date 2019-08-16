using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightProject.POCOs;
using FlightProject.Exceptions;

namespace FlightProject
{
    public class LoginService : ILoginService
    {
        internal DAOs.ILoginDAO _loginDAO;
        internal DAOs.IAdministratorDAO _administratorDAO;
        internal DAOs.IAirlineDAO _airlineDAO;
        internal DAOs.ICustomerDAO _customerDAO;
        
        public LoginService(string username, string password)
        {
            LoginEnum loginEnum = TryLogin(username);

            switch (loginEnum)
            {
                case LoginEnum.ADMINISTRATOR:
                    {
                        LoginToken<Administrator> loginToken = new LoginToken<Administrator>();
                        if (AdminLogin(username, password, out loginToken))
                        {
                            throw new NotImplementedException();
                        }
                        return;
                    }
                case LoginEnum.AIRLINE:
                    {
                        LoginToken<AirlineCompany> loginToken = new LoginToken<AirlineCompany>();
                        if (AirlineLogin(username, password, out loginToken))
                        {
                            throw new NotImplementedException();
                        }
                        return;
                    }
                case LoginEnum.CUSTOMER:
                    {
                        LoginToken<Customer> loginToken = new LoginToken<Customer>();
                        if (CustomerLogin(username, password, out loginToken))
                        {
                            throw new NotImplementedException();
                        }
                        return;
                    }
                default:
                    {
                        return;
                    }
            }
        }

        public LoginEnum TryLogin(string userName)
        {
            int loginValue = 0;
            _loginDAO = new DAOs.LoginDAOMSSQL();
            loginValue = _loginDAO.TryLogin(userName, loginValue);
            switch (loginValue)
            {
                case 1:
                    {
                        return LoginEnum.ADMINISTRATOR;
                    }
                case 2:
                    {
                        return LoginEnum.AIRLINE;
                    }
                case 3:
                    {
                        return LoginEnum.CUSTOMER;
                    }
                default:
                    {
                        throw new UserNotFoundException();
                    }
            }

        }

        public bool  AdminLogin(string userName, string password, out LoginToken<Administrator> loginToken)
        {
            _administratorDAO = new DAOs.AdministratorDAOMSSQL();
            Administrator administrator = _administratorDAO.GetAdministratorByUsername(userName);

            if (password == administrator.Password)
            {
                loginToken = new LoginToken<Administrator>();
                loginToken.user = administrator;
                return true;
            }

            throw new WrongPasswordException();
        }

        public bool AirlineLogin(string userName, string password, out LoginToken<AirlineCompany> loginToken)
        {
            _airlineDAO = new DAOs.AirlineDAOMSSQL();
            AirlineCompany airlineCompany = _airlineDAO.GetAirlineCompanybyUsername(userName);

            if (password == airlineCompany.Password)
            {
                loginToken = new LoginToken<AirlineCompany>();
                loginToken.user = airlineCompany;
                return true;
            }

            throw new WrongPasswordException();
        }

        public bool CustomerLogin(string userName, string password, out LoginToken<Customer> loginToken)
        {
            _customerDAO = new DAOs.CustomerDAOMSSQL();
            Customer customer = _customerDAO.GetCustomerByUsername(userName);

            if (password == customer.Password)
            {
                loginToken = new LoginToken<Customer>();
                loginToken.user = customer;
                return true;
            }

            throw new WrongPasswordException();
        }
    }
}
