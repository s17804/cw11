using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cw11.Models
{
    public class Patient
    {
        
        public int IdPatient { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public DateTime BirthDate { get; set; }
        
        public ICollection<Prescription> Prescriptions { get; set; } 
    }
}