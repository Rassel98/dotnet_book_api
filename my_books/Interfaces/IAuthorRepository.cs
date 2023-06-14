using my_books.Dto;
using my_books.Models;

namespace my_books.Interfaces
{
    public interface IAuthorRepository
    {
        ICollection<Author> GetAllAuthors();
        Author GetAuthor(int id);
        AuthorWithBookDto GetAuthorWithBooksTitle(int id);
        AuthorWithBooks GetAuthorWithBook(int id);
        AuthorWithBooks2 GetAuthorWithBook2(int id);
        AuthorWithBooks3 GetAuthorWithBook3(int id);
        bool EixisAuthors(int id);
        bool CreateAuthor(Author author);
        bool UpdateAuthor(Author author);
        bool DeleteAuthor(Author author);
        bool Save();
    }
}
