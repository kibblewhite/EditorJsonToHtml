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

    [JsonPropertyName("caption")]
    public string? Caption { get; set; }

    [JsonPropertyName("alignment")]
    public string? Alignment { get; set; }

    [JsonPropertyName("checked")]
    public bool? Checked { get; set; }  // Added property for checklist

    [JsonPropertyName("withHeadings")]
    public bool? WithHeadings { get; set; }  // Added property for table

    [JsonPropertyName("content")]
    public List<List<string?>>? Content { get; set; }
}
