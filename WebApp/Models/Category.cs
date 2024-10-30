using System.ComponentModel.DataAnnotations;

namespace LabProject.Models;

public enum Category
{
    [Display(Name = "Rodzina", Order = 1)]
    Family,
    [Display(Name = "Zanjomi", Order = 2)]
    Friend,
    [Display(Name = "Kontakt zawodowy", Order = 3)]
    Business
}