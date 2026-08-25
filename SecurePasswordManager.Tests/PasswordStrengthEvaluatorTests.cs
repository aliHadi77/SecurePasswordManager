using SecurePasswordManager.Security;

namespace SecurePasswordManager.Tests;

public class PasswordStrengthEvaluatorTests
{
    private readonly PasswordStrengthEvaluator _evaluator = new();

    [Fact]
    public void Evaluate_EmptyPassword_ShouldBeWeak()
    {
        PasswordStrengthResult result =
            _evaluator.Evaluate("");

        Assert.Equal(
            PasswordStrengthLevel.Weak,
            result.Level);

        Assert.Equal(0, result.Score);

        Assert.NotEmpty(result.Suggestions);
    }

    [Fact]
    public void Evaluate_ShortPassword_ShouldBeWeak()
    {
        PasswordStrengthResult result =
            _evaluator.Evaluate("abc");

        Assert.Equal(
            PasswordStrengthLevel.Weak,
            result.Level);

        Assert.Contains(
            result.Suggestions,
            s => s.Contains("طول"));
    }

    [Fact]
    public void Evaluate_PasswordWithAllCharacterTypes_ShouldBeStrong()
    {
        PasswordStrengthResult result =
            _evaluator.Evaluate(
                "Ab9!xK7#mP2@qL8$");

        Assert.True(result.Score >= 65);

        Assert.True(
            result.Level ==
            PasswordStrengthLevel.Strong ||
            result.Level ==
            PasswordStrengthLevel.VeryStrong);
    }

    [Fact]
    public void Evaluate_LongComplexPassword_ShouldBeVeryStrong()
    {
        PasswordStrengthResult result =
            _evaluator.Evaluate(
                "X7!mQ2@vL9#rT5$zP8^k");

        Assert.Equal(
            PasswordStrengthLevel.VeryStrong,
            result.Level);

        Assert.True(result.Score >= 85);
    }

    [Fact]
    public void Evaluate_RepeatedCharacters_ShouldReduceScore()
    {
        PasswordStrengthResult result =
            _evaluator.Evaluate(
                "AAAaaa111!!!");

        Assert.Contains(
            result.Suggestions,
            s => s.Contains("التكرار"));
    }

    [Fact]
    public void Evaluate_SequentialCharacters_ShouldReduceScore()
    {
        PasswordStrengthResult result =
            _evaluator.Evaluate(
                "Abcd1234!XYZ");

        Assert.Contains(
            result.Suggestions,
            s => s.Contains("التسلسلات"));
    }

    [Fact]
    public void Evaluate_CommonPassword_ShouldWarnUser()
    {
        PasswordStrengthResult result =
            _evaluator.Evaluate(
                "password123");

        Assert.Contains(
            result.Suggestions,
            s => s.Contains("الشائعة"));
    }

    [Fact]
    public void Evaluate_WithoutUppercase_ShouldSuggestUppercase()
    {
        PasswordStrengthResult result =
            _evaluator.Evaluate(
                "strongpassword123!");

        Assert.Contains(
            result.Suggestions,
            s => s.Contains("أحرفًا كبيرة"));
    }

    [Fact]
    public void Evaluate_WithoutDigits_ShouldSuggestDigits()
    {
        PasswordStrengthResult result =
            _evaluator.Evaluate(
                "StrongPassword!");

        Assert.Contains(
            result.Suggestions,
            s => s.Contains("أرقام"));
    }

    [Fact]
    public void Evaluate_WithoutSymbols_ShouldSuggestSymbols()
    {
        PasswordStrengthResult result =
            _evaluator.Evaluate(
                "StrongPassword123");

        Assert.Contains(
            result.Suggestions,
            s => s.Contains("رموز"));
    }

    [Fact]
    public void Evaluate_Score_ShouldAlwaysBeBetweenZeroAnd100()
    {
        string[] passwords =
        {
            "",
            "a",
            "123456",
            "password123",
            "StrongPassword123!",
            "X7!mQ2@vL9#rT5$zP8^k"
        };

        foreach (string password in passwords)
        {
            PasswordStrengthResult result =
                _evaluator.Evaluate(password);

            Assert.InRange(
                result.Score,
                0,
                100);
        }
    }
}