using Godot;
using GodotUIFrame;

namespace GodotUIFrame.Examples.Basic;

public partial class Demo : Node
{
    public override async void _Ready()
    {
        await UIFrame.Show<TestPanel>(new TestPanelData
        {
            TestString = "初始化"
        });
    }
}
