using System;

namespace DarElkotb.Settings;

public static class ImageFolderSettings
{
  public const string ImageFolder = "assets/images/books/";
  public const string AllowedExtensions = ".jpg, .jpeg, .png";
  public const int MaxFileSizeInMB = 1; // 1 MB
  public const int MaxFileSizeInBytes = 1 * 1024 * 1024; // 1 MB
}
