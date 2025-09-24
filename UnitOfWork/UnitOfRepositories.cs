using DarElkotb.RepositoryContract;

namespace DarElkotb.UnitOfWork;

public class UnitOfRepositories
{
  private IBookRepository _books;
  public IBookRepository Books => _books ??= new BookRepository(_context);
  private GenericRepository<Author>? _authors;
  public GenericRepository<Author> Authors => _authors ??= new GenericRepository<Author>(_context);
  private GenericRepository<Category>? _categories;
  public GenericRepository<Category> Categories => _categories ??= new GenericRepository<Category>(_context);
  private GenericRepository<Publisher>? _publishers;
  public GenericRepository<Publisher> Publishers => _publishers ??= new GenericRepository<Publisher>(_context);
  private readonly AppDbContext _context;

  public UnitOfRepositories(AppDbContext context)
  {
    _context = context;
  }

  public void SaveChanges()
  {
    _context.SaveChanges();
  }
  public async Task SaveChangesAsync()
  {
    await _context.SaveChangesAsync();
  }
}