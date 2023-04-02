using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiServer.Domain.Entities.WeatherForecast
{
    public record GetByIdWeatherForecastQuery(Guid id) : IRequest<IQueryable<Model.WeatherForecast>>;
}
