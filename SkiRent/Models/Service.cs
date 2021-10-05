using System;
using System.Collections.Generic;

#nullable disable

namespace SkiRent.Models
{
    public partial class Service
    {
        public int ServiceId { get; set; }
        public int StuffId { get; set; }
        public string Service1 { get; set; }
        public float Price { get; set; }

        public virtual Stuff Stuff { get; set; }
    }
}
