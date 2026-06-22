using dentist.api.Domain.Lookups;
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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Treatment>()
            .HasOne(t => t.Patient)
            .WithMany(p => p.Treatments)
            .HasForeignKey(t => t.PatientId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Treatment>()
            .HasOne(t => t.Doctor)
            .WithMany(d => d.Treatments)
            .HasForeignKey(t => t.DoctorId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Treatment>()
            .HasOne(t => t.DentistService)
            .WithMany(ds => ds.Treatments)
            .HasForeignKey(t => t.DentistServiceId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
