using ApiServer.Data.RepositoryInterfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiServer.Domain.Entities.WeatherForecast
{
    public class CreateWeatherForecastCommandHandler : IRequestHandler<CreateWeatherForecastCommand, Guid>
    {
        private readonly ILogger<CreateWeatherForecastCommandHandler> _logger;
        private readonly IWeatherForecastRepository _weatherForecastRepository;
        
        public CreateWeatherForecastCommandHandler(
            ILogger<CreateWeatherForecastCommandHandler> logger,
            IWeatherForecastRepository weatherForecastRepository)
        {
            _logger = logger;
            _weatherForecastRepository = weatherForecastRepository;
        }

        public async Task<Guid> Handle(CreateWeatherForecastCommand request, CancellationToken token)
        {
            var response = await _weatherForecastRepository.CreateAsync(request.Model, token);
            return response.Id;
        }
    }
}
