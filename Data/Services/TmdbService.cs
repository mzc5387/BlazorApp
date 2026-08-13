using System.Net.Http.Json;
using System.Text.Json;

public class TmdbService : ITmdbService
{
    private readonly HttpClient _http;
    private readonly IConfiguration _config;

    public TmdbService(HttpClient http, IConfiguration config)
    {
        _http = http;
        _config = config;
    }

    public async Task<MovieSearchResult?> SearchMoviesAsync(string query)
    {
        return await GetMoviesAsync($"search/movie?query={Uri.EscapeDataString(query)}");
    }

    public async Task<MovieSearchResult?> GetTopMoviesAsync()
    {
        return await GetMoviesAsync("movie/popular");
    }

    public async Task<MovieCredits?> GetMovieCreditsAsync(int movieId)
    {
        var apiKey = _config["TMDB:ApiKey"];
        if (string.IsNullOrWhiteSpace(apiKey))
        {
            throw new InvalidOperationException("TMDB API key is not configured. Check configuration section 'TMDB:ApiKey'.");
        }

        var response = await _http.GetAsync($"movie/{movieId}/credits?api_key={Uri.EscapeDataString(apiKey)}");
        if (!response.IsSuccessStatusCode)
        {
            var body = await response.Content.ReadAsStringAsync();
            throw new HttpRequestException($"TMDB credits request failed ({response.StatusCode}): {body}");
        }

        return await response.Content.ReadFromJsonAsync<MovieCredits>(options: new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });
    }

    private async Task<MovieSearchResult?> GetMoviesAsync(string endpoint)
    {
        var apiKey = _config["TMDB:ApiKey"];
        if (string.IsNullOrWhiteSpace(apiKey))
        {
            throw new InvalidOperationException("TMDB API key is not configured. Check configuration section 'TMDB:ApiKey'.");
        }

        var separator = endpoint.Contains('?') ? "&" : "?";
        var url = $"{endpoint}{separator}api_key={Uri.EscapeDataString(apiKey)}";
        var response = await _http.GetAsync(url);

        if (!response.IsSuccessStatusCode)
        {
            var body = await response.Content.ReadAsStringAsync();
            throw new HttpRequestException($"TMDB request failed ({response.StatusCode}): {body}");
        }

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        var result = await response.Content.ReadFromJsonAsync<MovieSearchResult>(options: options);
        if (result == null)
        {
            throw new InvalidOperationException("TMDB response could not be deserialized into MovieSearchResult.");
        }

        result.Results = result.Results
            .OrderByDescending(movie => movie.Popularity)
            .ToList();

        return result;
    }

    public async Task<TvShowSearchResult?> SearchTvShowsAsync(string query)
    {
        return await GetTvShowsAsync($"search/tv?query={Uri.EscapeDataString(query)}");
    }

    public async Task<TvShowSearchResult?> GetTopTvShowsAsync()
    {
        return await GetTvShowsAsync("tv/popular");
    }

    public async Task<TvShowCredits?> GetTvShowCreditsAsync(int tvShowId)
    {
        var apiKey = _config["TMDB:ApiKey"];
        if (string.IsNullOrWhiteSpace(apiKey))
        {
            throw new InvalidOperationException("TMDB API key is not configured. Check configuration section 'TMDB:ApiKey'.");
        }

        var response = await _http.GetAsync($"tv/{tvShowId}/credits?api_key={Uri.EscapeDataString(apiKey)}");
        if (!response.IsSuccessStatusCode)
        {
            var body = await response.Content.ReadAsStringAsync();
            throw new HttpRequestException($"TMDB credits request failed ({response.StatusCode}): {body}");
        }

        return await response.Content.ReadFromJsonAsync<TvShowCredits>(options: new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });
    }

    private async Task<TvShowSearchResult?> GetTvShowsAsync(string endpoint)
    {
        var apiKey = _config["TMDB:ApiKey"];
        if (string.IsNullOrWhiteSpace(apiKey))
        {
            throw new InvalidOperationException("TMDB API key is not configured. Check configuration section 'TMDB:ApiKey'.");
        }

        var separator = endpoint.Contains('?') ? "&" : "?";
        var url = $"{endpoint}{separator}api_key={Uri.EscapeDataString(apiKey)}";
        var response = await _http.GetAsync(url);

        if (!response.IsSuccessStatusCode)
        {
            var body = await response.Content.ReadAsStringAsync();
            throw new HttpRequestException($"TMDB request failed ({response.StatusCode}): {body}");
        }

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        var result = await response.Content.ReadFromJsonAsync<TvShowSearchResult>(options: options);
        if (result == null)
        {
            throw new InvalidOperationException("TMDB response could not be deserialized into TvShowSearchResult.");
        }

        result.Results = result.Results
            .OrderByDescending(tvshow => tvshow.Popularity)
            .ToList();

        return result;
    }
    }
