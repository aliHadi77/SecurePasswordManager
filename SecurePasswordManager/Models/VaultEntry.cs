namespace SecurePasswordManager.Models;

public sealed class VaultEntry
{
    public long Id { get; init; }

    public long VaultId { get; init; }

    public string ServiceName { get; set; } = string.Empty;

    public string Username { get; set; } = string.Empty;

    public byte[] EncryptedPassword { get; set; } = Array.Empty<byte>();

    public byte[] PasswordNonce { get; set; } = Array.Empty<byte>();

    public byte[] PasswordTag { get; set; } = Array.Empty<byte>();

    public byte[]? EncryptedNotes { get; set; }

    public byte[]? NotesNonce { get; set; }

    public byte[]? NotesTag { get; set; }

    public string? Website { get; set; }

    public DateTime CreatedAtUtc { get; init; }

    public DateTime UpdatedAtUtc { get; set; }
}