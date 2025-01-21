using LabProject.Models.GravityEntities;
using LabProject.Models.GravityModels;
using LabProject.Models.Mappers;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace LabProject.Models.Services
{
    public class BookService : IBookService
    {
        private readonly BookstoreContext _context;

        public BookService(BookstoreContext context)
        {
            _context = context;
        }

        public (List<BookModel>, int) GetBooks(int pageNumber, int pageSize)
        {
            var totalBooks = _context.Books.Count();
            var books = _context.Books
                .Select(b => new BookModel
                {
                    BookId = b.BookId,
                    Title = b.Title,
                    Isbn13 = b.Isbn13,
                    NumPages = b.NumPages,
                    PublicationDate = b.PublicationDate,
                    AuthorCount = _context.BookAuthors.Count(ba => ba.BookId == b.BookId),
                    SoldCount = _context.OrderLines.Count(ol => ol.BookId == b.BookId)
                })
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return (books, totalBooks);
        }
        public BookModel GetBookById(int id)
        {
            var bookEntity = _context.Books
                .FirstOrDefault(b => b.BookId == id);

            if (bookEntity == null)
                return null;

            return BookMapper.ToModel(bookEntity);
        }
        public List<AuthorModel> GetAuthorsByBookId(int bookId)
        {
            var book = _context.Books
                .Where(b => b.BookId == bookId)
                .Include(b => b.BookAuthors)
                .ThenInclude(ba => ba.Author)
                .FirstOrDefault();

            if (book == null)
            {
                return new List<AuthorModel>();
            }


            var authorModels = book.BookAuthors
                .Select(ba => AuthorMapper.ToModel(ba.Author))
                .ToList();

            return authorModels;
        }


        public void AddBook(BookModel model)
        {
            var bookEntity = BookMapper.ToEntity(model);

            _context.Books.Add(bookEntity);
            _context.SaveChanges();
        }

        public void UpdateBook(int id, BookModel model)
        {
            var bookEntity = _context.Books.FirstOrDefault(b => b.BookId == id);
            if (bookEntity != null)
            {
                bookEntity.Title = model.Title;
                bookEntity.Isbn13 = model.Isbn13;
                bookEntity.NumPages = model.NumPages;
                bookEntity.PublicationDate = model.PublicationDate;

                _context.SaveChanges();
            }
        }
    }
}