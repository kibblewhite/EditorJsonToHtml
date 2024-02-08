using EditorJsonToHtml.Lib.Models;

namespace EditorJsonToHtml.Lib.Renderers;

public static class RenderList
{
    public static void Render(CustomRenderTreeBuilder render_tree_builder, string? style, List<EditorJsBlockContent>? items)
    {
        if (items == null) return;

        render_tree_builder.Builder.OpenElement(render_tree_builder.SequenceCounter++, style == "ordered" ? "ol" : "ul");

        foreach (EditorJsBlockContent item in items)
        {
            render_tree_builder.Builder.OpenElement(render_tree_builder.SequenceCounter++, "li"); // Added "li" element name

            // Render item content
            render_tree_builder.RenderListItemContent(item);

            // Check and render nested lists
            if (item.Items != null && item.Items.Count > 0)
            {
                render_tree_builder.RenderNestedList(item.Items);
            }

            render_tree_builder.Builder.CloseElement(); // Closes "li" element
        }

        render_tree_builder.Builder.CloseElement(); // Closes "ol" or "ul" element
    }

    private static void RenderListItemContent(this CustomRenderTreeBuilder render_tree_builder, EditorJsBlockContent item)
    {
        if (item.Content != null)
        {
            render_tree_builder.Builder.AddMarkupContent(render_tree_builder.SequenceCounter++, item.Content);
        }
    }

    private static void RenderNestedList(this CustomRenderTreeBuilder render_tree_builder, List<EditorJsBlockContent> items)
    {
        render_tree_builder.Builder.OpenElement(render_tree_builder.SequenceCounter++, "ul");

        foreach (EditorJsBlockContent subItem in items)
        {
            render_tree_builder.Builder.OpenElement(render_tree_builder.SequenceCounter++, "li"); // Added "li" element name
            render_tree_builder.RenderListItemContent(subItem);
            if (subItem.Items is not null)
            {
                render_tree_builder.RenderNestedList(subItem.Items);
            }

            render_tree_builder.Builder.CloseElement(); // Closes "li" element
        }

        render_tree_builder.Builder.CloseElement(); // Closes "ul" element
    }
}
