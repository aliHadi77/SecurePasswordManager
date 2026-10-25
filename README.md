# Secure Password Manager

## 1. Project Overview

**Secure Password Manager** is a desktop application developed using C# and Windows Forms (.NET 8) to help users generate, manage, and securely store their passwords.

The application stores password entries locally in an SQLite database and uses encryption to protect sensitive information. It also provides password generation and password strength evaluation features through a simple graphical user interface.

## 2. Project Objectives

The main objectives of this project are to:

* Generate strong and random passwords.
* Evaluate password strength.
* Store account information securely.
* Encrypt sensitive data before storing it in the local database.
* Provide a simple interface for managing saved accounts.
* Allow users to copy passwords when needed.

## 3. Technologies Used

The project uses the following technologies:

* **Programming Language:** C#
* **Framework:** .NET 8
* **User Interface:** Windows Forms (WinForms)
* **Database:** SQLite
* **Key Derivation:** PBKDF2 with SHA-256
* **Encryption:** AES-GCM
* **Testing Framework:** xUnit

## 4. Main Features

### Vault Management

* Create a password vault.
* Unlock and lock the vault.
* Protect access to stored account information.

### Password Management

* Add, edit, delete, and search account entries.
* Store account passwords and optional notes in encrypted form.
* Show or hide passwords.
* Copy passwords to the clipboard.

### Password Generator

* Generate random passwords.
* Create passwords suitable for improving account security.

### Password Strength Evaluation

* Evaluate password strength to help users choose stronger passwords.

### Local Storage

* Store vault and account data in a local SQLite database.
* Encrypt sensitive information before saving it.

## 5. Security Design

The application uses the following security mechanisms:

* **PBKDF2 with SHA-256** to derive a key from the master password.
* **AES-GCM** to encrypt and authenticate sensitive data.
* A randomly generated Data Encryption Key (DEK) to encrypt stored account information.
* A Key Encryption Key (KEK), derived from the master password, to protect the DEK.
* A random salt, nonce, and authentication tag as required by the cryptographic design.

The application is designed for local password management and does not require cloud synchronization.

## 6. Test Vault Password

For the demonstration or testing setup, the vault password is:

`0000`

**Important:** This password should only be used if the demonstration environment has been configured with it. If a vault has already been created with another password, entering `0000` will not automatically unlock it.

For real use, choose a strong master password instead of `0000`.

## 7. System Requirements

To build and run the project, you need:

* Windows 10 or Windows 11.
* The .NET 8 SDK.
* Visual Studio 2022 with the .NET desktop development workload, or a compatible .NET development environment.
* Git, if you want to clone the repository.

## 8. How to Download the Project

Clone the repository using Git:

```bash
git clone https://github.com/aliHadi77/SecurePasswordManager.git
```

Navigate to the project directory:

```bash
cd SecurePasswordManager
```

Alternatively, open the repository on GitHub and select **Code → Download ZIP**.

Repository: https://github.com/aliHadi77/SecurePasswordManager

## 9. How to Run the Project

### Option A: Using Visual Studio

1. Install Visual Studio 2022 with the **.NET desktop development** workload.
2. Download or clone the repository.
3. Open the solution file (`.sln`) in Visual Studio. If the repository does not contain a solution file, open the project file (`.csproj`) instead.
4. Allow Visual Studio to restore the required NuGet packages.
5. Set the Windows Forms project as the startup project, if necessary.
6. Select the **Debug** or **Release** configuration.
7. Press **F5** or select **Start** to build and run the application.
8. Create a vault if one does not already exist.
9. If the demonstration vault was configured with the test password, enter `0000` to unlock it.

### Option B: Using the .NET CLI

Open a terminal in the directory containing the project file and run:

```bash
dotnet restore
```

Build the project:

```bash
dotnet build
```

Run the project:

```bash
dotnet run
```

These commands must be executed in the directory containing the appropriate `.csproj` file. If the repository contains multiple projects, run them from the correct project directory or specify the project file explicitly.

## 10. Running Automated Tests

If the repository includes the project's xUnit test project, restore the dependencies and run:

```bash
dotnet test
```

This command builds and executes the available automated tests.

## 11. Database and Vault Initialization

The application initializes its local database through its database initialization component.

On first use, create a vault through the application's interface. The vault password is used to derive the cryptographic key that protects the vault's encryption key.

**Note:** The password `0000` will work only if the existing vault was created using that password. Changing the README does not change the password stored or protected by the application.

## 12. Project Scope and Limitations

The project focuses on local password generation, strength evaluation, and encrypted password storage.

The current scope does not include:

* Cloud synchronization.
* Browser autofill.
* LSTM- or GAN-based password generation.

## 13. Repository

GitHub Repository:

https://github.com/aliHadi77/SecurePasswordManager

---

**Project Name:** Secure Password Manager
**Application Type:** Desktop Password Management Application
**Programming Language:** C#
**Framework:** .NET 8 Windows Forms
**Database:** SQLite
