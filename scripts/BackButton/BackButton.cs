using Godot;


public partial class BackButton : Node2D
{
	private void _on_back_button_pressed() {
		PackedScene MainScreen = ResourceLoader.Load<PackedScene>("res://scenes/Main.tscn");

		GetTree().ChangeSceneToPacked(MainScreen);
	}
}
