using my_books.Models;

namespace my_books.Dto
{
    public class AuthorDto
    {
      
        public string? Name { get; set; }
        public string? Password { get; set; }
        public string? Description { get; set; }
    }
    public class AuthorDto2
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
    }
    public class AuthorWithBookDto
    {

        public string Name { get; set; }
        public string? Description { get; set; }
        public List<string> BookTitle { get; set; }
    }

    public class AuthorWithBooks2
    {

        public string Name { get; set; }
        public string? Description { get; set; }
        public List<Book> book_list { get; set; }
    }
    public class AuthorWithBooks3
    {

        public string Name { get; set; }
        public string? Description { get; set; }
        public List<Book3> book_list { get; set; }
    }

    public class AuthorWithBooks
    {

        public string Name { get; set; }
        public string? Description { get; set; }
        public List<Book2> book_list { get; set; }
    }
}
