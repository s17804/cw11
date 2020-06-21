using System.Collections.Generic;
using cw11.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace cw11.Configurations
{
    public class PrescriptionMedicamentConfiguration : IEntityTypeConfiguration<PrescriptionMedicament>
    {
        public void Configure(EntityTypeBuilder<PrescriptionMedicament> builder)
        {
            builder.HasKey(m => new {m.IdMedicament, m.IdPrescription});
            
            builder.Property(pm => pm.Dose)
                .IsRequired();
            
            builder.Property(pm => pm.Details)
                .HasMaxLength(100)
                .IsRequired();

            builder.HasOne(pm => pm.Medicament)
                .WithMany(m => m.PrescriptionMedicaments)
                .HasForeignKey(pm => pm.IdMedicament);
            
            builder.HasOne(pm => pm.Prescription)
                .WithMany(p => p.PrescriptionMedicaments)
                .HasForeignKey(pm => pm.IdPrescription);

            
            var medicamentList = new List<PrescriptionMedicament>
            {
                new PrescriptionMedicament() {IdMedicament = 1, IdPrescription = 1, Dose = 50, Details = "Details 1"},
                new PrescriptionMedicament() {IdMedicament = 2, IdPrescription = 2, Dose = 100, Details = "Details 2"},
                new PrescriptionMedicament() {IdMedicament = 1, IdPrescription = 3, Dose = 150, Details = "Details 3"},
            };
            
            builder.HasData(medicamentList);
        }
    }
}


