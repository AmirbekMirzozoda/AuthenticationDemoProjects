using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;

var builder = WebApplication.CreateBuilder(args);

//register services

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/login";
    });
builder.Services.AddAuthorization();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/", ()=> "Hello World");
app.MapGet("/secret",[Authorize]()=> "this is my secret");

app.MapGet("/login", async context =>
{
    
    if (context.Request.Query["Username"] == "abdullo" && context.Request.Query["Password"] == "124")
    {
        var claims = new List<Claim>()
        {
            new(ClaimTypes.Name,"Ahmad"),
            new(ClaimTypes.Email,"ahmad@gmail.com")
        };
        
        var identity = new ClaimsIdentity(claims, "UserCookie");

       await context.SignInAsync(new ClaimsPrincipal(identity), new AuthenticationProperties()
        {
            ExpiresUtc = DateTime.UtcNow.AddMinutes(10),
            IsPersistent = true,
        });
    }
    else
    {
        await context.Response.WriteAsync("Please fill out the login and password fields");
    }
});


app.Run();


public class LoginDto
{
    public string Username { get; set; }
    public string Password { get; set; }
}
