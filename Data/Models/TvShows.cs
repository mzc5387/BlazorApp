using System.Text.Json.Serialization;

public class TvShow
{
    public int Id { get; set; }

    public string Name { get; set; } = "";

    [JsonPropertyName("original_name")]
    public string OriginalName { get; set; } = "";

    public string Overview { get; set; } = "";

    [JsonPropertyName("first_air_date")]
    public string First_Air_Date { get; set; } = "";

    [JsonPropertyName("poster_path")]
    public string Poster_Path { get; set; } = "";

    [JsonPropertyName("popularity")]
    public double Popularity { get; set; } = 0;

    [JsonPropertyName("original_language")]
    public string OriginalLanguage { get; set; } = "";

    [JsonPropertyName("vote_average")]
    public double VoteAverage { get; set; } = 0;

    [JsonPropertyName("vote_count")]
    public int VoteCount { get; set; }
}