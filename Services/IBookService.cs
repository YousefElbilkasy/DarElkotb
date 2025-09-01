namespace DarElkotb.Services;

public interface IBookService
{
  Task Add(AddBookViewModel book);
  Task Update(EditBookViewModel book);
}
