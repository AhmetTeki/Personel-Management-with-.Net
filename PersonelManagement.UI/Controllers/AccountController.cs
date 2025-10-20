
using Humanizer;
using MediatR;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

using PersonelManagement.Application.Requests;
using System.Security.Claims;
using PersonelManagement.Application.Dtos;
using System.Threading.Tasks;

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
            return View(new LoginRequest("", ""));
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            Result<LoginResponseDto?> result = await this._mediator.Send(request);
            if (result.IsSucces && result.Data != null)
            {
                await SetAuthCookie(result.Data, request.rememberMe);
                return RedirectToAction("Index", "Home", new { area = result.Data.Role });
            }
            else
            {
                if (result.Errors != null && result.Errors.Count > 0)
                {
                    foreach (ValidationError error in result.Errors)
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
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            Result<NoData> result = await this._mediator.Send(request);
            if (result.IsSucces)
            {
                return RedirectToAction("Login");
            }
            else
            {
                if (result.Errors != null && result.Errors.Count > 0)
                {
                    foreach (ValidationError error in result.Errors)
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
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
        private async Task SetAuthCookie(LoginResponseDto dto, bool rememberMe)
        {
            User.Claims.SingleOrDefault(x => x.Type == ClaimTypes.Name);
            List<Claim> claims = new List<Claim>
           {
               new Claim("Name",dto.Name),
               new Claim("Surname", dto.Surname),
               new Claim(ClaimTypes.Role, dto.Role.ToString()),
           };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            AuthenticationProperties authProperties = new AuthenticationProperties
            {
                //AllowRefresh = <bool>,
                // Refreshing the authentication session should be allowed.

                ExpiresUtc = DateTimeOffset.UtcNow.AddDays(30),
                //        // The time at which the authentication ticket expires. A 
                //        // value set here overrides the ExpireTimeSpan option of 
                //        // CookieAuthenticationOptions set with AddCookie.

                IsPersistent = rememberMe,
                //        // Whether the authentication session is persisted across 
                //        // multiple requests. When used with cookies, controls
                //        // whether the cookie's lifetime is absolute (matching the
                //        // lifetime of the authentication ticket) or session-based.

                //        //IssuedUtc = <DateTimeOffset>,
                //        // The time at which the authentication ticket was issued.

                //        //RedirectUri = <string>
                //        // The full path or absolute URI to be used as an http 
                //        // redirect response value.
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);
        }
    }
}
