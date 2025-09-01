using Microsoft.AspNetCore.Mvc;

namespace MyApp.Namespace
{
  public class BooksController : Controller
  {
    private readonly IDropDownService<Category> _categoryDropDownService;
    private readonly IDropDownService<Author> _authorDropDownService;
    private readonly IDropDownService<Publisher> _publisherDropDownService;
    private readonly IBookService _bookService;
    private readonly UnitOfRepositories _repositories;

    public BooksController(IDropDownService<Category> categoryDropDownService, IDropDownService<Author> authorDropDownService, IDropDownService<Publisher> publisherDropDownService, IBookService bookService, UnitOfRepositories repositories)
    {
      _categoryDropDownService = categoryDropDownService;
      _authorDropDownService = authorDropDownService;
      _publisherDropDownService = publisherDropDownService;
      _bookService = bookService;
      _repositories = repositories;
    }

    // GET: BooksController
    [HttpGet]
    public ActionResult Index()
    {
      var books = _repositories.Books.GetAll()
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
      return View(books);
    }

    [HttpGet]
    public ActionResult Add()
    {
      AddBookViewModel model = new()
      {
        Authors = _authorDropDownService.GetSelectList(),

        Categories = _categoryDropDownService.GetSelectList(),

        Publishers = _publisherDropDownService.GetSelectList()
      };
      return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Add(AddBookViewModel model)
    {
      if (!ModelState.IsValid)
      {
        model.Authors = _authorDropDownService.GetSelectList();
        model.Categories = _categoryDropDownService.GetSelectList();
        model.Publishers = _publisherDropDownService.GetSelectList();
        return View(model);
      }

      await _bookService.Add(model);

      return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public ActionResult Details(int id)
    {
      var book = _repositories.Books.GetById(id);

      if (book == null)
        return NotFound();

      return View(book);
    }

    [HttpGet]
    public ActionResult Edit(int id)
    {
      var book = _repositories.Books.GetById(id);
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
        Authors = _authorDropDownService.GetSelectList(),
        Categories = _categoryDropDownService.GetSelectList(),
        Publishers = _publisherDropDownService.GetSelectList(),
        CoverImageUrl = book.CoverImage
      };

      return View(model);
    }

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
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Delete(int id)
    {
      var book = _repositories.Books.GetById(id);
      if (book == null)
        return NotFound();

      _repositories.Books.Delete(book);
      await _repositories.SaveChangesAsync();

      return RedirectToAction(nameof(Index));
    }
  }
}