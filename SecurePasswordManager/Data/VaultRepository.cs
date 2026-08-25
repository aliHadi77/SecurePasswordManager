using Microsoft.Data.Sqlite;
using SecurePasswordManager.Models;

namespace SecurePasswordManager.Data;

public sealed class VaultRepository
{
    private const int NonceSize = 12;
    private const int TagSize = 16;

    private readonly string _connectionString;

    public VaultRepository(string databasePath)
    {
        if (string.IsNullOrWhiteSpace(databasePath))
        {
            throw new ArgumentException(
                "Database path cannot be empty.",
                nameof(databasePath));
        }

        _connectionString = new SqliteConnectionStringBuilder
        {
            DataSource = databasePath
        }.ToString();
    }

    // =========================================================
    // Vault
    // =========================================================

    public long CreateVault(Vault vault)
    {
        ArgumentNullException.ThrowIfNull(vault);

        ValidateVault(vault);

        using var connection = CreateConnection();
        using var command = connection.CreateCommand();

        command.CommandText = """
            INSERT INTO Vaults
            (
                Version,
                Salt,
                KdfAlgorithm,
                KdfHash,
                KdfIterations,
                KeySize,
                EncryptedDek,
                DekNonce,
                DekTag,
                CreatedAtUtc
            )
            VALUES
            (
                $version,
                $salt,
                $kdfAlgorithm,
                $kdfHash,
                $kdfIterations,
                $keySize,
                $encryptedDek,
                $dekNonce,
                $dekTag,
                $createdAtUtc
            );

            SELECT last_insert_rowid();
            """;

        command.Parameters.AddWithValue(
            "$version",
            vault.Version);

        command.Parameters.Add("$salt", SqliteType.Blob)
            .Value = vault.Salt;

        command.Parameters.AddWithValue(
            "$kdfAlgorithm",
            vault.KdfAlgorithm);

        command.Parameters.AddWithValue(
            "$kdfHash",
            vault.KdfHash);

        command.Parameters.AddWithValue(
            "$kdfIterations",
            vault.KdfIterations);

        command.Parameters.AddWithValue(
            "$keySize",
            vault.KeySize);

        command.Parameters.Add("$encryptedDek", SqliteType.Blob)
            .Value = vault.EncryptedDek;

        command.Parameters.Add("$dekNonce", SqliteType.Blob)
            .Value = vault.DekNonce;

        command.Parameters.Add("$dekTag", SqliteType.Blob)
            .Value = vault.DekTag;

        command.Parameters.AddWithValue(
            "$createdAtUtc",
            vault.CreatedAtUtc.ToString("O"));

        return Convert.ToInt64(
            command.ExecuteScalar());
    }

    public Vault? GetVault(long id)
    {
        using var connection = CreateConnection();
        using var command = connection.CreateCommand();

        command.CommandText = """
            SELECT
                Id,
                Version,
                Salt,
                KdfAlgorithm,
                KdfHash,
                KdfIterations,
                KeySize,
                EncryptedDek,
                DekNonce,
                DekTag,
                CreatedAtUtc
            FROM Vaults
            WHERE Id = $id;
            """;

        command.Parameters.AddWithValue(
            "$id",
            id);

        using var reader = command.ExecuteReader();

        if (!reader.Read())
        {
            return null;
        }

        return new Vault
        {
            Id = reader.GetInt64(0),
            Version = reader.GetInt32(1),
            Salt = (byte[])reader["Salt"],
            KdfAlgorithm = reader.GetString(3),
            KdfHash = reader.GetString(4),
            KdfIterations = reader.GetInt32(5),
            KeySize = reader.GetInt32(6),
            EncryptedDek = (byte[])reader["EncryptedDek"],
            DekNonce = (byte[])reader["DekNonce"],
            DekTag = (byte[])reader["DekTag"],
            CreatedAtUtc = ParseUtc(
                reader.GetString(10))
        };
    }

    public Vault? GetFirstVault()
    {
        using var connection = CreateConnection();
        using var command = connection.CreateCommand();

        command.CommandText = """
            SELECT
                Id,
                Version,
                Salt,
                KdfAlgorithm,
                KdfHash,
                KdfIterations,
                KeySize,
                EncryptedDek,
                DekNonce,
                DekTag,
                CreatedAtUtc
            FROM Vaults
            ORDER BY Id
            LIMIT 1;
            """;

        using var reader = command.ExecuteReader();

        if (!reader.Read())
        {
            return null;
        }

        return new Vault
        {
            Id = reader.GetInt64(0),
            Version = reader.GetInt32(1),
            Salt = (byte[])reader["Salt"],
            KdfAlgorithm = reader.GetString(3),
            KdfHash = reader.GetString(4),
            KdfIterations = reader.GetInt32(5),
            KeySize = reader.GetInt32(6),
            EncryptedDek = (byte[])reader["EncryptedDek"],
            DekNonce = (byte[])reader["DekNonce"],
            DekTag = (byte[])reader["DekTag"],
            CreatedAtUtc = ParseUtc(
                reader.GetString(10))
        };
    }

    public int GetVaultCount()
    {
        using var connection = CreateConnection();
        using var command = connection.CreateCommand();

        command.CommandText = """
            SELECT COUNT(*)
            FROM Vaults;
            """;

        return Convert.ToInt32(
            command.ExecuteScalar());
    }

    // =========================================================
    // Entries - Create
    // =========================================================

    public long AddEntry(VaultEntry entry)
    {
        ArgumentNullException.ThrowIfNull(entry);

        ValidateEntry(entry);

        using var connection = CreateConnection();
        using var command = connection.CreateCommand();

        command.CommandText = """
            INSERT INTO VaultEntries
            (
                VaultId,
                ServiceName,
                Username,
                EncryptedPassword,
                PasswordNonce,
                PasswordTag,
                EncryptedNotes,
                NotesNonce,
                NotesTag,
                Website,
                CreatedAtUtc,
                UpdatedAtUtc
            )
            VALUES
            (
                $vaultId,
                $serviceName,
                $username,
                $encryptedPassword,
                $passwordNonce,
                $passwordTag,
                $encryptedNotes,
                $notesNonce,
                $notesTag,
                $website,
                $createdAtUtc,
                $updatedAtUtc
            );

            SELECT last_insert_rowid();
            """;

        command.Parameters.AddWithValue(
            "$vaultId",
            entry.VaultId);

        command.Parameters.AddWithValue(
            "$serviceName",
            entry.ServiceName);

        command.Parameters.AddWithValue(
            "$username",
            entry.Username);

        command.Parameters.Add(
            "$encryptedPassword",
            SqliteType.Blob)
            .Value = entry.EncryptedPassword;

        command.Parameters.Add(
            "$passwordNonce",
            SqliteType.Blob)
            .Value = entry.PasswordNonce;

        command.Parameters.Add(
            "$passwordTag",
            SqliteType.Blob)
            .Value = entry.PasswordTag;

        command.Parameters.Add(
            "$encryptedNotes",
            SqliteType.Blob)
            .Value =
                (object?)entry.EncryptedNotes
                ?? DBNull.Value;

        command.Parameters.Add(
            "$notesNonce",
            SqliteType.Blob)
            .Value =
                (object?)entry.NotesNonce
                ?? DBNull.Value;

        command.Parameters.Add(
            "$notesTag",
            SqliteType.Blob)
            .Value =
                (object?)entry.NotesTag
                ?? DBNull.Value;

        command.Parameters.AddWithValue(
            "$website",
            (object?)entry.Website
            ?? DBNull.Value);

        command.Parameters.AddWithValue(
            "$createdAtUtc",
            entry.CreatedAtUtc.ToString("O"));

        command.Parameters.AddWithValue(
            "$updatedAtUtc",
            entry.UpdatedAtUtc.ToString("O"));

        return Convert.ToInt64(
            command.ExecuteScalar());
    }

    // =========================================================
    // Entries - Get One
    // =========================================================

    public VaultEntry? GetEntry(long id)
    {
        using var connection = CreateConnection();
        using var command = connection.CreateCommand();

        command.CommandText = """
            SELECT
                Id,
                VaultId,
                ServiceName,
                Username,
                EncryptedPassword,
                PasswordNonce,
                PasswordTag,
                EncryptedNotes,
                NotesNonce,
                NotesTag,
                Website,
                CreatedAtUtc,
                UpdatedAtUtc
            FROM VaultEntries
            WHERE Id = $id;
            """;

        command.Parameters.AddWithValue(
            "$id",
            id);

        using var reader = command.ExecuteReader();

        if (!reader.Read())
        {
            return null;
        }

        return ReadEntry(reader);
    }

    // =========================================================
    // Entries - Get All
    // =========================================================

    public List<VaultEntry> GetEntries(long vaultId)
    {
        var entries = new List<VaultEntry>();

        using var connection = CreateConnection();
        using var command = connection.CreateCommand();

        command.CommandText = """
            SELECT
                Id,
                VaultId,
                ServiceName,
                Username,
                EncryptedPassword,
                PasswordNonce,
                PasswordTag,
                EncryptedNotes,
                NotesNonce,
                NotesTag,
                Website,
                CreatedAtUtc,
                UpdatedAtUtc
            FROM VaultEntries
            WHERE VaultId = $vaultId
            ORDER BY ServiceName COLLATE NOCASE;
            """;

        command.Parameters.AddWithValue(
            "$vaultId",
            vaultId);

        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            entries.Add(
                ReadEntry(reader));
        }

        return entries;
    }

    // =========================================================
    // Entries - Search
    // =========================================================

    public List<VaultEntry> SearchEntries(
        long vaultId,
        string searchText)
    {
        if (string.IsNullOrWhiteSpace(searchText))
        {
            return GetEntries(vaultId);
        }

        var entries = new List<VaultEntry>();

        using var connection = CreateConnection();
        using var command = connection.CreateCommand();

        command.CommandText = """
            SELECT
                Id,
                VaultId,
                ServiceName,
                Username,
                EncryptedPassword,
                PasswordNonce,
                PasswordTag,
                EncryptedNotes,
                NotesNonce,
                NotesTag,
                Website,
                CreatedAtUtc,
                UpdatedAtUtc
            FROM VaultEntries
            WHERE VaultId = $vaultId
              AND
              (
                  ServiceName LIKE $search
                  OR Username LIKE $search
              )
            ORDER BY ServiceName COLLATE NOCASE;
            """;

        command.Parameters.AddWithValue(
            "$vaultId",
            vaultId);

        command.Parameters.AddWithValue(
            "$search",
            $"%{searchText.Trim()}%");

        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            entries.Add(
                ReadEntry(reader));
        }

        return entries;
    }

    // =========================================================
    // Entries - Update
    // =========================================================

    public bool UpdateEntry(VaultEntry entry)
    {
        ArgumentNullException.ThrowIfNull(entry);

        ValidateEntry(entry);

        using var connection = CreateConnection();
        using var command = connection.CreateCommand();

        command.CommandText = """
            UPDATE VaultEntries
            SET
                ServiceName = $serviceName,
                Username = $username,
                EncryptedPassword = $encryptedPassword,
                PasswordNonce = $passwordNonce,
                PasswordTag = $passwordTag,
                EncryptedNotes = $encryptedNotes,
                NotesNonce = $notesNonce,
                NotesTag = $notesTag,
                Website = $website,
                UpdatedAtUtc = $updatedAtUtc
            WHERE Id = $id
              AND VaultId = $vaultId;
            """;

        command.Parameters.AddWithValue(
            "$id",
            entry.Id);

        command.Parameters.AddWithValue(
            "$vaultId",
            entry.VaultId);

        command.Parameters.AddWithValue(
            "$serviceName",
            entry.ServiceName);

        command.Parameters.AddWithValue(
            "$username",
            entry.Username);

        command.Parameters.Add(
            "$encryptedPassword",
            SqliteType.Blob)
            .Value = entry.EncryptedPassword;

        command.Parameters.Add(
            "$passwordNonce",
            SqliteType.Blob)
            .Value = entry.PasswordNonce;

        command.Parameters.Add(
            "$passwordTag",
            SqliteType.Blob)
            .Value = entry.PasswordTag;

        command.Parameters.Add(
            "$encryptedNotes",
            SqliteType.Blob)
            .Value =
                (object?)entry.EncryptedNotes
                ?? DBNull.Value;

        command.Parameters.Add(
            "$notesNonce",
            SqliteType.Blob)
            .Value =
                (object?)entry.NotesNonce
                ?? DBNull.Value;

        command.Parameters.Add(
            "$notesTag",
            SqliteType.Blob)
            .Value =
                (object?)entry.NotesTag
                ?? DBNull.Value;

        command.Parameters.AddWithValue(
            "$website",
            (object?)entry.Website
            ?? DBNull.Value);

        command.Parameters.AddWithValue(
            "$updatedAtUtc",
            entry.UpdatedAtUtc.ToString("O"));

        return command.ExecuteNonQuery() > 0;
    }

    // =========================================================
    // Entries - Delete
    // =========================================================

    public bool DeleteEntry(long id)
    {
        using var connection = CreateConnection();
        using var command = connection.CreateCommand();

        command.CommandText = """
            DELETE FROM VaultEntries
            WHERE Id = $id;
            """;

        command.Parameters.AddWithValue(
            "$id",
            id);

        return command.ExecuteNonQuery() > 0;
    }

    // =========================================================
    // Helpers
    // =========================================================

    private SqliteConnection CreateConnection()
    {
        var connection =
            new SqliteConnection(
                _connectionString);

        connection.Open();

        using var pragma =
            connection.CreateCommand();

        pragma.CommandText =
            "PRAGMA foreign_keys = ON;";

        pragma.ExecuteNonQuery();

        return connection;
    }

    private static VaultEntry ReadEntry(
        SqliteDataReader reader)
    {
        return new VaultEntry
        {
            Id = reader.GetInt64(0),
            VaultId = reader.GetInt64(1),
            ServiceName = reader.GetString(2),
            Username = reader.GetString(3),
            EncryptedPassword =
                (byte[])reader["EncryptedPassword"],
            PasswordNonce =
                (byte[])reader["PasswordNonce"],
            PasswordTag =
                (byte[])reader["PasswordTag"],

            EncryptedNotes =
                reader["EncryptedNotes"] == DBNull.Value
                    ? null
                    : (byte[])reader["EncryptedNotes"],

            NotesNonce =
                reader["NotesNonce"] == DBNull.Value
                    ? null
                    : (byte[])reader["NotesNonce"],

            NotesTag =
                reader["NotesTag"] == DBNull.Value
                    ? null
                    : (byte[])reader["NotesTag"],

            Website =
                reader["Website"] == DBNull.Value
                    ? null
                    : reader.GetString(10),

            CreatedAtUtc =
                ParseUtc(reader.GetString(11)),

            UpdatedAtUtc =
                ParseUtc(reader.GetString(12))
        };
    }

    private static DateTime ParseUtc(
        string value)
    {
        return DateTime.Parse(
            value,
            null,
            System.Globalization.DateTimeStyles.RoundtripKind);
    }

    private static void ValidateVault(
        Vault vault)
    {
        if (vault.Salt is null ||
            vault.Salt.Length != 32)
        {
            throw new ArgumentException(
                "Vault salt must be exactly 32 bytes.",
                nameof(vault));
        }

        if (vault.EncryptedDek is null ||
            vault.EncryptedDek.Length == 0)
        {
            throw new ArgumentException(
                "Encrypted DEK cannot be empty.",
                nameof(vault));
        }

        if (vault.DekNonce is null ||
            vault.DekNonce.Length != NonceSize)
        {
            throw new ArgumentException(
                $"DEK nonce must be exactly {NonceSize} bytes.",
                nameof(vault));
        }

        if (vault.DekTag is null ||
            vault.DekTag.Length != TagSize)
        {
            throw new ArgumentException(
                $"DEK tag must be exactly {TagSize} bytes.",
                nameof(vault));
        }
    }

    private static void ValidateEntry(
        VaultEntry entry)
    {
        if (entry.VaultId <= 0)
        {
            throw new ArgumentException(
                "Vault ID must be greater than zero.",
                nameof(entry));
        }

        if (string.IsNullOrWhiteSpace(
                entry.ServiceName))
        {
            throw new ArgumentException(
                "Service name cannot be empty.",
                nameof(entry));
        }

        if (string.IsNullOrWhiteSpace(
                entry.Username))
        {
            throw new ArgumentException(
                "Username cannot be empty.",
                nameof(entry));
        }

        if (entry.EncryptedPassword is null ||
            entry.EncryptedPassword.Length == 0)
        {
            throw new ArgumentException(
                "Encrypted password cannot be empty.",
                nameof(entry));
        }

        if (entry.PasswordNonce is null ||
            entry.PasswordNonce.Length != NonceSize)
        {
            throw new ArgumentException(
                $"Password nonce must be exactly {NonceSize} bytes.",
                nameof(entry));
        }

        if (entry.PasswordTag is null ||
            entry.PasswordTag.Length != TagSize)
        {
            throw new ArgumentException(
                $"Password tag must be exactly {TagSize} bytes.",
                nameof(entry));
        }

        bool notesPresent =
            entry.EncryptedNotes is not null ||
            entry.NotesNonce is not null ||
            entry.NotesTag is not null;

        if (notesPresent)
        {
            if (entry.EncryptedNotes is null ||
                entry.EncryptedNotes.Length == 0)
            {
                throw new ArgumentException(
                    "Encrypted notes cannot be empty.",
                    nameof(entry));
            }

            if (entry.NotesNonce is null ||
                entry.NotesNonce.Length != NonceSize)
            {
                throw new ArgumentException(
                    $"Notes nonce must be exactly {NonceSize} bytes.",
                    nameof(entry));
            }

            if (entry.NotesTag is null ||
                entry.NotesTag.Length != TagSize)
            {
                throw new ArgumentException(
                    $"Notes tag must be exactly {TagSize} bytes.",
                    nameof(entry));
            }
        }
    }
}