using dentist.api.Application.DTOs;

namespace dentist.api.Application.Interfaces;

public interface IAuthService
{
    Task<LoginResponseDto?> LoginAsync(LoginRequestDto request);
}
