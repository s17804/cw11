using System.Collections.Generic;
using cw11.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace cw11.Configurations
{
    public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {

            builder.HasKey(d => d.IdDoctor);

            builder.Property(d => d.FirstName)
                .HasMaxLength(100)
                .IsRequired();
            
            builder.Property(d => d.LastName)
                .HasMaxLength(100)
                .IsRequired();
            
            builder.Property(d => d.Email)
                .HasMaxLength(100)
                .IsRequired();

            builder.HasMany(d => d.Prescriptions)
                .WithOne(p => p.Doctor);

            var doctorList = new List<Doctor>
            {
                new Doctor {IdDoctor = 1, FirstName = "Adam", LastName = "Arbuz", Email = "aa@gmail.com"},
                new Doctor {IdDoctor = 2, FirstName = "Bogusław", LastName = "Brokół", Email = "bb@gmail.com"}
            };


            builder.HasData(doctorList);
        }
    }
}