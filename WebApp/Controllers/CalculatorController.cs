using LabProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace LabProject.Controllers;

public class CalculatorController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Result(Calculator model)
    {
        if (!model.IsValid())
        {
            return View("Error");
        }
        return View(model);
    }
    public IActionResult Form()
    {
        return View();
    }
}

