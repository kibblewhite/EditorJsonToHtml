namespace EditorJsonToHtml.Lib.Renderers;

public static class RenderQuote
{
    public static void Render(CustomRenderTreeBuilder render_tree_builder, string? text, string? caption, string? alignment)
    {
        render_tree_builder.Builder.OpenElement(render_tree_builder.SequenceCounter++, "blockquote");

        if (!string.IsNullOrEmpty(alignment))
        {
            render_tree_builder.Builder.AddAttribute(render_tree_builder.SequenceCounter++, "class", $"text-{alignment}");
        }

        render_tree_builder.Builder.AddMarkupContent(render_tree_builder.SequenceCounter++, text);

        if (!string.IsNullOrEmpty(caption))
        {
            render_tree_builder.Builder.OpenElement(render_tree_builder.SequenceCounter++, "footer");
            render_tree_builder.Builder.AddMarkupContent(render_tree_builder.SequenceCounter++, caption);
            render_tree_builder.Builder.CloseElement(); // Close the footer
        }

        render_tree_builder.Builder.CloseElement(); // Close the blockquote
    }
}
