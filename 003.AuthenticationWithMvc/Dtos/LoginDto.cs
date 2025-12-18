using System.ComponentModel.DataAnnotations;

namespace _002.AuthenticationWithMvc.Dtos;

public class LoginDto
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string? ReturnUrl { get; set; }
}