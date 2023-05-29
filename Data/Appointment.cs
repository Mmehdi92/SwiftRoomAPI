﻿using System.ComponentModel.DataAnnotations.Schema;

namespace SwiftRoomAPI.Data
{
    public class Appointment
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Begin { get; set; }
        public DateTime End { get; set; }

        [ForeignKey(nameof(RoomId))]
        public int? RoomId { get; set; }
        public Room Room { get; set; }
    }
}
