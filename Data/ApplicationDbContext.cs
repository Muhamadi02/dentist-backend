using dentist.api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace dentist.api.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();
    public DbSet<Patient> Patients => Set<Patient>();
    public DbSet<DentistService> DentistServices => Set<DentistService>();
    public DbSet<Treatment> Treatments => Set<Treatment>();
}
