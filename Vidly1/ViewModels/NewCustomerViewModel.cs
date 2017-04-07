using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly1.Models;

namespace Vidly1.ViewModels
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> Membershiptypes { get; set; }
        public customer customer{ get; set; }
    }
}