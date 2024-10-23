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
    public string FirstName { get; set; }   
    
    [Required(ErrorMessage = "Proszę podać nazwisko!")]
    [MaxLength(length:50, ErrorMessage = "Imie nie moze byc dluzsze niz 50 znakow")]
    [MinLength(length:2, ErrorMessage = "Imie musi miec co najmniej 2 znaki!")]
    public string LastName { get; set; }   
    
    [EmailAddress]
    public string Email { get; set; }

    [Phone]
    [RegularExpression("\\d{3} \\d{3} \\d{3}", ErrorMessage = "Wpisz numer wg wzoru: xxx xxx xxx")]
    public string PhoneNumber { get; set; }

    [DataType(DataType.Date)]
    public DateOnly BirthDate { get; set; }
}