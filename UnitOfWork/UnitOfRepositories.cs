namespace DarElkotb.UnitOfWork;

public class UnitOfRepositories
{
  public GenericRepository<Author> Authors { get; }
  public GenericRepository<Book> Books { get; }
  public GenericRepository<Category> Categories { get; }
  public GenericRepository<Publisher> Publishers { get; }
  private readonly AppDbContext _context;

  public UnitOfRepositories(AppDbContext context)
  {
    Authors = new GenericRepository<Author>(context);
    Books = new GenericRepository<Book>(context);
    Categories = new GenericRepository<Category>(context);
    Publishers = new GenericRepository<Publisher>(context);
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