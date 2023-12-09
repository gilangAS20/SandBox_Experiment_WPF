using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationRoom.Models
{
    public class RoomID
    {

        public int FloorNumber { get; }
        public int RoomNumber { get; }

        public RoomID(int floorNumber, int roomNumber)
        {
            FloorNumber = floorNumber;
            RoomNumber = roomNumber;
        }

        public override string ToString()
        {
            return $"{FloorNumber}{RoomNumber}";
        }

        public override bool Equals(object obj)
        {
            return obj is RoomID roomID && 
                FloorNumber == roomID.FloorNumber && 
                RoomNumber == roomID.RoomNumber; 
        }

        public override int GetHashCode()
        {
            // code di bawah gagal entah kenapa
            //return HashCode.Combine(FloorNumber, RoomNumber);
            return null;
        }
    }
}
