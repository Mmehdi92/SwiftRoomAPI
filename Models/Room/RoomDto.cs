using SwiftRoomAPI.Models.Appointment;

namespace SwiftRoomAPI.Models.Room
{
    public class RoomDto: BaseRoomDto
    {
        public int Id { get; set; }
   
        public List<AppointmentDto> Appointments { get; set; }
    }

}

