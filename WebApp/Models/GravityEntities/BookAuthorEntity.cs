using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LabProject.Models.Gravity;
using Microsoft.EntityFrameworkCore;

namespace LabProject.Models.GravityEntities;

[PrimaryKey(nameof(BookId), nameof(AuthorId))]
[Table("book_author")]
public class BookAuthorEntity
{
    [Column("book_id")]
    public int BookId { get; set; }

    [Column("author_id")]
    public int AuthorId { get; set; }

    public BookEntity Book { get; set; }
    public AuthorEntity Author { get; set; }
}