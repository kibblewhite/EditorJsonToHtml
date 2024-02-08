using System.Text.Json.Serialization;

namespace EditorJsonToHtml.Lib.Models;

public class EditorJsBlock
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }

    [JsonPropertyName("data")]
    public EditorJsBlockData? Data { get; set; }
}
