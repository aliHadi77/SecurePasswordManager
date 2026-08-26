namespace SecurePasswordManager.Security;

public static class MasterPasswordValidator
{
    public const int MinimumLength = 14;
    public const int MaximumLength = 128;

    public const string ValidationMessage =
        "يجب أن تكون كلمة المرور الرئيسية من 14 إلى 128 حرفًا، وألا تبدأ أو تنتهي بمسافة أو تحتوي على أحرف تحكم.";

    public static void Validate(string? masterPassword)
    {
        if (masterPassword is null ||
            string.IsNullOrWhiteSpace(masterPassword) ||
            masterPassword.Length < MinimumLength ||
            masterPassword.Length > MaximumLength ||
            char.IsWhiteSpace(masterPassword[0]) ||
            char.IsWhiteSpace(masterPassword[^1]) ||
            masterPassword.Any(char.IsControl))
        {
            throw new ArgumentException(ValidationMessage);
        }
    }
}
