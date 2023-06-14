using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_books.Dto;
using my_books.Interfaces;
using my_books.Models;
using my_books.Repository;

namespace my_books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private readonly IPublisherRepository _publisherRepository;
        private readonly IMapper _mapper;

        public PublisherController(IPublisherRepository publisherRepository,IMapper mapper)
        {
            _publisherRepository = publisherRepository;
            _mapper = mapper;
        }
        [HttpGet("all_publishers")]
        [ProducesResponseType(200,Type=typeof(IEnumerable<Publisher>))]
        [ProducesResponseType(400)]
        public IActionResult GetAllPublishers()
        {
            if(!ModelState.IsValid)return BadRequest(ModelState);
            var publishers=_publisherRepository.GetAllPublishers();
            return Ok(new
            {
                message="Data comes successfully",
                data=publishers
            });
        }
        [HttpGet("all_publishers/{id}")]
        [ProducesResponseType(200,Type=typeof(Publisher))]
        [ProducesResponseType (200)]
        public IActionResult GetPublisher(int id)
        {
            try
            {
                if (!_publisherRepository.ExistPublisher(id))
                    return StatusCode(404, "publisher not found");
                var publisher = _publisherRepository.GetPublisher(id);
                return Ok(new
                {
                    message = "Data comes successfully",
                    data = publisher
                });
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("all_publisherwithbook/{id}")]
        [ProducesResponseType(200, Type = typeof(Publisher))]
        [ProducesResponseType(200)]
        public IActionResult GetPublisherwithbook(int id)
        {
            try
            {
                if (!_publisherRepository.ExistPublisher(id))
                    return StatusCode(404, "publisher not found");
                var publisher = _publisherRepository.GetPublisherwithbooks(id);
                return Ok(new
                {
                    message = "Data comes successfully",
                    data = publisher
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost()]
        [Route("add_publisher")]
        [ProducesResponseType(201)]
        public IActionResult CreatePublisher([FromBody] PublisherDto publisher)
        {
            if (publisher == null) return BadRequest();
            var publisherMap = _mapper.Map<Publisher>(publisher);
            if (!_publisherRepository.CreatePublisher(publisherMap))
                return StatusCode(500, "Internal server error");
            return Ok(new
            {
                message = "Data comes successfully",
                data = publisher
            });
        }
        [HttpPut("add_publisher/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult UpdateAuthors(int id, [FromBody] PublisherDto updatePublisher)
        {
            if (updatePublisher == null) return BadRequest();
            if (!_publisherRepository.ExistPublisher(id))
                return StatusCode(404, new { message = "Author not found" });
            var publisher = _publisherRepository.GetPublisher(id);
            publisher.Id = id;
            publisher.Description = updatePublisher.Description;
            publisher.Name = updatePublisher.Name;
            if (!_publisherRepository.UpdatePublisher(publisher))
                return StatusCode(500, new
                {
                    message = "internal server error"
                });
            return StatusCode(200, new
            {
                message = "Data updated successfully",
                data = publisher

            });

        }
        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult DeleteAuthor(int id)
        {
            if (!_publisherRepository.ExistPublisher(id))
                return BadRequest("Author not found");
            var publisher = _publisherRepository.GetPublisher(id);
            if (!_publisherRepository.DeletePublisher(publisher))
                return StatusCode(500, "Internal Server Error");
            return StatusCode(200, "publisher deleted Successfully");
        }

    }
}
