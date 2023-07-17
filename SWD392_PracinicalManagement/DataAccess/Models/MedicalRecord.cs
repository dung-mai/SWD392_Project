using System;
using System.Collections.Generic;

namespace SWD392_PracinicalManagement.DataAccess.Models
{
    public partial class MedicalRecord
    {
        public MedicalRecord()
        {
            ExaminationResults = new HashSet<ExaminationResult>();
        }

        public int MedicalRecordId { get; set; }
        public int? PatientId { get; set; }
        public string? Note { get; set; }

        public virtual Account? Patient { get; set; }
        public virtual ICollection<ExaminationResult> ExaminationResults { get; set; }
    }
}
