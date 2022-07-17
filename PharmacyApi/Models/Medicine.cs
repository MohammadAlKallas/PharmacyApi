using System;
using System.Collections.Generic;

#nullable disable

namespace PharmacyApi.Models
{
    public partial class Medicine
    {
        public int Id { get; set; }
        public byte ManufactureCompanyId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }

        public virtual ManufactureCompany ManufactureCompany { get; set; }
    }
}
