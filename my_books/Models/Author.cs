using System.ComponentModel.DataAnnotations;

namespace my_books.Models
{
    public class Author
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public ICollection<Book_Author> Book_Authors { get; set; }
    }
}
