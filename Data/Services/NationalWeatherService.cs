using System.Net.Http.Json;
using System.Text.Json;
using BlazorApp.Data.Interfaces;
using BlazorApp.Data.Models;

namespace BlazorApp.Data.Services;

public sealed class NationalWeatherService(HttpClient http) : IWeatherService
{
    // Camden, NJ: a centrally located coordinate used to obtain the local NWS grid forecast.
    private const string CamdenCountyPoint = "points/39.78,-74.99";
    private static readonly JsonSerializerOptions JsonOptions = new() { PropertyNameCaseInsensitive = true };

    public async Task<IReadOnlyList<WeatherPeriod>> GetCamdenCountyForecastAsync()
    {
        var point = await GetRequiredJsonAsync<NwsPointResponse>(CamdenCountyPoint)
            ?? throw new InvalidOperationException("The National Weather Service did not return a forecast location.");

        var forecastUrl = point.Properties?.Forecast
            ?? throw new InvalidOperationException("The National Weather Service did not provide a forecast URL for Camden County.");

        var forecast = await GetRequiredJsonAsync<NwsForecastResponse>(forecastUrl)
            ?? throw new InvalidOperationException("The National Weather Service did not return a forecast.");

        return forecast.Properties?.Periods ?? [];
    }

    private async Task<T?> GetRequiredJsonAsync<T>(string requestUri)
    {
        using var response = await http.GetAsync(requestUri, HttpCompletionOption.ResponseHeadersRead);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<T>(JsonOptions);
    }
}
