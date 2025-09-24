using DarElkotb.Data;
using DarElkotb.Models;
using DarElkotb.UnitOfWork;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DarElkotb.Services.DropDownServices;

public class AuthorDropdownService : IDropDownService<Author>
{
  private readonly UnitOfRepositories repositories;

  public AuthorDropdownService(UnitOfRepositories repositories)
  {
    this.repositories = repositories;
  }

  public async Task<IEnumerable<SelectListItem>> GetSelectList()
  {
    var authors = await repositories.Authors.GetAllAsync();
    return authors.Select(c => new SelectListItem()
      {
        Text = c.Name,
        Value = c.Id.ToString()
      })
      .OrderBy(c => c.Text)
      .ToList();
  }
}
