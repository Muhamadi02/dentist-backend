using dentist.api.Domain.Entities;

namespace dentist.api.Application.Interfaces;

public interface IJwtTokenService
{
    string GenerateToken(User user);
}
