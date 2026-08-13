using System.Text.Json.Serialization;

public class MovieSearchResult
{
    [JsonPropertyName("page")]
    public int Page { get; set; }

    [JsonPropertyName("results")]
    public List<Movie> Results { get; set; } = new();
}