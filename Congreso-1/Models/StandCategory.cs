using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Congreso_1.Models
{
    public class StandCategory
    {
        [Key]
        [Column(Order =0)]
        [ForeignKey("Stand")]
        public int stand_id { get; set; }
        public int category_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [ForeignKey("Category")]
        public virtual Stand Stand { get; set; }
        public virtual Category Category { get; set; }
    }
}