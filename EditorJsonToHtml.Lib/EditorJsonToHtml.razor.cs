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
        try
        {
            blocks = JsonSerializer.Deserialize<EditorJsBlocks>(EditorJson);
        }
        catch (Exception ex)
        {
            logger.LogTrace("Deserialise EditorJson Failed: {Exception}", ex.Message);
            throw;
        }

        CustomRenderTreeBuilder custom_render_tree_builder = new()
        {
            Builder = builder,
            SequenceCounter = 0
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
                RenderParagraph.Render(render_tree_builder, block?.Data?.Text);
                break;
            case SupportedRenderers.Header:
                RenderHeader.Render(render_tree_builder, block?.Data?.Text, block?.Data?.Level);
                break;
            case SupportedRenderers.List:
                RenderList.Render(render_tree_builder, block?.Data?.Style, block?.Data?.Items);
                break;
            case SupportedRenderers.Quote:
                RenderQuote.Render(render_tree_builder, block?.Data?.Text, block?.Data?.Caption, block?.Data?.Alignment);
                break;
            case SupportedRenderers.Checklist:
                RenderChecklist.Render(render_tree_builder, block?.Data?.Items);
                break;
            case SupportedRenderers.Table:
                RenderTable.Render(render_tree_builder, block?.Data?.WithHeadings ?? false, block?.Data?.Content);
                break;
        }
    }
}