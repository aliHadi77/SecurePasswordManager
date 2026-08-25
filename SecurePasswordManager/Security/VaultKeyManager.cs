using System.Security.Cryptography;

namespace SecurePasswordManager.Security;

public sealed class VaultKeyManager
{
    private const int KeySize = 32;

    private readonly EncryptionService _encryptionService;

    public VaultKeyManager(EncryptionService encryptionService)
    {
        _encryptionService = encryptionService
            ?? throw new ArgumentNullException(nameof(encryptionService));
    }

    public byte[] GenerateDataEncryptionKey()
    {
        return RandomNumberGenerator.GetBytes(KeySize);
    }

    public EncryptedData ProtectDataEncryptionKey(
        byte[] dataEncryptionKey,
        byte[] keyEncryptionKey)
    {
        ValidateKey(dataEncryptionKey, nameof(dataEncryptionKey));
        ValidateKey(keyEncryptionKey, nameof(keyEncryptionKey));

        return _encryptionService.Encrypt(
            dataEncryptionKey,
            keyEncryptionKey);
    }

    public byte[] UnprotectDataEncryptionKey(
        EncryptedData protectedDataEncryptionKey,
        byte[] keyEncryptionKey)
    {
        ValidateKey(keyEncryptionKey, nameof(keyEncryptionKey));

        return _encryptionService.Decrypt(
            protectedDataEncryptionKey,
            keyEncryptionKey);
    }

    private static void ValidateKey(byte[] key, string parameterName)
    {
        if (key is null || key.Length != KeySize)
        {
            throw new ArgumentException(
                $"Key must be exactly {KeySize} bytes.",
                parameterName);
        }
    }
}