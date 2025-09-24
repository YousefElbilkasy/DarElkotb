using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyApp.Namespace
{
  public class BooksController : Controller
  {
    private readonly IDropDownService<Category> _categoryDropDownService;
    private readonly IDropDownService<Author> _authorDropDownService;
    private readonly IDropDownService<Publisher> _publisherDropDownService;
    private readonly IBookService _bookService;

    public BooksController(IDropDownService<Category> categoryDropDownService, IDropDownService<Author> authorDropDownService, IDropDownService<Publisher> publisherDropDownService, IBookService bookService)
    {
      _categoryDropDownService = categoryDropDownService;
      _authorDropDownService = authorDropDownService;
      _publisherDropDownService = publisherDropDownService;
      _bookService = bookService;
    }

    // GET: BooksController
    [HttpGet]
    public async Task<ActionResult> Index()
    {
      var books = await _bookService.GetAll();

      var bookCards = books
      .Select(b => new BookCardForIndexViewModel
      {
        Id = b.Id,
        Title = b.Title,
        CoverImage = b.CoverImage,
        Price = b.Price,
        AuthorId = b.AuthorId,
        Author = b.Author,
        CategoryId = b.CategoryId,
        Category = b.Category,
        PublisherId = b.PublisherId,
        Publisher = b.Publisher
      })
        .ToList();

      return View(bookCards);
    }

    [Authorize(Roles = nameof(Role.Admin))]
    [HttpGet]
    public async Task<ActionResult> Add()
    {
      AddBookViewModel model = new()
      {
        Authors = await _authorDropDownService.GetSelectList(),

        Categories = await _categoryDropDownService.GetSelectList(),

        Publishers = await _publisherDropDownService.GetSelectList()
      };
      return View(model);
    }

    [Authorize(Roles = nameof(Role.Admin))]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Add(AddBookViewModel model)
    {
      if (!ModelState.IsValid)
      {
        model.Authors = await _authorDropDownService.GetSelectList();
        model.Categories = await _categoryDropDownService.GetSelectList();
        model.Publishers = await _publisherDropDownService.GetSelectList();
        return View(model);
      }

      await _bookService.Add(model);

      return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<ActionResult> Details(int id)
    {
      var book = await _bookService.GetById(id);

      if (book == null)
        return NotFound();

      return View(book);
    }

    [Authorize(Roles = nameof(Role.Admin))]
    [HttpGet]
    public async Task<ActionResult> Edit(int id)
    {
      var book = await _bookService.GetById(id);

      if (book == null)
        return NotFound();

      var model = new EditBookViewModel
      {
        Id = book.Id,
        Title = book.Title,
        Description = book.Description,
        Price = book.Price,
        PublishDate = book.PublishDate,
        AuthorId = book.AuthorId,
        CategoryId = book.CategoryId,
        PublisherId = book.PublisherId,
        Authors = await _authorDropDownService.GetSelectList(),
        Categories = await _categoryDropDownService.GetSelectList(),
        Publishers = await _publisherDropDownService.GetSelectList(),
        CoverImageUrl = book.CoverImage
      };

      return View(model);
    }

    [Authorize(Roles = nameof(Role.Admin))]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Edit(EditBookViewModel model)
    {
      if (!ModelState.IsValid)
      {
        return View(model);
      }

      await _bookService.Update(model);

      return RedirectToAction(nameof(Index));
    }

    // POST: BooksController/Delete/5
    [Authorize(Roles = nameof(Role.Admin))]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Delete(int id)
    {
      await _bookService.Delete(id);

      return RedirectToAction(nameof(Index));
    }
  }
}