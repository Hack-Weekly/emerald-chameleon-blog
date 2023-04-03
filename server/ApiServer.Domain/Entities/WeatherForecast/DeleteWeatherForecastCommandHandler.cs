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
    public class DeleteWeatherForecastCommandHandler : IRequestHandler<DeleteWeatherForecastCommand, Unit>
    {
        private readonly ILogger<DeleteWeatherForecastCommandHandler> _logger;
        private readonly IWeatherForecastRepository _weatherForecastRepository;

        public DeleteWeatherForecastCommandHandler(ILogger<DeleteWeatherForecastCommandHandler> logger, IWeatherForecastRepository repository)
        {
            _logger = logger;
            _weatherForecastRepository = repository;
        }

        public async Task<Unit> Handle(DeleteWeatherForecastCommand request, CancellationToken token)
        {
            await _weatherForecastRepository.DeleteAsync(request.model, token);
            return Unit.Value;
        }
    }
}
