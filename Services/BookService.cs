using System;
using System.Threading.Tasks;
using DarElkotb.Data;
using DarElkotb.Models;
using DarElkotb.Settings;
using DarElkotb.UnitOfWork;
using DarElkotb.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace DarElkotb.Services;

public class BookService : IBookService
{
  private readonly UnitOfRepositories repositories;
  private readonly IWebHostEnvironment _webHostEnvironment;
  private readonly string _imagePath;
  public BookService(IWebHostEnvironment webHostEnvironment, UnitOfRepositories repositories)
  {
    _webHostEnvironment = webHostEnvironment;
    this.repositories = repositories;
    _imagePath = $"{_webHostEnvironment.WebRootPath}/{ImageFolderSettings.ImageFolder}";
  }

  public async Task Add(AddBookViewModel book)
  {
    // Handle optional cover image
    string coverName = string.Empty;
    if (book.CoverImage != null && book.CoverImage.Length > 0)
    {
      coverName = $"{Guid.NewGuid()}{Path.GetExtension(book.CoverImage.FileName)}";
      var path = Path.Combine(_imagePath, coverName);
      using var stream = File.Create(path);
      await book.CoverImage.CopyToAsync(stream);
    }

    // Add the book to the repository
    repositories.Books.Add(new Book
    {
      Title = book.Title,
      Description = book.Description ?? "",
      CoverImage = coverName,
      Price = book.Price,
      PublishDate = book.PublishDate ?? DateTime.UtcNow,
      PublisherId = book.PublisherId,
      CategoryId = book.CategoryId,
      AuthorId = book.AuthorId
    });
    await repositories.SaveChangesAsync();
  }

  public async Task Update(EditBookViewModel book)
  {
    // Load existing entity
    var existing = repositories.Books.GetById(book.Id);
    if (existing == null)
      throw new InvalidOperationException($"Book with id {book.Id} not found");

    // Handle optional cover image - if provided, save and replace; otherwise keep existing
    if (book.CoverImage != null && book.CoverImage.Length > 0)
    {
      var coverName = $"{Guid.NewGuid()}{Path.GetExtension(book.CoverImage.FileName)}";
      var path = Path.Combine(_imagePath, coverName);
      using var stream = File.Create(path);
      await book.CoverImage.CopyToAsync(stream);
      existing.CoverImage = coverName;
    }

    // Update fields
    existing.Title = book.Title;
    existing.Description = book.Description ?? existing.Description;
    existing.Price = book.Price;
    existing.PublishDate = book.PublishDate ?? existing.PublishDate;
    existing.PublisherId = book.PublisherId;
    existing.CategoryId = book.CategoryId;
    existing.AuthorId = book.AuthorId;

    repositories.Books.Update(existing);
    await repositories.SaveChangesAsync();
  }
}
