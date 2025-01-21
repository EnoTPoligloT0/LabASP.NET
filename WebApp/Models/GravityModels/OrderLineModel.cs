using Microsoft.Build.Framework;

namespace LabProject.Models.GravityModels;

public class OrderLineModel
{
    [Required]
    public int OrderId { get; set; }

    [Required]
    public int BookId { get; set; }

    [Required]
    public decimal Price { get; set; }
}