using System.Security.Claims;
using ConfArch.Data.Repositories.Contracts;
using ConfArch.Web.AuthenticationSchemes;
using ConfArch.Web.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ConfArch.Web.Controllers;

public class AccountController : Controller
{
    private readonly IUserRepository _userRepository;

    public AccountController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [AllowAnonymous]
    public IActionResult Login(string returnUrl = "/") =>
        View(new LoginModel { ReturnUrl = returnUrl });

    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> Login(LoginModel model)
    {
        if (model.Username is null || model.Password is null)
            return BadRequest();
        var user = await _userRepository.GetByUsernameAndPassword(model.Username, model.Password);
        if (user is null)
            return Unauthorized();
        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new(ClaimTypes.Name, user.Name),
            new(ClaimTypes.Role, user.Role),
            new("FavoriteColor", user.FavoriteColor),
        };
        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var principal = new ClaimsPrincipal(identity);

        await HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            principal,
            new AuthenticationProperties { IsPersistent = model.RememberLogin });

        return LocalRedirect(model.ReturnUrl);
    }
    
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return Redirect("/");
    }

    [AllowAnonymous]
    public IActionResult LoginWithGoogle(string returnUrl = "/")
    {
        var props = new AuthenticationProperties
        {
            RedirectUri = Url.Action("GoogleLoginCallback"),
            Items =
            {
                { "returnUrl", returnUrl }
            }
        };
        return Challenge(props, GoogleDefaults.AuthenticationScheme);
    }

    [AllowAnonymous]
    public async Task<IActionResult> GoogleLoginCallback()
    {
        var result = await HttpContext.AuthenticateAsync(ExternalAuthenticationDefaults.AuthenticationScheme);

        var externalClaims = result.Principal?.Claims.ToList();
        var subjectIdClaim = externalClaims?.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
        var subjectValue = subjectIdClaim?.Value;

        if (subjectValue == null) return Unauthorized();
        var user = await _userRepository.GetByGoogleId(subjectValue);
        if (user == null) return Unauthorized();

        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new(ClaimTypes.Name, user.Name),
            new(ClaimTypes.Role, user.Role),
            new("FavoriteColor", user.FavoriteColor),
        };

        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var principal = new ClaimsPrincipal(identity);

        await HttpContext.SignOutAsync(ExternalAuthenticationDefaults.AuthenticationScheme);
        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
        
        return LocalRedirect(result.Properties?.Items["returnUrl"] ?? "");
    }
}
