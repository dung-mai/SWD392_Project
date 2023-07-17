using System;
using System.Collections.Generic;

namespace SWD392_PracinicalManagement.Models
{
    public partial class Department
    {
        public Department()
        {
            PracinicalCategories = new HashSet<PracinicalCategory>();
        }

        public int DepartmentId { get; set; }
        public string? DepartmentName { get; set; }

        public virtual ICollection<PracinicalCategory> PracinicalCategories { get; set; }
    }
}
