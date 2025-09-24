using System;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DarElkotb.ServicesContract;

public interface IDropDownService<T> where T : class
{
  public Task<IEnumerable<SelectListItem>> GetSelectList();
}
