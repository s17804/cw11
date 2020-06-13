using System;
using System.Collections.Generic;
using cw11.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace cw11.Configurations
{
    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {

            builder.HasKey(p => p.IdPatient);

            builder .Property(p => p.FirstName)
                .HasMaxLength(100)
                .IsRequired();
            
            builder .Property(p => p.LastName)
                .HasMaxLength(100)
                .IsRequired();
            
            builder .Property(p => p.BirthDate)
                .IsRequired();

            builder.HasMany(p => p.Prescriptions)
                .WithOne(pr => pr.Patient);

            var patientList = new List<Patient>
            {
                new Patient {IdPatient = 1, FirstName = "Celina", LastName = "Cebula", BirthDate = DateTime.Parse("1982-02-03")},
                new Patient {IdPatient = 2, FirstName = "Dorota", LastName = "Dynia", BirthDate = DateTime.Parse("1999-04-05")}
            };
            
            builder.HasData(patientList);
        }
    }
}