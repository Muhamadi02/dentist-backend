using dentist.api.Domain.Common;

namespace dentist.api.Domain.Entities;

public class Patient : BaseEntity
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateOnly DateOfBirth { get; set; }
    public string? Notes { get; set; }
    public ICollection<Treatment> Treatments { get; set; } = new List<Treatment>();
    
}
