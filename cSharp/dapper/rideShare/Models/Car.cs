using System.Collections.Generic;

namespace rideShare.Models
{
    public class Car : BaseEntity
    {
        public string make {get; set;}
        public string model {get; set;}
        public int seats {get; set;}
        public int driver {get; set;}
        public int riders {get; set;}
        public User driverUser {get; set;}
        public List<User> riderUsers {get; set;}
    }
}