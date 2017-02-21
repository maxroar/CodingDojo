using System;
using System.ComponentModel.DataAnnotations;

namespace theWall.Models
{
    public class User : BaseEntity
    {
        public string fname {get; set;}
        public string lname {get; set;}
        public string email {get; set;}
        public string password {get; set;}
    }
}