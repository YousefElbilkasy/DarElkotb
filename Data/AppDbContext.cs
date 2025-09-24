using System;
using DarElkotb.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DarElkotb.Data;

public class AppDbContext : IdentityDbContext<IdentityUser<int>, IdentityRole<int>, int>
{
  public DbSet<Book> Books { get; set; }
  public DbSet<Author> Authors { get; set; }
  public DbSet<Publisher> Publishers { get; set; }
  public DbSet<Category> Categories { get; set; }
  public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);

    modelBuilder.Entity<Book>().Property(b => b.Price).HasPrecision(18, 2);

    modelBuilder.Entity<Author>().HasData(
      new Author { Id = 1, Name = "محمد بن صالح العثيمين", Bio = "عالم سعودي وفقيه وأستاذ جامعي.", ProfileImage = "othaymeen.jpg" },
      new Author { Id = 2, Name = "ابن تيمية", Bio = "عالم مسلم مجتهد وفقيه ومفسر." },
      new Author { Id = 3, Name = "ابن القيم الجوزية", Bio = "عالم مسلم وفقيه ومفسر." },
      new Author { Id = 4, Name = "محمد ناصر الدين الألباني", Bio = "محدث وفقيه سوري.", ProfileImage = "albani.jpg" },
      new Author { Id = 5, Name = "صالح الفوزان", Bio = "عالم سعودي وعضو هيئة كبار العلماء.", ProfileImage = "fawzan.jpg" },
      new Author { Id = 6, Name = "ياسر البرهامي", Bio = "عالم مصري ودكتور أطفال.", ProfileImage = "borhamy.jpg" }
    );

    modelBuilder.Entity<Publisher>().HasData(
      new Publisher { Id = 1, Name = "دار ابن الجوزي", Description = "دار نشر إسلامية سعودية.", ContactEmail = "info@ibnaljawzi.com", Address = "الرياض، السعودية", IconImage = "ibnaljawzi.png" },
      new Publisher { Id = 2, Name = "دار السلام", Description = "دار نشر إسلامية مصرية.", ContactEmail = "info@daralsalam.com", Address = "القاهرة، مصر", IconImage = "daralsalam.png" }
    );

    modelBuilder.Entity<Category>().HasData(
      new Category { Id = 1, Name = "فقه" },
      new Category { Id = 2, Name = "عقيدة" },
      new Category { Id = 3, Name = "حديث" },
      new Category { Id = 4, Name = "تزكية" }
    );

    modelBuilder.Entity<Book>().HasData(
      new Book
      {
        Id = 1,
        Title = "شرح ثلاثة الأصول",
        Description = "شرح مبسط لكتاب ثلاثة الأصول.",
        Price = 35.00m,
        CoverImage = "thlathat_osool.jpg",
        AuthorId = 1,
        PublisherId = 1,
        CategoryId = 2,
        PublishDate = new DateTime(1995, 1, 1)
      },
      new Book
      {
        Id = 2,
        Title = "العقيدة الواسطية",
        Description = "كتاب في العقيدة الإسلامية.",
        Price = 40.00m,
        CoverImage = "wasitiyyah.jpg",
        AuthorId = 2,
        PublisherId = 2,
        CategoryId = 2,
        PublishDate = new DateTime(1318, 1, 1)
      },
      new Book
      {
        Id = 3,
        Title = "زاد المعاد في هدي خير العباد",
        Description = "كتاب في السيرة والفقه.",
        Price = 55.00m,
        CoverImage = "zad_almaad.jpg",
        AuthorId = 3,
        PublisherId = 1,
        CategoryId = 1,
        PublishDate = new DateTime(1350, 1, 1)
      },
      new Book
      {
        Id = 4,
        Title = "صفة صلاة النبي",
        Description = "شرح صفة صلاة النبي ﷺ.",
        Price = 25.00m,
        CoverImage = "salat_alnabi.jpg",
        AuthorId = 4,
        PublisherId = 2,
        CategoryId = 3,
        PublishDate = new DateTime(1969, 1, 1)
      },
      new Book
      {
        Id = 5,
        Title = "الإرشاد إلى صحيح الاعتقاد",
        Description = "كتاب في العقيدة الصحيحة.",
        Price = 30.00m,
        CoverImage = "ershad_etiqad.jpg",
        AuthorId = 5,
        PublisherId = 1,
        CategoryId = 2,
        PublishDate = new DateTime(2002, 1, 1)
      }
    );
  }
}
