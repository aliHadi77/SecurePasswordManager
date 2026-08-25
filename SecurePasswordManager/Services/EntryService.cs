using SecurePasswordManager.Data;
using SecurePasswordManager.Models;
using SecurePasswordManager.Security;
using System.Security.Cryptography;
using System.Text;

namespace SecurePasswordManager.Services;

public sealed class EntryService
{
    private readonly VaultService _vaultService;
    private readonly VaultRepository _repository;
    private readonly EncryptionService _encryptionService;

    public EntryService(
        VaultService vaultService,
        VaultRepository repository,
        EncryptionService encryptionService)
    {
        _vaultService = vaultService
            ?? throw new ArgumentNullException(nameof(vaultService));

        _repository = repository
            ?? throw new ArgumentNullException(nameof(repository));

        _encryptionService = encryptionService
            ?? throw new ArgumentNullException(nameof(encryptionService));
    }

    public long AddEntry(
        string serviceName,
        string username,
        string password,
        string? notes = null,
        string? website = null)
    {
        EnsureUnlocked();

        ValidateRequiredText(serviceName, nameof(serviceName));
        ValidateRequiredText(username, nameof(username));
        ValidateRequiredText(password, nameof(password));

        byte[] dek = _vaultService.GetDecryptedDek();

        try
        {
            EncryptedData encryptedPassword =
                EncryptText(password, dek);

            EncryptedData? encryptedNotes =
                string.IsNullOrWhiteSpace(notes)
                    ? null
                    : EncryptText(notes, dek);

            var entry = new VaultEntry
            {
                VaultId = _vaultService.CurrentVaultId!.Value,
                ServiceName = serviceName.Trim(),
                Username = username.Trim(),

                EncryptedPassword = encryptedPassword.Ciphertext,
                PasswordNonce = encryptedPassword.Nonce,
                PasswordTag = encryptedPassword.Tag,

                EncryptedNotes = encryptedNotes?.Ciphertext,
                NotesNonce = encryptedNotes?.Nonce,
                NotesTag = encryptedNotes?.Tag,

                Website = string.IsNullOrWhiteSpace(website)
                    ? null
                    : website.Trim(),

                CreatedAtUtc = DateTime.UtcNow,
                UpdatedAtUtc = DateTime.UtcNow
            };

            return _repository.AddEntry(entry);
        }
        finally
        {
            CryptographicOperations.ZeroMemory(dek);
        }
    }

    public string GetPassword(long entryId)
    {
        EnsureUnlocked();

        VaultEntry entry = GetOwnedEntry(entryId);

        byte[] dek = _vaultService.GetDecryptedDek();

        try
        {
            var encryptedPassword = new EncryptedData(
                entry.EncryptedPassword,
                entry.PasswordNonce,
                entry.PasswordTag);

            byte[] plaintext =
                _encryptionService.Decrypt(
                    encryptedPassword,
                    dek);

            try
            {
                return Encoding.UTF8.GetString(plaintext);
            }
            finally
            {
                CryptographicOperations.ZeroMemory(plaintext);
            }
        }
        finally
        {
            CryptographicOperations.ZeroMemory(dek);
        }
    }

    public string? GetNotes(long entryId)
    {
        EnsureUnlocked();

        VaultEntry entry = GetOwnedEntry(entryId);

        if (entry.EncryptedNotes is null)
            return null;

        if (entry.NotesNonce is null ||
            entry.NotesTag is null)
        {
            throw new CryptographicException(
                "Encrypted notes metadata is incomplete.");
        }

        byte[] dek = _vaultService.GetDecryptedDek();

        try
        {
            var encryptedNotes = new EncryptedData(
                entry.EncryptedNotes,
                entry.NotesNonce,
                entry.NotesTag);

            byte[] plaintext =
                _encryptionService.Decrypt(
                    encryptedNotes,
                    dek);

            try
            {
                return Encoding.UTF8.GetString(plaintext);
            }
            finally
            {
                CryptographicOperations.ZeroMemory(plaintext);
            }
        }
        finally
        {
            CryptographicOperations.ZeroMemory(dek);
        }
    }

    public List<VaultEntry> GetEntries()
    {
        EnsureUnlocked();

        return _repository.GetEntries(
            _vaultService.CurrentVaultId!.Value);
    }

    public List<VaultEntry> SearchEntries(string searchText)
    {
        EnsureUnlocked();

        return _repository.SearchEntries(
            _vaultService.CurrentVaultId!.Value,
            searchText);
    }

    public bool DeleteEntry(long entryId)
    {
        EnsureUnlocked();

        _ = GetOwnedEntry(entryId);

        return _repository.DeleteEntry(entryId);
    }

    private VaultEntry GetOwnedEntry(long entryId)
    {
        if (entryId <= 0)
            throw new ArgumentOutOfRangeException(nameof(entryId));

        VaultEntry? entry =
            _repository.GetEntry(entryId);

        if (entry is null ||
            entry.VaultId != _vaultService.CurrentVaultId)
        {
            throw new InvalidOperationException(
                "Entry was not found in the current vault.");
        }

        return entry;
    }

    private EncryptedData EncryptText(
        string plaintext,
        byte[] dek)
    {
        byte[] bytes =
            Encoding.UTF8.GetBytes(plaintext);

        try
        {
            return _encryptionService.Encrypt(
                bytes,
                dek);
        }
        finally
        {
            CryptographicOperations.ZeroMemory(bytes);
        }
    }

    private void EnsureUnlocked()
    {
        if (!_vaultService.IsUnlocked)
        {
            throw new InvalidOperationException(
                "The vault is locked.");
        }
    }

    private static void ValidateRequiredText(
        string value,
        string parameterName)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException(
                "Value cannot be empty.",
                parameterName);
        }
    }
    public bool UpdateEntry(
        long entryId,
        string serviceName,
        string username,
        string password,
        string? notes = null,
        string? website = null)
    {
        EnsureUnlocked();

        ValidateRequiredText(serviceName, nameof(serviceName));
        ValidateRequiredText(username, nameof(username));
        ValidateRequiredText(password, nameof(password));

        VaultEntry existing =
            GetOwnedEntry(entryId);

        byte[] dek =
            _vaultService.GetDecryptedDek();

        try
        {
            EncryptedData encryptedPassword =
                EncryptText(password, dek);

            EncryptedData? encryptedNotes =
                string.IsNullOrWhiteSpace(notes)
                    ? null
                    : EncryptText(notes, dek);

            existing.ServiceName = serviceName.Trim();
            existing.Username = username.Trim();

            existing.EncryptedPassword =
                encryptedPassword.Ciphertext;

            existing.PasswordNonce =
                encryptedPassword.Nonce;

            existing.PasswordTag =
                encryptedPassword.Tag;

            existing.EncryptedNotes =
                encryptedNotes?.Ciphertext;

            existing.NotesNonce =
                encryptedNotes?.Nonce;

            existing.NotesTag =
                encryptedNotes?.Tag;

            existing.Website =
                string.IsNullOrWhiteSpace(website)
                    ? null
                    : website.Trim();

            existing.UpdatedAtUtc =
                DateTime.UtcNow;

            return _repository.UpdateEntry(existing);
        }
        finally
        {
            CryptographicOperations.ZeroMemory(dek);
        }
    }
}