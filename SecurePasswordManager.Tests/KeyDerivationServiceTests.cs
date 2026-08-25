using SecurePasswordManager.Security;

namespace SecurePasswordManager.Tests;

public class KeyDerivationServiceTests
{
    [Fact]
    public void GenerateSalt_ShouldReturn32Bytes()
    {
        var service = new KeyDerivationService();

        byte[] salt = service.GenerateSalt();

        Assert.Equal(32, salt.Length);
    }

    [Fact]
    public void GenerateSalt_ShouldGenerateDifferentSalts()
    {
        var service = new KeyDerivationService();

        byte[] salt1 = service.GenerateSalt();
        byte[] salt2 = service.GenerateSalt();

        Assert.False(salt1.SequenceEqual(salt2));
    }

    [Fact]
    public void DeriveKey_ShouldReturn32Bytes()
    {
        var service = new KeyDerivationService();

        byte[] salt = service.GenerateSalt();

        byte[] key = service.DeriveKey(
            "TestPassword123!",
            salt);

        Assert.Equal(32, key.Length);
    }

    [Fact]
    public void DeriveKey_SamePasswordAndSalt_ShouldReturnSameKey()
    {
        var service = new KeyDerivationService();

        byte[] salt = service.GenerateSalt();
        string password = "TestPassword123!";

        byte[] key1 = service.DeriveKey(password, salt);
        byte[] key2 = service.DeriveKey(password, salt);

        Assert.Equal(key1, key2);
    }

    [Fact]
    public void DeriveKey_DifferentPasswords_ShouldReturnDifferentKeys()
    {
        var service = new KeyDerivationService();

        byte[] salt = service.GenerateSalt();

        byte[] key1 = service.DeriveKey(
            "PasswordOne123!",
            salt);

        byte[] key2 = service.DeriveKey(
            "PasswordTwo123!",
            salt);

        Assert.NotEqual(key1, key2);
    }

    [Fact]
    public void DeriveKey_DifferentSalts_ShouldReturnDifferentKeys()
    {
        var service = new KeyDerivationService();

        byte[] salt1 = service.GenerateSalt();
        byte[] salt2 = service.GenerateSalt();

        const string password = "TestPassword123!";

        byte[] key1 = service.DeriveKey(password, salt1);
        byte[] key2 = service.DeriveKey(password, salt2);

        Assert.NotEqual(key1, key2);
    }

    [Fact]
    public void DeriveKey_EmptyPassword_ShouldThrow()
    {
        var service = new KeyDerivationService();

        byte[] salt = service.GenerateSalt();

        Assert.Throws<ArgumentException>(() =>
            service.DeriveKey(string.Empty, salt));
    }

    [Fact]
    public void DeriveKey_InvalidSalt_ShouldThrow()
    {
        var service = new KeyDerivationService();

        byte[] invalidSalt = new byte[16];

        Assert.Throws<ArgumentException>(() =>
            service.DeriveKey(
                "TestPassword123!",
                invalidSalt));
    }
}