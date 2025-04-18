using Godot;
using MaxWallet.scripts.utils;
using System;
using System.IO;

public partial class Control : Godot.Control
{
	[Export]
	LineEdit Password;

	[Export]
	Label WarningLabel;

	[Export]
	FileDialog SelectFileWindow;

	[Export]
	FileDialog SaveFileWindow;

	[Export]
	CheckButton Mode;

	[Export]
	Node2D VisualizerNode;
	[Export]
	RichTextLabel RichLabel;
	string SelectFilePath;
	string SaveFilePath;
	byte[] FileContent;
	string FileDecrypted;
	public override void _Ready()
	{
	}

	private void Aviso(string message, string color) {
		WarningLabel.LabelSettings.FontColor = new Color(color);
		WarningLabel.Text = message;
		WarningLabel.Visible = true;
	}

	private bool Verify() {

		if(!File.Exists(SelectFilePath)) {
			Aviso("Select a valid file", "bd0a33");
			return true;
		}

		if (Path.GetExtension(SelectFilePath).ToLower() != ".txt") {
			Aviso("You must select a .txt file.", "bd0a33");
			return true;
		}

		return false;
	}
	private void _on_decrypt_pressed() {

		if (Verify()) return;

		if (File.Exists(SelectFilePath)) {
			try {

				Aviso("Now decrypting your file...", "fff700");  

				FileContent = File.ReadAllBytes(SelectFilePath);

				FileDecrypted = Decrypt.DecryptWalletData(FileContent, Password.Text);

				if(Mode.ButtonPressed) {
					VisualizerNode.Visible = true;
					RichLabel.Text = FileDecrypted;

					return;
				}
				SaveFileWindow.Popup();

				WarningLabel.Text = "";
			} 
			catch (UnauthorizedAccessException e) {
				Console.WriteLine("Permission denied: " + e.Message);
				
				Aviso("Permission denied. Please check your file permissions.", "bd0a33");

			}
			catch (IOException e)
			{
				Console.WriteLine("File access error: " + e.Message);
				Aviso("File access error. Ensure the file is not in use by another program.", "bd0a33");
			}
			catch (Exception e)
            {
				Aviso("Wrong password or corrupted data, try again.", "fff700");
				Console.WriteLine("Unexpected error: " + e.Message);
            }
		}
		

	}
	private void _on_select_file_pressed() {

		SelectFileWindow.Popup();

	}

	private void _on_select_file_file_selected(string path) {

		SelectFilePath = path;

	}

	private void _on_save_file_file_selected(string path) {

		SaveFilePath = path;

		File.WriteAllText(SaveFilePath, FileDecrypted);

		Aviso("File saved successfully", "00e200");

		Password.Text = "";
	}
}
