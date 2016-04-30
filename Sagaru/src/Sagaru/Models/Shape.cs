using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Sagaru.Models
{
    public class Shape
    {
        [Key]
        public int ShapeId { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public string Type { get; set; }
        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
