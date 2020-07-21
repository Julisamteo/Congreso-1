using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Congreso_1.Models
{
    public class Stand
    {
        [Key]

        public int Stand_id { get; set; }
        public int StandTypeId { get; set; }
        public Stand_Type Stand_Type { get; set; }
        public int Available { get; set; }
        public ICollection<Congress_Enterprise> Congress_Enterprises { get; set; }
    }
}
