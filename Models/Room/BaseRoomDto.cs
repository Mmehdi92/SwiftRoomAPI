using System.ComponentModel.DataAnnotations;

namespace SwiftRoomAPI.Models.Room
{
    public abstract class BaseRoomDto
    {
        [Required]
        public string Name { get; set; }
        public string ShortName { get; set; }
    }

}
