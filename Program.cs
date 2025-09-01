var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// Configure Entity Framework Core with SQL Server
builder.Services.AddDbContext<AppDbContext>(option => option.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("MonasterConnection"))
);

builder.Services.AddScoped<IDropDownService<Category>, CategoryDropdownService>();
builder.Services.AddScoped<IDropDownService<Author>, AuthorDropdownService>();
builder.Services.AddScoped<IDropDownService<Publisher>, PublisherDropdownService>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<UnitOfRepositories>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
  app.UseExceptionHandler("/Home/Error");
  app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
  name: "default",
  pattern: "{controller=Home}/{action=Index}/{id?}")
  .WithStaticAssets();


app.Run();
