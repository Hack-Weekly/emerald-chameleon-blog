namespace ApiServer.DTO.WeatherForecast
{
    public class CreateWeatherForecastDTO : IDTO
    {
        public int TemperatureC { get; set; }
        public string Summary { get; set; } = String.Empty;
        public string CityName { get; set; } = String.Empty;

    }
}
