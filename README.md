# Secure Saver
![home screen](https://github.com/user-attachments/assets/06304149-df1c-4b15-bb8f-b6e5f6528ebd)

Secure Saver is a desktop application built with Godot Engine that allows users to encrypt and decrypt text files with password protection.

## Table of contents

1. [Overview](#overview)  
2. [Features](#features)  
3. [How It Works](#how-it-works)  
   - [Encryption Process](#encryption-process)  
   - [Decryption Process](#decryption-process)  
4. [Security Features](#security-features)  
5. [Technical Implementation](#technical-implementation)  
6. [Download](#download)  
7. [Requirements](#requirements)  
8. [Getting Started](#getting-started)  
9. [License](#license)  
10. [Contributions](#contributions)  
11. [Disclaimer](#disclaimer)
    
## Overview

Secure Saver provides a straightforward interface for text file encryption and decryption, ensuring your sensitive information remains secure. The application uses AES encryption with strong password-based key derivation to protect your data.

## Features

- **File Encryption**: Encrypt text files with password protection
- **File Decryption**: Decrypt previously encrypted files with the correct password
- **Visualizer Mode**: View decrypted content directly in the application without saving
- **Secure File Handling**: Original files are securely overwritten and deleted after encryption
- **Strong Encryption**: Uses AES encryption with 500,000 iterations of key derivation for enhanced security

## How It Works

### Encryption Process
![Encrypt screen](https://github.com/user-attachments/assets/39822370-99d5-44c0-8e47-555d780b6898)

1. Select the encrypt option
2. Select a text file (.txt) to encrypt
3. Enter a password (minimum 6 characters)
4. Click "Encrypt"
5. Choose where to save the encrypted file
6. The original file is securely overwritten and deleted

### Decryption Process
![Decrypt screen](https://github.com/user-attachments/assets/9389c369-ca59-4e9b-87a6-4df3fe23fbbd)

1. Select the decrypt option
2. Select an encrypted file to decrypt
3. Enter the password used for encryption
4. Click "Decrypt"
5. If "Visualizer mode" is enabled, view the decrypted content directly in the application
6. Otherwise, select where to save the decrypted file

## Security Features

- **AES Encryption**: Industry-standard encryption algorithm
- **Secure Key Derivation**: Uses Rfc2898DeriveBytes with 500,000 iterations
- **Random Initialization Vector**: Each encryption uses a unique IV
- **Secure File Deletion**: Files are overwritten with random data before deletion
- **Password Protection**: All encryption/decryption requires a password

## Technical Implementation

- Built with Godot Engine
- Written in C#
- Uses System.Security.Cryptography for encryption operations
- Implements proper exception handling for file access and cryptographic operations

## Download

Pre-built executables are available in the [releases](https://github.com/Alekssandher/secure-saver/releases) section of the repository. Binaries are available for:
- Windows
- Linux

Simply download the appropriate version for your operating system, extract the files, and run the application.

## Requirements

- Godot Engine 4.3 Mono (version compatible with C# scripts)
- .NET support

## Getting Started

1. Clone the repository:
   ```
   git clone https://github.com/Alekssandher/secure-saver.git
   ```
2. Open the project in Godot Engine
3. Run the application

## License

This project is licensed under the GNU General Public License (GPL) version 3. You are free to use, modify, and distribute this software, provided that all copies and derivatives are also licensed under GPL v3.

## Contributions

Contributions are welcome! Please feel free to submit a Pull Request.
For more details, see the [LICENSE](https://github.com/Alekssandher/secure-saver/tree/main?tab=GPL-3.0-1-ov-file) file included in this repository.

## Disclaimer

This tool is provided for legitimate security purposes. Always ensure you have proper backups of your data before encryption.
