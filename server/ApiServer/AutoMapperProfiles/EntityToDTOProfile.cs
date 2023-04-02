using ApiServer.DTO.WeatherForecast;
using ApiServer.Model;
using AutoMapper;
using System.Runtime.InteropServices;

namespace ApiServer.AutoMapperProfiles
{
    public class EntityToDTOProfile : Profile
    {
        public EntityToDTOProfile()
        { 
            //GET mappings
            CreateMap<WeatherForecast, GetWeatherForecastDTO>().ReverseMap();

            //CREATE mappings
            CreateMap<WeatherForecast, CreateWeatherForecastDTO>().ReverseMap();
        }
    }
}
