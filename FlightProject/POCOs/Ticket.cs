using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightProject.Exceptions;

namespace FlightProject.POCOs
{
    internal class Ticket : IPoco
    {
        internal int Id { get; set; }
        internal int FlightId { get; set; }
        internal int CustomerId { get; set; }

        public Ticket()
        {
        }

        public Ticket(int flightId, int customerId)
        {
            FlightId = flightId;
            CustomerId = customerId;
        }

        public Ticket(int id, int flightId, int customerId) : this(id, flightId)
        {
            CustomerId = customerId;
        }

        public static bool operator ==(Ticket ticket, Ticket ticket1) => ticket.Equals(ticket1);

        public static bool operator !=(Ticket ticket, Ticket ticket1) => !(ticket == ticket1);

        public override bool Equals(object obj)
        {
            var ticket = obj as Ticket;
            return ticket != null &&
                   FlightId == ticket.FlightId &&
                   CustomerId == ticket.CustomerId;
        }

        public override int GetHashCode()
        {
            return 6000000 + Id.GetHashCode();
        }
    }
}
