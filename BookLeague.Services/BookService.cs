using BookLeague.Data;
using BookLeague.Models;
using BookLeague.Models.Book;
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
            //entity.Themes.Add() -- future development
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
                        .Books
                        .Where(e => e.CreatorId == _creatorId)
                        .Select(
                            e =>
                                new BookListItem
                                {
                                    BookId = e.BookId,
                                    BookName = e.BookName,
                                    Genre = e.Genre,
                                    Rating = e.Rating,
                                    Price = e.Price,
                                    PageCount = e.PageCount
                                }
                        );
                return query.ToArray();
            }
        }

        public BookDetail GetBookById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Books
                        .Single(e => e.BookId == id);
                return
                    new BookDetail
                    {
                        BookId = entity.BookId,
                        BookName = entity.BookName,
                        Genre = entity.Genre,
                        Rating = entity.Rating,
                        Price = entity.Price,
                        PageCount = entity.PageCount,
                        Description = entity.Description
                    };
            }
        }

        public bool UpdateBook(BookEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Books
                        .Single(e => e.BookId == model.BookId && e.CreatorId == _creatorId);
                entity.BookName = model.BookName;
                entity.Genre = model.Genre;
                entity.Rating = model.Rating;
                entity.Price = model.Price;
                entity.PageCount = model.PageCount;
                entity.Description = model.Description;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteBook(int bookId)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Books
                        .Single(e => e.BookId == bookId && e.CreatorId == _creatorId);

                ctx.Books.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
