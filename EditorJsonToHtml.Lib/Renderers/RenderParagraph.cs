﻿namespace EditorJsonToHtml.Lib.Renderers;

public static partial class RenderParagraph
{
    public static void Render(CustomRenderTreeBuilder render_tree_builder, string? id, string? text)
    {
        render_tree_builder.Builder.OpenElement(render_tree_builder.SequenceCounter, "p");
        render_tree_builder.Builder.AddAttribute(render_tree_builder.SequenceCounter, "id", id);

        Models.EditorJsStyling? css = render_tree_builder.EditorJsStylings.FirstOrDefault(item => item.Type == SupportedRenderers.Paragraph && item.Id == id);
        css ??= render_tree_builder.EditorJsStylings.FirstOrDefault(item => item.Type == SupportedRenderers.Paragraph && item.Id == null);

        if (css is not null)
        {
            render_tree_builder.Builder.AddAttribute(render_tree_builder.SequenceCounter, "class", css.Style);
        }

        render_tree_builder.Builder.AddMarkupContent(render_tree_builder.SequenceCounter, text);
        render_tree_builder.Builder.CloseElement();
    }
}
