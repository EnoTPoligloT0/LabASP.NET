using LabProject.Models.GravityEntities;
using LabProject.Models.GravityModels;
using LabProject.Models.Mappers;
using System.Linq;

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
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            var bookModels = books.Select(BookMapper.ToModel).ToList();
            return (bookModels, totalBooks);
        }
        public BookModel GetBookById(int id)
        {
            var bookEntity = _context.Books
                .FirstOrDefault(b => b.BookId == id);

            if (bookEntity == null)
                return null;

            return BookMapper.ToModel(bookEntity);
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
