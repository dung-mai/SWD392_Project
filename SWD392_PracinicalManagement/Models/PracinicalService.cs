using System;
using System.Collections.Generic;

namespace SWD392_PracinicalManagement.Models
{
    public partial class PracinicalService
    {
        public PracinicalService()
        {
            ExaminationResults = new HashSet<ExaminationResult>();
        }

        public int PracinicalServiceId { get; set; }
        public int CategoryId { get; set; }
        public string? ServiceName { get; set; }
        public string? ServiceDescription { get; set; }
        public decimal? Price { get; set; }

        public virtual PracinicalCategory Category { get; set; } = null!;
        public virtual ICollection<ExaminationResult> ExaminationResults { get; set; }
    }
}
