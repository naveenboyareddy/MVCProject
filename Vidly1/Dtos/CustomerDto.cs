using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly1.Models;
using System.ComponentModel.DataAnnotations;

namespace Vidly1.Dtos
{
    public class CustomerDto
    {
        public int id { get; set; }
        [Required]
        [StringLength(255)]
        public string name { get; set; }
        
        //[Min18YearsIfAMemeber]
        public DateTime? BirthDate { get; set; }
        public bool IsSubscribedToNewsLetter { get; set; }

        public MembershipTypeDto MembershipType { get; set; }

        public byte MembershipTypeId { get; set; }
    }
}