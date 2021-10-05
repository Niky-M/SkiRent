using System;
using System.Collections.Generic;

#nullable disable

namespace SkiRent.Models
{
    public partial class Stick
    {
        public Stick()
        {
            Orders = new HashSet<Order>();
        }

        public int StickId { get; set; }
        public int BrandId { get; set; }
        public int LevelId { get; set; }
        public int Length { get; set; }
        public float Price { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual Level Level { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
