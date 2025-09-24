
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DarElkotb.ViewModels.BookDTOs;

public class EditBookViewModel
{
  public int Id { get; set; }

  [MaxLength(200, ErrorMessage = "الحد المسموح به 200 حرف"),
  Display(Name = "العنوان"),
  Required(ErrorMessage = "هذا الحقل مطلوب")]
  public string Title { get; set; } = string.Empty;

  [MaxLength(2500, ErrorMessage = "الحد المسموح به 2500 حرف"),
  Display(Name = "الوصف")]
  public string? Description { get; set; } = string.Empty;

  [Display(Name = "السعر"),
  Required(ErrorMessage = "هذا الحقل مطلوب"),
  Range(.5, 100000, ErrorMessage = "السعر خارج النطاق المسموح به ، النطاق المسموح به 0.5 : 100,000")]
  public decimal Price { get; set; }

  [Display(Name = "تاريخ النشر")]
  public DateTime? PublishDate { get; set; }

  [Display(Name = "صورة الغلاف")]
  public IFormFile? CoverImage { get; set; } = default!;
  public string? CoverImageUrl { get; set; }

  [Display(Name = "المؤلف"),]
  public int AuthorId { get; set; }

  public IEnumerable<SelectListItem> Authors { get; set; } = Enumerable.Empty<SelectListItem>();

  [Display(Name = "الناشر")]
  public int PublisherId { get; set; }

  public IEnumerable<SelectListItem> Publishers { get; set; } = Enumerable.Empty<SelectListItem>();

  [Display(Name = "التصنيف")]
  public int CategoryId { get; set; }

  public IEnumerable<SelectListItem> Categories { get; set; } = Enumerable.Empty<SelectListItem>();

}