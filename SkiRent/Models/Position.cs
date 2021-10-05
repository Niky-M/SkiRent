using System;
using System.Collections.Generic;

#nullable disable

namespace SkiRent.Models
{
    public partial class Position
    {
        public Position()
        {
            StuffsPositions = new HashSet<StuffsPosition>();
        }

        public int PositionId { get; set; }
        public int Position1 { get; set; }

        public virtual ICollection<StuffsPosition> StuffsPositions { get; set; }
    }
}
