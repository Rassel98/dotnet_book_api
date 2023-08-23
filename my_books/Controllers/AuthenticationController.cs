using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_books.Dto;
using my_books.Interfaces;
using my_books.Models;
using System.IdentityModel.Tokens.Jwt;

namespace my_books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationRepository _authenticationRepository;

        public AuthenticationController(IAuthenticationRepository authenticationRepository)
        {
           _authenticationRepository = authenticationRepository;
        }
        [HttpPost]
        [Route("author_login")]
        public IActionResult Login([FromBody] LoginAuthors author)
        {
            if (!ModelState.IsValid) return BadRequest();
            if (!_authenticationRepository.EixisAuthor(author.UserName)) return BadRequest("user not found");
            var token = _authenticationRepository.LoginAuthor(author);
            if (token == "") return BadRequest(" username or password not match");
            return Ok(new { Token = token, Message = "Success" });
        }
    }
}
