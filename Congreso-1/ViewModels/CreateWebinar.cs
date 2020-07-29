using Congreso_1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Congreso_1.ViewModels
{
    public class CreateWebinar
    {
        public string WebinarTheme;
        public DateTime WebinarInitialDate;
        public DateTime WebinarEndDate;
        public bool available;
        public int congressId;
        public ICollection<Congress> congressList;
    }
}