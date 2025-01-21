using LabProject.Models.GravityModels;
using LabProject.Models.Mappers;
using Microsoft.EntityFrameworkCore;


namespace LabProject.Models.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly BookstoreContext _context;

        public AuthorService(BookstoreContext context)
        {
            _context = context;
        }

        public AuthorModel GetAuthorById(int id)
        {
            var authorEntity = _context.Authors
                .Include(a => a.BookAuthors)
                .ThenInclude(ba => ba.Book)
                .FirstOrDefault(a => a.AuthorId == id);

            return authorEntity == null ? null : AuthorMapper.ToModel(authorEntity);
        }

        public (List<AuthorModel>, int) GetAuthors(int pageNumber, int pageSize)
        {
            var totalAuthors = _context.Authors.Count();
            var authors = _context.Authors
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Include(a => a.BookAuthors)
                .ThenInclude(ba => ba.Book)
                .ToList();

            var authorModel = authors.Select(AuthorMapper.ToModel).ToList();
            return (authorModel, totalAuthors);
        }

        public void AddAuthor(AuthorModel model)
        {
            var authorEntity = AuthorMapper.ToEntity(model);
            _context.Authors.Add(authorEntity);
            _context.SaveChanges();
        }

        public void UpdateAuthor(int id, AuthorModel model)
        {
            var authorEntity = _context.Authors.FirstOrDefault(a => a.AuthorId == id);
            if (authorEntity != null)
            {
                authorEntity.AuthorName = model.AuthorName;
                _context.SaveChanges();
            }
        }

        public void DeleteAuthor(int id)
        {
            var authorEntity = _context.Authors.FirstOrDefault(a => a.AuthorId == id);
            if (authorEntity != null)
            {
                _context.Authors.Remove(authorEntity);
                _context.SaveChanges();
            }
        }
    }
}
