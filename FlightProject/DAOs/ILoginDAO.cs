using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightProject.DAOs
{
    internal interface ILoginDAO
    {
        int TryLogin(string userName, int loginValue);
    }
}
