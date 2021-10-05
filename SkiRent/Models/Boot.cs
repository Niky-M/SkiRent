using System;
using System.Collections.Generic;

#nullable disable

namespace SkiRent.Models
{
    public partial class Boot
    {
        public Boot()
        {
            Orders = new HashSet<Order>();
        }

        public int BootId { get; set; }
        public int BrandId { get; set; }
        public string Style { get; set; }
        public string Bracing { get; set; }
        public int LevelId { get; set; }
        public int Size { get; set; }
        public float Price { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual Level Level { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
