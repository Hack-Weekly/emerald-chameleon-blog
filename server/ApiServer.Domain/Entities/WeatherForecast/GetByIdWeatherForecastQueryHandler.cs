using ApiServer.Data.RepositoryInterfaces;
using ApiServer.Shared;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiServer.Domain.Entities.WeatherForecast
{
    public class GetByIdWeatherForecastQueryHandler : IRequestHandler<GetByIdWeatherForecastQuery, IQueryable<Model.WeatherForecast>>
    {

        private readonly ILogger<GetByIdWeatherForecastQueryHandler> _logger;
        private readonly IWeatherForecastRepository _weatherForecastRepository;
        public GetByIdWeatherForecastQueryHandler(ILogger<GetByIdWeatherForecastQueryHandler> logger, IWeatherForecastRepository repository)
        {
            _logger = logger;
            _weatherForecastRepository = repository; 
        }

        public Task<IQueryable<Model.WeatherForecast>> Handle(GetByIdWeatherForecastQuery request, CancellationToken token)
        {
            return Task.FromResult(_weatherForecastRepository.Get(request.id));
        }
    }
}
