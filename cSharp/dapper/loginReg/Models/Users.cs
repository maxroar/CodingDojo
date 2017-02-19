using System.ComponentModel.DataAnnotations;

namespace loginReg.models
{
    public class User
    {
        [Required]
        [MinLength(2)]
        public string fname {get; set;}
        [RequiredAttribute]
        [MinLengthAttribute(2)]
        public string lname {get; set;}
        [Required]
        [EmailAddressAttribute]
        public string email {get; set;}
        [RequiredAttribute]
        [RegularExpressionAttribute(@"(?=^.{8,30}$)(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&amp;*()_+}{&quot;&quot;:;'?/&gt;.&lt;,]).*$")]
        public string password {get; set;}
    }
}