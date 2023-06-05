using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SwiftRoomAPI.Models.Appointment
{
    public class AppointmentDto: BaseAppointmentDto
    {
        public int Id { get; set; }
     
        public string ApiUserId { get; set; }
        public int RoomId { get; set; }
    }

}