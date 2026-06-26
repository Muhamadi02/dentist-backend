using dentist.api.Domain.Entities;

namespace dentist.api.Application.Interfaces;

public interface IPatientService
{
    Task<IEnumerable<Patient>> GetAllAsync();

    Task<Patient?> GetByIdAsync(int id);

    Task<Patient> CreateAsync(Patient patient);

    Task<Patient?> UpdateAsync(int id, Patient patient);

    Task<bool> DeleteAsync(int id);
}
