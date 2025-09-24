namespace DarElkotb.ServicesContract;

public interface IBookService
{
  Task<IEnumerable<Book>> GetAll();
  Task<Book?> GetById(int id);
  Task Add(AddBookViewModel book);
  Task Update(EditBookViewModel book);
  Task Delete(int id);
  Task<Book> GetAnyBook();
}
