using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cw11.Models
{
    public class Prescription
    {
        public int IdPrescription { get; set; }
        
        public DateTime Date { get; set; }
        
        public DateTime DueDate { get; set; }

        [ForeignKey("Doctor")]
        public int IdDoctor { get; set; }
        
        [ForeignKey("Patient")]
        public int IdPatient { get; set; }
        
        public virtual Doctor Doctor { get; set; }

        public virtual Patient Patient { get; set; }
        
        public ICollection<PrescriptionMedicament> PrescriptionMedicaments { get; set; }
        
    }
}