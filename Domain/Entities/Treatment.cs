using dentist.api.Domain.Common;

namespace dentist.api.Domain.Entities;

public class Treatment : BaseEntity
{
    public int PatientId { get; set; }
    public int DoctorId { get; set; }
    public int DentistServiceId { get; set; }
    public decimal Price { get; set; }
    public decimal DoctorIncome { get; set; }
    public decimal ClinicIncome { get; set; }
    public DateTime TreatmentDate { get; set; }
    public string? Comment { get; set; }
    
}
