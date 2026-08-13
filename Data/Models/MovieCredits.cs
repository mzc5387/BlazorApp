using System.Text.Json.Serialization;

public class MovieCredits
{
    [JsonPropertyName("cast")]
    public List<CastMember> Cast { get; set; } = new();
}

public class CastMember
{
    public string Name { get; set; } = "";

    public string Character { get; set; } = "";

    [JsonPropertyName("profile_path")]
    public string ProfilePath { get; set; } = "";
}
