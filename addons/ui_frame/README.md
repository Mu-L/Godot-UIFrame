# UIFrame add-on

Copy this `ui_frame` directory to `res://addons/ui_frame` in a Godot .NET
project, wait for C# compilation, then enable **UIFrame** under
**Project > Project Settings > Plugins**.

UI scenes are loaded from `res://ui` by default. Built-in panel and window
scenes use the `panels` and `windows` subdirectories. Scene filenames are the
snake_case form of their C# type names.

See the repository-level README for API examples and packaging instructions.
