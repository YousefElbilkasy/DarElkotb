using System;

namespace DarElkotb.RepositoryContract;

public interface IBookRepository
{
  Task<IEnumerable<Book>> GetAllAsync();
  Task<Book> GetByIdAsync(int id);
  Task AddAsync(Book entity);
  void Update(Book entity);
  void Delete(Book entity);
  Task<Book?> GetAnyBookAsync();
}
