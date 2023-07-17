using System;
using System.Collections.Generic;

namespace SWD392_PracinicalManagement.Models
{
    public partial class ExaminationForm
    {
        public int ExaminationFormId { get; set; }
        public DateTime? MeetingDate { get; set; }
        public string? Note { get; set; }
        public int? PatientId { get; set; }
        public int? DoctorCode { get; set; }

        public virtual Doctor? DoctorCodeNavigation { get; set; }
        public virtual Account? Patient { get; set; }
    }
}
