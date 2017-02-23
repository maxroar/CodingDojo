using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace theWall.Models
{
    public class Post : BaseEntity
    {
        [Required]
        [MinLengthAttribute(10, ErrorMessage="Posts must be at least 10 characters")]
        public string content {get; set;}
        public int user_id {get; set;}
        public User user {get; set;}
        public List<Comment> comments {get; set;}
    }
}