using System;
using System.Collections.Generic;

#nullable disable

namespace SkiRent.Models
{
    public partial class Ski
    {
        public Ski()
        {
            Orders = new HashSet<Order>();
        }

        public int SkiId { get; set; }
        public int BrandId { get; set; }
        public string Style { get; set; }
        public int Length { get; set; }
        public int Weight { get; set; }
        public string Bracing { get; set; }
        public int LevelId { get; set; }
        public float Price { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual Level Level { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
