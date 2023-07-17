using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace SWD392_PracinicalManagement.Models
{
    [Serializable]
    public partial class PracinicalCategory
    {
        public PracinicalCategory()
        {
            PracinicalServices = new HashSet<PracinicalService>();
        }
        [XmlElement]
        public int PracinicalCategoryId { get; set; }

        [XmlElement]
        public string? PracinicalCategoryName { get; set; }

        [XmlElement]
        public string? Desctiption { get; set; }

        [XmlElement]
        public int DepartmentId { get; set; }

        [XmlElement]
        public int? CreatedBy { get; set; }

        [XmlElement]
        public DateTime? CreatedDate { get; set; }

        [XmlIgnore]
        public virtual Account? CreatedByNavigation { get; set; }
        [XmlIgnore]
        public virtual Department Department { get; set; } = null!;
        [XmlIgnore]
        public virtual ICollection<PracinicalService> PracinicalServices { get; set; }
    }
}
