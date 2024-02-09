using System.Text.Json.Serialization;

namespace EditorJsonToHtml.Lib.Models;

/// <summary>
/// Represents the data associated with an Editor.js block.
/// </summary>
public sealed class EditorJsBlockData
{
    /// <summary>
    /// Gets or sets the text content for various block types like paragraphs and quotes.
    /// </summary>
    [JsonPropertyName("text")]
    public string? Text { get; set; }

    /// <summary>
    /// Gets or sets the heading level for header blocks.
    /// </summary>
    [JsonPropertyName("level")]
    public int? Level { get; set; }

    /// <summary>
    /// Gets or sets the style for list blocks (e.g., ordered or unordered).
    /// </summary>
    [JsonPropertyName("style")]
    public string? Style { get; set; }

    /// <summary>
    /// Gets or sets the list of items for list blocks.
    /// </summary>
    [JsonPropertyName("items")]
    public List<EditorJsBlockContent>? Items { get; set; }

    /// <summary>
    /// Gets or sets the content for table blocks.
    /// </summary>
    [JsonPropertyName("content")]
    public List<List<string?>>? Content { get; set; }

    /// <summary>
    /// Gets or sets the caption for quote or image blocks.
    /// </summary>
    [JsonPropertyName("caption")]
    public string? Caption { get; set; }

    /// <summary>
    /// Gets or sets the alignment for quote blocks.
    /// </summary>
    [JsonPropertyName("alignment")]
    public string? Alignment { get; set; }

    /// <summary>
    /// Gets or sets the checkbox status for checklist items.
    /// </summary>
    [JsonPropertyName("checked")]
    public bool? Checked { get; set; }

    /// <summary>
    /// Gets or sets the flag indicating whether table blocks have headings.
    /// </summary>
    [JsonPropertyName("withHeadings")]
    public bool? WithHeadings { get; set; }

    // New properties for image rendering

    /// <summary>
    /// Gets or sets the URL for image blocks.
    /// </summary>
    [JsonPropertyName("url")]
    public string? Url { get; set; }

    /// <summary>
    /// Gets or sets the flag indicating whether image blocks have borders.
    /// </summary>
    [JsonPropertyName("withBorder")]
    public bool? WithBorder { get; set; }

    /// <summary>
    /// Gets or sets the flag indicating whether image blocks have background colors.
    /// </summary>
    [JsonPropertyName("withBackground")]
    public bool? WithBackground { get; set; }

    /// <summary>
    /// Gets or sets the flag indicating whether image blocks are stretched to 100% width.
    /// </summary>
    [JsonPropertyName("stretched")]
    public bool? Stretched { get; set; }

    // Added properties for warning block

    /// <summary>
    /// Gets or sets the title for warning blocks.
    /// </summary>
    [JsonPropertyName("title")]
    public string? Title { get; set; }

    /// <summary>
    /// Gets or sets the message content for warning blocks.
    /// </summary>
    [JsonPropertyName("message")]
    public string? Message { get; set; }
}
