using System.ComponentModel.DataAnnotations;

namespace theWall.Models
{
    public class Comment : BaseEntity
    {
        [Required]
        [MinLengthAttribute(2, ErrorMessage="Comments must be at least 2 characters")]
        public string content {get; set;}
        public int post_id {get; set;}
        public int user_id {get; set;}
        public User user {get; set;}
        public Post post {get; set;}
    }
}