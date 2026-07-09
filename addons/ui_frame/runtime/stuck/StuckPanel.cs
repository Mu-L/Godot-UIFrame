using Godot;

namespace GodotUIFrame;

public partial class StuckPanel : Control
{
    [Export] private TextureRect _icon;

    public override void _Process(double delta)
    {
        _icon.Rotation += (float)delta * 5;
    }
}
