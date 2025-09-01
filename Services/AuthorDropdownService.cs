using DarElkotb.Data;
using DarElkotb.Models;
using DarElkotb.UnitOfWork;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DarElkotb.Services;

public class AuthorDropdownService : IDropDownService<Author>
{
  private readonly UnitOfRepositories repositories;

  public AuthorDropdownService(UnitOfRepositories repositories)
  {
    this.repositories = repositories;
  }

  public IEnumerable<SelectListItem> GetSelectList()
  {
    return repositories.Authors.GetAll()
      .Select(c => new SelectListItem()
      {
        Text = c.Name,
        Value = c.Id.ToString()
      })
      .OrderBy(c => c.Text)
      .ToList();
  }
}
