namespace GodotUIFrame;

public partial class UINode<T> : UIBase where T : UIData
{
    public T Data { get; set; }
}
