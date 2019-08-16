using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightProject.Exceptions;

namespace FlightProject.POCOs
{
    public class Customer : IPoco, IUser
    {
        internal int Id { get; set; }
        internal string FirstName { get; set; }
        internal string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        internal string Address { get; set; }
        internal int PhoneNo { get; set; }
        internal int CreditCardNumber { get; set; }

        internal Customer()
        {
        }

        internal Customer(string userName, string password)
        {
            UserName = userName ?? throw new ArgumentNullException(nameof(userName));
            Password = password ?? throw new ArgumentNullException(nameof(password));
        }

        internal Customer(string firstName, string lastName, string userName, string password, string address, int phoneNo, int creditCardNumber) : this (userName, password)
        {
            FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
            Address = address ?? throw new ArgumentNullException(nameof(address));
            PhoneNo = phoneNo;
            CreditCardNumber = creditCardNumber;
        }

        internal Customer(int iD, string firstName, string lastName, string userName, string password, string address, int phoneNo, int creditCardNumber) : this (firstName, lastName, userName, password, address, phoneNo, creditCardNumber)
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
