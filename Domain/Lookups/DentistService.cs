using dentist.api.Domain.Common;
using dentist.api.Domain.Entities;

namespace dentist.api.Domain.Lookups;

public class DentistService : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public decimal DefaultPrice { get; set; }
    public bool IsActive { get; set; } = true;
    public ICollection<Treatment> Treatments { get; set; } = new List<Treatment>();
    
}
