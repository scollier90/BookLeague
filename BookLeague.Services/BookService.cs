using BookLeague.Data;
using BookLeague.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLeague.Services
{
    public class BookService
    {
        private readonly Guid _creatorId;

        public BookService(Guid creatorId)
        {
            _creatorId = creatorId;
        }

        public bool CreateBook(BookCreate model)
        {
            var entity =
                new Book()
                {
                    CreatorId = _creatorId,
                    BookName = model.BookName,
                    Genre = model.Genre,
                    Rating = model.Rating,
                    Price = model.Price,
                    PageCount = model.PageCount,
                    Description = model.Description
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Books.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<BookListItem> GetBooks()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Notes
                        .Where(e => e.CreatorId == _creatorId)
                        .Select(
                            e =>
                                new BookListItem
                                {
                                    BookId = e.BookId,
                                    BookName = e.BookName,

                                }
            }
        }
    }
}
