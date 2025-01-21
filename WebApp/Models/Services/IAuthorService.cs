using LabProject.Models.GravityModels;

namespace LabProject.Models.Services;

public interface IAuthorService
{
    AuthorModel GetAuthorById(int id);
    (List<AuthorModel>, int) GetAuthors(int pageNumber, int pageSize);
    void AddAuthor(AuthorModel model);
    void UpdateAuthor(int id, AuthorModel model);
    void DeleteAuthor(int id);
}