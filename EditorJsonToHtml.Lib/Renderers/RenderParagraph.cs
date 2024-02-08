using Microsoft.AspNetCore.Components.Rendering;

namespace EditorJsonToHtml.Lib.Renderers;

public static partial class RenderParagraph
{
    public static void Render(CustomRenderTreeBuilder render_tree_builder, string? textTwo)
    {
        render_tree_builder.Builder.OpenElement(render_tree_builder.SequenceCounter++, "p");
        render_tree_builder.Builder.AddMarkupContent(render_tree_builder.SequenceCounter++, textTwo);
        render_tree_builder.Builder.CloseElement();
    }
}
