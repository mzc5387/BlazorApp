using System.Text.Json.Serialization;

public class Movie
{
    public int Id { get; set; }

    public string Title { get; set; } = "";

    [JsonPropertyName("original_title")]
    public string OriginalTitle { get; set; } = "";

    public string Overview { get; set; } = "";

    [JsonPropertyName("release_date")]
    public string Release_Date { get; set; } = "";

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
