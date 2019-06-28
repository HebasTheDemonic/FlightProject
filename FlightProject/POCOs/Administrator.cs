using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightProject.Exceptions;

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
            Username = username ?? throw new ArgumentNullException(nameof(username));
            Password = password ?? throw new ArgumentNullException(nameof(password));
        }

        public Administrator(int id, string username, string password) : this(username, password)
        {
            Id = id;
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
            return 1000000 + Id.GetHashCode();
        }
    }
}
