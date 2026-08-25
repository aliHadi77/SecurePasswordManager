using Microsoft.Data.Sqlite;

namespace SecurePasswordManager.Data;

public sealed class DatabaseInitializer
{
    private readonly string _connectionString;

    public DatabaseInitializer(string databasePath)
    {
        if (string.IsNullOrWhiteSpace(databasePath))
            throw new ArgumentException(
                "Database path cannot be empty.",
                nameof(databasePath));

        _connectionString = new SqliteConnectionStringBuilder
        {
            DataSource = databasePath
        }.ToString();
    }

    public void Initialize()
    {
        using var connection = new SqliteConnection(_connectionString);

        connection.Open();

        using var command = connection.CreateCommand();

        command.CommandText = """
            PRAGMA foreign_keys = ON;

            CREATE TABLE IF NOT EXISTS Vaults
            (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Version INTEGER NOT NULL,
                Salt BLOB NOT NULL,
                KdfAlgorithm TEXT NOT NULL,
                KdfHash TEXT NOT NULL,
                KdfIterations INTEGER NOT NULL,
                KeySize INTEGER NOT NULL,
                EncryptedDek BLOB NOT NULL,
                DekNonce BLOB NOT NULL,
                DekTag BLOB NOT NULL,
                CreatedAtUtc TEXT NOT NULL
            );

            CREATE TABLE IF NOT EXISTS VaultEntries
            (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                VaultId INTEGER NOT NULL,
                ServiceName TEXT NOT NULL,
                Username TEXT NOT NULL,

                EncryptedPassword BLOB NOT NULL,
                PasswordNonce BLOB NOT NULL,
                PasswordTag BLOB NOT NULL,

                EncryptedNotes BLOB NULL,
                NotesNonce BLOB NULL,
                NotesTag BLOB NULL,

                Website TEXT NULL,

                CreatedAtUtc TEXT NOT NULL,
                UpdatedAtUtc TEXT NOT NULL,

                FOREIGN KEY (VaultId)
                    REFERENCES Vaults(Id)
                    ON DELETE CASCADE
            );

            CREATE INDEX IF NOT EXISTS IX_VaultEntries_VaultId
            ON VaultEntries(VaultId);

            CREATE INDEX IF NOT EXISTS IX_VaultEntries_ServiceName
            ON VaultEntries(ServiceName);
            """;

        command.ExecuteNonQuery();
    }
}