using System.Text.Json;
using System.Text.Json.Serialization;

namespace EditorJsonToHtml.Lib.Models;

public sealed class EditorJsStyling
{
    [JsonPropertyName("type")]
    [JsonConverter(typeof(SupportedRenderersConverter))]
    public required SupportedRenderers Type { get; init; }

    [JsonPropertyName("style")]
    public required string Style { get; init; }

    [JsonPropertyName("item-style")]
    public string? ItemStyle { get; init; }

    [JsonPropertyName("footer-style")]
    public string? FooterStyle { get; init; }

    [JsonPropertyName("id")]
    public string? Id { get; init; }

    [JsonPropertyName("level")]
    public int? Level { get; init; }
}

public class SupportedRenderersConverter : JsonConverter<SupportedRenderers>
{
    public override SupportedRenderers Read(ref Utf8JsonReader reader, Type type_to_convert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.String)
        {
            string? enum_string = reader.GetString();
            if (Enum.TryParse(enum_string, true, out SupportedRenderers result))
            {
                return result;
            }
        }

        return default; // or throw an exception if necessary
    }

    public override void Write(Utf8JsonWriter writer, SupportedRenderers value, JsonSerializerOptions options)
        => writer.WriteStringValue(value.ToString().ToLowerInvariant());
}