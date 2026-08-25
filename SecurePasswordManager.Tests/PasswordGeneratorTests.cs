using SecurePasswordManager.Security;

namespace SecurePasswordManager.Tests;

public class PasswordGeneratorTests
{
    private readonly PasswordGenerator _generator = new();

    [Fact]
    public void Generate_ShouldReturnRequestedLength()
    {
        string password =
            _generator.Generate(
                16,
                true,
                true,
                true,
                true);

        Assert.Equal(16, password.Length);
    }

    [Fact]
    public void Generate_ShouldContainAllSelectedCharacterTypes()
    {
        string password =
            _generator.Generate(
                32,
                true,
                true,
                true,
                true);

        Assert.Contains(
            password,
            char.IsUpper);

        Assert.Contains(
            password,
            char.IsLower);

        Assert.Contains(
            password,
            char.IsDigit);

        Assert.Contains(
            password,
            "!@#$%^&*()-_=+[]{};:,.?/"
                .Contains);
    }

    [Fact]
    public void Generate_OnlyUppercase_ShouldUseUppercaseCharacters()
    {
        string password =
            _generator.Generate(
                20,
                true,
                false,
                false,
                false);

        Assert.All(
            password,
            character => Assert.True(
                char.IsUpper(character)));
    }

    [Fact]
    public void Generate_ShouldRejectZeroLength()
    {
        Assert.Throws<ArgumentOutOfRangeException>(
            () => _generator.Generate(
                0,
                true,
                true,
                true,
                true));
    }

    [Fact]
    public void Generate_ShouldRejectLengthAbove128()
    {
        Assert.Throws<ArgumentOutOfRangeException>(
            () => _generator.Generate(
                129,
                true,
                true,
                true,
                true));
    }

    [Fact]
    public void Generate_ShouldRejectNoCharacterTypes()
    {
        Assert.Throws<ArgumentException>(
            () => _generator.Generate(
                16,
                false,
                false,
                false,
                false));
    }

    [Fact]
    public void Generate_ShouldRejectLengthSmallerThanSelectedTypes()
    {
        Assert.Throws<ArgumentException>(
            () => _generator.Generate(
                2,
                true,
                true,
                true,
                true));
    }

    [Fact]
    public void Generate_TwoPasswords_ShouldNormallyBeDifferent()
    {
        string first =
            _generator.Generate(
                32,
                true,
                true,
                true,
                true);

        string second =
            _generator.Generate(
                32,
                true,
                true,
                true,
                true);

        Assert.NotEqual(first, second);
    }
}