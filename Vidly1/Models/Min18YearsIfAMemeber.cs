using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly1.Models
{
	public class Min18YearsIfAMemeber : ValidationAttribute
	{
		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
		  var customer =(customer)validationContext.ObjectInstance;
		  if (customer.MembershipTypeId == MembershipType.unknown || customer.MembershipTypeId == MembershipType.PayAsYouGo)
			  return ValidationResult.Success;

		  if (customer.BirthDate == null)
			  return new ValidationResult ("Birthdate is required" );
		  var age = DateTime.Today.Year - customer.BirthDate.Value.Year;
		  return (age >= 18) 
			  ? ValidationResult.Success
			  : new ValidationResult("customer shpuld be 18 years old to go for MemberShipType");
	
		}
	}
}