using System.ComponentModel.DataAnnotations;

namespace my_books.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public bool IsRead { get; set; }
        public DateTime? ReadDate { get; set; }
        public int? Rate { get; set; }
        public string? Genre { get; set; }
        public string? CoverUrl { get; set; }
        public DateTime AddedDate { get; set; }
        //navigation properties
        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }
        public ICollection< Book_Author> Book_Authors { get; set; }
    }
}
