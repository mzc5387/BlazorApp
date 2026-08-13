using System.Text.Json.Serialization;

public class TvShowSearchResult
{
    [JsonPropertyName("page")]
    public int Page { get; set; }

    [JsonPropertyName("results")]
    public List<TvShow> Results { get; set; } = new();
}