using Microsoft.EntityFrameworkCore;
using my_books.Data;
using my_books.Dto;
using my_books.Interfaces;
using my_books.Models;

namespace my_books.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _context;

        public BookRepository(AppDbContext context)
        {
            _context = context;
        }
        public bool BookiExists(int id)
        {
           return _context.Books.Any(x => x.Id == id);
        }

        public bool CreateNewBook(BookDto book)
        {
            var _book = new Book()
            {
                Title = book.Title,
                Description = book.Description,
                IsRead = book.IsRead,
                ReadDate = book.IsRead ? book.ReadDate.Value : null,
                Rate = book.IsRead ? book.Rate.Value:null,
                Genre = book.Genre,
                CoverUrl = book.CoverUrl,
                AddedDate = DateTime.Now,
                PublisherId = book.PublisherId,
            };

            _context.Books.Add(_book);
            _context.SaveChanges();
            foreach (var i in book.AuthorsIds)
            {
                var _book_author = new Book_Author()
                {
                    BookId = _book.Id,
                    AuthorId = i
                };
                _context.Book_Authors.Add(_book_author);
                _context.SaveChanges();
            }
           return Save();
        }

        public bool DeleteBook(Book book)
        {
            _context.Remove(book);
            return Save();
        }

        public ICollection<Book> GetAllBooks()
        {
            return _context.Books.Include(e=>e.Publisher).ToList();
        }

        public Book GetBook(int id)
        {
            Console.WriteLine(id);
            return _context.Books.Where(b => b.Id == id).Include(e=>e.Publisher).FirstOrDefault();
        }

        public BookWithAuthorDto GetBookBookWithAuthorDto(int id)
        {
            Console.WriteLine(id);
            var _book_with_authors = _context.Books.Where(e => e.Id == id).Select(book => new BookWithAuthorDto()
            {   
                Id=book.Id,
                Title = book.Title,
                Description = book.Description,
                IsRead = book.IsRead,
                ReadDate = book.ReadDate,
                Rate =  book.Rate ,
                Genre = book.Genre,
                CoverUrl = book.CoverUrl,
                AddedDate = book.AddedDate,
                PublisherName = book.Publisher.Name,
                AuthorsName = book.Book_Authors.Select(a => a.Author.Name).ToList()

            }).FirstOrDefault();

            return _book_with_authors;
        }

        public bool Save()
        {
            var saved=_context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateBook(Book book)
        {
           _context.Update(book);
            return Save();
        }
    }
}
