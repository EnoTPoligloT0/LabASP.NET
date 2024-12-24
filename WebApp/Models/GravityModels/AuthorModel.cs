using System.ComponentModel.DataAnnotations;
using LabProject.Models.GravityEntities;

namespace LabProject.Models.GravityModels;

public class AuthorModel
{
    [Required]
    public string AuthorName { get; set; }

    public List<BookModel> Books { get; set; }

    public ICollection<BookAuthorEntity> BookAuthors { get; set; }
}