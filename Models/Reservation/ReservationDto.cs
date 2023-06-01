using SwiftRoomAPI.Data;

namespace SwiftRoomAPI.Models.Reservation
{
    public class ReservationDto: BaseReservationDto
    {
        public int RoomId { get; set; }

        public string ApiUserId { get; set; }
    }
}
