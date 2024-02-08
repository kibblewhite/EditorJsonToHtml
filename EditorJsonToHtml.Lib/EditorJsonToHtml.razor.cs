using EditorJsonToHtml.Lib.Models;
using EditorJsonToHtml.Lib.Renderers;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace EditorJsonToHtml.Lib;
public partial class EditorJsonToHtml : ComponentBase
{
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    [Parameter]
    public required string EditorJson { get; set; }

    [Parameter]
    public required string EditorStyling { get; set; }

    [Inject]
    public required ILogger<EditorJsonToHtml> logger { get; set; }

    protected override async Task OnInitializedAsync()
    {
        ChildContent = new(ConvertJsonToRenderFragment);
        StateHasChanged();
        await base.OnInitializedAsync();
    }

    private RenderFragment ConvertJsonToRenderFragment => builder =>
    {

        EditorJsBlocks? blocks;
        IEnumerable<EditorJsStyling>? editor_js_stylings; 

        try
        {
            blocks = JsonSerializer.Deserialize<EditorJsBlocks>(EditorJson);
        }
        catch (Exception ex)
        {
            logger.LogTrace("Deserialise EditorJsBlocks Failed: {Exception}", ex.Message);
            throw;
        }

        try
        {
            editor_js_stylings = JsonSerializer.Deserialize<IEnumerable<EditorJsStyling>>(EditorStyling);
        }
        catch (Exception ex)
        {
            logger.LogTrace("Deserialise EditorJsStyling Failed: {Exception}", ex.Message);
            throw;
        }

        CustomRenderTreeBuilder custom_render_tree_builder = new()
        {
            Builder = builder,
            EditorJsStylings = editor_js_stylings?.ToList().AsReadOnly() ?? Enumerable.Empty<EditorJsStyling>().ToList().AsReadOnly()
        };

        foreach (EditorJsBlock block in blocks?.Blocks ?? Enumerable.Empty<EditorJsBlock>())
        {
            RenderBlock(custom_render_tree_builder, block);
        }
    };

    private static void RenderBlock(CustomRenderTreeBuilder render_tree_builder, EditorJsBlock block)
    {
        if (Enum.TryParse(block.Type, true, out SupportedRenderers renderer) is false)
        {
            return;
        }

        switch (renderer)
        {
            case SupportedRenderers.Paragraph:
                RenderParagraph.Render(render_tree_builder, block.Id, block.Data?.Text);
                break;
            case SupportedRenderers.Header:
                RenderHeader.Render(render_tree_builder, block.Id, block?.Data?.Level, block?.Data?.Text);
                break;
            case SupportedRenderers.List:
                RenderList.Render(render_tree_builder, block.Id, block?.Data?.Style, block?.Data?.Items);
                break;
            case SupportedRenderers.Quote:
                RenderQuote.Render(render_tree_builder, block.Id, block?.Data?.Text, block?.Data?.Caption, block?.Data?.Alignment);
                break;
            case SupportedRenderers.Checklist:
                RenderChecklist.Render(render_tree_builder, block.Id, block?.Data?.Items);
                break;
            case SupportedRenderers.Table:
                RenderTable.Render(render_tree_builder, block.Id, block?.Data?.WithHeadings ?? false, block?.Data?.Content);
                break;
        }
    }
}
