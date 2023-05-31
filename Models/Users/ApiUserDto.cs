using System.ComponentModel.DataAnnotations;

namespace SwiftRoomAPI.Models.Users
{
    public class ApiUserDto: LogInDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
  

    }
}
