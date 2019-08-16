using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightProject.POCOs;

namespace FlightProject.DAOs
{
    internal class AirlineDAOMSSQL : IAirlineDAO
    {
        public void Add(AirlineCompany t)
        {
            throw new NotImplementedException();
        }

        public AirlineCompany get(int id)
        {
            throw new NotImplementedException();
        }

        public AirlineCompany GetAirlineCompanybyUsername(string userName)
        {
            throw new NotImplementedException();
        }

        public IList<AirlineCompany> getAll()
        {
            throw new NotImplementedException();
        }

        public AirlineCompany GetAllAirlinesByCountry(int countryId)
        {
            throw new NotImplementedException();
        }

        public void Remove(AirlineCompany t)
        {
            throw new NotImplementedException();
        }

        public void Update(AirlineCompany t)
        {
            throw new NotImplementedException();
        }
    }
}
