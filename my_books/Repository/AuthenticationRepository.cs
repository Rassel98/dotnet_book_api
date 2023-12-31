﻿using Microsoft.IdentityModel.Tokens;
using my_books.Common;
using my_books.Data;
using my_books.Interfaces;
using my_books.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace my_books.Repository
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthenticationRepository(AppDbContext context,IConfiguration configuration)
        {
           _context = context;
           _configuration = configuration;
        }

        public bool EixisAuthor(string username)
        {
            return _context.Authors.Any(e => e.Name == username);
        }

        public string LoginAuthor(LoginAuthors loginAuthors)
        {
            var _user=_context.Authors.FirstOrDefault(
                e=>e.Name== loginAuthors.UserName 
                && e.Password == CommonMethod.ConvertToEncrypt(loginAuthors.Password));
            if (_user == null) return "";
            var  token = GenerateToken(_user.Name);
            return token;
        }

        private String GenerateToken(string name)
        {
            var claim = new[]
            {
                new Claim( JwtRegisteredClaimNames.Sub,name),

                new Claim( JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
              
            };
            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var signingCredential = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claim,
                expires: DateTime.Now.AddDays(7),
                signingCredentials: signingCredential

                );
            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}
