using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Congreso_1.Models
{
    public class Webinar
    {
        [Key]

        public int WebinarId { get; set; }
    // Sirve para poner el tema del Webinar
      public string WebinarTheme { get; set; }
      public DateTime WebinarInitialDate { get; set; }
      public DateTime WebinarEndDate { get; set; }
      public int UserCount { get; set; }
      public int available { get; set; }


        // FALTA ID A ASPNET USERS

        public ApplicationUser User_ID { get; set; }

        // Permite a Schedule acceder a la Data
        public ICollection<Schedule> Schedules { get; set; }


    }
}
