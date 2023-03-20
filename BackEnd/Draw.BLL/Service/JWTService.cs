using Draw.Core.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Draw.BLL.Model;
using Draw.BLL.Interface;

namespace Draw.BLL.Service
{
    public class JWTService:IJWTService
    {
        private readonly UserManager<ApplicationUser> _userManger;
        private readonly JWT _jwt;
        public JWTService(UserManager<ApplicationUser> userManger, IOptions<JWT> jwt)
        {
            _userManger = userManger;
            _jwt = jwt.Value;
        }

        public async Task<string> Create(ApplicationUser user)
        {
            var Roles = await _userManger.GetRolesAsync(user);
            var UserClimes = await _userManger.GetClaimsAsync(user);

            foreach (var role in Roles)
            {
                UserClimes.Add(new Claim("roles", role));
            }

            var Clamis = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,user.UserName),
                new Claim(JwtRegisteredClaimNames.Email,user.Email),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
            new Claim("uid",user.Id)// This Value Will Read In Action To Define Current User Like User.FindFirst("uid").Value
            }.Union(UserClimes);

            var SymmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this._jwt.Key));
            var SigningCredentials = new SigningCredentials(SymmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var Token = new JwtSecurityToken(
                issuer: this._jwt.Issure,
                audience: this._jwt.Audince,
                claims: Clamis,
                expires: DateTime.Now.AddDays(this._jwt.DurationDays),
                signingCredentials: SigningCredentials
            );
            return new JwtSecurityTokenHandler().WriteToken(Token);
        }
    }
}
