using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventManagment.Areas.Admin.Models
{
    public class State
    {
        public int StateId { get; set; }

        [Required]
        public string StateName { get; set; }

        [Required]
        public int CountryId { get; set; }
    }
}