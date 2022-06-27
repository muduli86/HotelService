using AutoMapper;
using HotelService.Data;
using HotelService.Models;

namespace HotelService.Configuration
{
    public class MapperInitializer : Profile
    {
        public MapperInitializer() {
            CreateMap<Country, CountryDTO>().ReverseMap();
            CreateMap<Country, CreateCountryDTO>().ReverseMap();
            CreateMap<Hotel, HotelDTO>().ReverseMap();
            CreateMap<Hotel, CreateHotelDTO>().ReverseMap();
        }
    }
}