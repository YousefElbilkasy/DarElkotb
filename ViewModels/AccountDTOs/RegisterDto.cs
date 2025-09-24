using System;
using System.ComponentModel.DataAnnotations;

namespace DarElkotb.ViewModels.AccountDTOs;

public class RegisterDto
{
  [Required(ErrorMessage = "البريد الإلكتروني مطلوب")]
  [EmailAddress(ErrorMessage = "البريد الإلكتروني غير صحيح")]
  [Display(Name = "البريد الإلكتروني")]
  public string Email { get; set; } = string.Empty;

  [Required(ErrorMessage = "كلمة المرور مطلوبة")]
  [MinLength(6, ErrorMessage = "كلمة المرور يجب أن تكون 6 أحرف على الأقل")]
  [DataType(DataType.Password)]
  [Display(Name = "كلمة المرور")]
  public string Password { get; set; } = string.Empty;

  [Required(ErrorMessage = "تأكيد كلمة المرور مطلوب")]
  [Compare("Password", ErrorMessage = "كلمة المرور وتأكيدها غير متطابقان")]
  [DataType(DataType.Password)]
  [Display(Name = "تأكيد كلمة المرور")]
  public string ConfirmPassword { get; set; } = string.Empty;
}
