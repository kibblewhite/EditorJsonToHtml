using System.Text.Json.Serialization;

namespace EditorJsonToHtml.Lib.Models;

// Define classes for deserialization
public class EditorJsBlocks
{
    [JsonPropertyName("time")]
    public long? Time { get; set; }

    [JsonPropertyName("blocks")]
    public List<EditorJsBlock>? Blocks { get; set; }

    [JsonPropertyName("version")]
    public string? Version { get; set; }
}
