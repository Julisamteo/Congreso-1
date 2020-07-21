using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Congreso_1.Models
{
    public class City
    {
        [Key]
        public int CityId { get; set; }
        public string CityName { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
        // FALTA ID A ASPNET USERS

        public ICollection<ApplicationUser> User_ID { get; set; }
    }
}
