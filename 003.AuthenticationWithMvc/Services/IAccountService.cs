using _002.AuthenticationWithMvc.Dtos;

namespace _002.AuthenticationWithMvc.Services;

public interface IAccountService
{
    Task<Response<LoginResponseDto>> LoginAsync(LoginDto loginDto);
    Task<Response<RegisterDto>> RegisterAsync(RegisterDto model);
}