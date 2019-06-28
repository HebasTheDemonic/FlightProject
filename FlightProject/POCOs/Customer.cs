using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightProject.Exceptions;

namespace FlightProject.POCOs
{
    internal class Customer : IPoco, IUser
    {
        internal int Id { get; set; }
        internal string FirstName { get; set; }
        internal string LastName { get; set; }
        internal string UserName { get; set; }
        internal string Password { get; set; }
        internal string Address { get; set; }
        internal int PhoneNo { get; set; }
        internal int CreditCardNumber { get; set; }

        public Customer()
        {
        }

        public Customer(string firstName, string lastName, string userName, string password, string address, int phoneNo, int creditCardNumber)
        {
            FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
            UserName = userName ?? throw new ArgumentNullException(nameof(userName));
            Password = password ?? throw new ArgumentNullException(nameof(password));
            Address = address ?? throw new ArgumentNullException(nameof(address));
            PhoneNo = phoneNo;
            CreditCardNumber = creditCardNumber;
        }

        public Customer(int iD, string firstName, string lastName, string userName, string password, string address, int phoneNo, int creditCardNumber) : this (firstName, lastName, userName, password, address, phoneNo, creditCardNumber)
        {
            Id = iD;
        }

        public static bool operator ==(Customer customer, Customer customer1) => customer.Equals(customer1);

        public static bool operator !=(Customer customer, Customer customer1) => !(customer == customer1);

        public override bool Equals(object obj)
        {
            var customer = obj as Customer;
            if (UserName == null || customer.UserName == null)
            {
                throw new CorruptedDataException();
            }
            return customer != null &&
                   UserName == customer.UserName;
        }

        public override int GetHashCode()
        {
            return 3000000 + Id.GetHashCode();
        }
    }
}
