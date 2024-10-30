using LabProject.Models;
using LabProject.Models.Services;
using Microsoft.AspNetCore.Mvc;

namespace LabProject.Controllers;

public class ContactController : Controller
{
    // List kontaktow 
    private readonly IContactService _contactService;

    public ContactController(IContactService contactService)
    {
        _contactService = contactService;
    }

    public IActionResult Index()
    {
        return View(_contactService.GetAll());
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
        
        _contactService.Add(model);
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Delete(int id)
    {
        _contactService.Delete(id);
        return RedirectToAction(nameof(Index));
        
    }

    public IActionResult Details(int id)
    {
        var contact = _contactService.GetById(id);
        return View(contact); 

    }

    public IActionResult Edit(int id)
    {
        return View(_contactService.GetById(id));
    }

    [HttpPost]
    public IActionResult Edit(ContactModel model)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }
        
        _contactService.Update(model);
        return RedirectToAction(nameof(Index));
    }
}