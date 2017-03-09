using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace wishlist.Models

{
    public class Item : BaseEntity
    {
        [Key]
        public int id {get; set;}
        public string name {get; set;}
        public string description {get; set;}
        public int addedBy {get; set;}
        public List<Wish> Wishes {get; set;}
        public Item()
        {
            Wishes = new List<Wish>();
        }
    }
}