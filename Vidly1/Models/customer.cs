using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly1.Models
{
    public class customer
    {
        public int id { get; set; }
        [Required]
        [StringLength(255)]
        public string name { get; set; }
         [Display( Name = "Date of Birth")]
        [Min18YearsIfAMemeber]
        public DateTime? BirthDate { get; set; }
        public bool IsSubscribedToNewsLetter { get; set; }

        public MembershipType MembershipType { get; set; }
        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }
      

        

    }
    }