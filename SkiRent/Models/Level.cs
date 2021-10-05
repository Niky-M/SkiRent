using System;
using System.Collections.Generic;

#nullable disable

namespace SkiRent.Models
{
    public partial class Level
    {
        public Level()
        {
            Boots = new HashSet<Boot>();
            Skis = new HashSet<Ski>();
            Sticks = new HashSet<Stick>();
        }

        public int LevelId { get; set; }
        public string LevelName { get; set; }

        public virtual ICollection<Boot> Boots { get; set; }
        public virtual ICollection<Ski> Skis { get; set; }
        public virtual ICollection<Stick> Sticks { get; set; }
    }
}
