using System;
using System.Collections.Generic;

#nullable disable

namespace SkiRent.Models
{
    public partial class training
    {
        public int TrainingId { get; set; }
        public string TrainingType { get; set; }
        public int Duration { get; set; }
        public DateTime StartTime { get; set; }
        public float Price { get; set; }
        public int StuffId { get; set; }

        public virtual Stuff Stuff { get; set; }
    }
}
