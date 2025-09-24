using Microsoft.AspNetCore.Mvc;

namespace DarElkotb.Controllers;

public class HomeController : Controller
{
  private readonly IBookService _bookService;

  public HomeController(IBookService bookService)
  {
    _bookService = bookService;
  }

  public async Task<IActionResult> Index()
  {
    var book = await _bookService.GetAnyBook();
    return View(book);
  }
}
