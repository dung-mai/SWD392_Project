using System;
using System.Collections.Generic;

namespace SWD392_PracinicalManagement.Models
{
    public partial class ExaminationResult
    {
        public int ResultId { get; set; }
        public int MedicalRecord { get; set; }
        public int DoctorId { get; set; }
        public int ServiceId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public string? Description { get; set; }
        public byte[]? AttachmentFile { get; set; }

        public virtual Doctor Doctor { get; set; } = null!;
        public virtual MedicalRecord MedicalRecordNavigation { get; set; } = null!;
        public virtual PracinicalService Service { get; set; } = null!;
    }
}
