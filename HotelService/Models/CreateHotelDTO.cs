using System.ComponentModel.DataAnnotations;

namespace HotelService.Models
{
    public class CreateHotelDTO
    {
        [Required]
        [StringLength(maximumLength: 50, ErrorMessage = "Name is too long")]
        public string Name { get; set; }

        public string Address { get; set; }

        [Range(1, 5)]
        public string Rating { get; set; }

        [Required]
        public int CountryId { get; set; }
    }
}