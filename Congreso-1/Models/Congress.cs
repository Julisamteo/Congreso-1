﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Congreso_1.Models
{
    public class Congress
    {
        [Key]
        public int  CongressId { get; set; }
       public string CongressName { get; set; }
       public string CongressTheme { get; set; }
       public DateTime CongressInitialDate { get; set; }
       public DateTime CongressFinalDate { get; set; }
       public int Available { get; set; }
        public ICollection<Webinar> Webinar { get; set; }

    }
}
