using my_books.Models;
using System.ComponentModel.DataAnnotations;

namespace my_books.Dto
{
    public class BookDto
    {
       
        public string Title { get; set; }  
        public string Description { get; set; }
        public bool IsRead { get; set; }
        public DateTime? ReadDate { get; set; }
        public int? Rate { get; set; }
        public string? Genre { get; set; }
        public string? CoverUrl { get; set; }
        public int PublisherId { get; set; }
        public List<int> AuthorsIds { get; set; }
    }
    public class BookWithAuthorDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsRead { get; set; }
        public DateTime? ReadDate { get; set; }
        public int? Rate { get; set; }
        public string? Genre { get; set; }
        public string? CoverUrl { get; set; }
        public DateTime AddedDate { get; set; }
        public string PublisherName { get; set; }
        public List<String> AuthorsName { get; set; }
    }
    public class Book2
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsRead { get; set; }
        public DateTime? ReadDate { get; set; }
        public int? Rate { get; set; }
        public string? Genre { get; set; }
        public string? CoverUrl { get; set; }
        public DateTime AddedDate { get; set; }
       
    }
    public class Book3
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Publisher Publisher { get; set; }

    }
}
