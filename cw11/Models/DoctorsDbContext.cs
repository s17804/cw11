using Microsoft.EntityFrameworkCore;

namespace cw11.Models
{
    public class DoctorsDbContext : DbContext
    {
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<PrescriptionMedicament> PrescriptionMedicaments { get; set; }

        public DoctorsDbContext()
        {
        }

        public DoctorsDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Doctor>()
                .HasKey(d => d.IdDoctor);

            modelBuilder.Entity<Doctor>()
                .Property(d => d.FirstName)
                .HasMaxLength(100)
                .IsRequired();

        }
    }
}