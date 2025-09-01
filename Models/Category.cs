using System;
using System.ComponentModel.DataAnnotations;

namespace DarElkotb.Models;

public class Category
{
  public int Id { get; set; }
  [MaxLength(250)]
  public string Name { get; set; } = string.Empty;
  public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
