using System;
using System.Collections.Generic;

#nullable disable

namespace SkiRent.Models
{
    public partial class Order
    {
        public int OrderId { get; set; }
        public int ClientId { get; set; }
        public int? StuffId { get; set; }
        public int? SkiId { get; set; }
        public int? BootId { get; set; }
        public int? StickId { get; set; }
        public string Status { get; set; }
        public DateTime Data { get; set; }
        public float Price { get; set; }

        public virtual Boot Boot { get; set; }
        public virtual Client Client { get; set; }
        public virtual Ski Ski { get; set; }
        public virtual Stick Stick { get; set; }
        public virtual Stuff Stuff { get; set; }
    }
}
