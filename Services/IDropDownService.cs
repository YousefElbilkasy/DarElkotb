using System;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DarElkotb.Services;

public interface IDropDownService<T> where T : class
{
  public IEnumerable<SelectListItem> GetSelectList();
}
