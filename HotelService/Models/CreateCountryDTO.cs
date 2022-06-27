using System.ComponentModel.DataAnnotations;

namespace HotelService.Models
{
    public class CreateCountryDTO
    {
        [Required]
        [StringLength(maximumLength: 50, ErrorMessage = "Name is too long")]
        public string Name { get; set; }

        [Required]
        [StringLength(maximumLength: 3, ErrorMessage = "ShortName is too long")]
        public string ShortName { get; set; }
    }
}