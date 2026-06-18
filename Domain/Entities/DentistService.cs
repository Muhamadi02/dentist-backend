using dentist.api.Domain.Common;

namespace dentist.api.Domain.Entities;

public class DentistService : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public decimal DefaultPrice { get; set; }
    public bool IsActive { get; set; } = true;
    
}
