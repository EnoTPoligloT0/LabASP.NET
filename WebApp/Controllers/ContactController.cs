using LabProject.Models;
using LabProject.Models.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LabProject.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        public IActionResult Index()
        {
            var contacts = _contactService.GetAll(); // Fetch fresh data from the database
            return View(contacts);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var model = new ContactModel
            {
                Organizations = _contactService.GetAllOrganizations()
                    .Select(e => new SelectListItem
                    {
                        Value = e.Id.ToString(),
                        Text = e.Name,
                        Selected = e.Id == 102 // Default selection if needed
                    }).ToList()
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Add(ContactModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Organizations = _contactService.GetAllOrganizations()
                    .Select(e => new SelectListItem
                    {
                        Value = e.Id.ToString(),
                        Text = e.Name,
                        Selected = e.Id == model.OrganizationId
                    }).ToList();
                return View(model);
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
            if (contact == null)
            {
                return NotFound();
            }
            return View(contact);
        }

        public IActionResult Edit(int id)
        {
            var contact = _contactService.GetById(id);
            if (contact == null) return NotFound();

            // Repopulate organizations for the Edit view
            contact.Organizations = _contactService.GetAllOrganizations()
                .Select(e => new SelectListItem
                {
                    Value = e.Id.ToString(),
                    Text = e.Name,
                    Selected = e.Id == contact.OrganizationId
                }).ToList();
            return View(contact);
        }

        [HttpPost]
        public IActionResult Edit(ContactModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Organizations = _contactService.GetAllOrganizations()
                    .Select(e => new SelectListItem
                    {
                        Value = e.Id.ToString(),
                        Text = e.Name,
                        Selected = e.Id == model.OrganizationId
                    }).ToList();
                return View(model);
            }

            _contactService.Update(model);
            return RedirectToAction(nameof(Index));
        }
    }
}
