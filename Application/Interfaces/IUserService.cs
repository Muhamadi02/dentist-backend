using dentist.api.Application.DTOs;

namespace dentist.api.Application.Interfaces;

public interface IUserService
{
    Task<IEnumerable<UserResponseDto>> GetAllAsync();

    Task<UserResponseDto?> GetByIdAsync(int id);

    Task<UserResponseDto> CreateAsync(UserCreateDto dto);

    Task<UserResponseDto?> UpdateAsync(int id, UserUpdateDto dto);

    Task<bool> DeleteAsync(int id);
    
}
