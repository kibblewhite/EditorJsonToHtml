using EditorJsonToHtml.Lib.Models;
using System;
using System.Collections.Generic;
namespace EditorJsonToHtml.Lib.Renderers;

public sealed class BlockRenderCssStyle
{
    // todo (2024-20-09|kibble) Add in optional parameters (default null) for things like header which matches on level for example...
    public static EditorJsStyling? BuildEditorJsStylings(CustomRenderTreeBuilder render_tree_builder, SupportedRenderers render_type, string? id, int? level = null)
    {
        EditorJsStyling? css = render_tree_builder.EditorJsStylings.FirstOrDefault(item => item.Type == render_type && item.Level == level && item.Id == id);
        css ??= render_tree_builder.EditorJsStylings.FirstOrDefault(item => item.Type == render_type && item.Level == level && item.Id == null);
        return css;
    }
}
