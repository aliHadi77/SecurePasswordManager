using System.Security.Cryptography;
using SecurePasswordManager.Data;
using SecurePasswordManager.Security;
using SecurePasswordManager.Services;
using SecurePasswordManager.Models;

namespace SecurePasswordManager.Tests;

public class VaultServiceTests
{
    private static string CreateTestDatabasePath()
    {
        return Path.Combine(
            Path.GetTempPath(),
            $"SecurePasswordManager_VaultService_{Guid.NewGuid():N}.db");
    }

    private static VaultService CreateService(string databasePath)
    {
        var initializer =
            new DatabaseInitializer(databasePath);

        initializer.Initialize();

        var repository =
            new VaultRepository(databasePath);

        return new VaultService(
            repository,
            new KeyDerivationService(),
            new EncryptionService());
    }

    [Fact]
    public void CreateVault_ShouldCreateVault()
    {
        string path = CreateTestDatabasePath();

        try
        {
            VaultService service =
                CreateService(path);

            long vaultId =
                service.CreateVault("StrongMasterPassword!123");

            Assert.True(vaultId > 0);
            Assert.False(service.IsUnlocked);
            Assert.Null(service.CurrentVaultId);
        }
        finally
        {
            DeleteTestDatabase(path);
        }
    }

    [Fact]
    public void Unlock_WithCorrectPassword_ShouldSucceed()
    {
        string path = CreateTestDatabasePath();

        try
        {
            VaultService service =
                CreateService(path);

            long vaultId =
                service.CreateVault(
                    "StrongMasterPassword!123");

            service.Unlock(
                vaultId,
                "StrongMasterPassword!123");

            Assert.True(service.IsUnlocked);
            Assert.Equal(
                vaultId,
                service.CurrentVaultId);

            byte[] dek =
                service.GetDecryptedDek();

            Assert.Equal(32, dek.Length);

            CryptographicOperations.ZeroMemory(dek);
        }
        finally
        {
            DeleteTestDatabase(path);
        }
    }

    [Fact]
    public void Unlock_WithWrongPassword_ShouldFail()
    {
        string path = CreateTestDatabasePath();

        try
        {
            VaultService service =
                CreateService(path);

            long vaultId =
                service.CreateVault(
                    "StrongMasterPassword!123");

            Assert.Throws<UnauthorizedAccessException>(
                () => service.Unlock(
                    vaultId,
                    "WrongPassword!999"));

            Assert.False(service.IsUnlocked);
            Assert.Null(service.CurrentVaultId);
        }
        finally
        {
            DeleteTestDatabase(path);
        }
    }

    [Fact]
    public void Lock_ShouldClearUnlockedState()
    {
        string path = CreateTestDatabasePath();

        try
        {
            VaultService service =
                CreateService(path);

            long vaultId =
                service.CreateVault(
                    "StrongMasterPassword!123");

            service.Unlock(
                vaultId,
                "StrongMasterPassword!123");

            Assert.True(service.IsUnlocked);

            service.Lock();

            Assert.False(service.IsUnlocked);
            Assert.Null(service.CurrentVaultId);

            Assert.Throws<InvalidOperationException>(
                () => service.GetDecryptedDek());
        }
        finally
        {
            DeleteTestDatabase(path);
        }
    }

    [Fact]
    public void GetDecryptedDek_WhenLocked_ShouldFail()
    {
        string path = CreateTestDatabasePath();

        try
        {
            VaultService service =
                CreateService(path);

            Assert.Throws<InvalidOperationException>(
                () => service.GetDecryptedDek());
        }
        finally
        {
            DeleteTestDatabase(path);
        }
    }

    [Fact]
    public void Unlock_NonExistingVault_ShouldFail()
    {
        string path = CreateTestDatabasePath();

        try
        {
            VaultService service =
                CreateService(path);

            Assert.Throws<InvalidOperationException>(
                () => service.Unlock(
                    999999,
                    "StrongMasterPassword!123"));
        }
        finally
        {
            DeleteTestDatabase(path);
        }
    }

    [Fact]
    public void CreateVault_WithEmptyPassword_ShouldFail()
    {
        string path = CreateTestDatabasePath();

        try
        {
            VaultService service =
                CreateService(path);

            Assert.Throws<ArgumentException>(
                () => service.CreateVault(""));
        }
        finally
        {
            DeleteTestDatabase(path);
        }
    }

    [Fact]
    public void CreateVault_WithPasswordViolatingPolicy_ShouldNotCreateVault()
    {
        string path = CreateTestDatabasePath();

        try
        {
            VaultService service =
                CreateService(path);

            Assert.Throws<ArgumentException>(
                () => service.CreateVault("short"));

            var repository = new VaultRepository(path);

            Assert.Equal(0, repository.GetVaultCount());
        }
        finally
        {
            DeleteTestDatabase(path);
        }
    }

    [Fact]
    public void Unlock_WithEmptyPassword_ShouldFail()
    {
        string path = CreateTestDatabasePath();

        try
        {
            VaultService service =
                CreateService(path);

            long vaultId =
                service.CreateVault(
                    "StrongMasterPassword!123");

            Assert.Throws<ArgumentException>(
                () => service.Unlock(
                    vaultId,
                    ""));
        }
        finally
        {
            DeleteTestDatabase(path);
        }
    }

    [Fact]
    public void CreateVault_WhenVaultAlreadyExists_ShouldFail()
    {
        string path = CreateTestDatabasePath();

        try
        {
            VaultService service =
                CreateService(path);

            _ = service.CreateVault(
                "StrongMasterPassword!123");

            Assert.Throws<InvalidOperationException>(
                () => service.CreateVault(
                    "AnotherStrongMasterPassword!456"));

            var repository = new VaultRepository(path);

            Assert.Equal(1, repository.GetVaultCount());
        }
        finally
        {
            DeleteTestDatabase(path);
        }
    }

    private static void DeleteTestDatabase(string path)
    {
        try
        {
            if (File.Exists(path))
                File.Delete(path);
        }
        catch
        {
            // Do not hide the actual test result.
        }
    }
}
