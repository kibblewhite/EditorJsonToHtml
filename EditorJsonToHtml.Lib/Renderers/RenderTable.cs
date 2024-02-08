namespace EditorJsonToHtml.Lib.Renderers;

public static class RenderTable
{
    public static void Render(CustomRenderTreeBuilder render_tree_builder, bool withHeadings, List<List<string?>>? content)
    {
        if (content == null) return;

        render_tree_builder.Builder.OpenElement(render_tree_builder.SequenceCounter, "table");

        if (withHeadings)
        {
            render_tree_builder.Builder.OpenElement(render_tree_builder.SequenceCounter, "thead");
            render_tree_builder.Builder.OpenElement(render_tree_builder.SequenceCounter, "tr");

            foreach (string? cell in content.First())
            {
                render_tree_builder.Builder.OpenElement(render_tree_builder.SequenceCounter, "th");
                render_tree_builder.Builder.AddMarkupContent(render_tree_builder.SequenceCounter, cell);
                render_tree_builder.Builder.CloseElement(); // Close the th
            }

            render_tree_builder.Builder.CloseElement(); // Close the tr
            render_tree_builder.Builder.CloseElement(); // Close the thead
        }

        render_tree_builder.Builder.OpenElement(render_tree_builder.SequenceCounter, "tbody");

        foreach (List<string?> row in content.Skip(withHeadings ? 1 : 0))
        {
            render_tree_builder.Builder.OpenElement(render_tree_builder.SequenceCounter, "tr");

            foreach (string? cell in row)
            {
                render_tree_builder.Builder.OpenElement(render_tree_builder.SequenceCounter, "td");
                render_tree_builder.Builder.AddMarkupContent(render_tree_builder.SequenceCounter, cell);
                render_tree_builder.Builder.CloseElement(); // Close the td
            }

            render_tree_builder.Builder.CloseElement(); // Close the tr
        }

        render_tree_builder.Builder.CloseElement(); // Close the tbody
        render_tree_builder.Builder.CloseElement(); // Close the table
    }
}
