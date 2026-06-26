using dentist.api.Application.Interfaces;
using dentist.api.Data;
using dentist.api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace dentist.api.Infrastructure.Services;

public class PatientService : IPatientService
{
    private readonly ApplicationDbContext _context;

    public PatientService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Patient>> GetAllAsync()
    {
        return await _context.Patients.ToListAsync();
    }

    public async Task<Patient?> GetByIdAsync(int id)
    {
        return await _context.Patients.FindAsync(id);
    }

    public async Task<Patient> CreateAsync(Patient patient)
    {
        patient.CreatedAt = DateTime.UtcNow;

        _context.Patients.Add(patient);

        await _context.SaveChangesAsync();
        
        return patient;
    }

    public async Task<Patient?> UpdateAsync(int id, Patient patient)
    {
        var existingPatient = await _context.Patients.FindAsync(id);
        if (existingPatient == null)
        {
            return null;
        }

        existingPatient.FirstName = patient.FirstName;
        existingPatient.LastName = patient.LastName;
        existingPatient.PhoneNumber = patient.PhoneNumber;
        existingPatient.Email = patient.Email;
        existingPatient.DateOfBirth = patient.DateOfBirth;
        existingPatient.Notes = patient.Notes;

        await _context.SaveChangesAsync();
        return existingPatient;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var patient = await _context.Patients.FindAsync(id);
        if (patient == null)
        {
            return false;
        }

        _context.Patients.Remove(patient);
        await _context.SaveChangesAsync();
        return true;
    }
}
