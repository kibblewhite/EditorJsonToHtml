using EditorJsonToHtml.Lib.Models;

namespace EditorJsonToHtml.Lib.Renderers;

public static class RenderChecklist
{
    public static void Render(CustomRenderTreeBuilder render_tree_builder, List<EditorJsBlockContent>? items)
    {
        if (items == null) return;

        render_tree_builder.Builder.OpenElement(render_tree_builder.SequenceCounter++, "ul");
        render_tree_builder.Builder.AddAttribute(render_tree_builder.SequenceCounter++, "style", "list-style-type: none;");

        foreach (EditorJsBlockContent item in items)
        {
            render_tree_builder.Builder.OpenElement(render_tree_builder.SequenceCounter++, "li");

            // Render the checkbox
            render_tree_builder.Builder.OpenElement(render_tree_builder.SequenceCounter++, "input");
            render_tree_builder.Builder.AddAttribute(render_tree_builder.SequenceCounter++, "type", "checkbox");
            render_tree_builder.Builder.AddAttribute(render_tree_builder.SequenceCounter++, "disabled", "true");
            if (item.Checked ?? false)
            {
                render_tree_builder.Builder.AddAttribute(render_tree_builder.SequenceCounter++, "checked", "checked");
            }

            render_tree_builder.Builder.CloseElement(); // Close the input

            // Render checklist item text
            render_tree_builder.Builder.AddMarkupContent(render_tree_builder.SequenceCounter++, item.Text);

            // Check and render nested checklists
            if (item.Items != null && item.Items.Count > 0)
            {
                Render(render_tree_builder, item.Items);
            }

            render_tree_builder.Builder.CloseElement(); // Close the li
        }

        render_tree_builder.Builder.CloseElement(); // Close the ul
    }
}
