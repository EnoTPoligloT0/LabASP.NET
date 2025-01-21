using LabProject.Models.Gravity;
using LabProject.Models.GravityEntities;
using LabProject.Models.GravityModels;

namespace LabProject.Models.Mappers;

public static class BookMapper
{
    public static BookEntity ToEntity(BookModel model)
    {
        return new BookEntity()
        {
            BookId = model.BookId,
            Title = model.Title,
            Isbn13 = model.Isbn13,
            NumPages = model.NumPages,
            PublicationDate = model.PublicationDate
        };
    }

    public static BookModel ToModel(BookEntity entity)
    {
        return new BookModel
        {
            BookId = entity.BookId,
            Title = entity.Title,
            Isbn13 = entity.Isbn13,
            NumPages = entity.NumPages,
            PublicationDate = entity.PublicationDate,
            AuthorCount = entity.BookAuthors != null ? entity.BookAuthors.Count : 0,
            SoldCount = entity.OrderLines != null ? entity.OrderLines.Count : 0
        };
    }
}