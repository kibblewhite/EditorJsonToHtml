using System.Reflection;

namespace EditorJsonToHtml.Lib;

public enum SupportedRenderers
{
    [StringValue(nameof(Paragraph))]
    Paragraph,

    [StringValue(nameof(Header))]
    Header,

    [StringValue(nameof(List))]
    List,

    [StringValue(nameof(Quote))]
    Quote,

    [StringValue(nameof(Checklist))]
    Checklist,

    [StringValue(nameof(Table))]
    Table,

    [StringValue(nameof(Image))]
    Image,

    [StringValue(nameof(Delimiter))]
    Delimiter,

    [StringValue(nameof(Warning))]
    Warning
}

[AttributeUsage(AttributeTargets.Field)]
public sealed class StringValueAttribute(string value) : Attribute
{
    public string Value { get; } = value;
}

public static class EnumExtensions
{
    public static string StringValue<T>(this T value) where T : Enum
    {
        string fieldName = value.ToString();
        FieldInfo? field = typeof(T).GetField(fieldName, BindingFlags.Public | BindingFlags.Static);
        return (field?.GetCustomAttribute<StringValueAttribute>()?.Value ?? fieldName).ToLower();
    }
}
