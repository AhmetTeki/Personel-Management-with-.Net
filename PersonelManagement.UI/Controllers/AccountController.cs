
using Humanizer;
using MediatR;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

using PersonelManagement.Application.Requests;
using System.Security.Claims;
using PersonelManagement.Application.Dtos;

namespace PersonelManagement.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest request)
        {
           var result=await this._mediator.Send(request);
            if (result.IsSucces)
            {
                return RedirectToAction("", "", new {area=""});
            }
            else
            {
                if (result.Errors != null && result.Errors.Count > 0)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                    }
                }
                else
                {
                    ModelState.AddModelError("", result.ErrorMassage ?? "Bilinmeyen bir hata oluştu, sistem üreticinize başvurun.");
                }
                return View(request);
            }
            
        }
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult LogOut()
        {
            return View();
        }
        private async Task SetAuthCookie(LoginResponseDto dto)
        {
           // User.Claims.SingleOrDefault(x => x.Type == ClaimTypes.Name);
        //    var claims = new List<Claim>
        //    {
        //        new Claim("UserId",dto.Id+""),
        //    new Claim("Name", dto.Name),
        //    new Claim("Surname", dto.Surname),
        //    new Claim(ClaimTypes.Role, dto.Role.ToString()),
        //};

        //    var claimsIdentity = new ClaimsIdentity(
        //        claims, CookieAuthenticationDefaults.AuthenticationScheme);

        //    var authProperties = new AuthenticationProperties
        //    {
        //        //AllowRefresh = <bool>,
        //        // Refreshing the authentication session should be allowed.

        //        ExpiresUtc = DateTimeOffset.UtcNow.AddDays(30),
        //        // The time at which the authentication ticket expires. A 
        //        // value set here overrides the ExpireTimeSpan option of 
        //        // CookieAuthenticationOptions set with AddCookie.

        //        IsPersistent = rememberMe,
        //        // Whether the authentication session is persisted across 
        //        // multiple requests. When used with cookies, controls
        //        // whether the cookie's lifetime is absolute (matching the
        //        // lifetime of the authentication ticket) or session-based.

        //        //IssuedUtc = <DateTimeOffset>,
        //        // The time at which the authentication ticket was issued.

        //        //RedirectUri = <string>
        //        // The full path or absolute URI to be used as an http 
        //        // redirect response value.
        //    };

        //    await HttpContext.SignInAsync(
        //        CookieAuthenticationDefaults.AuthenticationScheme,
        //        new ClaimsPrincipal(claimsIdentity),
        //        authProperties);
        }
    }
}
