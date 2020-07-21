using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Congreso_1.Models
{
    public class Congress_Enterprise
    {
        [Key]
        public int CongressId { get; set; }
        public Congress Congress { get; set; }
        public int EnterpriseId { get; set; }
        public Enterprise Enterprise { get; set; }
        public int StandId { get; set; }
        public Stand Stand { get; set; }
    }
}
