using System;
using System.Collections.Generic;

#nullable disable

namespace SkiRent.Models
{
    public partial class StuffsPosition
    {
        public int StuffsPositionId { get; set; }
        public int StuffId { get; set; }
        public int PositionId { get; set; }

        public virtual Position Position { get; set; }
        public virtual Stuff Stuff { get; set; }
    }
}
