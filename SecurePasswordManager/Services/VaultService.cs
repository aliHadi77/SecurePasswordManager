using System.Security.Cryptography;
using SecurePasswordManager.Data;
using SecurePasswordManager.Models;
using SecurePasswordManager.Security;

namespace SecurePasswordManager.Services;

public sealed class VaultService
{
    private readonly VaultRepository _repository;
    private readonly KeyDerivationService _keyDerivationService;
    private readonly EncryptionService _encryptionService;

    private byte[]? _decryptedDek;
    private long? _currentVaultId;

    public VaultService(
        VaultRepository repository,
        KeyDerivationService keyDerivationService,
        EncryptionService encryptionService)
    {
        _repository = repository
            ?? throw new ArgumentNullException(nameof(repository));

        _keyDerivationService = keyDerivationService
            ?? throw new ArgumentNullException(nameof(keyDerivationService));

        _encryptionService = encryptionService
            ?? throw new ArgumentNullException(nameof(encryptionService));
    }

    public bool IsUnlocked =>
        _decryptedDek is not null &&
        _currentVaultId.HasValue;

    public long? CurrentVaultId => _currentVaultId;

    public long CreateVault(string masterPassword)
    {
        ValidateMasterPassword(masterPassword);

        if (_repository.GetVaultCount() > 0)
        {
            throw new InvalidOperationException(
                "A vault already exists. Only one vault is supported.");
        }

        byte[] salt =
            _keyDerivationService.GenerateSalt();

        byte[] kek =
            _keyDerivationService.DeriveKey(
                masterPassword,
                salt);

        byte[] dek =
            RandomNumberGenerator.GetBytes(32);

        try
        {
            EncryptedData encryptedDek =
                _encryptionService.Encrypt(
                    dek,
                    kek);

            var vault = new Vault
            {
                Version = 1,
                Salt = salt,
                KdfAlgorithm = "PBKDF2",
                KdfHash = "SHA256",
                KdfIterations = 600_000,
                KeySize = 256,
                EncryptedDek = encryptedDek.Ciphertext,
                DekNonce = encryptedDek.Nonce,
                DekTag = encryptedDek.Tag,
                CreatedAtUtc = DateTime.UtcNow
            };

            return _repository.CreateVault(vault);
        }
        finally
        {
            CryptographicOperations.ZeroMemory(kek);
            CryptographicOperations.ZeroMemory(dek);
        }
    }

    public void Unlock(long vaultId, string masterPassword)
    {
        if (vaultId <= 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(vaultId));
        }

        ValidateMasterPassword(masterPassword);

        if (IsUnlocked)
        {
            throw new InvalidOperationException(
                "A vault is already unlocked.");
        }

        Vault? vault =
            _repository.GetVault(vaultId);

        if (vault is null)
        {
            throw new InvalidOperationException(
                "Vault was not found.");
        }

        byte[] kek =
            _keyDerivationService.DeriveKey(
                masterPassword,
                vault.Salt);

        try
        {
            var encryptedDek = new EncryptedData(
                vault.EncryptedDek,
                vault.DekNonce,
                vault.DekTag);

            byte[] dek =
                _encryptionService.Decrypt(
                    encryptedDek,
                    kek);

            if (dek.Length != 32)
            {
                CryptographicOperations.ZeroMemory(dek);

                throw new CryptographicException(
                    "The vault DEK has an invalid size.");
            }

            _decryptedDek = dek;
            _currentVaultId = vault.Id;
        }
        catch (CryptographicException)
        {
            throw new UnauthorizedAccessException(
                "The master password is incorrect or the vault data is invalid.");
        }
        finally
        {
            CryptographicOperations.ZeroMemory(kek);
        }
    }

    public void Lock()
    {
        if (_decryptedDek is not null)
        {
            CryptographicOperations.ZeroMemory(
                _decryptedDek);

            _decryptedDek = null;
        }

        _currentVaultId = null;
    }

    public byte[] GetDecryptedDek()
    {
        EnsureUnlocked();

        return _decryptedDek!.ToArray();
    }

    private void EnsureUnlocked()
    {
        if (!IsUnlocked)
        {
            throw new InvalidOperationException(
                "The vault is locked.");
        }
    }

    private static void ValidateMasterPassword(
        string masterPassword)
    {
        if (string.IsNullOrWhiteSpace(masterPassword))
        {
            throw new ArgumentException(
                "Master password cannot be empty.",
                nameof(masterPassword));
        }
    }
}