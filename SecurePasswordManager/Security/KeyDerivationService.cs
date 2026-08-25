using System.Security.Cryptography;

namespace SecurePasswordManager.Security;

public sealed class KeyDerivationService
{
    private const int SaltSize = 32;
    private const int KeySize = 32;
    private const int Iterations = 600_000;

    public byte[] GenerateSalt()
    {
        return RandomNumberGenerator.GetBytes(SaltSize);
    }

    public byte[] DeriveKey(string masterPassword, byte[] salt)
    {
        if (string.IsNullOrWhiteSpace(masterPassword))
            throw new ArgumentException(
                "Master password cannot be empty.",
                nameof(masterPassword));

        if (salt is null || salt.Length != SaltSize)
            throw new ArgumentException(
                $"Salt must be exactly {SaltSize} bytes.",
                nameof(salt));

        return Rfc2898DeriveBytes.Pbkdf2(
            masterPassword,
            salt,
            Iterations,
            HashAlgorithmName.SHA256,
            KeySize);
    }
}