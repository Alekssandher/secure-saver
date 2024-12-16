using Godot;
using System;

public partial class ButtonsManager : VBoxContainer
{
	[Export]
	Button EncryptButton;
	
	[Export]
	Button DescryptButton;


    private void _on_encrypt_pressed() {

		PackedScene EncryptScene = ResourceLoader.Load<PackedScene>("res://scenes/Encrypt.tscn"); 

		GetTree().ChangeSceneToPacked(EncryptScene);
	}
	private void _on_decrypt_pressed() {

		PackedScene DecryptScene = ResourceLoader.Load<PackedScene>("res://scenes/Decrypt.tscn");

		GetTree().ChangeSceneToPacked(DecryptScene);
	}
	
}
