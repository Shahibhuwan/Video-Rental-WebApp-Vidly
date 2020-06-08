using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Vidly.Models;
//Validation attribute is class for validation defined in using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Min18YearsIfAMember: ValidationAttribute
    { //Validatecontext helps to access the other propertie of the model
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;                                                                                      // it is an object that provide acccess to the containing class which helps to access the other propertie of that class
                                                                                                                                    //it is of type customer because we validating customer model class 
            if (customer.MembershipTypeId == MembershipType.Unknown || customer.MembershipTypeId == MembershipType.PayAsYouGo)
                return ValidationResult.Success;
            //0&1 are magic number which are clear to us but not for the another developer working with these codes
            if (customer.BirthDate == null)
                return new ValidationResult("Birthdate is required ");

            var age = DateTime.Today.Year - customer.BirthDate.Value.Year;

            return (age >= 18) ? ValidationResult.Success :new ValidationResult("Customer must atleast 18");
        }
    }
}




//Instance The instance of class to validate.
//ValidationContext The context that describes the object to validate.
//ValidationResults The collection of validation results descriptions.
//ValidateAllProperties Enabled continues to validate all properties.