using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Congreso_1.Models
{
    public class Stand_Type
    {
        [Key]
        public int StandType { get; set; }
        public string StandTypeName { get; set; }
        public string StandTypeDescription { get; set; }
        public int ResourceQuantity { get; set; }
    }
}
