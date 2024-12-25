using LabProject.Models.Gravity;
using LabProject.Models.GravityEntities;
using LabProject.Models.GravityModels;

namespace LabProject.Models.Mappers;

public static class AuthorMapper
{
    public static AuthorEntity ToEntity(AuthorModel model)
    {
        return new AuthorEntity
        {
            AuthorId = model.AuthorId,
            AuthorName = model.AuthorName
        };
    }

    public static AuthorModel ToModel(AuthorEntity entity)
    {
        var authorModel = new AuthorModel
        {
            AuthorName = entity.AuthorName,
            Books = new List<BookModel>()
        };

        foreach (var bookAuthor in entity.BookAuthors)
        {
            authorModel.Books.Add(BookMapper.ToModel(bookAuthor.Book));
        }

        return authorModel;
    }
}