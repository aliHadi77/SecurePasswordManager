namespace SecurePasswordManager.Models;

public sealed class Vault
{
    public long Id { get; init; }

    public int Version { get; init; } = 1;

    public byte[] Salt { get; init; } = Array.Empty<byte>();

    public string KdfAlgorithm { get; init; } = "PBKDF2";

    public string KdfHash { get; init; } = "SHA256";

    public int KdfIterations { get; init; } = 600_000;

    public int KeySize { get; init; } = 256;

    public byte[] EncryptedDek { get; init; } = Array.Empty<byte>();

    public byte[] DekNonce { get; init; } = Array.Empty<byte>();

    public byte[] DekTag { get; init; } = Array.Empty<byte>();

    public DateTime CreatedAtUtc { get; init; }
}