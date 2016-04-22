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
        public int x { get; set; }
        public int y { get; set; }
    }
}
