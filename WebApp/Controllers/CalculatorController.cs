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

    public IActionResult Result(Operators? op, double? x, double? y)
    {
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
            case Operators.Subtract:
                result = x - y;
                ViewBag.Operator = "-";
                break;
            case Operators.Divide:
                if (y == 0)
                {
                    ViewData["Error"] = "Cannot divide by zero";
                    return View("CalculatorError");
                }

                result = x / y;
                ViewBag.Operator = "/";
                break;
            case Operators.Multiply:
                result = x * y;
                ViewBag.Operator = "*";
                break;
            default:
                ViewData["Error"] = "Invalid operation";
                return View("CalculatorError");
        }

        ViewBag.Result = result;
        ViewBag.X = x;
        ViewBag.Y = y;
        return View();
    }

    public IActionResult Form()
    {
        return View();
    }
}

