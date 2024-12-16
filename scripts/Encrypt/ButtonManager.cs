using Godot;
using MaxWallet.scripts.utils;
using System;
using System.IO;

public partial class ButtonManager : HBoxContainer
{
	[Export]
	LineEdit Password1;

	[Export]
	LineEdit Password2;

	[Export]
	FileDialog SelectFileWindow;

	[Export]
	FileDialog SaveFileWindow;

	[Export]
	Label WarningLabel;
	string SelectFilePath;
	string SaveFilePath;
	string FileContent;

	byte[] FileEncrypted;
	public override void _Ready()
	{

	}

	private void Aviso(string message, string color) {
		WarningLabel.LabelSettings.FontColor = new Color(color);
		WarningLabel.Text = message;
		WarningLabel.Visible = true;
	}

	private bool Verify(){
		if(Password1.Text != Password2.Text) {
			Aviso("The passwords must be the same.", "bd0a33");
			return true;
		}

		if(Password1.Text.Length < 6) {
			Aviso("Make sure to have a good password.", "bd0a33");
			return true;
		}
		if(string.IsNullOrWhiteSpace(Password1.Text) || string.IsNullOrWhiteSpace(Password2.Text)) {
			Aviso("The password can't be null or blank.", "bd0a33");
			return true;
		}

		if(SelectFilePath == null) {
			Aviso("File path not found, select your file.", "bd0a33");
			return true;
		}

		if (Path.GetExtension(SelectFilePath).ToLower() != ".txt") {
			Aviso("You must select a .txt file.", "bd0a33");
			return true;
		}

		WarningLabel.Text = "";
		return false;
	}
	private void _on_encrypt_pressed() {
		if (Verify()) return;

		if (File.Exists(SelectFilePath))
        {
            try
            {              
				Aviso("Now encrypting your file...", "fff700");  

                FileContent = File.ReadAllText(SelectFilePath);
				
				FileEncrypted = Encrypt.EncryptData(FileContent, Password1.Text);

				SaveFileWindow.Popup();

				WarningLabel.Text = "";


            }
            catch (Exception e)
            {
                GD.PrintErr("Error reading file");
				Console.WriteLine("Error reading file");
            }
        }
        else
        {
            Aviso("There was an unexpected error, try again.", "bd0a33");
        }

	}
	private void _on_select_file_pressed(){
	
		SelectFileWindow.Popup();
	}
	private void _on_select_file_file_selected(string path) {

		SelectFilePath = path;

	}
	private void _on_save_file_file_selected(string path) {

		SaveFilePath = path;

		File.WriteAllBytes(SaveFilePath, FileEncrypted);

		Aviso("File saved successfully", "00e200");
	}
}
