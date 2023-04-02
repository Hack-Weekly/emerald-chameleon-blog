using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiServer.Model;

namespace ApiServer.Domain.Entities.WeatherForecast
{
    public record DeleteWeatherForecastCommand(Model.WeatherForecast model) : IRequest<Unit>;
}
