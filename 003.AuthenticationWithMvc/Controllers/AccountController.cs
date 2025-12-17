using System.Security.Claims;
using _002.AuthenticationWithMvc.Dtos;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace _002.AuthenticationWithMvc.Controllers;

public class AccountController : Controller
{

    [HttpGet]
    public IActionResult Login(string? returnUrl)
    {
        return View(new LoginDto() { ReturnUrl = returnUrl });
    }
    
    [HttpPost]
    public async Task<IActionResult> Login(LoginDto model)
    {
        if (ModelState.IsValid == false)
            return View(model);
            
        if (model is { Username: "user1", Password: "user1" })
        {
            //fill claims 
            var cliams = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, "Alijon"),
                new Claim(ClaimTypes.Email, "alijon@gmail.com"),
                new Claim(ClaimTypes.Role, "Admin")
            };
       
            //create identity 
            var userIdentity = new ClaimsIdentity(cliams, "UserIdentity");
            
            // create principal
            var userPrincipal = new ClaimsPrincipal(userIdentity);

            await  HttpContext.SignInAsync(userPrincipal, new AuthenticationProperties
            {
                ExpiresUtc = DateTime.UtcNow.AddMinutes(10),
                IsPersistent = true,
            });

            // if (model.ReturnUrl != null)
            //     return Redirect(model.ReturnUrl);
            //else
            return RedirectToAction("Index", "Home");
        }
        
        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync();
        
        return RedirectToAction("Index","Home");
    }

    [HttpGet]
    public IActionResult AccessDenied()
    {
        return View();
    }
}