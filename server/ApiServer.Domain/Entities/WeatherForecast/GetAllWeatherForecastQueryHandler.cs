using ApiServer.Data.RepositoryInterfaces;
using ApiServer.DTO.WeatherForecast;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiServer.Domain.Entities.WeatherForecast
{
    public class GetAllWeatherForecastQueryHandler : IRequestHandler<GetAllWeatherForecastQuery, IQueryable<Model.WeatherForecast>>
    {
        private ILogger<GetAllWeatherForecastQueryHandler> _logger;
        private readonly IWeatherForecastRepository _weatherForecastRepository;

        public GetAllWeatherForecastQueryHandler(
            ILogger<GetAllWeatherForecastQueryHandler> logger,
            IWeatherForecastRepository weatherForecastRepository)
        {
            _logger = logger;
            _weatherForecastRepository = weatherForecastRepository;
        }

        public Task<IQueryable<Model.WeatherForecast>> Handle(GetAllWeatherForecastQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_weatherForecastRepository.Get());
        }
    }
}
