using System;
using System.Collections.Generic;

namespace SWD392_PracinicalManagement.DataAccess.Models
{
    public partial class PracinicalCategory
    {
        public PracinicalCategory()
        {
            PracinicalServices = new HashSet<PracinicalService>();
        }

        public int PracinicalCategoryId { get; set; }
        public string? PracinicalCategoryName { get; set; }
        public string? Desctiption { get; set; }
        public int DepartmentId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual Department Department { get; set; } = null!;
        public virtual ICollection<PracinicalService> PracinicalServices { get; set; }
    }
}
