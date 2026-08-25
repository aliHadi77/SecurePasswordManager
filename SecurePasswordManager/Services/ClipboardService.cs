namespace SecurePasswordManager.Services;

public sealed class ClipboardService
{
    public void CopyText(string text)
    {
        if (string.IsNullOrEmpty(text))
        {
            throw new ArgumentException(
                "Text to copy cannot be empty.",
                nameof(text));
        }

        Clipboard.SetText(text);
    }
}