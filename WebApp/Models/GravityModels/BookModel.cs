using System.ComponentModel.DataAnnotations;

namespace LabProject.Models.GravityModels;

public class BookModel
{
    [Required]
    public string Title { get; set; }

    [MaxLength(13)]
    public string Isbn13 { get; set; }

    public int? NumPages { get; set; }

    public DateTime? PublicationDate { get; set; }

    public int AuthorCount { get; set; }

    public int SoldCount { get; set; }
}