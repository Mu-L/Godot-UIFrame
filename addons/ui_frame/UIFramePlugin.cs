using Godot;

namespace GodotUIFrame.Addons.UIFrame;

[Tool]
public partial class UIFramePlugin : EditorPlugin
{
    private const string AutoloadName = "UiFrame";
    private const string AutoloadPath = "res://addons/ui_frame/runtime/UIFrame.cs";
    private UIFrameEditorInspectorPlugin _inspectorPlugin;

    public override void _EnterTree()
    {
        if (!ProjectSettings.HasSetting($"autoload/{AutoloadName}"))
        {
            AddAutoloadSingleton(AutoloadName, AutoloadPath);
        }

        _inspectorPlugin = new UIFrameEditorInspectorPlugin
        {
            UndoRedo = GetUndoRedo()
        };
        AddInspectorPlugin(_inspectorPlugin);
        AddToolMenuItem("UIFrame/Auto Bind Selected UIBase", Callable.From(AutoBindSelected));
    }

    public override void _ExitTree()
    {
        RemoveToolMenuItem("UIFrame/Auto Bind Selected UIBase");
        if (ProjectSettings.HasSetting($"autoload/{AutoloadName}"))
        {
            RemoveAutoloadSingleton(AutoloadName);
        }

        if (_inspectorPlugin == null) return;

        RemoveInspectorPlugin(_inspectorPlugin);
        _inspectorPlugin = null;
    }

    private void AutoBindSelected()
    {
        var selection = EditorInterface.Singleton.GetSelection();
        if (selection == null) return;

        foreach (var item in selection.GetSelectedNodes())
        {
            if (item is UIBase uiBase)
            {
                _inspectorPlugin?.AutoBind(uiBase);
            }
        }
    }
}
