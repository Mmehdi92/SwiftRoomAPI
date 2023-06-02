using System.ComponentModel.DataAnnotations;

namespace SwiftRoomAPI.Models.Appointment
{
    public class CreateAppointmentDto: BaseAppointmentDto
    {
        [Required]
        public string ApiUserId { get; set; }
        [Required]
        public int RoomId { get; set; } 
    }
}