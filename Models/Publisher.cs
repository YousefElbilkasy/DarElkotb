using System;
using System.ComponentModel.DataAnnotations;

namespace DarElkotb.Models;

public class Publisher
{
  public int Id { get; set; }
  [MaxLength(250)]
  public string Name { get; set; } = string.Empty;
  [MaxLength(2500)]
  public string Description { get; set; } = string.Empty;
  [EmailAddress, MaxLength(700)]
  public string ContactEmail { get; set; } = string.Empty;
  [MaxLength(500)]
  public string Address { get; set; } = string.Empty;
  [MaxLength(500)]
  public string IconImage { get; set; } = string.Empty;
  public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
