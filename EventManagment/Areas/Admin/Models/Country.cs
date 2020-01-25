using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventManagment.Areas.Admin.Models
{
    public class Country
    {
        
        public int CountryId { get; set; }

        [Required]
        public string CountryName { get; set; }
    }
}