using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LabProject.Models.GravityEntities;

[Table("book")]
public class BookEntity
{
    [Key]
    [Column("book_id")]
    public int BookId { get; set; }

    [Required]
    [Column("title")]
    public string Title { get; set; }

    [Column("isbn13")]
    [MaxLength(13)]
    public string Isbn13 { get; set; }

    [Column("num_pages")]
    public int? NumPages { get; set; }

    [Column("publication_date")]
    public DateTime? PublicationDate { get; set; }

    public ICollection<BookAuthorEntity> BookAuthors { get; set; }
    public ICollection<OrderLineEntity> OrderLines { get; set; }
}