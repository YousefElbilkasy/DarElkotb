using System;
using Microsoft.AspNetCore.Identity;

namespace DarElkotb.Services;

public class AccountService : IAccountService
{
  private readonly UserManager<IdentityUser<int>> _userManager;
  private readonly SignInManager<IdentityUser<int>> _signInManager;

  public AccountService(SignInManager<IdentityUser<int>> signInManager, UserManager<IdentityUser<int>> userManager)
  {
    _signInManager = signInManager;
    _userManager = userManager;
  }

  public Task<bool> ForgotPassword(string email)
  {
    throw new NotImplementedException();
  }

  public async Task<SignInResult?> Login(LoginDto loginDto)
  {
    var result = await _signInManager.PasswordSignInAsync(loginDto.Email, loginDto.Password, loginDto.RememberMe, false);
    return result;
  }

  public async Task<IdentityResult?> Register(RegisterDto registerDto)
  {
    var user = new IdentityUser<int> { UserName = registerDto.Email, Email = registerDto.Email };
    var result = await _userManager.CreateAsync(user, registerDto.Password);
    if (result.Succeeded)
    {
      // Assign the user to the "User" role
      await _userManager.AddToRoleAsync(user, nameof(Role.User));

      // Sign in the user
      await _signInManager.SignInAsync(user, isPersistent: false);
    }

    return result;
  }

  public async Task SignOut()
  {
    await _signInManager.SignOutAsync();
  }
}
