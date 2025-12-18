using Microsoft.AspNetCore.Identity;

namespace _002.AuthenticationWithMvc.Models.Entities;

public class User : IdentityUser<long>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}