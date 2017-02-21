using System;
using System.ComponentModel.DataAnnotations;

namespace loginReg.Models
{
    public abstract class BaseEntity {
        [Key]
        public int id {get; set;}
        public DateTime createdAt {get; set;}
        public DateTime updatedAt {get; set;}

    }
}