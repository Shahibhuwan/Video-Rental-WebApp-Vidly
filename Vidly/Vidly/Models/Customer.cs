using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations; 

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Please enter the Name")]                                           //data annotation is also used to validate the action parameter
        [StringLength(255)]
        public string Name { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }
        
        public MembershipType MembershipType { get; set; } //navigation properties which is used to load obj and its related obj from db

        [Display(Name = "MembershipType")]       // the below comment is for for validation 
        public byte MembershipTypeId { get; set; } //byte properties makes MembershipTypeid implicitly required because the null value cannot be converted to bytes but if the byte properties was nullabel i.e byte? then null value was aaccepteable in the form //FOR OPTIMIZTION  we can only read the needy data but not all the membershiptype obj
        [Display(Name ="Date Of Birth")]
        [Min18YearsIfAMember]
        public DateTime? BirthDate { get; set; }


       
    }
}