using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventManagment.Areas.Admin.Models
{
    public class Organizer
    {
        public int EventId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string EventName { get; set; }

        [Required]
        public string EventDetails { get; set; }
    }
}