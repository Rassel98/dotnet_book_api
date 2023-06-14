using my_books.Data;
using my_books.Models;
using System.Threading;
using System.Xml;

namespace my_books
{
    public class AppDbInitializer
    {
        private readonly AppDbContext context;

        public AppDbInitializer(AppDbContext context)
        {
            this.context = context;
        }
        public void SeedDataContext()
        {
            if (!context.Books.Any())
            {
                context.Books.AddRange(
               new Book()
                {
                   Title="1st Book Title",
                Description="1st book description",
                IsRead=true,
                ReadDate=DateTime.Now.AddDays(-10),
                Genre="Biography",
            
                Rate = 5,
                AddedDate =DateTime.Now.AddDays(-20),

                },
                new Book()
                {
                Title = "2st Book Title",
                Description = "2st book description",
                IsRead = false,
                Genre = "Biography",
               
                AddedDate = DateTime.Now,

                },

               new Book()
               {
                Title = "3rd Book Title",
                Description = "3rd book description",
                IsRead = true,
                ReadDate = DateTime.Now.AddDays(-10),
                Genre = "Biography",
               
                CoverUrl="https//jdskfsdf.png",
                Rate=4,
                AddedDate = DateTime.Now,

                }
                
                            );
                context.SaveChanges();

            }
        }

    }
}
