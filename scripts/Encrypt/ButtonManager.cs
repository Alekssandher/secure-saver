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
		Aviso("For safety, after this action the original file will be overwrtten and deleted", "fff700");
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

	private void SafeDeleteFile(string filePath) {

		long fileSize = new FileInfo(filePath).Length;

		byte[] randomData = new byte[fileSize];
		Random random = new Random();
		random.NextBytes(randomData);

		using (FileStream fs = new FileStream(filePath, FileMode.Open, System.IO.FileAccess.Write))
		{
			fs.Write(randomData, 0, randomData.Length);
		}

		File.Delete(filePath);

		Console.WriteLine("Files overwritten");
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

				SafeDeleteFile(SelectFilePath);


            }
			catch (UnauthorizedAccessException e) {
				Console.WriteLine("Permission denied: " + e.Message);

				Aviso("Permission denied. Please check your file permissions.", "bd0a33");

			}
			catch (IOException e) // Exceção para problemas de E/S
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

		Password1.Text = "";
		Password2.Text = "";
	}
}
