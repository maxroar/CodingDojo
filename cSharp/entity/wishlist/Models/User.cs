using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace wishlist.Models
{
    public class User : BaseEntity
    {
        [Key]
        public int id {get; set;}
        public string fname {get; set;}
        public string lname {get; set;}
        public string email {get; set;}
        public string password {get; set;}

        public List<Wish> Wishes {get; set;}

        public User()
        {
            Wishes = new List<Wish>();
        }
    }
}