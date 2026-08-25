using SecurePasswordManager.Security;
using System.Security.Cryptography;
using System.Text;

namespace SecurePasswordManager.Tests;

public class EncryptionServiceTests
{
    [Fact]
    public void Encrypt_ThenDecrypt_ShouldReturnOriginalData()
    {
        var service = new EncryptionService();

        byte[] key = RandomNumberGenerator.GetBytes(32);
        byte[] originalData = Encoding.UTF8.GetBytes(
            "Secure Password Manager Test");

        EncryptedData encrypted = service.Encrypt(
            originalData,
            key);

        byte[] decrypted = service.Decrypt(
            encrypted,
            key);

        Assert.Equal(originalData, decrypted);
    }

    [Fact]
    public void Encrypt_ShouldGenerateDifferentNonces()
    {
        var service = new EncryptionService();

        byte[] key = RandomNumberGenerator.GetBytes(32);
        byte[] data = Encoding.UTF8.GetBytes("Test");

        EncryptedData encrypted1 = service.Encrypt(data, key);
        EncryptedData encrypted2 = service.Encrypt(data, key);

        Assert.False(
            encrypted1.Nonce.SequenceEqual(encrypted2.Nonce));
    }

    [Fact]
    public void Decrypt_WithWrongKey_ShouldFail()
    {
        var service = new EncryptionService();

        byte[] key = RandomNumberGenerator.GetBytes(32);
        byte[] wrongKey = RandomNumberGenerator.GetBytes(32);

        byte[] data = Encoding.UTF8.GetBytes("Secret");

        EncryptedData encrypted = service.Encrypt(data, key);

        Assert.ThrowsAny<CryptographicException>(() =>
            service.Decrypt(encrypted, wrongKey));
    }

    [Fact]
    public void Decrypt_WithModifiedCiphertext_ShouldFail()
    {
        var service = new EncryptionService();

        byte[] key = RandomNumberGenerator.GetBytes(32);
        byte[] data = Encoding.UTF8.GetBytes("Secret");

        EncryptedData encrypted = service.Encrypt(data, key);

        byte[] modifiedCiphertext =
            (byte[])encrypted.Ciphertext.Clone();

        modifiedCiphertext[0] ^= 0x01;

        var modifiedData = new EncryptedData(
            modifiedCiphertext,
            encrypted.Nonce,
            encrypted.Tag);

        Assert.ThrowsAny<CryptographicException>(() =>
            service.Decrypt(modifiedData, key));
    }

    [Fact]
    public void Decrypt_WithModifiedTag_ShouldFail()
    {
        var service = new EncryptionService();

        byte[] key = RandomNumberGenerator.GetBytes(32);
        byte[] data = Encoding.UTF8.GetBytes("Secret");

        EncryptedData encrypted = service.Encrypt(data, key);

        byte[] modifiedTag =
            (byte[])encrypted.Tag.Clone();

        modifiedTag[0] ^= 0x01;

        var modifiedData = new EncryptedData(
            encrypted.Ciphertext,
            encrypted.Nonce,
            modifiedTag);

        Assert.ThrowsAny<CryptographicException>(() =>
            service.Decrypt(modifiedData, key));
    }

    [Fact]
    public void Encrypt_WithInvalidKey_ShouldThrow()
    {
        var service = new EncryptionService();

        byte[] invalidKey = new byte[16];
        byte[] data = Encoding.UTF8.GetBytes("Secret");

        Assert.Throws<ArgumentException>(() =>
            service.Encrypt(data, invalidKey));
    }
}