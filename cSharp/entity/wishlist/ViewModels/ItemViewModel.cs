using System.ComponentModel.DataAnnotations;

namespace wishlist.ViewModels{
    public class ItemViewModel{
        [Required(ErrorMessage = "You must include an item name.")]
        [MinLengthAttribute(2, ErrorMessage = "Items must be at least 2 characters.")]
        public string name {get; set;}
        [RequiredAttribute(ErrorMessage = "Please include a description.")]
        public string description {get; set;}
    }
}