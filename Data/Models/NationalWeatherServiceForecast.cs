using System.Text.Json.Serialization;

namespace BlazorApp.Data.Models;

public sealed class NwsPointResponse
{
    [JsonPropertyName("properties")]
    public NwsPointProperties? Properties { get; init; }
}

public sealed class NwsPointProperties
{
    [JsonPropertyName("forecast")]
    public string? Forecast { get; init; }
}

public sealed class NwsForecastResponse
{
    [JsonPropertyName("properties")]
    public NwsForecastProperties? Properties { get; init; }
}

public sealed class NwsForecastProperties
{
    [JsonPropertyName("periods")]
    public List<WeatherPeriod> Periods { get; init; } = [];
}

public sealed class WeatherPeriod
{
    [JsonPropertyName("name")]
    public string Name { get; init; } = string.Empty;

    [JsonPropertyName("icon")]
    public string Icon { get; init; } = string.Empty;

    [JsonPropertyName("startTime")]
    public DateTimeOffset StartTime { get; init; }

    [JsonPropertyName("temperature")]
    public int Temperature { get; init; }

    [JsonPropertyName("temperatureUnit")]
    public string TemperatureUnit { get; init; } = string.Empty;

    [JsonPropertyName("windSpeed")]
    public string WindSpeed { get; init; } = string.Empty;

    [JsonPropertyName("windDirection")]
    public string WindDirection { get; init; } = string.Empty;

    [JsonPropertyName("shortForecast")]
    public string ShortForecast { get; init; } = string.Empty;

    [JsonPropertyName("detailedForecast")]
    public string DetailedForecast { get; init; } = string.Empty;
}
