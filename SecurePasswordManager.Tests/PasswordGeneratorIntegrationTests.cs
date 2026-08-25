using SecurePasswordManager.Security;

namespace SecurePasswordManager.Tests;

public class PasswordGeneratorIntegrationTests
{
    [Fact]
    public void GeneratedPassword_ShouldBeEvaluatedAsStrongOrVeryStrong()
    {
        var generator = new PasswordGenerator();
        var evaluator = new PasswordStrengthEvaluator();

        string password = generator.Generate(
            20,
            includeUppercase: true,
            includeLowercase: true,
            includeDigits: true,
            includeSymbols: true);

        PasswordStrengthResult result =
            evaluator.Evaluate(password);

        Assert.True(
            result.Level == PasswordStrengthLevel.Strong ||
            result.Level == PasswordStrengthLevel.VeryStrong);

        Assert.InRange(
            result.Score,
            65,
            100);
    }

    [Fact]
    public void GeneratedPassword_ShouldMatchRequestedLength()
    {
        var generator = new PasswordGenerator();

        string password = generator.Generate(
            24,
            true,
            true,
            true,
            true);

        Assert.Equal(24, password.Length);
    }

    [Fact]
    public void GeneratedPassword_ShouldContainRequestedCharacterCategories()
    {
        var generator = new PasswordGenerator();

        string password = generator.Generate(
            32,
            true,
            true,
            true,
            true);

        Assert.Contains(password, char.IsUpper);
        Assert.Contains(password, char.IsLower);
        Assert.Contains(password, char.IsDigit);

        Assert.Contains(
            password,
            character => !char.IsLetterOrDigit(character));
    }
}