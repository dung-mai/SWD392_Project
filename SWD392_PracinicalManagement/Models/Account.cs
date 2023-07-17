using System;
using System.Collections.Generic;

namespace SWD392_PracinicalManagement.Models
{
    public partial class Account
    {
        public Account()
        {
            Doctors = new HashSet<Doctor>();
            ExaminationForms = new HashSet<ExaminationForm>();
            MedicalRecords = new HashSet<MedicalRecord>();
            PracinicalCategories = new HashSet<PracinicalCategory>();
        }

        public int AccountId { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public int? RoleId { get; set; }
        public string? Name { get; set; }
        public string? Gender { get; set; }
        public DateTime? Dob { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public bool? Status { get; set; }

        public virtual Role? Role { get; set; }
        public virtual ICollection<Doctor> Doctors { get; set; }
        public virtual ICollection<ExaminationForm> ExaminationForms { get; set; }
        public virtual ICollection<MedicalRecord> MedicalRecords { get; set; }
        public virtual ICollection<PracinicalCategory> PracinicalCategories { get; set; }
    }
}
