using System.ComponentModel.DataAnnotations;

namespace SwiftRoomAPI.Models.Appointment
{
    public abstract class BaseAppointmentDto
    {
        public string ApiUserId { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public DateTime Begin { get; set; }
        [Required]
        public DateTime End { get; set; }
      
    }

}