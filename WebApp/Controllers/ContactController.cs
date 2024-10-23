using LabProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace LabProject.Controllers;

public class ContactController : Controller
{
    // List kontaktow 
    private static Dictionary<int, ContactModel> _contacts = new()
    {
        {
            1, new ContactModel()
            {
                Id = 1,
                FirstName = "John",
                LastName = "Smith",
                Email = "john@gmail.com",
                PhoneNumber = "888888888",
                BirthDate = new(1984, 10, 26)
            }
        },
        {
            2, new ContactModel()
            {
                Id = 2,
                FirstName = "Ela",
                LastName = "McDonald",
                Email = "ela@gmail.com",
                PhoneNumber = "777222444",
                BirthDate = new(1986, 9, 26)
            }
        },
        {
            3, new ContactModel()
            {
                Id = 3,
                FirstName = "Paul",
                LastName = "Kings",
                Email = "paul@gmail.com",
                PhoneNumber = "856312534",
                BirthDate = new(1999, 5, 26)
            }
        }
    };

    private static int _currentId = 3;
    
    public IActionResult Index()
    {
        return View(_contacts);
    }

    //formularz dodania kontaktu
    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }

    //odebranie danych z formularza zapisa kontaktu i powrot do listy kontaktow
    [HttpPost]
    public IActionResult Add(ContactModel model)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }
        
        model.Id = ++_currentId;
        _contacts.Add(model.Id, model);
        return View("Index", _contacts);
    }

    public IActionResult Delete(int id)
    {
        _contacts.Remove(id);
        return View("Index", _contacts);
    }

    public IActionResult Details(int id)
    {
        return View(_contacts[id]);
    }
}