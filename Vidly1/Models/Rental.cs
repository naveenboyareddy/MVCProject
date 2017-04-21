using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly1.Models
{
    public class Rental
    {
        public int ID { get; set; }
        public DateTime DateRented { get; set; }
        public DateTime? DateReturned { get; set; }
        [Required   ]
        public customer Customers { get; set; }
        [Required]
        public Movie Movies { get; set; }
    }

}