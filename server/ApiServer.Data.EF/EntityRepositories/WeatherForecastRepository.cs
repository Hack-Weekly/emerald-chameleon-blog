using ApiServer.Data.RepositoryInterfaces;
using ApiServer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiServer.Data.EF.EntityRepositories
{
    public class WeatherForecastRepository : BaseRepository<WeatherForecast>, IWeatherForecastRepository //this class EXTENDS our base repository & implements the repositories interface
    {
        private readonly MainDbContext _context;

        //our constructor/class extends the base class from above so all of those implementations are implemented here 
        //therefore we meet the 'contract' requirements of the interface
        public WeatherForecastRepository(MainDbContext context) : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
    }
}
