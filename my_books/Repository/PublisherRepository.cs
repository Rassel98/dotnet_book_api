using Microsoft.EntityFrameworkCore;
using my_books.Data;
using my_books.Dto;
using my_books.Interfaces;
using my_books.Models;

namespace my_books.Repository
{
    public class PublisherRepository : IPublisherRepository
    {
        private readonly AppDbContext _context;

        public PublisherRepository(AppDbContext context)
        {
            _context = context;
        }
        public bool CreatePublisher(Publisher publisher)
        {
            _context.Publishers.Add(publisher);
            return Save();
        }

        public bool DeletePublisher(Publisher publisher)
        {
           _context.Publishers.Remove(publisher);
            return Save();
        }

        public bool ExistPublisher(int id)
        {
            return _context.Publishers.Any(x => x.Id == id);
        }

        public ICollection<Publisher> GetAllPublishers()
        {
            return _context.Publishers.ToList();
        }

        public Publisher GetPublisher(int id)
        {
            return _context.Publishers.Where(p => p.Id == id).FirstOrDefault();
        }

        public PublisherwithBook GetPublisherwithbooks(int id)
        {
           var publisher= _context.Publishers
                .Where(p => p.Id == id)
                .Select(p=>new PublisherwithBook()
                {
                     Id = p.Id,
                     Name = p.Name,
                     Description = p.Description,
                  // Book_list = (ICollection<BookWithAuthorDto>)p.Books.Select(book=> new BookWithAuthorDto()
                   Book_list = p.Books.Select(book=> new BookWithAuthorDto()
                   {
                       Id = book.Id,
                       Title = book.Title,
                       Description = book.Description,
                       IsRead = book.IsRead,
                       ReadDate = book.ReadDate,
                       Rate = book.Rate,
                       Genre = book.Genre,
                       CoverUrl = book.CoverUrl,
                       AddedDate = book.AddedDate,
                       PublisherName = book.Publisher.Name,
                       AuthorsName = book.Book_Authors.Select(a => a.Author.Name).ToList()

                   }).ToList()
                })
                .FirstOrDefault();
            return publisher;
        }

        public bool Save()
        {
           return _context.SaveChanges()>0;
        }

        public bool UpdatePublisher(Publisher publisher)
        {
            _context.Publishers.Update(publisher);
            return Save();
        }
    }
}
