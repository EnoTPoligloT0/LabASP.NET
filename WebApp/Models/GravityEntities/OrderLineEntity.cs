using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LabProject.Models.GravityEntities;

[Table("order_line")]
public class OrderLineEntity
{
    [Key]
    [Column("line_id")]
    public int LineId { get; set; }

    [Required]
    [Column("order_id")]
    public int OrderId { get; set; }

    [Required]
    [Column("book_id")]
    public int BookId { get; set; }

    [Required]
    [Column("price")]
    public decimal Price { get; set; }

    public BookEntity Book { get; set; }
}