using System.Runtime.Intrinsics.X86;
using System;
using System.ComponentModel.DataAnnotations;

namespace DarElkotb.Attributes;

public class AllowedExtensionAttribute : ValidationAttribute
{
  private readonly string _allowedExtensions;

  public AllowedExtensionAttribute(string allowedExtensions)
  {
    _allowedExtensions = allowedExtensions;
  }

  protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
  {
    var file = value as IFormFile;

    if (file is not null)
    {
      var extension = Path.GetExtension(file.FileName);

      if (!_allowedExtensions.Split(',').Contains(extension, StringComparer.OrdinalIgnoreCase))
        return new ValidationResult($"الامتدادات المسموح بها: {_allowedExtensions}");
    }

    return ValidationResult.Success;
  }
}
