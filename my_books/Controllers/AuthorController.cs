using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_books.Common;
using my_books.Dto;
using my_books.Interfaces;
using my_books.Models;
using my_books.Repository;

namespace my_books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public AuthorController(IAuthorRepository authorRepository,IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("all_authors")]
        [ProducesResponseType(200, Type=typeof(IEnumerable<Author>))]
        [ProducesResponseType(400)]
        public IActionResult GetAllAuthors()
        {
            if(!ModelState.IsValid)return BadRequest(ModelState);
            var authors=_mapper.Map<List<AuthorDto2>>(_authorRepository.GetAllAuthors());
            return Ok(new {message="Data get Successfully",data=authors});
        }
        [HttpGet]
        [Route("all_authors/{id}")]
        [ProducesResponseType(200, Type = typeof(AuthorDto2))]
        [ProducesResponseType(400)]
        [Authorize]
        public IActionResult GetBooks(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!_authorRepository.EixisAuthors(id))
                return StatusCode(404, new { message = "Book not found" });
            var author = _mapper.Map<AuthorDto2>(_authorRepository.GetAuthor(id));
            return Ok(new
            {
                message = "Data coming successfully",
                data = author
            });
        }

        [Authorize]
        [HttpGet]
        [Route("all_authorswithbooktitle/{id}")]
        [ProducesResponseType(200, Type = typeof(AuthorWithBookDto))]
        [ProducesResponseType(400)]
        public IActionResult GetAuthorWithBook(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!_authorRepository.EixisAuthors(id))
                return StatusCode(404, new { message = "Book not found" });
            var author = _authorRepository.GetAuthorWithBooksTitle(id);
            return Ok(new
            {
                message = "Data coming successfully",
                data = author
            });
        }

        [HttpGet]
        [Route("all_authorswithbooks/{id}")]
        [ProducesResponseType(200, Type = typeof(AuthorWithBooks))]
        [ProducesResponseType(400)]
        public IActionResult GetAuthorWithBooks(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!_authorRepository.EixisAuthors(id))
                return StatusCode(404, new { message = "Book not found" });
            var author = _authorRepository.GetAuthorWithBook(id);
            return Ok(new
            {
                message = "Data coming successfully",
                data = author
            });
        }

        [HttpGet]
        [Route("all_authorswithbooks2/{id}")]
        [ProducesResponseType(200, Type = typeof(AuthorWithBooks))]
        [ProducesResponseType(400)]
        public IActionResult GetAuthorWithBooks2(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!_authorRepository.EixisAuthors(id))
                return StatusCode(404, new { message = "Book not found" });
            var author = _authorRepository.GetAuthorWithBook2(id);
            return Ok(new
            {
                message = "Data coming successfully",
                data = author
            });
        }
        [HttpGet]
        [Route("all_authorswithbooks3/{id}")]
        [ProducesResponseType(200, Type = typeof(AuthorWithBooks3))]
        [ProducesResponseType(400)]
        public IActionResult GetAuthorWithBooks3(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!_authorRepository.EixisAuthors(id))
                return StatusCode(404, new { message = "Book not found" });
            var author = _authorRepository.GetAuthorWithBook3(id);
            return Ok(new
            {
                message = "Data coming successfully",
                data = author
            });
        }

        [HttpPost]
        [Route("add_author")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public IActionResult GetBooks([FromBody] AuthorDto author)
        {
            if (author == null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var auhorMap = _mapper.Map<Author>(author);
            if (!_authorRepository.CreateAuthor(auhorMap))
                return StatusCode(500, "internal server error");
            ;
            return StatusCode(201, new
            {
                message = "Data saved successfully",

            });
        }
        [HttpPut("add_authors/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult UpdateAuthors(int id, [FromBody] AuthorDto author)
        {
            if (author == null) return BadRequest();
            if (!_authorRepository.EixisAuthors(id))
                return StatusCode(404, new { message = "Author not found" });
            var auth= _authorRepository.GetAuthor(id);
            var pass = CommonMethod.ConvertToEncrypt(author.Password);
            auth.Id = id;
            auth.Description = author.Description??auth.Description;
            auth.Password = author.Password==null?auth.Password:pass;
            auth.Name = author.Name==null ? auth.Name:author.Name;
            auth.Book_Authors = auth.Book_Authors;
            if (!_authorRepository.UpdateAuthor(auth))
                return StatusCode(500, new
                {
                    message = "internal server error"
                });
            return StatusCode(200, new
            {
                message = "Data updated successfully",
                data=auth

            });

        }
        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult DeleteAuthor(int id)
        {
            if(!_authorRepository.EixisAuthors(id))
                return BadRequest("Author not found");
            var author=_authorRepository.GetAuthor(id);
            if (!_authorRepository.DeleteAuthor(author))
                return StatusCode(500, "Internal Server Error");
            return StatusCode(200, "author deleted Successfully");
        }
    }
}
