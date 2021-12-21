using System;
using System.Collections.Generic;

#nullable disable

namespace coreDatabaseFirstApproachApplication.Models
{
    public partial class Brand
    {
        public Brand()
        {
            Products = new HashSet<Product>();
        }

        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public string BrandDesc { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
