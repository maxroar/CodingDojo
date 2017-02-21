namespace theWall.Models
{
    public class Comment : BaseEntity
    {
        public string content {get; set;}
        public int post_id {get; set;}
        public int user_id {get; set;}
    }
}