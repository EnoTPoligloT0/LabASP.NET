using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace LabProject.Models;

public class ContactModel
{
    [HiddenInput]
    public int Id { get; set; }

    [Required(ErrorMessage ="Proszę podać imię!")]
    [MaxLength(length:20, ErrorMessage = "Imie nie moze byc dluzsze niz 20 znakow")]
    [MinLength(length:2, ErrorMessage = "Imie musi miec co najmniej 2 znaki!")]
    [Display(Name = "Imie", Order = 1)]
    public string FirstName { get; set; }   
    
    [Required(ErrorMessage = "Proszę podać nazwisko!")]
    [MaxLength(length:50, ErrorMessage = "Imie nie moze byc dluzsze niz 50 znakow")]
    [MinLength(length:2, ErrorMessage = "Imie musi miec co najmniej 2 znaki!")]
    [Display(Name = "Nazwisko", Order = 2)]
    public string LastName { get; set; }   
    
    [EmailAddress]
    [Display(Name = "Adres e-mail", Order = 4)]
    public string Email { get; set; }

    [Phone]
    [RegularExpression("\\d{3} \\d{3} \\d{3}", ErrorMessage = "Wpisz numer wg wzoru: xxx xxx xxx")]
    [Display(Name = "Telefon", Order = 3)]
    public string PhoneNumber { get; set; }

    [DataType(DataType.Date)]
    [Display(Name = "Data urodzenia")]
    public DateOnly BirthDate { get; set; }

    [Display(Name = "Kategoria")]
    public Category Category { get; set; }
}