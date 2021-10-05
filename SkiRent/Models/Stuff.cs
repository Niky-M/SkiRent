using System;
using System.Collections.Generic;

#nullable disable

namespace SkiRent.Models
{
    public partial class Stuff
    {
        public Stuff()
        {
            Orders = new HashSet<Order>();
            Services = new HashSet<Service>();
            StuffsPositions = new HashSet<StuffsPosition>();
            training = new HashSet<training>();
        }

        public int StuffId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public long Phone { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Service> Services { get; set; }
        public virtual ICollection<StuffsPosition> StuffsPositions { get; set; }
        public virtual ICollection<training> training { get; set; }
    }
}
