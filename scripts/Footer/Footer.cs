using Godot;
using System;

public partial class Footer : HBoxContainer
{
	string url = "https://github.com/Alekssandher/secure-saver";
	private void _on_button_pressed() {
		OS.ShellOpen(url);
	}
}
