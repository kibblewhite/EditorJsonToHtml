using EditorJsonToHtml.Lib.Models;

namespace EditorJsonToHtml.Lib.Renderers;

public sealed class RenderEmbed : IBlockRenderer
{
    /// <summary>
    /// Renders the "Embed" block.
    /// </summary>
    /// <param name="render_tree_builder">The custom render tree builder.</param>
    /// <param name="block">The EditorJs block data.</param>
    public static void Render(CustomRenderTreeBuilder render_tree_builder, EditorJsBlock block)
    {
        string? id = block.Id;
        string? service = block.Data?.Service;
        string? source = block.Data?.Source;
        string? embed = block.Data?.Embed;
        int width = block.Data?.Width ?? 0;
        int height = block.Data?.Height ?? 0;
        string? caption = block.Data?.Caption;

        // Render embed
        render_tree_builder.Builder.OpenElement(render_tree_builder.SequenceCounter, "div");
        render_tree_builder.Builder.AddAttribute(render_tree_builder.SequenceCounter, "id", id);

        EditorJsStyling? css = render_tree_builder.EditorJsStylings.FirstOrDefault(item => item.Type == SupportedRenderers.Embed && item.Id == id);
        css ??= render_tree_builder.EditorJsStylings.FirstOrDefault(item => item.Type == SupportedRenderers.Embed && item.Id == null);

        if (css is not null)
        {
            render_tree_builder.Builder.AddAttribute(render_tree_builder.SequenceCounter, "class", css.Style);
        }

        // Add embed source based on the service
        switch (service?.ToLower())
        {
            case "coub":
                RenderCoubEmbed(render_tree_builder, source, embed, width, height);
                break;
            // Add other services as needed
            default:
                // Handle unknown or unsupported service
                break;
        }

        render_tree_builder.Builder.CloseElement(); // Close the div element

        // Render caption
        if (!string.IsNullOrEmpty(caption))
        {
            render_tree_builder.Builder.OpenElement(render_tree_builder.SequenceCounter, "p");
            render_tree_builder.Builder.AddMarkupContent(render_tree_builder.SequenceCounter, caption);
            render_tree_builder.Builder.CloseElement(); // Close the p element
        }
    }

    // Helper method to render Coub embed
    private static void RenderCoubEmbed(CustomRenderTreeBuilder render_tree_builder, string? source, string? embed, int width, int height)
    {
        render_tree_builder.Builder.OpenElement(render_tree_builder.SequenceCounter, "iframe");
        render_tree_builder.Builder.AddAttribute(render_tree_builder.SequenceCounter, "src", embed);
        render_tree_builder.Builder.AddAttribute(render_tree_builder.SequenceCounter, "width", width);
        render_tree_builder.Builder.AddAttribute(render_tree_builder.SequenceCounter, "height", height);
        render_tree_builder.Builder.AddAttribute(render_tree_builder.SequenceCounter, "frameborder", "0");
        render_tree_builder.Builder.AddAttribute(render_tree_builder.SequenceCounter, "allow", "autoplay");
        render_tree_builder.Builder.AddAttribute(render_tree_builder.SequenceCounter, "allowfullscreen", "true");
        render_tree_builder.Builder.CloseElement(); // Close the iframe element
    }
}
