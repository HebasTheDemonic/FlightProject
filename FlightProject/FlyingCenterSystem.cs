using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightProject.POCOs;
using FlightProject.Facades;
using FlightProject.DAOs;

namespace FlightProject
{
    public class FlyingCenterSystem
    {
        private static FlyingCenterSystem instance;
        private static object key = new object();
        public string Username { get; set; }
        public string Password { get; set; }
        public static List<FacadeBase> FacadeList;
        private static int FacadeListIndex = 0;
        public bool isTestMode = false;

        public static FlyingCenterSystem GetInstance()
        {
            lock (key)
            {
                if(instance == null)
                {
                    instance = new FlyingCenterSystem();
                }
            }
            return instance;
        }

        private FlyingCenterSystem()
        {
            FacadeList = new List<FacadeBase>();
            GetFacade();
        }

        public int UserLogin()
        {
            LoginService loginService = new LoginService(Username,Password);
            return loginService.FacadeIndex;
        }

        internal static int GetFacade(LoginToken<Administrator> loginToken)
        {
            LoggedInAdministratorFacade loggedInAdministratorFacade = new LoggedInAdministratorFacade(loginToken);
            FacadeList.Add(loggedInAdministratorFacade);
            FacadeListIndex++;
            return FacadeListIndex;
        }

        internal static int GetFacade(LoginToken<AirlineCompany> loginToken)
        {
            LoggedInAirlineFacade loggedInAirlineFacade = new LoggedInAirlineFacade(loginToken);
            FacadeList.Add(loggedInAirlineFacade);
            FacadeListIndex++;
            return FacadeListIndex;
        }

        internal static int GetFacade(LoginToken<Customer> loginToken)
        {
            LoggedInCustomerFacade loggedInCustomerFacade = new LoggedInCustomerFacade(loginToken);
            FacadeList.Add(loggedInCustomerFacade);
            FacadeListIndex++;
            return FacadeListIndex;
        }

        internal static void GetFacade()
        {
            AnonymousUserFacade anonymousUserFacade = new AnonymousUserFacade();
            FacadeList.Add(anonymousUserFacade);
        }

        public void StartTest()
        {
            if (isTestMode)
            {
                GeneralDAOMSSQL generalDAOMSSQL = new GeneralDAOMSSQL();
                generalDAOMSSQL.DBTestPrep();
            }
        }

        public void ClearDb()
        {
            if (isTestMode)
            {
                GeneralDAOMSSQL generalDAOMSSQL = new GeneralDAOMSSQL();
                generalDAOMSSQL.DBClear();
            }
        }
    }

    
}
