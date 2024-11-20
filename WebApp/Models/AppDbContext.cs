using Microsoft.EntityFrameworkCore;

namespace LabProject.Models;

public class AppDbContext : DbContext
{
    public DbSet<ContactEntity> Contacts { get; set; }
    public DbSet<OrganizationEntity> Organizations { get; set; }
    private string DbPath { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = Path.Join(path, "contacts.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseSqlite($"Data source={DbPath}")
            .LogTo(Console.WriteLine, LogLevel.Information); // Enable query logging
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OrganizationEntity>()
            .ToTable("Organizations")
            .HasData(
                new OrganizationEntity
                {
                    Id = 101,
                    NIP = "123456",
                    Name = "Wsei",
                    REGON = "929382382"
                },
                new OrganizationEntity
                {
                    Id = 102,
                    NIP = "654321",
                    Name = "Halo",
                    REGON = "929382382"
                });

        modelBuilder.Entity<OrganizationEntity>()
            .OwnsOne(o => o.Adress)
            .HasData(
                new { OrganizationEntityId = 101, Street = "sw. Filipa 17", City = "Krakow" },
                new { OrganizationEntityId = 102, Street = "Dworcowa", City = "Lodz" }
            );

        modelBuilder.Entity<ContactEntity>()
            .Property(c => c.OrganizationId)
            .HasDefaultValue(101);

        modelBuilder.Entity<ContactEntity>()
            .HasData(
                new ContactEntity
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "johndoe@gmail.com",
                    PhoneNumber = "123456789",
                    BirthDate = new DateOnly(1980, 1, 1),
                    Created = DateTime.Now,
                    OrganizationId = 101
                },
                new ContactEntity
                {
                    Id = 2,
                    FirstName = "Paul",
                    LastName = "Foe",
                    Email = "paulfoe@gmail.com",
                    PhoneNumber = "123456789",
                    BirthDate = new DateOnly(1980, 1, 1),
                    Created = DateTime.Now,
                    OrganizationId = 101
                });
    }
}
