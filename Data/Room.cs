namespace SwiftRoomAPI.Data
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }


        public virtual IList<Room> Rooms { get; set; }
    }
}