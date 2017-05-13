using System.ComponentModel.DataAnnotations;

namespace Exercise.Models
{
    public class AddressRequest
    {
        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public string City { get; set; }

        [Required(ErrorMessage = "State is required")]
        public string State { get; set; }

        [Required(ErrorMessage = "Zip is required")]
        [StringLength(5, ErrorMessage = "Zip code should be 5 lenght long.", MinimumLength = 5)]
        public string Zip { get; set; }
    }
}