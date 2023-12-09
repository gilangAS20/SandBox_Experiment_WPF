using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using ReservationRoom.Models;

namespace ReservationRoom.Exceptions
{
    class ReservationConflictException : Exception
    {
        public Reservation ExistingReservation { get; }
        public Reservation IncomingReservation { get; }
        public ReservationConflictException()
        {
        }

        public ReservationConflictException(string message) : base(message)
        {
        }

        public ReservationConflictException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ReservationConflictException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public ReservationConflictException(Reservation existingReservation, Reservation incomingReservation)
        {
            ExistingReservation = existingReservation;
            IncomingReservation = incomingReservation;
        }
    }
}
