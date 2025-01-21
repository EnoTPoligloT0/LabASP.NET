namespace LabProject.Models.Gravity;

public class BookViewModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Isbn13 { get; set; }
    public int NumPages { get; set; }
    public DateTime PublicationDate { get; set; }
    public int AuthorCount { get; set; }
    public int SoldCopies { get; set; }
}