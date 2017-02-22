using System.ComponentModel.DataAnnotations;
using System;

namespace theWall.Models
{
    public class Post : BaseEntity
    {
        [Required]
        [MinLengthAttribute(10, ErrorMessage="Posts must be at least 10 characters")]
        public string content {get; set;}
        public int user_id {get; set;}
    }
}