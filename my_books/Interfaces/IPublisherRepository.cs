using my_books.Dto;
using my_books.Models;

namespace my_books.Interfaces
{
    public interface IPublisherRepository
    {
        ICollection<Publisher> GetAllPublishers();
        Publisher GetPublisher(int id);
        PublisherwithBook GetPublisherwithbooks(int id);
        bool ExistPublisher(int id);
        bool CreatePublisher(Publisher publisher);
        bool UpdatePublisher(Publisher publisher);
        bool DeletePublisher(Publisher publisher);
        bool Save();
    }
}
