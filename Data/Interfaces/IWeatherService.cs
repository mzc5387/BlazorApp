using BlazorApp.Data.Models;

namespace BlazorApp.Data.Interfaces;

public interface IWeatherService
{
    Task<IReadOnlyList<WeatherPeriod>> GetCamdenCountyForecastAsync();
}
