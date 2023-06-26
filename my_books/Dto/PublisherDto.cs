using my_books.Models;
using System.ComponentModel.DataAnnotations;

namespace my_books.Dto
{
    public class PublisherDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
       
    }

    public class PublisherwithBook
    {
       
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public ICollection<BookWithAuthorDto> Book_list { get; set; }
    }
}
