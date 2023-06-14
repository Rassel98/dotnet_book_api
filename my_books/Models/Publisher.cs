using System.ComponentModel.DataAnnotations;

namespace my_books.Models
{
    public class Publisher
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public ICollection<Book> Books { get; set; }
    }

    public class Publisher2
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
       
    }
}
