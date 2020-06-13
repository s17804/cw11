using System;
using System.Collections.Generic;
using cw11.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace cw11.Configurations
{
    public class MedicamentConfiguration : IEntityTypeConfiguration<Medicament>
    {
        public void Configure(EntityTypeBuilder<Medicament> builder)
        {
            builder.HasKey(m => m.IdMedicament);

            builder.Property(m => m.Name)
                .HasMaxLength(100)
                .IsRequired();
            
            builder.Property(m => m.Description)
                .HasMaxLength(100)
                .IsRequired();
            
            builder.Property(m => m.Type)
                .HasMaxLength(100)
                .IsRequired();

            builder.HasMany(m => m.PrescriptionMedicaments)
                .WithOne(mp => mp.Medicament); 

            var medicamentList = new List<Medicament>
            {
                new Medicament {IdMedicament = 1, Name = "Prozac", Description = "Prozac description", Type = "Type 1"},
                new Medicament {IdMedicament = 2, Name = "Aspirin", Description = "Aspirin description", Type = "Type 2"}
            };
            
            builder.HasData(medicamentList);
        }
    }
}