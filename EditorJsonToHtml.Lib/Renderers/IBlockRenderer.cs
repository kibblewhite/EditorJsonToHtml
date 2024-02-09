using EditorJsonToHtml.Lib.Models;

namespace EditorJsonToHtml.Lib.Renderers;

public interface IBlockRenderer
{
    static abstract void Render(CustomRenderTreeBuilder render_tree_builder, EditorJsBlock block);
}
