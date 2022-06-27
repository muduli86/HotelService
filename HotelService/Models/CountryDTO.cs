using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelService.Models
{
    public class CountryDTO : CreateCountryDTO
    {
        [Required]
        public int Id { get; set; }

        public IList<HotelDTO> Hotels { get; set; }
    }
}