using Microsoft.Extensions.Configuration;
using DL;
using Entities;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BL
{

    public class UserBL : IUserBL
    {
        IUserDL IUserDl;
        public IConfiguration _configuration { get; }
        public UserBL(IUserDL IUserDl, IConfiguration configuration)
        {
            this.IUserDl = IUserDl;
            _configuration = configuration;
        }
        public async Task<User> GetUser(string email, string password)
        {

            User user =await IUserDl.GetUser(email, password);
            if (user == null) return null;
      
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration.GetSection("key").Value);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);
            return user;
        }
    }
}
