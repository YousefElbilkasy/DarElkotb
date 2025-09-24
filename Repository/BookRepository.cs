using System;
using DarElkotb.RepositoryContract;

namespace DarElkotb.Repository;

public class BookRepository : GenericRepository<Book>, IBookRepository
{
  private readonly AppDbContext _context;
  public BookRepository(AppDbContext context) : base(context)
  {
    _context = context;
  }
  public async Task<Book?> GetAnyBookAsync() => await _context.Books.FirstOrDefaultAsync();
}
