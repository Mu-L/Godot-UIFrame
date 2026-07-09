using System;

namespace GodotUIFrame;

[AttributeUsage(AttributeTargets.Class)]
public abstract class UILayer : Attribute, IComparable<UILayer>
{
	public int CompareTo(UILayer other)
	{
		return GetOrder().CompareTo(other.GetOrder());
	}

	public abstract string GetName();
	public abstract int GetOrder();
}

public class PanelLayer : UILayer
{
	public override string GetName() => "Panels";
	public override int GetOrder() => 1;
}

public class WindowLayer : UILayer
{
	public override string GetName() => "Windows";
	public override int GetOrder() => 3;
}
