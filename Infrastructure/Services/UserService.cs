using dentist.api.Application.DTOs;
using dentist.api.Application.Interfaces;
using dentist.api.Data;
using dentist.api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using dentist.api.Domain.Common;

namespace dentist.api.Infrastructure.Services;

public class UserService : IUserService
{
    private readonly ApplicationDbContext _context;

    public UserService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<UserResponseDto>> GetAllAsync()
    {
        var users = await _context.Users.ToListAsync();

        return users.Select(ToResponseDto);
    }

    public async Task<UserResponseDto?> GetByIdAsync(int id)
    {
        var user = await _context.Users.FindAsync(id);

        if (user == null)
        {
            return null;
        }

        return ToResponseDto(user);
    }

    public async Task<UserResponseDto> CreateAsync(UserCreateDto dto)
    {
        var emailExists = await _context.Users.AnyAsync(u => u.Email == dto.Email);

        if (emailExists)
        {
            throw new InvalidOperationException("A user with this Email already exists.");
        }

        if (dto.Role != Roles.Admin && dto.Role != Roles.Doctor)
        {
            throw new Exception("Invalid user role.");
        }

        var user = ToEntity(dto);

        user.CreatedAt = DateTime.UtcNow;

        _context.Users.Add(user);

        await _context.SaveChangesAsync();

        return ToResponseDto(user);
    }

    public async Task<UserResponseDto?> UpdateAsync(int id, UserUpdateDto dto)
    {
        var user = await _context.Users.FindAsync(id);

        if (user == null)
        {
            return null;
        }

        var emailExists = await _context.Users.AnyAsync(u => u.Email == dto.Email && u.Id != id);

        if (emailExists)
        {
            throw new InvalidOperationException("A user with this Email already exists.");
        }

        if (dto.Role != Roles.Admin && dto.Role != Roles.Doctor)
        {
            throw new Exception("Invalid user role.");
        }

        user.FirstName = dto.FirstName;
        user.LastName = dto.LastName;
        user.PhoneNumber = dto.PhoneNumber;
        user.Email = dto.Email;
        user.Role = dto.Role;
        user.IsActive = dto.IsActive;
        
        user.ModifiedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return ToResponseDto(user);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var user = await _context.Users.FindAsync(id);

        if (user == null)
        {
            return false;
        }

        _context.Users.Remove(user);

        await _context.SaveChangesAsync();

        return true;
    }

    private static UserResponseDto ToResponseDto(User user)
    {
        return new UserResponseDto
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            PhoneNumber = user.PhoneNumber,
            Email = user.Email,
            Role = user.Role,
            IsActive = user.IsActive
        };
    }

    private static User ToEntity(UserCreateDto dto)
    {
        return new User
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            PhoneNumber = dto.PhoneNumber,
            Email = dto.Email,
            Password = dto.Password, 
            Role = dto.Role,
            IsActive = true
        };
    }

}
