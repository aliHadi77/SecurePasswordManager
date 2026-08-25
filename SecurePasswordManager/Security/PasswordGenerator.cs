using System.Security.Cryptography;

namespace SecurePasswordManager.Security;

public sealed class PasswordGenerator
{
    private const string Uppercase =
        "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

    private const string Lowercase =
        "abcdefghijklmnopqrstuvwxyz";

    private const string Digits =
        "0123456789";

    private const string Symbols =
        "!@#$%^&*()-_=+[]{};:,.?/";

    public string Generate(
        int length,
        bool includeUppercase,
        bool includeLowercase,
        bool includeDigits,
        bool includeSymbols)
    {
        if (length <= 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(length),
                "Password length must be greater than zero.");
        }

        if (length > 128)
        {
            throw new ArgumentOutOfRangeException(
                nameof(length),
                "Password length cannot exceed 128 characters.");
        }

        var characterSets = new List<string>();

        if (includeUppercase)
            characterSets.Add(Uppercase);

        if (includeLowercase)
            characterSets.Add(Lowercase);

        if (includeDigits)
            characterSets.Add(Digits);

        if (includeSymbols)
            characterSets.Add(Symbols);

        if (characterSets.Count == 0)
        {
            throw new ArgumentException(
                "At least one character type must be selected.");
        }

        if (length < characterSets.Count)
        {
            throw new ArgumentException(
                "Password length must be at least the number of selected character types.");
        }

        var password = new char[length];

        int position = 0;

        // Ensure that every selected character category
        // appears at least once.
        foreach (string characterSet in characterSets)
        {
            password[position++] =
                GetRandomCharacter(characterSet);
        }

        string allCharacters =
            string.Concat(characterSets);

        // Fill the remaining positions securely.
        while (position < password.Length)
        {
            password[position++] =
                GetRandomCharacter(allCharacters);
        }

        // Cryptographically secure Fisher-Yates shuffle.
        Shuffle(password);

        return new string(password);
    }

    private static char GetRandomCharacter(
        string characterSet)
    {
        int index =
            RandomNumberGenerator.GetInt32(
                characterSet.Length);

        return characterSet[index];
    }

    private static void Shuffle(char[] characters)
    {
        for (int i = characters.Length - 1; i > 0; i--)
        {
            int j =
                RandomNumberGenerator.GetInt32(i + 1);

            (characters[i], characters[j]) =
                (characters[j], characters[i]);
        }
    }
}