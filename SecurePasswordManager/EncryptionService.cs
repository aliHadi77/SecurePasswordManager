using System.Security.Cryptography;

namespace SecurePasswordManager.Security;

public sealed class EncryptionService
{
    private const int KeySize = 32;
    private const int NonceSize = 12;
    private const int TagSize = 16;

    public EncryptedData Encrypt(byte[] plaintext, byte[] key)
    {
        ValidateKey(key);

        if (plaintext is null)
            throw new ArgumentNullException(nameof(plaintext));

        byte[] nonce = RandomNumberGenerator.GetBytes(NonceSize);
        byte[] ciphertext = new byte[plaintext.Length];
        byte[] tag = new byte[TagSize];

        using var aes = new AesGcm(key, TagSize);

        aes.Encrypt(
            nonce,
            plaintext,
            ciphertext,
            tag);

        return new EncryptedData(
            ciphertext,
            nonce,
            tag);
    }

    public byte[] Decrypt(EncryptedData encryptedData, byte[] key)
    {
        ValidateKey(key);

        if (encryptedData is null)
            throw new ArgumentNullException(nameof(encryptedData));

        byte[] plaintext = new byte[encryptedData.Ciphertext.Length];

        using var aes = new AesGcm(key, TagSize);

        aes.Decrypt(
            encryptedData.Nonce,
            encryptedData.Ciphertext,
            encryptedData.Tag,
            plaintext);

        return plaintext;
    }

    private static void ValidateKey(byte[] key)
    {
        if (key is null || key.Length != KeySize)
        {
            throw new ArgumentException(
                $"Encryption key must be exactly {KeySize} bytes.",
                nameof(key));
        }
    }
}

public sealed record EncryptedData(
    byte[] Ciphertext,
    byte[] Nonce,
    byte[] Tag);