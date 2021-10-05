using System;
using System.Collections.Generic;

#nullable disable

namespace SkiRent.Models
{
    public partial class Brand
    {
        public Brand()
        {
            Boots = new HashSet<Boot>();
            Skis = new HashSet<Ski>();
            Sticks = new HashSet<Stick>();
        }

        public int BrandId { get; set; }
        public string BrandName { get; set; }

        public virtual ICollection<Boot> Boots { get; set; }
        public virtual ICollection<Ski> Skis { get; set; }
        public virtual ICollection<Stick> Sticks { get; set; }
    }
}
