using my_books.Dto;
using my_books.Models;

namespace my_books.Interfaces
{
    public interface IBookRepository
    {
        ICollection<Book> GetAllBooks();
        Book GetBook(int id);
        BookWithAuthorDto GetBookBookWithAuthorDto(int id);
        bool BookiExists(int id);
        bool CreateNewBook(BookDto book);
        bool UpdateBook(Book book);
        bool DeleteBook(Book book);
        bool Save();
    }
}
