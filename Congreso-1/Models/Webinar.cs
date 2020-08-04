using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Congreso_1.Models
{
    public class Webinar
    {
        [Key]
        public int WebinarId { get; set; }
        // Sirve para poner el tema del Webinar

        [Display(Name = "Tema")]
        public string WebinarTheme { get; set; }

        [Display(Name = "Fecha y hora de inicio")]
        public DateTime WebinarInitialDate { get; set; }

        [Display(Name = "Fecha y hora de finalización")]
        public DateTime WebinarEndDate { get; set; }
        public int UserCount { get; set; }

        [Display(Name = "Disponible")]
        public bool available { get; set; }

        [ForeignKey("Congress")]
        public int CongressId { get; set; }

        public virtual Congress Congress { get; set; }

        [ForeignKey("User_ID")]
        public string AspNetUserId { get; set; }
        public virtual ApplicationUser User_ID { get; set; }

    }
}
