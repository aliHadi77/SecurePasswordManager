using System.Security.Cryptography;
using SecurePasswordManager.Security;

namespace SecurePasswordManager.Tests;

public class VaultKeyManagerTests
{
    [Fact]
    public void GenerateDataEncryptionKey_ShouldReturn32Bytes()
    {
        var encryptionService = new EncryptionService();
        var manager = new VaultKeyManager(encryptionService);

        byte[] dek = manager.GenerateDataEncryptionKey();

        Assert.Equal(32, dek.Length);
    }

    [Fact]
    public void GenerateDataEncryptionKey_ShouldGenerateDifferentKeys()
    {
        var encryptionService = new EncryptionService();
        var manager = new VaultKeyManager(encryptionService);

        byte[] dek1 = manager.GenerateDataEncryptionKey();
        byte[] dek2 = manager.GenerateDataEncryptionKey();

        Assert.False(dek1.SequenceEqual(dek2));
    }

    [Fact]
    public void ProtectAndUnprotect_ShouldReturnOriginalDek()
    {
        var encryptionService = new EncryptionService();
        var manager = new VaultKeyManager(encryptionService);

        byte[] dek = manager.GenerateDataEncryptionKey();
        byte[] kek = RandomNumberGenerator.GetBytes(32);

        EncryptedData protectedDek =
            manager.ProtectDataEncryptionKey(dek, kek);

        byte[] recoveredDek =
            manager.UnprotectDataEncryptionKey(protectedDek, kek);

        Assert.True(
            CryptographicOperations.FixedTimeEquals(
                dek,
                recoveredDek));
    }

    [Fact]
    public void Unprotect_WithWrongKek_ShouldFail()
    {
        var encryptionService = new EncryptionService();
        var manager = new VaultKeyManager(encryptionService);

        byte[] dek = manager.GenerateDataEncryptionKey();
        byte[] kek = RandomNumberGenerator.GetBytes(32);
        byte[] wrongKek = RandomNumberGenerator.GetBytes(32);

        EncryptedData protectedDek =
            manager.ProtectDataEncryptionKey(dek, kek);

        Assert.ThrowsAny<CryptographicException>(() =>
            manager.UnprotectDataEncryptionKey(
                protectedDek,
                wrongKek));
    }

    [Fact]
    public void Protect_WithInvalidDek_ShouldThrow()
    {
        var encryptionService = new EncryptionService();
        var manager = new VaultKeyManager(encryptionService);

        byte[] invalidDek = new byte[16];
        byte[] kek = RandomNumberGenerator.GetBytes(32);

        Assert.Throws<ArgumentException>(() =>
            manager.ProtectDataEncryptionKey(
                invalidDek,
                kek));
    }

    [Fact]
    public void Protect_WithInvalidKek_ShouldThrow()
    {
        var encryptionService = new EncryptionService();
        var manager = new VaultKeyManager(encryptionService);

        byte[] dek = manager.GenerateDataEncryptionKey();
        byte[] invalidKek = new byte[16];

        Assert.Throws<ArgumentException>(() =>
            manager.ProtectDataEncryptionKey(
                dek,
                invalidKek));
    }
}