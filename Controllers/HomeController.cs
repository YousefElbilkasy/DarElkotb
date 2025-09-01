using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DarElkotb.Models;

namespace DarElkotb.Controllers;

public class HomeController : Controller
{
  public IActionResult Index()
  {
    return View();
  }
}
