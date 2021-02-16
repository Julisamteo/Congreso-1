using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Congreso_1.Models
{
    public class Category
    {
        [Key]
        public int category_id { get; set; }
        [MaxLength(length:50)]
        public string category_name { get; set; }
        public string category_description { get; set; }

    }
}