using System;
using Microsoft.AspNetCore.Identity;

namespace DarElkotb.ServicesContract;

public interface IAccountService
{
  Task<SignInResult?> Login(LoginDto loginDto);
  Task<IdentityResult?> Register(RegisterDto registerDto);
  Task SignOut();
  Task<bool> ForgotPassword(string email);
}
