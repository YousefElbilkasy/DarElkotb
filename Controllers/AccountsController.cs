using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DarElkotb.Controllers
{
  public class AccountsController : Controller
  {
    private readonly IAccountService _accountService;

    public AccountsController(IAccountService accountService)
    {
      _accountService = accountService;
    }

    // GET: Accounts/Login
    [HttpGet]
    public IActionResult Login() => View(new LoginDto());

    // POST: Accounts/Login
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginDto model)
    {
      if (!ModelState.IsValid)
        return View(model);

      var result = await _accountService.Login(model);
      if (result.Succeeded)
        return RedirectToAction(nameof(Index), "Home");

      ModelState.AddModelError("", "البريد الالكتروني او كلمة السر خطأ");
      return View(model);
    }

    // GET: Accounts/Register
    [HttpGet]
    public IActionResult Register() => View(new RegisterDto());

    // POST: Accounts/Register
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(RegisterDto model)
    {
      if (!ModelState.IsValid)
        return View(model);

      var result = await _accountService.Register(model);

      if (result.Succeeded)
        return RedirectToAction(nameof(Index), "Home");

      foreach (var error in result.Errors)
        ModelState.AddModelError("", error.Description);

      return View(model);
    }

    public IActionResult ForgotPassword() => View();

    // GET: Accounts/SignOut
    public async Task<IActionResult> SignOut()
    {
      await _accountService.SignOut();
      return RedirectToAction(nameof(Index), "Home");
    }

  }
}
