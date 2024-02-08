using Microsoft.AspNetCore.Components.Rendering;

namespace EditorJsonToHtml.Lib;

public class CustomRenderTreeBuilder
{
    public required RenderTreeBuilder Builder { get; init; }
    public required int SequenceCounter { get; set; }
}
