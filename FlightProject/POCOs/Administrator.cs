using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightProject.POCOs
{
    internal class Administrator : IPoco, IUser
    {
        internal int Id { get; set; }
        internal string Username { get; set; }
        internal string Password { get; set; }

        public Administrator()
        {
        }

        public Administrator(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public Administrator(int id, string username, string password)
        {
            Id = id;
            Username = username;
            Password = password;
        }

        public static bool operator ==(Administrator administrator1, Administrator administrator2) => administrator1.Equals(administrator2);

        public static bool operator !=(Administrator administrator1, Administrator administrator2) => !(administrator1 == administrator2);

        public override bool Equals(object obj)
        {
            var administrator = obj as Administrator;
            if (Username == null || administrator.Username == null)
            {
                throw new CorruptedDataException();
            }
            return administrator != null &&
                   Username == administrator.Username;
        }

        public override int GetHashCode()
        {
            if (this.Id == 0)
            {
                throw new UnregisteredUserException();
            }
            return 100 + Id;
        }
    }
}
