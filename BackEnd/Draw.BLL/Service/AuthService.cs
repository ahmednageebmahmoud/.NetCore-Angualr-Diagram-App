using Draw.BLL.Interface;
using Draw.Core.Helpers.Consts;
using Draw.Core.Model;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw.BLL.Service
{
    public class AuthService:IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManger;
        private readonly IJWTService _jwtService;
        public AuthService(UserManager<ApplicationUser> userManger, IJWTService authService)
        {
            _userManger = userManger;
            _jwtService = authService;
        }


        public async Task<AuthModel> Register(RegisterModel register)
        {
            //Check From Email
            if (await this._userManger.FindByEmailAsync(register.Email) is not null)
                return new AuthModel { Message = "Email Is Alredy Used" };

            //Check From UserName
            if (await this._userManger.FindByNameAsync(register.UserName) is not null)
                return new AuthModel { Message = "UserName Is Alredy Used" };

            var User = new ApplicationUser
            {
                Email = register.Email,
                UserName = register.UserName,
            };

            //Create User
            var Result = await this._userManger.CreateAsync(User, register.Password);

            if (!Result.Succeeded)
                return new AuthModel { Message = String.Join("m", Result.Errors.Select(c => c.Description).ToList()) };

            //Add User Role
            Result = await this._userManger.AddToRoleAsync(User, RoleConst.User);
            if (!Result.Succeeded)
                return new AuthModel { Message = String.Join("m", Result.Errors.Select(c => c.Description).ToList()) };

            //Create JWT Token
            var Token = await this._jwtService.Create(User);
            return new AuthModel
            {
                Message = "User Register Successfully",
                IsAuthenticated = true,
                Roles = new List<string> { RoleConst.User },
                Token = Token
            };
        }

        public async Task<AuthModel> Login(LoginModel login)
        {

            var User = await this._userManger.FindByNameAsync(login.UserName);

            //Check From UserName And Password
            if (User is null || !(await _userManger.CheckPasswordAsync(User, login.Password)))
                return new AuthModel { Message = "User Name Or Password Is Incorrect" };

            //Create JWT Token
            var Token = await this._jwtService.Create(User);
            return new AuthModel
            {
                Message = "User Login Successfully",
                IsAuthenticated = true,
                Roles = new List<string> { RoleConst.User},
                Token = Token
            };
        }
    }
}
