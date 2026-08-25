using SecurePasswordManager.Data;
using SecurePasswordManager.Security;
using SecurePasswordManager.Services;

namespace SecurePasswordManager.Tests;

public class EntryServiceTests
{
    private static string CreateTestDatabasePath()
    {
        return Path.Combine(
            Path.GetTempPath(),
            $"SecurePasswordManager_Entry_{Guid.NewGuid():N}.db");
    }

    private static EntryService CreateService(
        string path,
        out VaultService vaultService)
    {
        new DatabaseInitializer(path).Initialize();

        var repository = new VaultRepository(path);

        vaultService = new VaultService(
            repository,
            new KeyDerivationService(),
            new EncryptionService());

        var entryService = new EntryService(
            vaultService,
            repository,
            new EncryptionService());

        return entryService;
    }

    [Fact]
    public void AddEntry_ThenGetPassword_ShouldReturnOriginalPassword()
    {
        string path = CreateTestDatabasePath();

        try
        {
            EntryService entries =
                CreateService(path, out VaultService vault);

            long vaultId =
                vault.CreateVault("StrongMasterPassword!123");

            vault.Unlock(
                vaultId,
                "StrongMasterPassword!123");

            long entryId =
                entries.AddEntry(
                    "Example",
                    "user@example.com",
                    "P@ssword123!",
                    "Private notes",
                    "https://example.com");

            string password =
                entries.GetPassword(entryId);

            Assert.Equal(
                "P@ssword123!",
                password);

            Assert.Equal(
                "Private notes",
                entries.GetNotes(entryId));
        }
        finally
        {
            Delete(path);
        }
    }

    [Fact]
    public void AddEntry_ShouldNotStorePasswordAsPlaintext()
    {
        string path = CreateTestDatabasePath();

        try
        {
            EntryService entries =
                CreateService(path, out VaultService vault);

            long vaultId =
                vault.CreateVault("StrongMasterPassword!123");

            vault.Unlock(
                vaultId,
                "StrongMasterPassword!123");

            long entryId =
                entries.AddEntry(
                    "Example",
                    "user@example.com",
                    "P@ssword123!");

            var repository =
                new VaultRepository(path);

            var entry =
                repository.GetEntry(entryId);

            Assert.NotNull(entry);

            string stored =
                Convert.ToBase64String(
                    entry.EncryptedPassword);

            Assert.DoesNotContain(
                "P@ssword123!",
                stored);
        }
        finally
        {
            Delete(path);
        }
    }

    [Fact]
    public void GetEntries_ShouldReturnCurrentVaultEntriesOnly()
    {
        string path = CreateTestDatabasePath();

        try
        {
            EntryService entries =
                CreateService(path, out VaultService vault);

            long vaultId =
                vault.CreateVault("StrongMasterPassword!123");

            vault.Unlock(
                vaultId,
                "StrongMasterPassword!123");

            entries.AddEntry(
                "Google",
                "user1",
                "Password1!");

            entries.AddEntry(
                "GitHub",
                "user2",
                "Password2!");

            var result =
                entries.GetEntries();

            Assert.Equal(2, result.Count);
        }
        finally
        {
            Delete(path);
        }
    }

    [Fact]
    public void SearchEntries_ShouldFindMatchingService()
    {
        string path = CreateTestDatabasePath();

        try
        {
            EntryService entries =
                CreateService(path, out VaultService vault);

            long vaultId =
                vault.CreateVault("StrongMasterPassword!123");

            vault.Unlock(
                vaultId,
                "StrongMasterPassword!123");

            entries.AddEntry(
                "Google",
                "user1",
                "Password1!");

            entries.AddEntry(
                "GitHub",
                "user2",
                "Password2!");

            var result =
                entries.SearchEntries("Google");

            Assert.Single(result);
            Assert.Equal(
                "Google",
                result[0].ServiceName);
        }
        finally
        {
            Delete(path);
        }
    }

    [Fact]
    public void LockedVault_ShouldPreventEntryAccess()
    {
        string path = CreateTestDatabasePath();

        try
        {
            EntryService entries =
                CreateService(path, out VaultService vault);

            Assert.Throws<InvalidOperationException>(
                () => entries.GetEntries());
        }
        finally
        {
            Delete(path);
        }
    }

    [Fact]
    public void DeleteEntry_ShouldRemoveEntry()
    {
        string path = CreateTestDatabasePath();

        try
        {
            EntryService entries =
                CreateService(path, out VaultService vault);

            long vaultId =
                vault.CreateVault("StrongMasterPassword!123");

            vault.Unlock(
                vaultId,
                "StrongMasterPassword!123");

            long entryId =
                entries.AddEntry(
                    "Example",
                    "user@example.com",
                    "Password123!");

            Assert.True(
                entries.DeleteEntry(entryId));

            Assert.Empty(
                entries.GetEntries());
        }
        finally
        {
            Delete(path);
        }
    }

    private static void Delete(string path)
    {
        try
        {
            if (File.Exists(path))
                File.Delete(path);
        }
        catch
        {
        }
    }
    [Fact]
    public void UpdateEntry_ShouldUpdatePasswordAndUsername()
    {
        string path = CreateTestDatabasePath();

        try
        {
            EntryService entries =
                CreateService(path, out VaultService vault);

            long vaultId =
                vault.CreateVault("StrongMasterPassword!123");

            vault.Unlock(
                vaultId,
                "StrongMasterPassword!123");

            long entryId =
                entries.AddEntry(
                    "Example",
                    "old@example.com",
                    "OldPassword123!");

            bool updated =
                entries.UpdateEntry(
                    entryId,
                    "Updated Example",
                    "new@example.com",
                    "NewPassword456!");

            Assert.True(updated);

            Assert.Equal(
                "NewPassword456!",
                entries.GetPassword(entryId));

            var result =
                entries.GetEntries();

            Assert.Single(result);

            Assert.Equal(
                "Updated Example",
                result[0].ServiceName);

            Assert.Equal(
                "new@example.com",
                result[0].Username);
        }
        finally
        {
            Delete(path);
        }
    }
}