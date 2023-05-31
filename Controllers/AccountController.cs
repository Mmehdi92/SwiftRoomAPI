using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SwiftRoomAPI.Contracts;
using SwiftRoomAPI.Models.Users;

namespace SwiftRoomAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthManager _authManager;

        public AccountController(IAuthManager authManager)
        {
            this._authManager = authManager;
        }


        [HttpPost]
        [Route("register")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> RegisterUser( [FromBody]ApiUserDto apiUserDto)
        {
            var errors = await _authManager.RegisterUser(apiUserDto);
            if (errors.Any()) {
            foreach (var error in errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }

            return Ok();
        }


        [HttpPost]
        [Route("login")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Login([FromBody] LogInDto logInDto)
        {
            var authResponse = await _authManager.LogIn(logInDto);
            if (authResponse is null)
            {
                return Unauthorized();  
            }
            return Ok(authResponse);    
        }



        //[HttpPost]
        //[Route("refreshtoken")]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //public async Task<ActionResult> RefreshToken([FromBody] AuthResponseDto reqeust)
        //{
        //    var authResponse = await _authManager.VerifyRefreshToken(reqeust);
        //    if (authResponse is null)
        //    {
        //        return Unauthorized();
        //    }
        //    return Ok(authResponse);
        //}
    }
}
