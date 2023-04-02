using ApiServer.AutoMapperProfiles;
using Microsoft.AspNetCore.Mvc;

namespace ApiServer.Controllers.CRUD
{
    [ApiController]
    [Route("/api/WeatherForecast")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWeatherForecastRepository _weatherForecastRepository;
        private readonly IMediator _mediator;

        public WeatherForecastController(
            ILogger<WeatherForecastController> logger
            , IWeatherForecastRepository weatherForecastRepository,
            IMediator mediator)
        {
            _logger = logger;
            _weatherForecastRepository = weatherForecastRepository;
            _mediator = mediator;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<ActionResult<IEnumerable<GetWeatherForecastDTO>>> Get(CancellationToken token)
        {
            _logger.LogDebug("Example Debug Log Message - In GetWeatherForecast");
            var response = await _mediator.Send(new GetAllWeatherForecastQuery(), token);
            return Ok(response.ToList().MapToDTO<IEnumerable<GetWeatherForecastDTO>>());
        }

        [HttpGet("/api/WeatherForecast/{id}", Name = "GetByIdWeatherForecast")]
        public async Task<ActionResult<GetWeatherForecastDTO>> Get(
            [FromRoute] Guid id, 
            CancellationToken token)
        {
            var response = (await _mediator.Send(new GetByIdWeatherForecastQuery(id), token)).FirstOrDefault();
            return Ok(response.MapToDTO<GetWeatherForecastDTO>());
        }

        [HttpPost(Name = "CreateWeatherForecast")]
        [ProducesResponseType(typeof(CreateWeatherForecastDTO), StatusCodes.Status201Created)]
        public async Task<ActionResult<WeatherForecast>> Post(
            [FromBody] CreateWeatherForecastDTO model,
            CancellationToken token)
        {
            var entity = model.MapToEntity<WeatherForecast>();
            var id = await _mediator.Send(new CreateWeatherForecastCommand(entity), token);
            entity.Id = id;

            return Accepted(entity.MapToDTO<GetWeatherForecastDTO>());
        }

        [HttpDelete(Name = "DeleteWeatherForecast")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Delete(
            GetWeatherForecastDTO model,
            CancellationToken token)
        {
            var entity = model.MapToEntity<WeatherForecast>();
            _ = await _mediator.Send(new DeleteWeatherForecastCommand(entity), token);
            return Ok();
        }
    }
}