using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventManagment.Areas.Admin.Models
{
    public class City
    {
        public int CityId { get; set; }

        [Required]
        public string CityName { get; set; }

        [Required]
        public int StateId { get; set; }
    }
}