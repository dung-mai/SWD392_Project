using System;
using System.Collections.Generic;

namespace SWD392_PracinicalManagement.DataAccess.Models
{
    public partial class Doctor
    {
        public Doctor()
        {
            ExaminationResults = new HashSet<ExaminationResult>();
        }

        public int AccountId { get; set; }
        public int Code { get; set; }
        public DateTime? HireDate { get; set; }
        public string? ExpertiseDetail { get; set; }
        public int? DepartmentId { get; set; }

        public virtual Account Account { get; set; } = null!;
        public virtual ICollection<ExaminationResult> ExaminationResults { get; set; }
    }
}
