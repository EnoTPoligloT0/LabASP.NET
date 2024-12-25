using LabProject.Models.Gravity;
using LabProject.Models.GravityEntities;
using Microsoft.EntityFrameworkCore;

namespace LabProject.Models;

public class BookstoreContext : DbContext
{
    public DbSet<BookEntity> Books { get; set; }
    public DbSet<AuthorEntity> Authors { get; set; }
    public DbSet<BookAuthorEntity> BookAuthors { get; set; }
    public DbSet<OrderLineEntity> OrderLines { get; set; }

    public BookstoreContext(DbContextOptions<BookstoreContext> options) : base(options) { }
}