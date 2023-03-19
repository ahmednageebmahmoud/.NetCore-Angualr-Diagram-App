using Draw.BLL.Interface;
using Draw.Core.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Draw.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            this._authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel registerModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var Result = await this._authService.Register(registerModel);
            if (!Result.IsAuthenticated)
            {
                return BadRequest(Result.Message);
            }


            return Ok(Result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var Result = await this._authService.Login(loginModel);
            if (!Result.IsAuthenticated)
            {
                return BadRequest(Result.Message);
            }


            return Ok(Result);
        }
    }
}
