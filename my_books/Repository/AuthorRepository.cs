using Microsoft.EntityFrameworkCore;
using my_books.Data;
using my_books.Dto;
using my_books.Interfaces;
using my_books.Models;

namespace my_books.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly AppDbContext _context;

        public AuthorRepository(AppDbContext context)
        {
          _context = context;
        }
        public bool CreateAuthor(Author author)
        {
            _context.Authors.Add(author);
            return Save();
        }

        public bool DeleteAuthor(Author author)
        {
            _context.Remove(author);
            return Save();
        }

        public bool EixisAuthors(int id)
        {
            return _context.Authors.Any(a => a.Id == id);
        }

        public ICollection<Author> GetAllAuthors()
        {
            return _context.Authors.ToList();
        }

        public Author GetAuthor(int id)
        {
          return  _context.Authors.Where(a=>a.Id == id).FirstOrDefault();
        }

        public AuthorWithBookDto GetAuthorWithBooksTitle(int id)
        {
            var _author=_context.Authors.Where(e=>e.Id==id)
                .Select(n=>new AuthorWithBookDto()
                {
                    Name=n.Name,
                    Description=n.Description,
                    BookTitle=n.Book_Authors.Select(n=>n.Book.Title).ToList()
                })
                .FirstOrDefault();
            return _author;
        }

        public AuthorWithBooks GetAuthorWithBook(int id)
        {
            return _context.Authors.Where(e => e.Id == id).Select(b=>new AuthorWithBooks() 
            { Name=b.Name,
            Description=b.Description,
            book_list= b.Book_Authors.Select(book=>new Book2()
            {
                Id=book.Book.Id,
                Description=book.Book.Description,
                Title=book.Book.Title,
                AddedDate=book.Book.AddedDate,
                CoverUrl=book.Book.CoverUrl,
                Genre = book.Book.Genre,
                IsRead=book.Book.IsRead,
                Rate=book.Book.Rate,
                ReadDate = book.Book.ReadDate
               
            }).ToList()
            }).FirstOrDefault();
        }

        public AuthorWithBooks2 GetAuthorWithBook2(int id)
        {
            return _context.Authors.Where(e => e.Id == id).Select(b => 
            new AuthorWithBooks2()
            {
                Name = b.Name,
                Description = b.Description,
                book_list = b.Book_Authors.Select(book => book.Book).ToList()
            }).FirstOrDefault();
        }

        public AuthorWithBooks3 GetAuthorWithBook3(int id)
        {
            return _context.Authors.Where(e => e.Id == id).Select(b =>
            new AuthorWithBooks3()
            {
                Name = b.Name,
                Description = b.Description,
                book_list = b.Book_Authors.Select(book => new Book3()
                {
                    Id = book.Book.Id,
                    Title = book.Book.Title,
                    Publisher= book.Book.Publisher
                }).ToList()
            }).FirstOrDefault();
        }



        public bool Save()
        {
           var saved= _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateAuthor(Author author)
        {
            _context.Update(author);
            return Save();

        }
    }
}
