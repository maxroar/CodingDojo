namespace theWall.Models
{
    public class Post : BaseEntity
    {
        public string content {get; set;}
        public int user_id {get; set;}
    }
}