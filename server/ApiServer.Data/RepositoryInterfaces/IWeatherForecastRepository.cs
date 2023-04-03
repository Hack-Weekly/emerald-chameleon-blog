using ApiServer.SharedInterfaces;
using ApiServer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ApiServer.Data.RepositoryInterfaces
{
    public interface IWeatherForecastRepository : IRepository<WeatherForecast>
    {

    }
}
