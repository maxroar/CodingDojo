using System.ComponentModel.DataAnnotations;

namespace wishlist.Models

{
    public class Wish
    {
        [Key]
        public int WishId {get; set;}
        public int userId {get; set;}
        public User user {get; set;}
        public int itemId {get; set;}
        public Item item {get; set;}
    }
}