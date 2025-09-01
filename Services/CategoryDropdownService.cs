using Microsoft.AspNetCore.Mvc.Rendering;

namespace DarElkotb.Services;

public class CategoryDropdownService : IDropDownService<Category>
{
  private readonly UnitOfRepositories repositories;

  public CategoryDropdownService(UnitOfRepositories repositories)
  {
    this.repositories = repositories;
  }

  public IEnumerable<SelectListItem> GetSelectList()
  {
    return repositories.Categories.GetAll()
      .Select(c => new SelectListItem()
      {
        Text = c.Name,
        Value = c.Id.ToString()
      })
      .OrderBy(c => c.Text)
      .ToList();
  }
}
