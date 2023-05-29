using System.ComponentModel.DataAnnotations.Schema;

namespace SwiftRoomAPI.Models.Appointment
{
    public class AppointmentDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Begin { get; set; }
        public DateTime End { get; set; }
        public int RoomId { get; set; }
    }
}