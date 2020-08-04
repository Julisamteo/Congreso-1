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
        public string StandName { get; set; }
        public string EnterpriseLogo { get; set; }
        public string EnterpriseBanner { get; set; }
        public string StandBody { get; set; }
        public string StandResourceA { get; set; }
        public string StandResourceB { get; set; }
        public string StandResourceC { get; set; }
        public ICollection<Stand> Stands { get; set; }
    }
}
