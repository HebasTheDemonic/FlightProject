﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightProject.Exceptions;

namespace FlightProject.POCOs
{
    public class Administrator : IPoco, IUser
    {
        internal int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        internal Administrator()
        {
        }

        // This constructor is for registering new administrators and for making an Administrator object for login service.

        internal Administrator(string username, string password)
        {
            UserName = username ?? throw new ArgumentNullException(nameof(username));
            Password = password ?? throw new ArgumentNullException(nameof(password));
        }

        // This constructor is for an Administrator object pulled from the database.

        internal Administrator(int id, string username, string password) : this(username, password)
        {
            Id = id;
        }

        public static bool operator ==(Administrator administrator1, Administrator administrator2) => administrator1.Equals(administrator2);

        public static bool operator !=(Administrator administrator1, Administrator administrator2) => !(administrator1 == administrator2);

        public override bool Equals(object obj)
        {
            var administrator = obj as Administrator;
            if (UserName == null || administrator.UserName == null)
            {
                throw new CorruptedDataException();
            }
            return administrator != null &&
                   UserName == administrator.UserName;
        }

        public override int GetHashCode()
        {
            return 1000000 + Id.GetHashCode();
        }
    }
}
