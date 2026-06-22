using dentist.api.Domain.Common;
using dentist.api.Domain.Lookups;

namespace dentist.api.Domain.Entities;

public class Treatment : BaseEntity
{
    public int PatientId { get; set; }
    public Patient Patient { get; set; } = null!;

    public int DoctorId { get; set; }
    public User Doctor { get; set; } = null!;

    public int DentistServiceId { get; set; }
    public DentistService DentistService { get; set; } = null!;

    public decimal Price { get; set; }
    public decimal DoctorIncome { get; set; }
    public decimal ClinicIncome { get; set; }
    public DateTime TreatmentDate { get; set; }
    public string? Comment { get; set; }
    
}
