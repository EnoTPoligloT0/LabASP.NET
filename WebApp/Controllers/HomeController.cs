using System.Diagnostics;
using System.Net.Sockets;
using Microsoft.AspNetCore.Mvc;
using LabProject.Models;
using Microsoft.VisualBasic.CompilerServices;

namespace LabProject.Controllers;

public class HomeController : Controller
{
    // napisz metode age, ktura przyjmuje paramtre z data urodzin i wyswietla wiek w latatch, mesiacach i dniach
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult About()
    {
        return View();
    }

    public IActionResult Calculator(Operators? op, double? x, double? y)
    {
        // var op = Request.Query["op"];
        // var x = double.Parse(Request.Query["x"]);
        // var y = double.Parse(Request.Query["y"]);
        if (x is null || y is null)
        {
            ViewData["Error"] = "Please fill all values";
            return View("CalculatorError");
        }
        
        
        double? result = 0.0d;
        
        switch (op)
        {
            case Operators.Add:
                result = x + y;
                ViewBag.Operator = "+";
                break;
            case Operators.Sub:
                result = x - y;
                ViewBag.Operator = "-";
                break;
            case Operators.Div:
                result = x / y;
                ViewBag.Operator = "/";
                break;
            case Operators.Mul:
                result = x * y;
                ViewBag.Operator = "*";
                break;
            default:
                ViewBag.Error = "Invalid operation";
                return View("CalculatorError");
        }
        ViewBag.Result = result;
        ViewBag.X = x;
        ViewBag.y = y;
        return View();
    }
    
    public IActionResult Age(DateTime birthDate)
    {
        var today = DateTime.Today;
        if (birthDate > today)
        {
            ModelState.AddModelError("birthDate", "Birth date cannot be in the future.");
            return View();
        }
        var age = today - birthDate;

        int years = today.Year - birthDate.Year;
        int months = today.Month - birthDate.Month;
        int days = today.Day - birthDate.Day;

        if (days < 0)
        {
            months--;
            days += DateTime.DaysInMonth(today.Year, today.Month - 1);
        }

        if (months < 0)
        {
            years--;
            months += 12;
        }

        ViewBag.Years = years;
        ViewBag.Months = months;
        ViewBag.Days = days;

        return View();
    }

  
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    
}
public enum Operators
{
    Add,Sub,Mul,Div
}