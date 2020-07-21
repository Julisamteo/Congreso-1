using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Congreso_1.Models
{
    public class Digital_Resource
    {
        [Key]

        public int DresourceId { get; set; }
        public string ResourceUrl { get; set; }
        public string ResourceHtml { get; set; }
        public int Available { get; set; }
        public ICollection<Stand_Resource> Stand_Resources { get; set; }
    }
}
