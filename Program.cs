using DarElkotb.Helpers.Seeders;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// Configure Entity Framework Core with SQL Server
builder.Services.AddDbContext<AppDbContext>(option => option.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("MonasterConnection")));

builder.Services.AddIdentity<IdentityUser<int>, IdentityRole<int>>().AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

// Register application services
builder.Services.AddScoped<IDropDownService<Category>, CategoryDropdownService>();
builder.Services.AddScoped<IDropDownService<Author>, AuthorDropdownService>();
builder.Services.AddScoped<IDropDownService<Publisher>, PublisherDropdownService>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<UnitOfRepositories>();

var app = builder.Build();

// insert Roles
using var scope = app.Services.CreateScope();
var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<int>>>();
await IdentitySeeder.SeedRolesAsync(roleManager);

// insert Admin User
var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser<int>>>();
await IdentitySeeder.SeedAdminUserAsync(userManager);


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
  app.UseExceptionHandler("/Home/Error");
  app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
  name: "default",
  pattern: "{controller=Home}/{action=Index}/{id?}")
  .WithStaticAssets();


app.Run();
