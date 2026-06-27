using dentist.api.Application.DTOs;
using dentist.api.Application.Interfaces;
using dentist.api.Data;
using Microsoft.EntityFrameworkCore;

namespace dentist.api.Infrastructure.Services;

public class AuthService : IAuthService
{
    private readonly ApplicationDbContext _context;

    private readonly IJwtTokenService _jwtTokenService;

    public AuthService(ApplicationDbContext context, IJwtTokenService jwtTokenService)
    {
        _context = context;
        _jwtTokenService = jwtTokenService;
    }

    public async Task<LoginResponseDto?> LoginAsync(LoginRequestDto request)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == request.Email);

        if (user == null)
        {
            return null;
        }

        if (!user.IsActive)
        {
            return null;
        }

        if (user.Password != request.Password)
        {
            return null;
        }

        var token = _jwtTokenService.GenerateToken(user);

        return new LoginResponseDto { Token = token };
    }

}
