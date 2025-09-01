namespace DarElkotb.Repository;

public class GenericRepository<TEntity> where TEntity : class
{
  private readonly AppDbContext _context;
  public GenericRepository(AppDbContext context)
  {
    _context = context;
  }

  public IEnumerable<TEntity> GetAll() => _context.Set<TEntity>();
  public TEntity GetById(int id) => _context.Set<TEntity>().Find(id)!;
  public void Add(TEntity entity) => _context.Set<TEntity>().Add(entity);
  public void Update(TEntity entity) => _context.Set<TEntity>().Update(entity);
  public void Delete(TEntity entity) => _context.Set<TEntity>().Remove(entity);
}