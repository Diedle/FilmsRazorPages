using Films.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace Films.Pages
{
    [IgnoreAntiforgeryToken]
    public class LoginModel : PageModel
    {

        ApplicationContext contextt;
        IHttpContextAccessor httpContextAccessor;

        [BindProperty]
        public User User { get; set; }

        public LoginModel(ApplicationContext db, IHttpContextAccessor httpContextAccessor)
        {
            contextt = db;
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (User.login is null || User.password is null)
                return BadRequest("Email и/или пароль не установлены");

            User? user = contextt.Users.FirstOrDefault(p => p.login == User.login && p.password == User.password);

            if (user is null)
                return Unauthorized();

            var claims = new List<Claim> { new Claim(ClaimTypes.Name, user.login) };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Cookies");

            await httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
            return RedirectToPage("Index");
        }

    }
}