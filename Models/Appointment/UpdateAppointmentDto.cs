namespace SwiftRoomAPI.Models.Appointment
{
    public class UpdateAppointmentDto: BaseAppointmentDto
    {
        public int Id { get; set; }
        public string ApiUserId { get; set; }
        public int RoomId { get; set; }
    }

}