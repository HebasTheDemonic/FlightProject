using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightProject
{
    public class LoginToken<T> where T : IUser
    {
        public T user { get; set; }
    }
}
