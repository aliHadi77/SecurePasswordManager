using System.Security.Cryptography;
using Microsoft.Data.Sqlite;
using SecurePasswordManager.Data;
using SecurePasswordManager.Models;

namespace SecurePasswordManager.Tests;

public class VaultRepositoryTests
{
    private static string CreateTestDatabasePath()
    {
        return Path.Combine(
            Path.GetTempPath(),
            $"SecurePasswordManager_Test_{Guid.NewGuid():N}.db");
    }

    private static Vault CreateTestVault()
    {
        byte[] key = RandomNumberGenerator.GetBytes(32);

        return new Vault
        {
            Version = 1,
            Salt = RandomNumberGenerator.GetBytes(32),
            KdfAlgorithm = "PBKDF2",
            KdfHash = "SHA256",
            KdfIterations = 600_000,
            KeySize = 256,
            EncryptedDek = RandomNumberGenerator.GetBytes(32),
            DekNonce = RandomNumberGenerator.GetBytes(12),
            DekTag = RandomNumberGenerator.GetBytes(16),
            CreatedAtUtc = DateTime.UtcNow
        };
    }

    private static VaultEntry CreateTestEntry(long vaultId)
    {
        return new VaultEntry
        {
            VaultId = vaultId,
            ServiceName = "Example Service",
            Username = "test@example.com",
            EncryptedPassword = RandomNumberGenerator.GetBytes(32),
            PasswordNonce = RandomNumberGenerator.GetBytes(12),
            PasswordTag = RandomNumberGenerator.GetBytes(16),
            EncryptedNotes = RandomNumberGenerator.GetBytes(20),
            NotesNonce = RandomNumberGenerator.GetBytes(12),
            NotesTag = RandomNumberGenerator.GetBytes(16),
            Website = "https://example.com",
            CreatedAtUtc = DateTime.UtcNow,
            UpdatedAtUtc = DateTime.UtcNow
        };
    }

    private static VaultRepository CreateRepository(
        string databasePath)
    {
        var initializer =
            new DatabaseInitializer(databasePath);

        initializer.Initialize();

        return new VaultRepository(databasePath);
    }

    [Fact]
    public void CreateVault_ThenGetVault_ShouldReturnVault()
    {
        string path = CreateTestDatabasePath();

        try
        {
            var repository = CreateRepository(path);

            Vault vault = CreateTestVault();

            long id = repository.CreateVault(vault);

            Vault? result = repository.GetVault(id);

            Assert.NotNull(result);
            Assert.Equal(id, result.Id);
            Assert.Equal(32, result.Salt.Length);
            Assert.Equal(600_000, result.KdfIterations);
            Assert.Equal(256, result.KeySize);
        }
        finally
        {
            DeleteTestDatabase(path);
        }
    }

    [Fact]
    public void AddEntry_ThenGetEntry_ShouldReturnEntry()
    {
        string path = CreateTestDatabasePath();

        try
        {
            var repository = CreateRepository(path);

            long vaultId =
                repository.CreateVault(CreateTestVault());

            VaultEntry entry =
                CreateTestEntry(vaultId);

            long entryId =
                repository.AddEntry(entry);

            VaultEntry? result =
                repository.GetEntry(entryId);

            Assert.NotNull(result);
            Assert.Equal(entryId, result.Id);
            Assert.Equal(vaultId, result.VaultId);
            Assert.Equal(
                entry.ServiceName,
                result.ServiceName);

            Assert.Equal(
                entry.Username,
                result.Username);

            Assert.Equal(
                entry.EncryptedPassword,
                result.EncryptedPassword);
        }
        finally
        {
            DeleteTestDatabase(path);
        }
    }

    [Fact]
    public void SearchEntries_ShouldFindMatchingService()
    {
        string path = CreateTestDatabasePath();

        try
        {
            var repository = CreateRepository(path);

            long vaultId =
                repository.CreateVault(CreateTestVault());

            repository.AddEntry(
                CreateTestEntry(vaultId));

            VaultEntry second =
    CreateTestEntry(vaultId);

            second.ServiceName = "Another Service";
            second.Username = "another@sample.net";

            repository.AddEntry(second);

            List<VaultEntry> results =
                repository.SearchEntries(
                    vaultId,
                    "Example");

            Assert.Single(results);
            Assert.Equal(
                "Example Service",
                results[0].ServiceName);
        }
        finally
        {
            DeleteTestDatabase(path);
        }
    }

    [Fact]
    public void UpdateEntry_ShouldModifyEntry()
    {
        string path = CreateTestDatabasePath();

        try
        {
            var repository = CreateRepository(path);

            long vaultId =
                repository.CreateVault(CreateTestVault());

            VaultEntry entry =
                CreateTestEntry(vaultId);

            long id =
                repository.AddEntry(entry);

            VaultEntry? saved =
                repository.GetEntry(id);

            Assert.NotNull(saved);

            saved.ServiceName = "Updated Service";
            saved.Username = "updated@example.com";
            saved.UpdatedAtUtc = DateTime.UtcNow;

            bool updated =
                repository.UpdateEntry(saved);

            Assert.True(updated);

            VaultEntry? result =
                repository.GetEntry(id);

            Assert.NotNull(result);
            Assert.Equal(
                "Updated Service",
                result.ServiceName);

            Assert.Equal(
                "updated@example.com",
                result.Username);
        }
        finally
        {
            DeleteTestDatabase(path);
        }
    }

    [Fact]
    public void DeleteEntry_ShouldRemoveEntry()
    {
        string path = CreateTestDatabasePath();

        try
        {
            var repository = CreateRepository(path);

            long vaultId =
                repository.CreateVault(CreateTestVault());

            long id =
                repository.AddEntry(
                    CreateTestEntry(vaultId));

            bool deleted =
                repository.DeleteEntry(id);

            Assert.True(deleted);

            VaultEntry? result =
                repository.GetEntry(id);

            Assert.Null(result);
        }
        finally
        {
            DeleteTestDatabase(path);
        }
    }

    [Fact]
    public void DeleteVault_ShouldCascadeDeleteEntries()
    {
        string path = CreateTestDatabasePath();

        try
        {
            var repository = CreateRepository(path);

            long vaultId =
                repository.CreateVault(CreateTestVault());

            long entryId =
                repository.AddEntry(
                    CreateTestEntry(vaultId));

            using var connection =
                new SqliteConnection(
                    new SqliteConnectionStringBuilder
                    {
                        DataSource = path
                    }.ToString());

            connection.Open();

            using var command =
                connection.CreateCommand();

            command.CommandText =
                "DELETE FROM Vaults WHERE Id = $id;";

            command.Parameters.AddWithValue(
                "$id",
                vaultId);

            command.ExecuteNonQuery();

            Assert.Null(
                repository.GetEntry(entryId));
        }
        finally
        {
            DeleteTestDatabase(path);
        }
    }

    private static void DeleteTestDatabase(
        string path)
    {
        try
        {
            if (File.Exists(path))
                File.Delete(path);
        }
        catch
        {
            // Test cleanup should not hide the actual test result.
        }
    }
}