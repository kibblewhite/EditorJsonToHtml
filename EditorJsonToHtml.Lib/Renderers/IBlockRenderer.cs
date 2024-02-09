using EditorJsonToHtml.Lib.Models;

namespace EditorJsonToHtml.Lib.Renderers;

public interface IBlockRenderer
{
    static abstract void Render(CustomRenderTreeBuilder render_tree_builder, EditorJsBlock block);

    static virtual void Resize(int width, int height)
    {
        // Default implementation for Resize method
        // Code to resize the shape
    }
}
