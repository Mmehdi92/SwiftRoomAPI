using Microsoft.AspNetCore.Identity;

namespace SwiftRoomAPI.Data
{
    public class ApiUser: IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ImageUrl { get; set; }
        public string CompanyName { get; set; } 
        // contains Id from IdentityUser 

    }
}
