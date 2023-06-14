using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_books.Dto;
using my_books.Interfaces;
using my_books.Models;
using System.Diagnostics.Metrics;

namespace my_books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public BookController(IBookRepository bookRepository,IMapper mapper)
        {
           _bookRepository = bookRepository;
        _mapper = mapper;
        }
        [HttpGet]
        [Route("all_books")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Book>))]
        [ProducesResponseType(400)]
        public IActionResult GetAllBooks()
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var books = _bookRepository.GetAllBooks();
            return Ok(new {message="Data coming successfully",
            data=books});
        }
        [HttpGet]
        [Route("all_books/{id}")]
        [ProducesResponseType(200, Type = typeof(Book))]
        [ProducesResponseType(400)]
        public IActionResult GetBooks(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(!_bookRepository.BookiExists(id))
                return StatusCode(404,new {message="Book not found"});
            var book = _bookRepository.GetBook(id);
            return Ok(new
            {
                message = "Data coming successfully",
                data = book
            });
        }
        [HttpGet]
        [Route("all_bookswithpublishername/{id}")]
        [ProducesResponseType(200, Type = typeof(BookWithAuthorDto))]
        [ProducesResponseType(400)]
        public IActionResult GetBookWithPublisherName(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!_bookRepository.BookiExists(id))
                return StatusCode(404, new { message = "Book not found" });
            var book = _bookRepository.GetBookBookWithAuthorDto(id);
            return Ok(new
            {
                message = "Data coming successfully",
                data = book
            });
        }
        [HttpPost]
        [Route("add_new_book")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public IActionResult GetBooks([FromBody]BookDto book)
        {
            if(book ==null )
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
           // var bookMap = _mapper.Map<Book>(book);
            if (!_bookRepository.CreateNewBook(book))
                return StatusCode(500, "internal server error");
             ;
            return StatusCode(201,new
            {
                message = "Data saved successfully",
               
            });
        }

      
        [HttpPut("update_book/{id}")]
        
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult UpdateBook(int id,[FromBody] BookDto updatebook)
        {
            if (updatebook == null)
                return BadRequest(ModelState);
            if(!_bookRepository.BookiExists(id))
                return StatusCode(404, new { message = "Book not found" });

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var book = _bookRepository.GetBook(id);

            book.Title = updatebook.Title;
            book.Id= id;           
            book.Description = updatebook.Description;
            book.AddedDate = DateTime.Now;
            book.ReadDate = updatebook.IsRead==true?updatebook.ReadDate:null;
            book.IsRead = updatebook.IsRead;
            book.CoverUrl = updatebook.CoverUrl;        

            //var bookMap = _mapper.Map<Book>(book);
            if (!_bookRepository.UpdateBook(book))
                return StatusCode(500, "internal server error");
            ;
            return StatusCode(200, new
            {
                message = "Data updated successfully",

            });
        }
        [HttpDelete("delete_book/{id}")]

        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult DeleteBook(int id)
        {
         
            if (!_bookRepository.BookiExists(id))
                return StatusCode(404, new { message = "Book not found" });

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var book = _bookRepository.GetBook(id);
            //var bookMap = _mapper.Map<Book>(book);
            if (!_bookRepository.DeleteBook(book))
                return StatusCode(500, "internal server error");
            ;
            return StatusCode(200, new
            {
                message = "Data deleted successfully",

            });
        }
    }
}
