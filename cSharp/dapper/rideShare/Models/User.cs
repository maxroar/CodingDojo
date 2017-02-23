namespace rideShare.Models
{
    public class User : BaseEntity
    {
        public string username {get; set;}
        public string email {get; set;}
        public string password {get; set;}
        public string passwordConfirmation {get; set;}
        public bool isDriver {get; set;}
    }
}