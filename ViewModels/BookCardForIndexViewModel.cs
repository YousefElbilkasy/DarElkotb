using System;
using DarElkotb.Models;

namespace DarElkotb.ViewModels;

public class BookCardForIndexViewModel
{
  public int Id { get; set; }
  public string Title { get; set; } = string.Empty;
  public string CoverImage { get; set; } = string.Empty;
  public decimal Price { get; set; }
  public int AuthorId { get; set; }
  public virtual Author Author { get; set; } = default!;
  public int PublisherId { get; set; }
  public virtual Publisher Publisher { get; set; } = default!;
  public int CategoryId { get; set; }
  public virtual Category Category { get; set; } = default!;

}
