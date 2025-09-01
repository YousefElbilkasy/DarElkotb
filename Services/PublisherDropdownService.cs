using Microsoft.AspNetCore.Mvc.Rendering;

namespace DarElkotb.Services;

public class PublisherDropdownService : IDropDownService<Publisher>
{
  private readonly UnitOfRepositories repositories;

  public PublisherDropdownService(UnitOfRepositories repositories)
  {
    this.repositories = repositories;
  }

  public IEnumerable<SelectListItem> GetSelectList()
  {
    return repositories.Publishers.GetAll()
      .Select(c => new SelectListItem()
      {
        Text = c.Name,
        Value = c.Id.ToString()
      })
      .OrderBy(c => c.Text)
      .ToList();
  }
}
