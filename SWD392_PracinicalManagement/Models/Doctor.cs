using System;
using System.Collections.Generic;

namespace SWD392_PracinicalManagement.Models
{
    public partial class Doctor
    {
        public Doctor()
        {
            ExaminationForms = new HashSet<ExaminationForm>();
            ExaminationResults = new HashSet<ExaminationResult>();
        }

        public int AccountId { get; set; }
        public int Code { get; set; }
        public DateTime? HireDate { get; set; }
        public string? ExpertiseDetail { get; set; }
        public int? DepartmentId { get; set; }

        public virtual Account Account { get; set; } = null!;
        public virtual ICollection<ExaminationForm> ExaminationForms { get; set; }
        public virtual ICollection<ExaminationResult> ExaminationResults { get; set; }
    }
}
