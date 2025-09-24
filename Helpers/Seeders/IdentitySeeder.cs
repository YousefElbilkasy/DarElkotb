using System;
using Microsoft.AspNetCore.Identity;

namespace DarElkotb.Helpers.Seeders;

public static class IdentitySeeder
{
  public static async Task SeedRolesAsync(RoleManager<IdentityRole<int>> roleManager)
  {
    foreach (var roleName in Enum.GetNames(typeof(Role)))
    {
      if (!await roleManager.RoleExistsAsync(roleName))
        await roleManager.CreateAsync(new IdentityRole<int>(roleName));
    }
  }

  public static async Task SeedAdminUserAsync(UserManager<IdentityUser<int>> userManager)
  {
    var adminEmail = "admin@example.com";
    if (await userManager.FindByEmailAsync(adminEmail) == null)
    {
      var admin = new IdentityUser<int> { UserName = adminEmail, Email = adminEmail };
      await userManager.CreateAsync(admin, "Admin123!");
      await userManager.AddToRoleAsync(admin, nameof(Role.Admin));
    }
  }
}
