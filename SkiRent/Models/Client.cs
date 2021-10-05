using System;
using System.Collections.Generic;

#nullable disable

namespace SkiRent.Models
{
    public partial class Client
    {
        public Client()
        {
            Orders = new HashSet<Order>();
        }

        public int ClientId { get; set; }
        public string Name { get; set; }
        public long Phone { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public int Size { get; set; }
        public float? Depozit { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
