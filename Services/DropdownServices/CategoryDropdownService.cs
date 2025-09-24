using Microsoft.AspNetCore.Mvc.Rendering;

namespace DarElkotb.Services.DropDownServices;

public class CategoryDropdownService : IDropDownService<Category>
{
  private readonly UnitOfRepositories repositories;

  public CategoryDropdownService(UnitOfRepositories repositories)
  {
    this.repositories = repositories;
  }

  public async Task<IEnumerable<SelectListItem>> GetSelectList()
  {
    var categories = await repositories.Categories.GetAllAsync();
      return categories.Select(c => new SelectListItem()
      {
        Text = c.Name,
        Value = c.Id.ToString()
      })
      .OrderBy(c => c.Text)
      .ToList();
  }
}
