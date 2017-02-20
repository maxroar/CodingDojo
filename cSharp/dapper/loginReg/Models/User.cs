using System;
using System.ComponentModel.DataAnnotations;

namespace loginReg.Models
{
    public class User : BaseEntity
    {
        public int userID {get; set;}
        [Required]
        [MinLength(2, ErrorMessage = "First name must be filled in and at least 2 characters.")]
        public string fname {get; set;}
        [RequiredAttribute]
        [MinLengthAttribute(2, ErrorMessage = "Last name must be filled in and at least 2 characters.")]
        public string lname {get; set;}
        [Required(ErrorMessage = "You must include an email address.")]
        [EmailAddressAttribute(ErrorMessage = "Please use a valid email address.")]
        public string email {get; set;}
        [RequiredAttribute(ErrorMessage = "Please include a password.")]
        [RegularExpressionAttribute(@"(?=^.{8,30}$)(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&amp;*()_+}{&quot;&quot;:;'?/&gt;.&lt;,]).*$", ErrorMessage = "Password must be 8 charactes long and contain at least 1 of each: uppercase letter, lowercase letter, number, and special character.")]
        public string password {get; set;}
        public DateTime createdAt {get; set;}
        public DateTime updatedAt {get; set;}
    }
}