namespace SwiftRoomAPI.Data
{
    public class Reservation
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public int RoomId { get; set; }
        public Room Room { get; set; }

        public string ApiUserId { get; set; }
        public ApiUser ApiUser { get; set; }
    }
}
