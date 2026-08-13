using System.Text.Json.Serialization;

public class TvShowCredits
{
    [JsonPropertyName("cast")]
    public List<TvCastMember> Cast { get; set; } = new();
}

public class TvCastMember
{
    public string Name { get; set; } = "";

    public string Character { get; set; } = "";

    [JsonPropertyName("profile_path")]
    public string ProfilePath { get; set; } = "";
}