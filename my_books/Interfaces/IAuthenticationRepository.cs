using my_books.Models;

namespace my_books.Interfaces
{
    public interface IAuthenticationRepository
    {
        string LoginAuthor(LoginAuthors loginAuthors);
        bool EixisAuthor(string username);
    }
}
