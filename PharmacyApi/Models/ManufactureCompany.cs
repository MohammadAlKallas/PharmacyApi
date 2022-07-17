using System;
using System.Collections.Generic;

#nullable disable

namespace PharmacyApi.Models
{
    public partial class ManufactureCompany
    {
        public ManufactureCompany()
        {
            Medicines = new HashSet<Medicine>();
        }

        public byte Id { get; set; }
        public string Value { get; set; }

        public virtual ICollection<Medicine> Medicines { get; set; }
    }
}
