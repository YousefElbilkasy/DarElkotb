using Microsoft.AspNetCore.Mvc.Rendering;

namespace DarElkotb.Services.DropDownServices;

public class PublisherDropdownService : IDropDownService<Publisher>
{
  private readonly UnitOfRepositories repositories;

  public PublisherDropdownService(UnitOfRepositories repositories)
  {
    this.repositories = repositories;
  }

  public async Task<IEnumerable<SelectListItem>> GetSelectList()
  {
    var publishers = await repositories.Publishers.GetAllAsync();
    return publishers.Select(c => new SelectListItem()
    {
      Text = c.Name,
      Value = c.Id.ToString()
    })
    .OrderBy(c => c.Text)
    .ToList();
  }
}
