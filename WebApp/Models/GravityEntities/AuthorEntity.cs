using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LabProject.Models.Gravity;

namespace LabProject.Models.GravityEntities;

[Table("author")]
public class AuthorEntity
{

    [Key]
    [Column("author_id")]
    public int AuthorId { get; set; }

    [Required]
    [Column("author_name")]
    public string AuthorName { get; set; }

    public ICollection<BookAuthorEntity> BookAuthors { get; set; }
}