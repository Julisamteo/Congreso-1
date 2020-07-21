using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Congreso_1.Models
{
    public class Stand_Resource
    {
        [Key]

        public int StandId { get; set; }
        public Stand Stand { get; set; }
        public int DResourceId {get; set;}
        public Digital_Resource Digital_Resource { get; set; }

    }
}
