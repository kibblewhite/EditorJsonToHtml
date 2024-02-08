using EditorJsonToHtml.Lib.Models;

namespace EditorJsonToHtml.Lib.Renderers;

public static class RenderList
{
    public static void Render(CustomRenderTreeBuilder render_tree_builder, string? id, string? style, List<EditorJsBlockContent>? items)
    {
        if (items == null) return;

        render_tree_builder.Builder.OpenElement(render_tree_builder.SequenceCounter, style == "ordered" ? "ol" : "ul");
        render_tree_builder.Builder.AddAttribute(render_tree_builder.SequenceCounter, "id", id);

        Models.EditorJsStyling? css = render_tree_builder.EditorJsStylings.FirstOrDefault(item => item.Type == SupportedRenderers.List && item.Id == id);
        css ??= render_tree_builder.EditorJsStylings.FirstOrDefault(item => item.Type == SupportedRenderers.List && item.Id == null);

        if (css is not null)
        {
            render_tree_builder.Builder.AddAttribute(render_tree_builder.SequenceCounter, "class", css.Style);
        }

        foreach (EditorJsBlockContent item in items)
        {
            render_tree_builder.Builder.OpenElement(render_tree_builder.SequenceCounter, "li"); // Added "li" element name

            if (css is not null && css.ItemStyle is not null)
            {
                render_tree_builder.Builder.AddAttribute(render_tree_builder.SequenceCounter, "class", css.ItemStyle);
            }

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
            render_tree_builder.Builder.AddMarkupContent(render_tree_builder.SequenceCounter, item.Content);
        }
    }

    private static void RenderNestedList(this CustomRenderTreeBuilder render_tree_builder, List<EditorJsBlockContent> items)
    {
        render_tree_builder.Builder.OpenElement(render_tree_builder.SequenceCounter, "ul");

        foreach (EditorJsBlockContent subItem in items)
        {
            render_tree_builder.Builder.OpenElement(render_tree_builder.SequenceCounter, "li"); // Added "li" element name
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
