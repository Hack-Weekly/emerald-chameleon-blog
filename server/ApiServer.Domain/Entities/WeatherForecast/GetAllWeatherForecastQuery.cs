using MediatR;
using ApiServer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ApiServer.Domain.Entities.WeatherForecast
{
    public record GetAllWeatherForecastQuery() : IRequest<IQueryable<Model.WeatherForecast>>;
}
