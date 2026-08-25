namespace SecurePasswordManager.Models;

public sealed class PasswordGeneratorOptions
{
    public int Length { get; init; } = 16;

    public bool IncludeUppercase { get; init; } = true;

    public bool IncludeLowercase { get; init; } = true;

    public bool IncludeDigits { get; init; } = true;

    public bool IncludeSymbols { get; init; } = true;
}