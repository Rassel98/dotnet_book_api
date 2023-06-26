using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_books.Dto;
using my_books.Interfaces;
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
        public IActionResult Login([FromBody] AuthorDto author)
        {
            if (!ModelState.IsValid) return BadRequest();
            if (!_authenticationRepository.EixisAuthor(author.Name)) return BadRequest("user not found");
            var token=_authenticationRepository.LoginAuthor(author.Name);
            return Ok(new { Token = token, Message = "Success" });
        }
    }
}
