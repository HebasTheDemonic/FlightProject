using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightProject.Exceptions;

namespace FlightProject.POCOs
{
    internal class Flight : IPoco
    {
        internal int Id { get; set; }
        internal int AirlineCompanyId { get; set; }
        internal int OriginCountryId { get; set; }
        internal int DestinationCountryId { get; set; }
        internal string DepartureTime { get; set; }
        internal string LandingTime { get; set; }
        internal string FlightStatus { get; set; }
        internal int TotalTickets { get; set; }
        internal int RemainingTickets { get; set; }

        public Flight()
        {
        }

        public Flight(int airlineCompanyId, int originCountryId, int destinationCountryId, string departureTime, string landingTime, int totalTickets)
        {
            AirlineCompanyId = airlineCompanyId;
            OriginCountryId = originCountryId;
            DestinationCountryId = destinationCountryId;
            DepartureTime = departureTime ?? throw new ArgumentNullException(nameof(departureTime));
            LandingTime = landingTime ?? throw new ArgumentNullException(nameof(landingTime));
            TotalTickets = totalTickets;
        }

        public Flight(int id, int airlineCompanyId, int originCountryId, int destinationCountryId, string departureTime, string landingTime, string flightStatus, int totalTickets, int remainingTickets) : this (airlineCompanyId, originCountryId, destinationCountryId, departureTime, landingTime, totalTickets)
        {
            Id = id;
            FlightStatus = flightStatus ?? throw new ArgumentNullException(nameof(flightStatus));
            RemainingTickets = remainingTickets;
        }

        public static bool operator ==(Flight flight, Flight flight1) => flight.Equals(flight1);

        public static bool operator !=(Flight flight, Flight flight1) => !(flight == flight1);

        public override bool Equals(object obj)
        {
            var flight = obj as Flight;
            return flight != null &&
                   AirlineCompanyId == flight.AirlineCompanyId &&
                   OriginCountryId == flight.OriginCountryId &&
                   DestinationCountryId == flight.DestinationCountryId;
        }

        public override int GetHashCode()
        {
            return 5000000 + Id.GetHashCode();
        }
    }
}
