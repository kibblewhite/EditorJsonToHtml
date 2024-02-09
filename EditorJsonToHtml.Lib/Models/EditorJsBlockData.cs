using System.Text.Json.Serialization;

namespace EditorJsonToHtml.Lib.Models;

public class EditorJsBlockData
{
    [JsonPropertyName("text")]
    public string? Text { get; set; }

    [JsonPropertyName("level")]
    public int? Level { get; set; }

    [JsonPropertyName("style")]
    public string? Style { get; set; }

    [JsonPropertyName("items")]
    public List<EditorJsBlockContent>? Items { get; set; }

    [JsonPropertyName("content")]
    public List<List<string?>>? Content { get; set; }

    [JsonPropertyName("caption")]
    public string? Caption { get; set; }

    [JsonPropertyName("alignment")]
    public string? Alignment { get; set; }

    // Added property for checklist
    [JsonPropertyName("checked")]
    public bool? Checked { get; set; }

    // Added property for table
    [JsonPropertyName("withHeadings")]
    public bool? WithHeadings { get; set; }

    // New properties for image rendering
    [JsonPropertyName("url")]
    public string? Url { get; set; }

    [JsonPropertyName("withBorder")]
    public bool? WithBorder { get; set; }

    [JsonPropertyName("withBackground")]
    public bool? WithBackground { get; set; }

    [JsonPropertyName("stretched")]
    public bool? Stretched { get; set; }

    // Added property for warning block
    [JsonPropertyName("title")]
    public string? Title { get; set; }

    [JsonPropertyName("message")]
    public string? Message { get; set; }
}
