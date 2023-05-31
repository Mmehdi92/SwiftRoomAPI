using Microsoft.AspNetCore.Identity;
using SwiftRoomAPI.Models.Users;

namespace SwiftRoomAPI.Contracts
{
    public interface IAuthManager
    {
        Task<IEnumerable<IdentityError>> RegisterUser(ApiUserDto userDto);
        Task<AuthResponseDto> LogIn(LogInDto logInDto);
        //Task<string> CreateRefreshToken();
        //Task<AuthResponseDto> VerifyRefreshToken(AuthResponseDto request);
    }
}
