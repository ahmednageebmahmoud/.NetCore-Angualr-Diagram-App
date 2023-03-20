﻿using Draw.BLL.Helpers.Auth;
using Draw.BLL.Helpers.Reponse;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Draw.API.Controllers
{
    //  [EnableCors()]
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

        public async Task<ActionResult<IResponse<AuthModel>>> Register([FromBody] RegisterModel registerModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var Reponse = await this._authService.Register(registerModel);
            if (!Reponse.IsSuccess)
            {
                return BadRequest(Reponse);
            }


            return Ok(Reponse);
        }

        [HttpPost("login")]
        public async Task<ActionResult<IResponse<AuthModel>>> Login([FromBody] LoginModel loginModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var Reponse = await this._authService.Login(loginModel);
            if (!Reponse.IsSuccess)
            {
                return BadRequest(Reponse);
            }


            return Ok(Reponse);
        }
    }
}
