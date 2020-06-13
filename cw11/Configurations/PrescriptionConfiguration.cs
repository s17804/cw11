using System;
using System.Collections.Generic;
using cw11.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace cw11.Configurations
{
    public class PrescriptionConfiguration : IEntityTypeConfiguration<Prescription>
    {
        public void Configure(EntityTypeBuilder<Prescription> builder)
        {
            builder.HasKey(p => p.IdPrescription);

            builder.Property(p => p.Date)
                .IsRequired();
            
            builder.Property(p => p.DueDate)
                .IsRequired();

            builder.HasOne(p => p.Doctor)
                .WithMany(d => d.Prescriptions)
                .HasForeignKey(p => p.IdDoctor);
            
            builder.HasOne(p => p.Patient)
                .WithMany(pa => pa.Prescriptions)
                .HasForeignKey(p => p.IdPatient);

            builder.HasMany(p => p.PrescriptionMedicaments)
                .WithOne(pm => pm.Prescription);
            
            
            var prescriptionList = new List<Prescription>
            {
                new Prescription {IdPrescription = 1, Date = DateTime.Parse("2020-05-20"), DueDate = DateTime.Parse("2020-06-20"), IdPatient = 1, IdDoctor = 1},
                new Prescription {IdPrescription = 2, Date = DateTime.Parse("2020-05-21"), DueDate = DateTime.Parse("2020-06-21"), IdPatient = 1, IdDoctor = 2},
                new Prescription {IdPrescription = 3, Date = DateTime.Parse("2020-05-22"), DueDate = DateTime.Parse("2020-06-22"), IdPatient = 2, IdDoctor = 2},
            };
            
            builder.HasData(prescriptionList);
        }
    }
}