namespace EditorJsonToHtml.Lib.Renderers;

public static class RenderHeader
{
    public static void Render(CustomRenderTreeBuilder render_tree_builder, string? text, int? level)
    {
        render_tree_builder.Builder.OpenElement(render_tree_builder.SequenceCounter, $"h{level}");
        render_tree_builder.Builder.AddMarkupContent(render_tree_builder.SequenceCounter, text);
        render_tree_builder.Builder.CloseElement();
    }
}
