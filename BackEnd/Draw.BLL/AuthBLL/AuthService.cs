using Draw.BLL.ReponseBLL;
using Draw.Core.Consts;
using Draw.Core.Model;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw.BLL.AuthBLL
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManger;
        private readonly IJWTService _jwtService;
        public AuthService(UserManager<ApplicationUser> userManger, IJWTService authService)
        {
            _userManger = userManger;
            _jwtService = authService;
        }


        public async Task<IResponse<AuthModel>> Register(RegisterModel register)
        {
            //Check From Email
            if (await _userManger.FindByEmailAsync(register.Email) is not null)
                return Reponse<AuthModel>.Error("Email Is Alredy Used");

            //Check From UserName
            if (await _userManger.FindByNameAsync(register.UserName) is not null)
                return Reponse<AuthModel>.Error("UserName Is Alredy Used");

            var User = new ApplicationUser
            {
                Email = register.Email,
                UserName = register.UserName,
            };

            //Create User
            var Result = await _userManger.CreateAsync(User, register.Password);

            if (!Result.Succeeded)
                return Reponse<AuthModel>.Error(string.Join("m", Result.Errors.Select(c => c.Description).ToList()));

            //Add User Role
            Result = await _userManger.AddToRoleAsync(User, RoleConst.User);
            if (!Result.Succeeded)
                return Reponse<AuthModel>.Error(string.Join("m", Result.Errors.Select(c => c.Description).ToList()));

            //Create JWT Token
            var Token = await _jwtService.Create(User);
            return Reponse<AuthModel>.Success("Register Successfully", new AuthModel
            {
                Roles = new List<string> { RoleConst.User },
                Token = Token
            });
        }

        public async Task<IResponse<AuthModel>> Login(LoginModel login)
        {

            var User = await _userManger.FindByNameAsync(login.UserName);

            //Check From UserName And Password
            if (User is null || !await _userManger.CheckPasswordAsync(User, login.Password))
                return Reponse<AuthModel>.Error("User Name Or Password Is Incorrect");

            //Create JWT Token
            var Token = await _jwtService.Create(User);
            return Reponse<AuthModel>.Success("Login Successfully", new AuthModel
            {
                Roles = new List<string> { RoleConst.User },
                Token = Token
            });
        }
    }
}
