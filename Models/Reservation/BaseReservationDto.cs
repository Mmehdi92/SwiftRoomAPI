using SwiftRoomAPI.Data;
using SwiftRoomAPI.Models.Reservation;

namespace SwiftRoomAPI.Models.Reservation
{
    public class BaseReservationDto
    {
       
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}

