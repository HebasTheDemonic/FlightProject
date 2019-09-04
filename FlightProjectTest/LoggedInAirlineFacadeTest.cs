using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FlightProject;
using FlightProject.Facades;
using FlightProject.POCOs;
using FlightProject.Exceptions;

namespace FlightProjectTest
{
    [TestClass]
    public class LoggedInAirlineFacadeTest
    {
        private static FlyingCenterSystem flyingCenterSystem = FlyingCenterSystem.GetInstance();

        [TestInitialize]
        public void TestStart()
        {
            flyingCenterSystem.isTestMode = true;
            flyingCenterSystem.StartTest();
            flyingCenterSystem.isTestMode = false;
        }

        [TestMethod]
        public void CancelFlight_FlightFound()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        [ExpectedException(typeof(NullResultException))]
        private void CancelFlight_FlightNotFound_ThrowsException()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        private void CreateFlight_NewFlight()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        [ExpectedException(typeof(DataAlreadyExistsException))]
        public void CreateFlight_FlightAlreadyExists_ThrowsException()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void UpdateFlight_FligtFound()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        [ExpectedException(typeof(NullResultException))]
        public void UpdateFlight_FlightNotFound_ThrowsException()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void ChangeMyPassword_CorrectPasswordEntered()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        [ExpectedException(typeof(WrongPasswordException))]
        public void ChangeMyPassword_WrongPasswordEntered()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void ModifyAirlineCompany_CorrectPasswordEntered()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        [ExpectedException(typeof(WrongPasswordException))]
        public void ModifyAirlineCompany_WrongPasswordEntered()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void GetAllFlights_CompanyHasFlights_ReturnNonNullList()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        [ExpectedException(typeof(NullResultException))]
        public void GetAllFlights_CompanyHasNoFlights_ThrowException()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void GetAllTicketsByFlight_FlightHasTickets()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        [ExpectedException(typeof(NullResultException))]
        public void GetAllTicketsByFlight_FlightNotFound_ThrowsException()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        [ExpectedException(typeof(NullResultException))]
        public void GetTicketsByFlight_FlightHasNoTickets_ThrowsException()
        {
            throw new NotImplementedException();
        }

        public LoggedInAirlineFacade GetAirlineFacade(string username, string password)
        {
            flyingCenterSystem.Username = username;
            flyingCenterSystem.Password = password;
            int facadeIndex = flyingCenterSystem.UserLogin();
            LoggedInAirlineFacade airlineFacade = (LoggedInAirlineFacade)FlyingCenterSystem.FacadeList[facadeIndex];
            return airlineFacade;
        }
    }
}
