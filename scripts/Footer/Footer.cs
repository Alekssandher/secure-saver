using Godot;
using System;

public partial class Footer : HBoxContainer
{
	string url = "https://bing.com";
	private void _on_button_pressed() {
		OS.ShellOpen(url);
	}
}
