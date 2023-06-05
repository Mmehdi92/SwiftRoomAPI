using System.ComponentModel.DataAnnotations;

namespace SwiftRoomAPI.Models.Appointment
{
    public class CreateAppointmentDto: BaseAppointmentDto
    {
   
        public string ApiUserId { get; set; }
      
        public int RoomId { get; set; } 
    }
}