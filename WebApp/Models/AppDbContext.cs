using Microsoft.EntityFrameworkCore;

namespace LabProject.Models;

public class AppDbContext : DbContext
{
    public DbSet<ContactEntity> Contacts { get; set; }

    private string DbPath { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = Path.Join(path, "contacts.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"Data source={DbPath}");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ContactEntity>()
            .HasData(
                new ContactEntity()
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "johndoe@gmail.com",
                    PhoneNumber = "123456789",
                    BirthDate = new DateOnly(1980, 1, 1),
                    Created = DateTime.Now,
                },
                new ContactEntity()
                {
                    Id = 2,
                    FirstName = "Paul",
                    LastName = "Foe",
                    Email = "paulfoe@gmail.com",
                    PhoneNumber = "123456789",
                    BirthDate = new DateOnly(1980, 1, 1),
                    Created = DateTime.Now,
                });
    }
}