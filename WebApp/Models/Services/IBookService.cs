using LabProject.Models.GravityModels;

namespace LabProject.Models.Services;

public interface IBookService
{
    (List<BookModel>, int) GetBooks(int pageNumber, int pageSize);
    BookModel GetBookById(int id);
    void AddBook(BookModel model);
    void UpdateBook(int id, BookModel model);
}