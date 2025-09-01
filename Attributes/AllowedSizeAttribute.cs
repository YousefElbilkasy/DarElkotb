using System;
using System.ComponentModel.DataAnnotations;

namespace DarElkotb.Attributes;

public class AllowedSizeAttribute : ValidationAttribute
{
  private readonly int _maxSizeInBytes;

  public AllowedSizeAttribute(int maxSizeInBytes)
  {
    _maxSizeInBytes = maxSizeInBytes;
  }

  protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
  {
    var file = value as IFormFile;

    if (file is not null && file.Length > _maxSizeInBytes)
      return new ValidationResult($"الحد الأقصى لحجم الملف هو {_maxSizeInBytes / 1024 / 1024} ميجابايت");

    return ValidationResult.Success;
  }
}
