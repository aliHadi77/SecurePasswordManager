using System.Text.RegularExpressions;

namespace SecurePasswordManager.Security;

public enum PasswordStrengthLevel
{
    Weak,
    Medium,
    Strong,
    VeryStrong
}

public sealed record PasswordStrengthResult(
    int Score,
    PasswordStrengthLevel Level,
    IReadOnlyList<string> Suggestions);

public sealed class PasswordStrengthEvaluator
{
    public PasswordStrengthResult Evaluate(string password)
    {
        if (password is null)
            throw new ArgumentNullException(nameof(password));

        if (password.Length == 0)
        {
            return new PasswordStrengthResult(
                0,
                PasswordStrengthLevel.Weak,
                new[]
                {
                    "استخدم كلمة مرور تحتوي على أحرف وأرقام ورموز."
                });
        }

        int score = 0;
        var suggestions = new List<string>();

        // Length
        // Length
        if (password.Length >= 20)
            score += 40;
        else if (password.Length >= 16)
            score += 35;
        else if (password.Length >= 12)
            score += 28;
        else if (password.Length >= 8)
            score += 18;
        else if (password.Length >= 6)
            score += 10;
        else
            suggestions.Add(
                "زد طول كلمة المرور إلى 12 حرفًا على الأقل.");

        if (password.Length < 12 &&
            !suggestions.Contains(
                "زد طول كلمة المرور إلى 12 حرفًا على الأقل."))
        {
            suggestions.Add(
                "يفضل استخدام كلمة مرور بطول 12 حرفًا أو أكثر.");
        }

        // Character variety
        bool hasUpper =
            password.Any(char.IsUpper);

        bool hasLower =
            password.Any(char.IsLower);

        bool hasDigit =
            password.Any(char.IsDigit);

        bool hasSymbol =
            password.Any(c =>
                !char.IsLetterOrDigit(c));

        int characterTypes = 0;

        if (hasUpper)
        {
            score += 10;
            characterTypes++;
        }
        else
        {
            suggestions.Add(
                "أضف أحرفًا كبيرة.");
        }

        if (hasLower)
        {
            score += 10;
            characterTypes++;
        }
        else
        {
            suggestions.Add(
                "أضف أحرفًا صغيرة.");
        }

        if (hasDigit)
        {
            score += 10;
            characterTypes++;
        }
        else
        {
            suggestions.Add(
                "أضف أرقامًا.");
        }

        if (hasSymbol)
        {
            score += 15;
            characterTypes++;
        }
        else
        {
            suggestions.Add(
                "أضف رموزًا خاصة مثل ! أو @ أو #.");
        }

        // Repeated characters
        if (HasRepeatedCharacters(password))
        {
            score -= 10;

            suggestions.Add(
                "تجنب التكرار المتكرر لنفس الحرف أو الرقم.");
        }

        // Sequential patterns
        if (HasSequentialPattern(password))
        {
            score -= 15;

            suggestions.Add(
                "تجنب التسلسلات السهلة مثل 1234 أو abcd.");
        }

        // Common weak passwords
        if (LooksLikeCommonPassword(password))
        {
            score -= 25;

            suggestions.Add(
                "تجنب كلمات المرور الشائعة أو الأنماط المعروفة.");
        }

        score = Math.Clamp(score, 0, 100);

        PasswordStrengthLevel level =
            GetLevel(score);

        return new PasswordStrengthResult(
            score,
            level,
            suggestions.Distinct().ToArray());
    }

    private static PasswordStrengthLevel GetLevel(
        int score)
    {
        return score switch
        {
            < 40 =>
                PasswordStrengthLevel.Weak,

            < 65 =>
                PasswordStrengthLevel.Medium,

            < 85 =>
                PasswordStrengthLevel.Strong,

            _ =>
                PasswordStrengthLevel.VeryStrong
        };
    }

    private static bool HasRepeatedCharacters(
        string password)
    {
        if (password.Length < 3)
            return false;

        for (int i = 2; i < password.Length; i++)
        {
            if (password[i] == password[i - 1] &&
                password[i] == password[i - 2])
            {
                return true;
            }
        }

        return false;
    }

    private static bool HasSequentialPattern(
        string password)
    {
        if (password.Length < 4)
            return false;

        for (int i = 0; i <= password.Length - 4; i++)
        {
            int d1 = password[i + 1] - password[i];
            int d2 = password[i + 2] - password[i + 1];
            int d3 = password[i + 3] - password[i + 2];

            if (d1 == 1 && d2 == 1 && d3 == 1)
                return true;

            if (d1 == -1 && d2 == -1 && d3 == -1)
                return true;
        }

        return false;
    }

    private static bool LooksLikeCommonPassword(
        string password)
    {
        string normalized =
            password.Trim().ToLowerInvariant();

        string[] commonPasswords =
        {
            "password",
            "password123",
            "123456",
            "12345678",
            "123456789",
            "qwerty",
            "qwerty123",
            "admin",
            "admin123",
            "welcome",
            "letmein"
        };

        return commonPasswords.Contains(
            normalized);
    }
}