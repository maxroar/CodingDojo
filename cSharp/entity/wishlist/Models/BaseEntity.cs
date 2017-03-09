using System;

namespace wishlist.Models
{
    public abstract class BaseEntity {
        
        public DateTime createdAt {get; set;}
        public DateTime updatedAt {get; set;}

    }
}