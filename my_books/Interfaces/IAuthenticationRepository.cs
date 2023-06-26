using my_books.Models;

namespace my_books.Interfaces
{
    public interface IAuthenticationRepository
    {
        string LoginAuthor(string username);
        bool EixisAuthor(string username);
    }
}
