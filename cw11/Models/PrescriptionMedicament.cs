using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cw11.Models
{
   [Table("Prescription_Medicament")]
    public class PrescriptionMedicament
    {
        public int Dose { get; set; }
        
        public string Details { get; set; }

        public int IdPrescription { get; set; }

        public int IdMedicament { get; set; }
        
        public Prescription Prescription { get; set; }

        public Medicament Medicament { get; set; }
        
    }
}