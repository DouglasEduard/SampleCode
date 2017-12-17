using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly2.Models
{
    public class Min18yearsifAMember: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            if ((customer.MembershipTypeId == MembershipType.Unknown) || 
                (customer.MembershipTypeId == MembershipType.PayAsYouGo))
                return ValidationResult.Success;

            if (customer.Birthdate == null)
                return new ValidationResult("Birthdata is required.");

            bool hasMore18years  = customer.Birthdate.Value.AddYears(18) <= DateTime.Today;

            return hasMore18years ?
                   ValidationResult.Success :
                   new ValidationResult("Customer must be at least 18 years old to go on a membership.");
        }
    }
}