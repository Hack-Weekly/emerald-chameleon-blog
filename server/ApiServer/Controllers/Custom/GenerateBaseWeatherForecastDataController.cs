using ApiServer.AutoMapperProfiles;
using ApiServer.Controllers.CRUD;
using ApiServer.Data.RepositoryInterfaces;
using ApiServer.DTO.WeatherForecast;
using ApiServer.Model;
using Microsoft.AspNetCore.Mvc;

namespace ApiServer.Controllers.Custom
{
    [ApiController]
    [Route("/api/GenerateBaseWeatherForecastData")]
    public class GenerateBaseWeatherForecastDataController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWeatherForecastRepository _weatherForecastRepository;

        public GenerateBaseWeatherForecastDataController(
            ILogger<WeatherForecastController> logger
            , IWeatherForecastRepository weatherForecastRepository)
        {
            _logger = logger;
            _weatherForecastRepository = weatherForecastRepository;
        }

        [HttpGet(Name = "GetGenerateBaseWeatherForecastData")]
        public async Task<ActionResult<GetWeatherForecastDTO>> Get(CancellationToken token)
        {
            var newWeatherForecast = new Model.WeatherForecast("Detorit", 32)
            {
                CityName = "Detroit",
                TemperatureC = 32,
                Summary = "Nice"
            };
            var response = await _weatherForecastRepository.CreateAsync(newWeatherForecast, token);
            _logger.LogDebug("Example Debug Log Message");
            return Ok(response.MapToDTO<GetWeatherForecastDTO>());
        }
    }
}
