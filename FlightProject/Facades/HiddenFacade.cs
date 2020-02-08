<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightProject.DAOs;

namespace FlightProject.Facades
{
    public class HiddenFacade
    {
        GeneralDAOMSSQL generalDAO;

        internal HiddenFacade()
        {
            generalDAO = new GeneralDAOMSSQL();
        }

        public void clearDb()
        {
            generalDAO.DBClear();
        }

        public void DbTestPrep()
        {
            generalDAO.DBTestPrep();
        }

        public void CleanFlightList()
        {
            generalDAO.CleanFlightList();
        }
    }

   
}
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightProject.DAOs;

namespace FlightProject.Facades
{
    class HiddenFacade
    {
        GeneralDAOMSSQL generalDAO;

        internal HiddenFacade()
        {
            generalDAO = new GeneralDAOMSSQL();
        }

        public void clearDb()
        {
            generalDAO.DBClear();
        }

        public void DbTestPrep()
        {
            generalDAO.DBTestPrep();
        }

        public void CleanFlightList()
        {
            generalDAO.CleanFlightList();
        }
    }
}
>>>>>>> 62807a85e985d18b4f08d83f3533f802794deebb
