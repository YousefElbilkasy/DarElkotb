using System;
using System.ComponentModel.DataAnnotations;

namespace DarElkotb.Models;

public class Book
{
  public int Id { get; set; }
  [MaxLength(200)]
  public string Title { get; set; } = string.Empty;
  [MaxLength(2500)]
  public string Description { get; set; } = string.Empty;
  public decimal Price { get; set; }
  public DateTime PublishDate { get; set; }
  [MaxLength(500)]
  public string CoverImage { get; set; } = "DefaultImage.jpeg";
  public int AuthorId { get; set; }
  public virtual Author Author { get; set; } = default!;
  public int PublisherId { get; set; }
  public virtual Publisher Publisher { get; set; } = default!;
  public int CategoryId { get; set; }
  public virtual Category Category { get; set; } = default!;
}
