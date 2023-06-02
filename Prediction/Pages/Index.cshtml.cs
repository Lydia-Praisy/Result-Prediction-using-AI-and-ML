using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Prediction.Model;
using Prediction.ViewModel;
using System.Security.Claims;

namespace Prediction.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public LoginViewModel LoginModel { get; set; }

        public IActionResult OnGet()
        {
            try
            {
                if (User.Identity.IsAuthenticated)
                {
                    return this.RedirectToPage("/Home");
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }

            return this.Page();
        }

        public async Task<IActionResult> OnPostLogIn(LoginModel loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (this.LoginModel.Username == "lydia")
                    {
                        var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, this.LoginModel.Username)
                    };
                        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                        return this.RedirectToPage("/Home");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Invalid username or password.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }

            return this.Page();
        }
    }
}