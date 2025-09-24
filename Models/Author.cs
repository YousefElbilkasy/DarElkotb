using System;
using System.ComponentModel.DataAnnotations;

namespace DarElkotb.Models;

public class Author
{
  public int Id { get; set; }
  [MaxLength(250)]
  public string Name { get; set; } = string.Empty;
  [MaxLength(2500)]
  public string Bio { get; set; } = string.Empty;
  [MaxLength(500)]
  public string ProfileImage { get; set; } = "default.jpg";
  public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
